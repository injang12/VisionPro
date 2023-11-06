using Cognex.VisionPro;

using INIFileManager;
using Cameras;
using DisplaySetting;
using ImageFileManager;
using SplashThreadManager;

using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisionProTest
{
    public partial class FormMain : Form
    {
        private readonly CogRecordDisplay[] mDisplay = new CogRecordDisplay[UcDefine.MAX_CAMERA * UcDefine.MAX_STEP];   // 디스플레이
        private readonly Label[] mLabel = new Label[UcDefine.MAX_CAMERA * UcDefine.MAX_STEP];   // 디스플레이 라벨

        private static ICogAcqFifo mAcqFifo = null;
        private static ICogFrameGrabber mFrameGrabber = null;

        private int selectStep = 0;                  // 선택한 스탭
        private int nextStep = 0;                    // 촬영 후 다음 스탭
        private int MoveValX, MoveValY;              // 마우스 좌표 값
        private int screenArrayW, screenArrayH;      // 디스플레이 갯수 지정
        private int stepSave = -1;                   // 스탭 저장
        private int videoFormatIndex = 0;            // 포맷 형식 저장

        private bool displayScale = false;           // 디스플레이 확대 확인
        private bool isLive = false;                 // Live 중인지 확인
        private bool _move;                          // 윈도우 창 클릭 감지
        private bool isExpansion = false;            // 디스플레이 갯수 1개일 때 확대 금지

        public FormMain()
        {
            InitializeComponent();
            FormMain_Load();

            BtnLoadImage.Enabled = true;
            BtnSaveImage.Enabled = true;
            BtnSetupLoad.Enabled = true;
            BtnDisplay.Enabled = true;
        }

        private async void FormMain_Load()   // 메인폼 로드
        {
            SplashThread Splash = new SplashThread();

            Splash.Open();
            
            Hide();

            Splash.UpdateProgressBar(50);
            Splash.SetStatus("카메라 연결 중...");
            CameraTypeComboBox = CameraManager.SetCamera(CameraTypeComboBox, CameraTypeComboBox_SelectedIndexChanged);

            Splash.UpdateProgressBar(100);
            Splash.Close();
            Splash.Join();

            FormDisplay _FormDisplay = new FormDisplay();

            _FormDisplay.Display_Load();

            (screenArrayH, screenArrayW) = await _FormDisplay.WaitForUserInput();
            _FormDisplay.Dispose();

            isExpansion = screenArrayH * screenArrayW != 1;

            Show();
            Activate();
            CenterToScreen();

            await Task.Run(() => ArrangeScreen(screenArrayW, screenArrayH));
        }

        private void ArrangeScreen(int screenLayout_W, int screenLayout_H)      // 디스플레이 생성 메서드
        {
            int screenWidth = pnlDisplay.Width / screenLayout_W - 5;
            int screenHeight = pnlDisplay.Height / screenLayout_H;

            for (int i = 0; i < screenLayout_W; i++)
            {
                for (int j = 0; j < screenLayout_H; j++)
                {
                    int index = (j * screenLayout_W) + i;

                    Invoke((MethodInvoker)(() =>
                    {
                        mDisplay[index] = DisplayManager.InitDisplay(pnlDisplay, screenWidth, screenHeight, index, i, j);
                        mDisplay[index].Click += new EventHandler(CogDisplay_Main_Arr_Click);
                        mDisplay[index].DoubleClick += new EventHandler(CogDisplay_Main_Arr_DoubleClick);

                        mLabel[index] = DisplayManager.InitLabel(pnlDisplay, mDisplay, screenWidth, index);
                    }));
                }
            } 
        }

        private void Print_Log(string strValue)                      // 로그 출력 메서드
        {
            if(strValue == null)
                return;

            listLog.Items.Add(DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss] ") + strValue);
            listLog.SelectedIndex = listLog.Items.Count - 1;
            listLog.SelectedIndex = -1;
        }

        private void LiveEnable(bool _bool)       // 라이브 시 컨트롤 활성화/비활성화 메서드
        {
            VidFormatComboBox.Enabled = _bool;
            btnExit.Enabled = _bool;
            btnTriggerChange.Enabled = _bool;
            BtnSetupLoad.Enabled = _bool;
            btnAcquire.Enabled = _bool;
            isLive = !_bool;
        }

        private void TriggerChangeEnable(bool _bool)      // 트리거 모드 변경 시 컨트롤 활성화/비활성화 메서드
        {
            chkEnbStrobe.Enabled = _bool;
            btnLive.Enabled = _bool;
            btnAcquire.Enabled = _bool;
            VidFormatComboBox.Enabled = _bool;
        }

        private void StepFix()                           // 디스플레이 확대 시 스탭 고정 메서드
        {
            if (displayScale && stepSave == -1)
                stepSave = nextStep;
            else if (!displayScale && stepSave != -1)
            {
                nextStep = stepSave;
                stepSave = -1;
            }
            if (displayScale)
                nextStep = selectStep;
        }

        private void NextStepCheck()                     // 다음 스탭 메서드
        {
            nextStep++;
            if (nextStep == screenArrayH * screenArrayW)
                nextStep = 0;
        }

        private void GraphicClear(CogRecordDisplay display)       // 디스플레이 그래픽 제거 메서드
        {
            display.InteractiveGraphics.Clear();
            display.StaticGraphics.Clear();
        }

        private void Live_ToolRun()                         // 라이브 and Tool 실행 메서드
        {
            Print_Log("라이브 시작...");
            while (isLive)
            {
                CameraManager.AcquireStart(mDisplay[selectStep], (double)exposureUpDown.Value, (double)brightnessUpDown.Value, (double)contrastUpDown.Value);
                BtnRun.PerformClick();
            }
            Print_Log("라이브 종료");
        }

        private bool CameraCheck()                        // 카메라 연결 체크 메서드
        {
            if (mAcqFifo == null)
            {
                Print_Log("카메라를 연결해 주세요");
                return false;
            }
            return true;
        }

        private void BtnCountClear(object sender, EventArgs e)   // 이미지(H/W) 카운트 초기화 이벤트
        {
            INIFiles.Set_INI_Path(Application.StartupPath + "\\CONFIG\\ImageCount.ini");
            INIFiles.WriteValue("COMMON", "Count", "0");
            Print_Log("카운트 초기화 완료!" + Environment.NewLine + "현재 카운트: 0");
        }

        private void CameraTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)   // 프레임 그래버 콤보박스 선택 이벤트
        {
            mFrameGrabber = new CogFrameGrabbers()[CameraTypeComboBox.SelectedIndex];
            CameraManager.SetFormat(mFrameGrabber, VidFormatComboBox, VidFormatComboBox_SelectedIndexChanged);
        }

        private void VidFormatComboBox_SelectedIndexChanged(object sender, EventArgs e)  // 선택한 비디오 포맷으로 FIFO 생성 이벤트
        {
            mAcqFifo = CameraManager.SetFifo(mFrameGrabber, VidFormatComboBox);

            btnAcquire.Enabled = true;
            btnLive.Enabled = true;
            btnTriggerChange.Enabled = true;
        }

        private void AcqFifo_Complete(object sender, CogCompleteEventArgs e)   // 카메라 촬영(H/W) 메서드
        {
            if (InvokeRequired)
            {
                object[] eventArgs = { sender, e };
                Invoke(new CogCompleteEventHandler(AcqFifo_Complete), eventArgs);
                return;
            }

            StepFix();
            mDisplay[nextStep] = CameraManager.HardWare_AcqFifo(mDisplay[nextStep]);
            BtnRun.PerformClick();
            Print_Log(ImageManager.HardwareImageSave(hwNameTxt.Text, hwNameCombo.Text, mDisplay[nextStep].Image));

            NextStepCheck();
        }

        private void CogDisplay_Main_Arr_Click(object sender, EventArgs e)  // 디스플레이 클릭 이벤트
        {
            selectStep = DisplayManager.ClickEvent(sender, mLabel, selectStep, screenArrayW * screenArrayH);
        }

        private void CogDisplay_Main_Arr_DoubleClick(object sender, EventArgs e)   // 디스플레이 더블클릭 이벤트
        {
            if (!isExpansion)
                return;

            DisplayManager.DoubleClickEvent(mDisplay, mLabel, pnlDisplay, selectStep, displayScale);

            displayScale = !displayScale;
        }

        private void BtnDisplayClear_Click(object sender, EventArgs e)     // 디스플레이 이미지 클리어 버튼 클릭 이벤트
        {
            for (int i = 0; i < screenArrayW * screenArrayH; i++)
            {
                GraphicClear(mDisplay[i]);
                mDisplay[i].Image = null;
            }
        }

        private void BtnLive_Click(object sender, EventArgs e)  // 라이브 버튼 클릭 이벤트
        {
            if (!CameraCheck())
                return;

            if (btnLive.Text == "라이브 종료")
            {
                LiveEnable(true);
                btnLive.Text = "라이브 시작";
            }
            else
            {
                LiveEnable(false);
                Thread toolThread = new Thread(new ThreadStart(Live_ToolRun));
                toolThread.Start();
                btnLive.Text = "라이브 종료";
            }
        }

        private void BtnAcquire_Click(object sender, EventArgs e)    // 촬영 버튼 클릭 이벤트
        {
            if (!CameraCheck())
                return;

            StepFix();
            CameraManager.AcquireStart(mDisplay[nextStep], (double)exposureUpDown.Value, (double)brightnessUpDown.Value, (double)contrastUpDown.Value);
            NextStepCheck();

            BtnRun.PerformClick();
        }

        private async void BtnDisplay_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < screenArrayW * screenArrayH; i++)
            {
                mDisplay[i].Dispose();
                mLabel[i].Dispose();
            }

            BtnLoadImage.Enabled = false;
            BtnSaveImage.Enabled = false;
            BtnSetupLoad.Enabled = false;
            BtnDisplay.Enabled = false;

            FormDisplay _FormDisplay = new FormDisplay();

            await Task.Run(() => _FormDisplay.Display_Load());

            (screenArrayH, screenArrayW) = await _FormDisplay.WaitForUserInput();
            _FormDisplay.Dispose();

            isExpansion = screenArrayH * screenArrayW != 1;

            await Task.Run(() => ArrangeScreen(screenArrayW, screenArrayH));

            BtnLoadImage.Enabled = true;
            BtnSaveImage.Enabled = true;
            BtnSetupLoad.Enabled = true;
            BtnDisplay.Enabled = true;
        }

        private void BtnLogClear_Click(object sender, EventArgs e)    // 로그 메세지 클리어 버튼 클릭 이벤트
        {
            listLog.Items.Clear();
        }

        private void BtnSaveImage_Click(object sender, EventArgs e)   // 이미지 저장 클릭 이벤트
        {
            if (ImageManager.SaveImage(mDisplay[selectStep]))
                Print_Log("이미지 저장 완료");
            else
                Print_Log("이미지 저장 실패");
        }

        private void BtnLoadImage_Click(object sender, EventArgs e)   // 이미지 로드 클릭 이벤트
        {
            if (ImageManager.LoadImage(mDisplay[selectStep]))
                Print_Log("이미지 불러오기 성공");
            else
                Print_Log("이미지 불러오기 실패");
        }

        private void BtnTriggerChange_Click(object sender, EventArgs e)    // 트리거 모드 전환 클릭 이벤트
        {
            if (!CameraCheck())
                return;

            if (mAcqFifo.OwnedTriggerParams == null)
            {
                Print_Log($"이 보드 타입 {mAcqFifo.FrameGrabber.Name}은(는)" + Environment.NewLine + "트리거 모드를 지원하지 않습니다.");
                return;
            }

            mAcqFifo.Flush();

            if (btnTriggerChange.Text == "H/W Trigger")
            {
                CameraManager.HardWareTriggerStart((double)exposureUpDown.Value, (double)brightnessUpDown.Value, (double)contrastUpDown.Value, chkEnbStrobe.Checked);
                mAcqFifo.Complete += AcqFifo_Complete;
                btnTriggerChange.Text = "S/W Trigger";
                TriggerChangeEnable(false);
                videoFormatIndex = VidFormatComboBox.SelectedIndex;
                Print_Log("H/W 트리거 모드 변경");
            }
            else
            {
                CameraManager.HardWareTriggerStop();
                VidFormatComboBox.Items.Clear();
                CameraManager.SetFormat(mFrameGrabber, VidFormatComboBox, VidFormatComboBox_SelectedIndexChanged);
                btnTriggerChange.Text = "H/W Trigger";
                TriggerChangeEnable(true);
                VidFormatComboBox.SelectedIndex = videoFormatIndex;
                Print_Log("S/W 트리거 모드 변경");
            }
        }

        private void BtnSetupLoad_Click(object sender, EventArgs e)   // Setup 버튼 클릭 이벤트
        {
            FormSetup _FormSetup = new FormSetup();

            ImageManager.TempImageSave(mDisplay[selectStep].Image);
            _FormSetup.Setup_Load();
            _FormSetup.Owner = this;
        }

        private void BtnRun_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FormSetup.SelectModel()))
                return;

            mDisplay[nextStep].StaticGraphics.Clear();
            mDisplay[nextStep].InteractiveGraphics.Clear();

            FormSetup.SelectToolRun(mDisplay[nextStep]);
        }

        private void BtnExit_Click(object sender, EventArgs e)   // 종료 버튼 클릭 이벤트
        {
            Application.Exit();    // 어플리케이션 종료
        }

        private void PnlMouse_MouseDown(object sender, MouseEventArgs e)   // 마우스 패널 클릭 이벤트
        {
            _move = true;
            MoveValX = e.X;
            MoveValY = e.Y;
        }

        private void PnlMouse_MouseMove(object sender, MouseEventArgs e)   // 마우스 패널 클릭 중 움직임 이벤트
        {
            if (_move)
                this.SetDesktopLocation(MousePosition.X - MoveValX, MousePosition.Y - MoveValY);
        }

        private void PnlMouse_MouseUp(object sender, MouseEventArgs e)      // 마우스 패널 클릭 종료 이벤트
        {
            _move = false;
        }
    }
}