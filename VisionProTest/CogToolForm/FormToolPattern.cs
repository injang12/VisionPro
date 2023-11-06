using Cognex.VisionPro;
using Cognex.VisionPro.Display;

using ImageFileManager;
using INIFileManager;

using System;
using System.IO;
using System.Windows.Forms;

namespace VisionProTest
{
    public partial class FormToolPattern : Form
    {
        public static CogDisplay TrainDisplay = new CogDisplay();

        private static int total = 0;
        private static int index = 0;
        private static bool isOverlap = false;

        public FormToolPattern()
        {
            InitializeComponent();
            TrainDisplay = cogDisplay_Pattern;
        }

        public void LoadParam(int _index)
        {
            ToolLoadManager.SetINIPath(UcDefine.PMAlign);
            ToolLoadManager.LoadSearchRegion(UcDefine.PMAlign, _index);
            ToolLoadManager.LoadTrainRegion(_index);

            txtThreshold.Text = ToolLoadManager.LoadThreshold(_index);
            txtAngleLow.Text = ToolLoadManager.LoadAngleLow(_index);
            txtAngleHigh.Text = ToolLoadManager.LoadAngleHigh(_index);
            txtScaleLow.Text = ToolLoadManager.LoadScaleLow(_index);
            txtScaleHigh.Text = ToolLoadManager.LoadScaleHigh(_index);
            txtApprox.Text = ToolLoadManager.LoadApprox(_index);
            chkHighSensitivity.Checked = ToolLoadManager.LoadIsHighSensitivity(_index);
            ModelToolName.Text = ToolLoadManager.LoadModelToolName(_index);

            Pattern_Param();

            if (File.Exists(UcDefine.ModelListPath + "\\" + FormSetup.strSelectedName + "\\MasterImage.bmp"))
            {
                ToolPattern.Masking(FormImageMasking.Load_MaskImage(ModelToolName.Text));
                ToolPattern.Train_Pattern(chkHighSensitivity.Checked, TrainDisplay);
            }
        }

        public static void Pattern_Param(int _index)
        {
            ToolLoadManager.SetINIPath(UcDefine.PMAlign);
            ToolLoadManager.LoadSearchRegion(UcDefine.PMAlign, _index);
            ToolLoadManager.LoadTrainRegion(_index);

            ToolPattern.Threshold = Convert.ToDouble(ToolLoadManager.LoadThreshold(_index));
            ToolPattern.AngleLow = CogMisc.DegToRad(Convert.ToDouble(ToolLoadManager.LoadAngleLow(_index)));
            ToolPattern.AngleHigh = CogMisc.DegToRad(Convert.ToDouble(ToolLoadManager.LoadAngleHigh(_index)));
            ToolPattern.ScaleLow = Convert.ToDouble(ToolLoadManager.LoadScaleLow(_index));
            ToolPattern.ScaleHigh = Convert.ToDouble(ToolLoadManager.LoadScaleHigh(_index));
            ToolPattern.Approx = Convert.ToInt16(ToolLoadManager.LoadApprox(_index));
        }

        private void Pattern_Param()
        {
            ToolPattern.Threshold = Convert.ToDouble(txtThreshold.Text);
            ToolPattern.AngleLow = CogMisc.DegToRad(Convert.ToDouble(txtAngleLow.Text));
            ToolPattern.AngleHigh = CogMisc.DegToRad(Convert.ToDouble(txtAngleHigh.Text));
            ToolPattern.ScaleLow = Convert.ToDouble(txtScaleLow.Text);
            ToolPattern.ScaleHigh = Convert.ToDouble(txtScaleHigh.Text);
            ToolPattern.Approx = Convert.ToInt16(txtApprox.Text);
        }

        private static void FileExistsAndCreate(string toolName, string modelToolName)
        {
            string ModelPath = $"{UcDefine.ModelListPath + "\\" + FormSetup.strSelectedName}\\";

            if (!Directory.Exists(ModelPath))
                Directory.CreateDirectory(ModelPath);

            ModelPath += toolName + ".ini";

            if (!File.Exists(ModelPath))
            {
                using (FileStream fs = File.Create(ModelPath))
                {
                }
                INIFiles.Set_INI_Path(ModelPath);

                INIFiles.WriteValue("COMMON", "Total", "0");
            }
            else
            {
                INIFiles.Set_INI_Path(ModelPath);
                total = Convert.ToInt16(INIFiles.ReadValue("COMMON", "Total"));
            }

            for (int i = 0; i < total; i++)
            {
                if (INIFiles.ReadValue($"{toolName}{(i + 1)}", "Name") == modelToolName)
                {
                    isOverlap = true;
                    index = i + 1;
                    break;
                }
            }
        }

