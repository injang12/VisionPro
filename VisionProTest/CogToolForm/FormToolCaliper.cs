using ImageFileManager;

using System;
using System.Windows.Forms;

namespace VisionProTest
{
    public partial class FormToolCaliper : Form
    {
        public FormToolCaliper()
        {
            InitializeComponent();
        }

        public void LoadParam(int _index)
        {
            ToolLoadManager.SetINIPath(UcDefine.Caliper);
            ToolLoadManager.GetSearchRegion(UcDefine.Caliper, _index);

            DoubleEdged.Checked = ToolLoadManager.GetMode(_index);
            comboPolarity.SelectedIndex = ToolLoadManager.GetEdge1Polarity(_index);
            comboPolarity2.SelectedIndex = ToolLoadManager.GetEdge2Polarity(_index);
            txtThreshold.Text = ToolLoadManager.GetThreshold(_index);
            txtFilterSize.Text = ToolLoadManager.GetFilterSize(_index);
            txtEdgePairWidth.Text = ToolLoadManager.GetEdgePairWidth(_index);
            ModelToolName.Text = ToolLoadManager.GetModelToolName(_index);

            Caliper_Param();
        }

        public static void Caliper_Param(int _index)
        {
            ToolLoadManager.SetINIPath(UcDefine.Caliper);
            ToolLoadManager.GetSearchRegion(UcDefine.Caliper, _index);

            ToolCaliper.DoubleEdge = ToolLoadManager.GetMode(_index);
            ToolCaliper.Polarity = ToolLoadManager.GetEdge1Polarity(_index);
            ToolCaliper.Threshold = Convert.ToDouble(ToolLoadManager.GetThreshold(_index));
            ToolCaliper.FilterSize = Convert.ToDouble(ToolLoadManager.GetFilterSize(_index));

            if (ToolCaliper.DoubleEdge)
            {
                ToolCaliper.Polarity2 = ToolLoadManager.GetEdge2Polarity(_index);
                ToolCaliper.EdgePairWidth = Convert.ToInt16(ToolLoadManager.GetEdgePairWidth(_index));
            }
        }

        private void Caliper_Param()
        {
            ToolCaliper.DoubleEdge = DoubleEdged.Checked;
            ToolCaliper.Polarity = comboPolarity.SelectedIndex;
            ToolCaliper.Threshold = Convert.ToDouble(txtThreshold.Text);
            ToolCaliper.FilterSize = Convert.ToDouble(txtFilterSize.Text);

            if (ToolCaliper.DoubleEdge)
            {
                ToolCaliper.Polarity2 = comboPolarity2.SelectedIndex;
                ToolCaliper.EdgePairWidth = Convert.ToInt16(txtEdgePairWidth.Text);
            }
        }

        private void BtnSearchRegion_Click(object sender, EventArgs e)
        {
            ToolCaliper.SearchRegion_Create();
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

            if (threshold > 10000)
                txtThreshold.Text = "10000";
            else if (threshold < 0)
                txtThreshold.Text = "0";

            if (filterSize <= 0)
                txtFilterSize.Text = "1";
            else if (filterSize > 99999)
                txtFilterSize.Text = "99999";

            Caliper_Param();

            ToolCaliper.Find_Run(ToolCaliper.SetupDisplay);
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

            ToolSaveManager.SearchRegion_Rect = ToolCaliper.SearchRegion_Rect;

            ImageManager.Save_ImageFile(UcDefine.ModelListPath + FormSetup.strSelectedName + "\\MasterImage.bmp", ToolCaliper.SetupDisplay.Image);
            
            string strMode = null;

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

            ToolSaveManager.Polarity = comboPolarity.Text;
            ToolSaveManager.Threshold = txtThreshold.Text;
            ToolSaveManager.FilterSize = txtFilterSize.Text;
            ToolSaveManager.SaveParam(ModelToolName.Text, UcDefine.Caliper, strMode);
            ToolSaveManager.ToolParamSave(UcDefine.ModelListPath + FormSetup.strSelectedName + "\\", "Caliper", ModelToolName.Text);
        }

        private void DoubleEdged_CheckedChanged(object sender, EventArgs e)
        {
            label11.Visible = DoubleEdged.Checked;
            txtEdgePairWidth.Visible = DoubleEdged.Checked;
            label6.Visible = DoubleEdged.Checked;
            comboPolarity2.Visible = DoubleEdged.Checked;

            ToolCaliper.DoubleEdge = DoubleEdged.Checked;
        }
    }
}