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
        public static CogRectangleAffine SearchRegion_Rect { get; set; } = new CogRectangleAffine();
        public static CogRecordDisplay CogDisplay { get; set; } = new CogRecordDisplay();

        public static string ModelName { get; set; }
        private string ModelListPath { get; set; } = Application.StartupPath + $"\\CONFIG\\ModelList\\{ModelName}\\";

        private static bool DoubleEdge;
        private static int Polarity, Polarity2;
        private static string Threshold, FilterSize, EdgePairWidth, ToolName;

        public FormToolCaliper()
        {
            InitializeComponent();
        }

        public void CaliperRegist(int _index)
        {
            if (File.Exists(ModelListPath + "Caliper.ini"))
            {
                SetCaliperParam(_index);
                LoadParam();
            }
        }

        public static void SetCaliperParam(int _index)
        {
            ToolLoadManager.SetINIPath(UcDefine.Caliper);
            ToolLoadManager.GetSearchRegion(UcDefine.Caliper, _index);

            DoubleEdge = ToolLoadManager.GetMode(_index);
            Polarity = ToolLoadManager.GetEdge1Polarity(_index);

            if (DoubleEdge)
                Polarity2 = ToolLoadManager.GetEdge2Polarity(_index);

            Threshold = ToolLoadManager.GetThreshold(_index);
            FilterSize = ToolLoadManager.GetFilterSize(_index);

            if (DoubleEdge)
                EdgePairWidth = ToolLoadManager.GetEdgePairWidth(_index);
            ToolName = ToolLoadManager.GetModelToolName(_index);
        }

        private void LoadParam()
        {
            DoubleEdged.Checked = DoubleEdge;
            comboPolarity.SelectedIndex = Polarity;
            comboPolarity2.SelectedIndex = Polarity2;
            txtThreshold.Text = Threshold;
            txtFilterSize.Text = FilterSize;
            txtEdgePairWidth.Text = EdgePairWidth;
            ModelToolName.Text = ToolName;
        }

        public static bool StartRun(ICogImage cogImage, CogDisplay display)
        {
            int index = Polarity;
            index++;

            CogCaliperTool CaliperTool = new CogCaliperTool
            {
                InputImage = cogImage,
                Region = SearchRegion_Rect
            };

            CogCaliperScorerContrast ScorerConstrast = new CogCaliperScorerContrast();

            CaliperTool.RunParams.SingleEdgeScorers.Clear();
            CaliperTool.RunParams.SingleEdgeScorers.Add(ScorerConstrast);

            CaliperTool.RunParams.ContrastThreshold = Convert.ToDouble(Threshold);
            CaliperTool.RunParams.FilterHalfSizeInPixels = Convert.ToInt32(FilterSize);
            CaliperTool.RunParams.Edge0Polarity = (CogCaliperPolarityConstants)index;

            switch (DoubleEdge)
            {
                case true:
                    int index2 = Polarity2;
                    index2++;

                    CaliperTool.RunParams.EdgeMode = CogCaliperEdgeModeConstants.Pair;
                    CaliperTool.RunParams.Edge1Polarity = (CogCaliperPolarityConstants)index2;
                    CaliperTool.RunParams.Edge0Position = -1 * (Convert.ToDouble(EdgePairWidth) / 2);
                    CaliperTool.RunParams.Edge1Position = Convert.ToDouble(EdgePairWidth) / 2;
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

        private void BtnSearchRegion_Click(object sender, EventArgs e)
        {
            SearchRegion_Rect.GraphicDOFEnable = CogRectangleAffineDOFConstants.All;
            SearchRegion_Rect.Interactive = true;
            SearchRegion_Rect.XDirectionAdornment = CogRectangleAffineDirectionAdornmentConstants.SolidArrow;
            SearchRegion_Rect.YDirectionAdornment = CogRectangleAffineDirectionAdornmentConstants.Arrow;
            SearchRegion_Rect.SelectedSpaceName = "#";
            SearchRegion_Rect.SelectedColor = CogColorConstants.Blue;

            CogDisplay.StaticGraphics.Clear();
            CogDisplay.InteractiveGraphics.Clear();

            if (!File.Exists(ModelListPath + "Caliper.ini"))
            {
                SearchRegion_Rect.CenterX = 500;
                SearchRegion_Rect.CenterY = 500;
                SearchRegion_Rect.SideXLength = 200;
                SearchRegion_Rect.SideYLength = 200;
                SearchRegion_Rect.Rotation = 0;
            }

            CogDisplay.InteractiveGraphics.Add(SearchRegion_Rect, null, false);
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

            CogDisplay.StaticGraphics.Clear();
            CogDisplay.InteractiveGraphics.Clear();

            if (threshold > 10000)
                txtThreshold.Text = "10000";
            else if (threshold < 0)
                txtThreshold.Text = "0";

            if (filterSize <= 0)
                txtFilterSize.Text = "1";
            else if (filterSize > 99999)
                txtFilterSize.Text = "99999";

            StartRun(CogDisplay.Image, CogDisplay);
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

            _ImageManager.Save_ImageFile(ModelListPath + "MasterImage.bmp", CogDisplay.Image);

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
            ToolSaveManager.ToolParamSave(ModelListPath, "Caliper", ModelToolName.Text);
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