        private void SavePMAlignParam(int value)
        {
            ToolSaveManager.SaveTrainRegion(ToolPattern.TrainRegion_Rect, value);
            ToolSaveManager.SaveSearchRegion(ToolPattern.SearchRegion_Rect, value);
            ToolSaveManager.SaveToolName(UcDefine.strPMAlign, ModelToolName.Text, value);
            ToolSaveManager.SaveHighSensitivity(Convert.ToString(chkHighSensitivity.Checked), value);
            ToolSaveManager.SaveThreshold(UcDefine.strPMAlign, txtThreshold.Text, value);
            ToolSaveManager.SaveAngleLow(txtAngleLow.Text, value);
            ToolSaveManager.SaveAngleHigh(txtAngleHigh.Text, value);
            ToolSaveManager.SaveScaleLow(txtScaleLow.Text, value);
            ToolSaveManager.SaveScaleHigh(txtScaleHigh.Text, value);
            ToolSaveManager.SaveApprox(txtApprox.Text, value);
        }

        private void BtnTrainRegion_Click(object sender, EventArgs e)    // TrainRegion 버튼 클릭 이벤트
        {
            ToolPattern.TrainRegion_Create();
        }

        private void BtnMasking_Click(object sender, EventArgs e)        // Masking 버튼 클릭 이벤트
        {
            if (string.IsNullOrEmpty(ModelToolName.Text))
            {
                MessageBox.Show("이름을 입력해 주세요.");
                return;
            }

            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == "FormImageMask")
                {
                    frm.Activate();
                    return;
                }
            }
            if (FormImageMasking.ImageMasking(ToolPattern.SetupDisplay.Image, ModelToolName.Text))
            {
                ToolPattern.Masking(FormImageMasking.Load_MaskImage(ModelToolName.Text));
                ImageManager.Save_ImageFile(UcDefine.ModelListPath + "\\" + FormSetup.strSelectedName + $"\\Mask_{ModelToolName.Text}.bmp", (CogImage8Grey)FormImageMasking.MaskingImage);
            }
        }

        private void BtnTrain_Click(object sender, EventArgs e)
        {
            ToolPattern.Masking(FormImageMasking.Load_MaskImage(ModelToolName.Text));

            if (!ToolPattern.Train_Pattern(chkHighSensitivity.Checked, TrainDisplay))
            {
                MessageBox.Show("트레인 실패!");
                return;
            }
        }

        private void BtnSearchRegion_Click(object sender, EventArgs e)
        {
            ToolPattern.SearchRegion_Create();
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            Pattern_Param();
            ToolPattern.MainDisplay_Clear();
            ToolPattern.Find_Run();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ModelToolName.Text))
            {
                MessageBox.Show("이름을 입력 해주세요.", "확인");
                return;
            }

            if (MessageBox.Show("저장하시겠습니까?", "확인", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            FileExistsAndCreate(UcDefine.strPMAlign, ModelToolName.Text);

            if (!isOverlap)
            {
                if (MessageBox.Show("패턴을 새로 추가 하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    total++;
                    INIFiles.WriteValue("COMMON", "Total", Convert.ToString(total));

                    SavePMAlignParam(total);
                    ToolSaveManager.ToolParamSave(UcDefine.ModelListPath + "\\" + FormSetup.strSelectedName + "\\", UcDefine.strPMAlign, ModelToolName.Text);
                }
                else
                    return;
            }
            else
            {
                if (MessageBox.Show("기존 패턴과 이름이 같습니다 덮어쓰시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SavePMAlignParam(index);
                else
                    return;
            }
            ImageManager.Save_ImageFile(UcDefine.ModelListPath + "\\" + FormSetup.strSelectedName + "\\MasterImage.bmp", ToolPattern.SetupDisplay.Image);
        }
    }
}