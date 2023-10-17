using Cognex.VisionPro;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.Caliper;

using ImageFileManager;

using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace VisionProTest
{
    public partial class FormToolCaliper : Form
    {
        private CogRectangleAffine SearchRegion_Rect = new CogRectangleAffine();
        private static CogRecordDisplay mDisplay = new CogRecordDisplay();

        private static string modelName;
        private readonly string modelListPath = Application.StartupPath + $"\\CONFIG\\ModelList\\{modelName}\\";

        public FormToolCaliper()
        {
            InitializeComponent();
        }

        public void SetStrName(string strname)
        {
            modelName = strname;
        }

        public void SetDisplay(CogRecordDisplay _display)
        {
            mDisplay = _display;
        }

        public void CaliperRegist(int _index)
        {
            if (File.Exists(modelListPath + "Caliper.ini"))
                LoadParam(_index);
        }

        private void BtnSearchRegion_Click(object sender, EventArgs e)
        {
            SearchRegion_Rect.GraphicDOFEnable = CogRectangleAffineDOFConstants.All;
            SearchRegion_Rect.Interactive = true;
            SearchRegion_Rect.XDirectionAdornment = CogRectangleAffineDirectionAdornmentConstants.SolidArrow;
            SearchRegion_Rect.YDirectionAdornment = CogRectangleAffineDirectionAdornmentConstants.Arrow;
            SearchRegion_Rect.SelectedSpaceName = "#";
            SearchRegion_Rect.SelectedColor = CogColorConstants.Blue;

            mDisplay.StaticGraphics.Clear();
            mDisplay.InteractiveGraphics.Clear();

            if (!File.Exists(modelListPath + "Caliper.ini"))
            {
                SearchRegion_Rect.CenterX = 500;
                SearchRegion_Rect.CenterY = 500;
                SearchRegion_Rect.SideXLength = 200;
                SearchRegion_Rect.SideYLength = 200;
                SearchRegion_Rect.Rotation = 0;
            }

            mDisplay.InteractiveGraphics.Add(SearchRegion_Rect, null, false);
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtThreshold.Text, out double threshold))
            {
                MessageBox.Show("Threshold 입력이 잘못 되었습니다.");
                return;
            }

            if (!int.TryParse(txtThreshold.Text, out int filterSize))
            {
                MessageBox.Show("Filter Size 입력이 잘못 되었습니다.");
                return;
            }

            mDisplay.StaticGraphics.Clear();
            mDisplay.InteractiveGraphics.Clear();

            if (threshold > 10000)
                txtThreshold.Text = "10000";
            else if (threshold < 0)
                txtThreshold.Text = "0";

            if (filterSize <= 0)
                txtFilterSize.Text = "1";
            else if (filterSize > 99999)
                txtFilterSize.Text = "99999";

            StartRun(mDisplay.Image, mDisplay);
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

            string strMode = null;
            ImageManager _ImageManager = new ImageManager();

            _ImageManager.Save_ImageFile(modelListPath + "MasterImage.bmp", mDisplay.Image);

            switch (DoubleEdged.Checked)
            {
                case true:
                    strMode = "Double";
                    ToolSaveManager.Polarity2 = comboPolarity2.Text;
                    ToolSaveManager.EdgePairWidth = txtEdgePairWidth.Text;
                    break;
                case false:
                    strMode = "Single";
                    ToolSaveManager.Polarity2 = "";
                    ToolSaveManager.EdgePairWidth = "10";
                    break;
            }

            ToolSaveManager.SearchRegion_Rect = SearchRegion_Rect;
            ToolSaveManager.Polarity = comboPolarity.Text;
            ToolSaveManager.Threshold = txtThreshold.Text;
            ToolSaveManager.FilterSize = txtFilterSize.Text;
            ToolSaveManager.SaveParam(ModelToolName.Text, UcDefine.Caliper, strMode);
            ToolSaveManager.ToolParamSave(modelListPath, "Caliper", ModelToolName.Text);
        }

        public bool StartRun(ICogImage cogImage, CogDisplay display)
        {
            int index = comboPolarity.SelectedIndex;
            index++;

            CogCaliperTool CaliperTool = new CogCaliperTool
            {
                InputImage = cogImage,
                Region = SearchRegion_Rect
            };

            CogCaliperScorerContrast ScorerConstrast = new CogCaliperScorerContrast();

            CaliperTool.RunParams.SingleEdgeScorers.Clear();
            CaliperTool.RunParams.SingleEdgeScorers.Add(ScorerConstrast);

            CaliperTool.RunParams.ContrastThreshold = Convert.ToDouble(txtThreshold.Text);
            CaliperTool.RunParams.FilterHalfSizeInPixels = Convert.ToInt32(txtFilterSize.Text);
            CaliperTool.RunParams.Edge0Polarity = (CogCaliperPolarityConstants)index;

            switch (DoubleEdged.Checked)
            {
                case true:
                    int index2 = comboPolarity2.SelectedIndex;
                    index2++;

                    CaliperTool.RunParams.EdgeMode = CogCaliperEdgeModeConstants.Pair;
                    CaliperTool.RunParams.Edge1Polarity = (CogCaliperPolarityConstants)index2;
                    CaliperTool.RunParams.Edge0Position = -1 * (Convert.ToDouble(txtEdgePairWidth.Text) / 2);
                    CaliperTool.RunParams.Edge1Position = Convert.ToDouble(txtEdgePairWidth.Text) / 2;
                    break;
                case false:
                    CaliperTool.RunParams.EdgeMode = CogCaliperEdgeModeConstants.SingleEdge;
                    break;
            }

            CaliperTool.LastRunRecordDiagEnable = CogCaliperLastRunRecordDiagConstants.TransformedRegionPixels;

            CaliperTool.Run();

            if (CaliperTool.Results.Count <= 0 || CaliperTool.Results == null)
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

            CogCompositeShape doubleEdgeGrapic = CaliperTool.Results[0].CreateResultGraphics(CogCaliperResultGraphicConstants.All);
            display.StaticGraphics.Add(doubleEdgeGrapic, "");

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

            return true;
        }

        public void LoadParam(int _index)
        {
            ToolLoadManager _ToolLoadManager = new ToolLoadManager();

            _ToolLoadManager.SetINIPath(UcDefine.Caliper);

            SearchRegion_Rect = _ToolLoadManager.GetSearchRegion(_index);
            DoubleEdged.Checked = ToolLoadManager.GetMode(_index);
            comboPolarity.SelectedIndex = ToolLoadManager.GetEdge1Polarity(_index);

            if (DoubleEdged.Checked)
                comboPolarity2.SelectedIndex = ToolLoadManager.GetEdge2Polarity(_index);

            txtThreshold.Text = ToolLoadManager.GetThreshold(_index);
            txtFilterSize.Text = ToolLoadManager.GetFilterSize(_index);

            if (DoubleEdged.Checked)
                txtEdgePairWidth.Text = ToolLoadManager.GetEdgePairWidth(_index);
            ModelToolName.Text = ToolLoadManager.GetModelToolName(_index);
        }

        private void DoubleEdged_CheckedChanged(object sender, EventArgs e)
        {
            label11.Visible = DoubleEdged.Checked;
            txtEdgePairWidth.Visible = DoubleEdged.Checked;
            label6.Visible = DoubleEdged.Checked;
            comboPolarity2.Visible = DoubleEdged.Checked;
        }
    }
}