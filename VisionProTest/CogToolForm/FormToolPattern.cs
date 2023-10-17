using Cognex.VisionPro;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.PixelMap;
using Cognex.VisionPro.PMAlign;

using ImageFileManager;

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace VisionProTest
{
    public partial class FormToolPattern : Form
    {
        public static CogRectangleAffine SearchRegion_Rect { get; set; } = new CogRectangleAffine();
        public static CogRectangleAffine TrainRegion_Rect { get; set; } = new CogRectangleAffine();
        private CogDisplay TrainDisplay { get; set; } = new CogDisplay();
        public static CogRecordDisplay CogDisplay { get; set; } = new CogRecordDisplay();

        private CogPMAlignTool PMAlignTool { get; } = new CogPMAlignTool();
        private CogPixelMapTool PixelMapTool { get; } = new CogPixelMapTool();
        private ImageManager Image_Manager { get; } = new ImageManager();

        public static string ModelName { get; set; }
        private string ModelListPath { get; set; } = Application.StartupPath + $"\\CONFIG\\ModelList\\{ModelName}\\";

        public FormToolPattern()
        {
            InitializeComponent();
            TrainDisplay = cogDisplay_Pattern;
        }

        public void PatternRegist(int _index)
        {
            if (File.Exists(ModelListPath + "\\PMAlign.ini"))
                LoadParam(_index);

            if (File.Exists(ModelListPath + "\\MasterImage.bmp"))
            {
                PMAlignTool.Pattern.TrainImageMask = Load_MaskImage(ModelToolName.Text);
                Train_Pattern(true, Image_Manager.Load_ImageFile(ModelListPath + "\\MasterImage.bmp"), TrainDisplay);
            }
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
        }

        public bool Train_Pattern(bool fileLoad, ICogImage image, CogDisplay display = null)
        {
            if (image == null)
                return false;

            if (image.ToString() == "Cognex.VisionPro.CogImage16Range")
            {
                PixelMapTool.InputImage = image;
                PixelMapTool.Run();
            }
            else if (image.ToString() == "Cognex.VisionPro.CogImage24PlanarColor")
            {
                image = CogImageConvert.GetIntensityImage(image, 0, 0, image.Width, image.Height);
            }

            if (image.ToString() == "Cognex.VisionPro.CogImage16Range")
            {
                PMAlignTool.Pattern.TrainImage = PixelMapTool.OutputImage;
                PMAlignTool.Pattern.TrainImage.SelectedSpaceName = "#";
            }
            else
            {
                PMAlignTool.Pattern.TrainImage = image;
            }

            if (chkHighSensitivity.Checked)
            {
                PMAlignTool.Pattern.TrainAlgorithm = CogPMAlignTrainAlgorithmConstants.PatMaxHighSensitivity;
                PMAlignTool.RunParams.RunAlgorithm = CogPMAlignRunAlgorithmConstants.PatMax;
            }
            else
            {
                PMAlignTool.Pattern.TrainAlgorithm = CogPMAlignTrainAlgorithmConstants.PatMax;
                PMAlignTool.RunParams.RunAlgorithm = CogPMAlignRunAlgorithmConstants.PatMax;
            }

            PMAlignTool.Pattern.TrainRegion = TrainRegion_Rect;
            PMAlignTool.Pattern.Origin.TranslationX = TrainRegion_Rect.CenterX;
            PMAlignTool.Pattern.Origin.TranslationY = TrainRegion_Rect.CenterY;

            PMAlignTool.Pattern.TrainRegionMode = CogRegionModeConstants.PixelAlignedBoundingBoxAdjustMask;

            try
            {
                PMAlignTool.Pattern.Train();
            }
            catch
            {
                return false;
            }

            if (PMAlignTool.Pattern.Trained)
            {
                if (!fileLoad)
                {
                    Image_Manager.Save_ImageFile(ModelListPath + "\\MasterImage.bmp", image);
                }

                if (display != null && PMAlignTool.Pattern.Trained)
                {
                    display.Fit();

                    PMAlignTool.Pattern.GetTrainedPatternImage().SelectedSpaceName = "#";

                    display.Image = PMAlignTool.Pattern.GetTrainedPatternImage();
                    display.StaticGraphics.Clear();

                    display.StaticGraphics.AddList(PMAlignTool.Pattern.CreateGraphicsCoarse(CogColorConstants.Yellow), null);
                    display.StaticGraphics.AddList(PMAlignTool.Pattern.CreateGraphicsFine(CogColorConstants.Green), null);
                }
            }

            return PMAlignTool.Pattern.Trained;
        }

        private CogImage8Grey Load_MaskImage(string _name)
        {
            if (!File.Exists(ModelListPath + $"\\Mask_{_name}.bmp"))
                return null;

            CogImage8Grey MaskImage = (CogImage8Grey)Image_Manager.Load_ImageFile(ModelListPath + $"\\Mask_{_name}.bmp");

            return MaskImage;
        }
        
        private void BtnTrainRegion_Click(object sender, EventArgs e)    // TrainRegion 버튼 클릭 이벤트
        {
            if (CogDisplay.Image == null)
                return;

            CogDisplay.StaticGraphics.Clear();
            CogDisplay.InteractiveGraphics.Clear();

            TrainRegion_Rect.GraphicDOFEnable = CogRectangleAffineDOFConstants.All;
            TrainRegion_Rect.Interactive = true;
            CogDisplay.InteractiveGraphics.Add(TrainRegion_Rect, null, false);
        }

        private void BtnMasking_Click(object sender, EventArgs e)        // Masking 버튼 클릭 이벤트
        {
            if (CogDisplay.Image == null)
                return;
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

            FormImageMasking _FormImageMasking = new FormImageMasking
            {
                StartPosition = FormStartPosition.CenterScreen
            };

            _FormImageMasking.cogImageMaskingEditV2.Image = null;
            _FormImageMasking.cogImageMaskingEditV2.MaskImage = Load_MaskImage(ModelToolName.Text);
            _FormImageMasking.cogImageMaskingEditV2.Image = CogDisplay.Image;
            _FormImageMasking.ShowDialog();

            if (_FormImageMasking.SelectedMasking())
            {
                PMAlignTool.Pattern.TrainImageMask = _FormImageMasking.cogImageMaskingEditV2.MaskImage;
                Image_Manager.Save_ImageFile(ModelListPath + $"\\Mask_{ModelToolName.Text}.bmp", _FormImageMasking.cogImageMaskingEditV2.MaskImage);
            }
        }

        private void BtnTrain_Click(object sender, EventArgs e)
        {
            if (CogDisplay.Image == null)
                return;

            PMAlignTool.Pattern.TrainImageMask = Load_MaskImage(ModelToolName.Text);

            if (!Train_Pattern(false, CogDisplay.Image, TrainDisplay))
                MessageBox.Show("트레인 실패!");
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("패턴을 삭제 하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                File.Delete(ModelListPath + "\\MasterImage.bmp");

                if (File.Exists(ModelListPath + "\\Mask.bmp"))
                    File.Delete(ModelListPath + "\\Mask.bmp");

                PMAlignTool.Pattern.Untrain();
                TrainDisplay.Image = null;

                chkHighSensitivity.Checked = false;
            }
        }

        private void BtnSearchRegion_Click(object sender, EventArgs e)
        {
            if (CogDisplay.Image == null)
                return;

            SearchRegion_Rect.GraphicDOFEnable = CogRectangleAffineDOFConstants.All;
            SearchRegion_Rect.Interactive = true;

            CogDisplay.StaticGraphics.Clear();
            CogDisplay.InteractiveGraphics.Clear();

            if (SearchRegion_Rect.SelectedColor == CogColorConstants.Red)
                SearchRegion_Rect.SelectedColor = CogColorConstants.Cyan;

            CogDisplay.InteractiveGraphics.Add(SearchRegion_Rect, null, false);
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            if (CogDisplay.Image == null)
                return;

            CogDisplay.StaticGraphics.Clear();
            CogDisplay.InteractiveGraphics.Clear();

            StartRun(CogDisplay.Image, CogDisplay);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (CogDisplay.Image == null)
                return;

            if (ModelToolName.Text == "" || ModelToolName.Text == null)
            {
                MessageBox.Show("이름을 입력 해주세요.", "확인");
                return;
            }

            if (MessageBox.Show("저장하시겠습니까?", "확인", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            ToolSaveManager.SearchRegion_Rect = SearchRegion_Rect;
            ToolSaveManager.TrainRegion_Rect = TrainRegion_Rect;
            ToolSaveManager.Threshold = txtThreshold.Text;
            ToolSaveManager.AngleLow = txtAngleLow.Text;
            ToolSaveManager.AngleHigh = txtAngleHigh.Text;
            ToolSaveManager.ScaleLow = txtScaleLow.Text;
            ToolSaveManager.ScaleHigh = txtScaleHigh.Text;
            ToolSaveManager.Approx = txtApprox.Text;
            ToolSaveManager.IsHighSensitivity = Convert.ToString(chkHighSensitivity.Checked);
            ToolSaveManager.SaveParam(ModelToolName.Text, UcDefine.PMAlign);
            ToolSaveManager.ToolParamSave(ModelListPath + "\\", "PMAlign", ModelToolName.Text);
        }

        public bool StartRun(ICogImage cogImage, CogDisplay display)
        {
            PointF _ptResult = new PointF
            {
                X = 0,
                Y = 0
            };

            if (!PMAlignTool.Pattern.Trained)
                return false;

            if (cogImage.ToString() == "Cognex.VisionPro.CogImage16Range")
            {
                PMAlignTool.InputImage = PixelMapTool.OutputImage;

                if (PMAlignTool.InputImage == null)
                    return false;

                PMAlignTool.InputImage.SelectedSpaceName = "#";
            }
            else
                PMAlignTool.InputImage = cogImage;

            PMAlignTool.RunParams.ZoneAngle.Configuration = CogPMAlignZoneConstants.LowHigh;
            PMAlignTool.RunParams.AcceptThreshold = Convert.ToDouble(txtThreshold.Text);
            PMAlignTool.RunParams.ZoneAngle.Low = CogMisc.DegToRad(Convert.ToDouble(txtAngleLow.Text));
            PMAlignTool.RunParams.ZoneAngle.High = CogMisc.DegToRad(Convert.ToDouble(txtAngleHigh.Text));
            PMAlignTool.RunParams.ZoneScale.Low = Convert.ToDouble(txtScaleLow.Text);
            PMAlignTool.RunParams.ZoneScale.High = Convert.ToDouble(txtScaleHigh.Text);
            PMAlignTool.RunParams.ApproximateNumberToFind = Convert.ToInt16(txtApprox.Text);

            PMAlignTool.SearchRegion = SearchRegion_Rect;

            PMAlignTool.Run();

            if (PMAlignTool.Results.Count <= 0)
            {
                SearchRegion_Rect.SelectedColor = CogColorConstants.Red;
                SearchRegion_Rect.XDirectionAdornment = CogRectangleAffineDirectionAdornmentConstants.None;
                SearchRegion_Rect.YDirectionAdornment = CogRectangleAffineDirectionAdornmentConstants.None;

                display.StaticGraphics.Add(SearchRegion_Rect, "");

                CogGraphicLabel ngLabelScore = new CogGraphicLabel
                {
                    Text = "NG",
                    X = 300,
                    Y = 200,
                    Color = CogColorConstants.Red,
                    Font = new Font("Tahoma", 50.11f)
                };

                display.StaticGraphics.Add(ngLabelScore, null);
                ngLabelScore.Dispose();

                return false;
            }

            for (int j = 0; j < PMAlignTool.Results.Count; j++)
            {
                if (PMAlignTool.Results[j].Score > PMAlignTool.RunParams.AcceptThreshold)
                {
                    CogCompositeShape m_ResultGraphic = PMAlignTool.Results[j].CreateResultGraphics(
                        CogPMAlignResultGraphicConstants.MatchRegion | CogPMAlignResultGraphicConstants.Origin);

                    CogTransform2DLinear m_ResultPos = PMAlignTool.Results[j].GetPose();

                    // 결과 
                    _ptResult.X = (float)m_ResultPos.TranslationX;
                    _ptResult.Y = (float)m_ResultPos.TranslationY;

                    display.StaticGraphics.Add(m_ResultGraphic, null);

                    CogGraphicLabel labelScore = new CogGraphicLabel
                    {
                        Text = $"{string.Format("{0:0}", PMAlignTool.Results[j].Score * 100)}" + ", " + _ptResult.X + ", " + _ptResult.Y,
                        X = _ptResult.X,
                        Y = _ptResult.Y + 100,
                        Color = CogColorConstants.Blue
                    };

                    display.StaticGraphics.Add(labelScore, null);

                    CogGraphicLabel okLabelScore = new CogGraphicLabel
                    {
                        Text = "OK",
                        X = 300,
                        Y = 200,
                        Color = CogColorConstants.Green,
                        Font = new Font("Tahoma", 50.11f)
                    };

                    display.StaticGraphics.Add(okLabelScore, null);

                    okLabelScore.Dispose();
                }
            }
            return true;
        }
    }
}