using Cognex.VisionPro;
using Cognex.VisionPro.Display;

using ImageFileManager;

using System;
using System.IO;
using System.Windows.Forms;

namespace VisionProTest
{
    public partial class FormToolPattern : Form
    {
        public static CogDisplay TrainDisplay = new CogDisplay();

        public FormToolPattern()
        {
            InitializeComponent();
            TrainDisplay = cogDisplay_Pattern;
        }

        public void LoadParam(int _index)
        {
            ToolLoadManager.SetINIPath(UcDefine.PMAlign);
            ToolLoadManager.GetSearchRegion(UcDefine.PMAlign, _index);
            ToolLoadManager.GetTrainRegion(_index);

            txtThreshold.Text = ToolLoadManager.GetThreshold(_index);
            txtAngleLow.Text = ToolLoadManager.GetAngleLow(_index);
            txtAngleHigh.Text = ToolLoadManager.GetAngleHigh(_index);
            txtScaleLow.Text = ToolLoadManager.GetScaleLow(_index);
            txtScaleHigh.Text = ToolLoadManager.GetScaleHigh(_index);
            txtApprox.Text = ToolLoadManager.GetApprox(_index);
            chkHighSensitivity.Checked = ToolLoadManager.GetIsHighSensitivity(_index);
            ModelToolName.Text = ToolLoadManager.GetModelToolName(_index);

            Pattern_Param();

            if (File.Exists(UcDefine.ModelListPath + FormSetup.strSelectedName + "\\MasterImage.bmp"))
            {
                ToolPattern.Masking(FormImageMasking.Load_MaskImage(ModelToolName.Text));
                ToolPattern.Train_Pattern(chkHighSensitivity.Checked, TrainDisplay);
            }
        }

        public static void Pattern_Param(int _index)
        {
            ToolLoadManager.SetINIPath(UcDefine.PMAlign);
            ToolLoadManager.GetSearchRegion(UcDefine.PMAlign, _index);
            ToolLoadManager.GetTrainRegion(_index);

            ToolPattern.Threshold = Convert.ToDouble(ToolLoadManager.GetThreshold(_index));
            ToolPattern.AngleLow = CogMisc.DegToRad(Convert.ToDouble(ToolLoadManager.GetAngleLow(_index)));
            ToolPattern.AngleHigh = CogMisc.DegToRad(Convert.ToDouble(ToolLoadManager.GetAngleHigh(_index)));
            ToolPattern.ScaleLow = Convert.ToDouble(ToolLoadManager.GetScaleLow(_index));
            ToolPattern.ScaleHigh = Convert.ToDouble(ToolLoadManager.GetScaleHigh(_index));
            ToolPattern.Approx = Convert.ToInt16(ToolLoadManager.GetApprox(_index));
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
                ImageManager.Save_ImageFile(UcDefine.ModelListPath + FormSetup.strSelectedName + $"\\Mask_{ModelToolName.Text}.bmp", (CogImage8Grey)FormImageMasking.MaskingImage);
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
            ImageManager.Save_ImageFile(UcDefine.ModelListPath + FormSetup.strSelectedName + "\\MasterImage.bmp", ToolPattern.SetupDisplay.Image);
        }

        private void BtnSearchRegion_Click(object sender, EventArgs e)
        {
            ToolPattern.SearchRegion_Create();
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            Pattern_Param();
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

            ToolSaveManager.SearchRegion_Rect = ToolPattern.SearchRegion_Rect;
            ToolSaveManager.TrainRegion_Rect = ToolPattern.TrainRegion_Rect;
            ToolSaveManager.Threshold = txtThreshold.Text;
            ToolSaveManager.AngleLow = txtAngleLow.Text;
            ToolSaveManager.AngleHigh = txtAngleHigh.Text;
            ToolSaveManager.ScaleLow = txtScaleLow.Text;
            ToolSaveManager.ScaleHigh = txtScaleHigh.Text;
            ToolSaveManager.Approx = txtApprox.Text;
            ToolSaveManager.IsHighSensitivity = Convert.ToString(chkHighSensitivity.Checked);
            ToolSaveManager.SaveParam(ModelToolName.Text, UcDefine.PMAlign);
            ToolSaveManager.ToolParamSave(UcDefine.ModelListPath + FormSetup.strSelectedName + "\\", "PMAlign", ModelToolName.Text);
        }
    }
}