using ImageFileManager;

using INIFileManager;

using System;
using System.IO;
using System.Windows.Forms;

namespace VisionProTest
{
    public partial class FormToolCaliper : Form
    {
        private static int total = 0;
        private static int index = 0;
        private static bool isOverlap = false;

        public FormToolCaliper()
        {
            InitializeComponent();
        }

        public void LoadParam(int _index)
        {
            ToolLoadManager.SetINIPath(UcDefine.Caliper);
            ToolLoadManager.LoadSearchRegion(UcDefine.Caliper, _index);

            DoubleEdged.Checked = ToolLoadManager.LoadMode(_index);
            comboPolarity.SelectedIndex = ToolLoadManager.LoadEdge1Polarity(_index);
            comboPolarity2.SelectedIndex = ToolLoadManager.LoadEdge2Polarity(_index);
            txtThreshold.Text = ToolLoadManager.LoadThreshold(_index);
            txtFilterSize.Text = ToolLoadManager.LoadFilterSize(_index);
            txtEdgePairWidth.Text = ToolLoadManager.LoadEdgePairWidth(_index);
            ModelToolName.Text = ToolLoadManager.LoadModelToolName(_index);

            Caliper_Param();
        }

        public static void Caliper_Param(int _index)
        {
            ToolLoadManager.SetINIPath(UcDefine.Caliper);
            ToolLoadManager.LoadSearchRegion(UcDefine.Caliper, _index);

            ToolCaliper.DoubleEdge = ToolLoadManager.LoadMode(_index);
            ToolCaliper.Polarity = ToolLoadManager.LoadEdge1Polarity(_index);
            ToolCaliper.Threshold = Convert.ToDouble(ToolLoadManager.LoadThreshold(_index));
            ToolCaliper.FilterSize = Convert.ToDouble(ToolLoadManager.LoadFilterSize(_index));

            if (ToolCaliper.DoubleEdge)
            {
                ToolCaliper.Polarity2 = ToolLoadManager.LoadEdge2Polarity(_index);
                ToolCaliper.EdgePairWidth = Convert.ToInt16(ToolLoadManager.LoadEdgePairWidth(_index));
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

        private static void FileExistsAndCreate(string toolName, string modelToolName)
        {
            string ModelPath = $"{UcDefine.ModelListPath + FormSetup.strSelectedName}\\";

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

        private void SaveCaliperParam(int value)
        {
            ToolSaveManager.SaveSearchRegion(ToolCaliper.SearchRegion_Rect, value);
            ToolSaveManager.SaveToolName(UcDefine.strCaliper, ModelToolName.Text, value);
            ToolSaveManager.SaveThreshold(UcDefine.strCaliper, txtThreshold.Text, value);
            ToolSaveManager.SaveEdgeType(DoubleEdged.Checked, value);
            ToolSaveManager.SaveEdgePolarity(comboPolarity.Text, value, 1);
            ToolSaveManager.SaveEdgePolarity(comboPolarity2.Text, value, 2);
            ToolSaveManager.SaveFilterSize(txtFilterSize.Text, value);
            ToolSaveManager.SaveEdgePairWidth(txtEdgePairWidth.Text, value);
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

            FileExistsAndCreate(UcDefine.strCaliper, ModelToolName.Text);

            if (!isOverlap)
            {
                if (MessageBox.Show("캘리퍼를 새로 추가 하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    total++;
                    INIFiles.WriteValue("COMMON", "Total", Convert.ToString(total));

                    SaveCaliperParam(total);
                    ToolSaveManager.ToolParamSave(UcDefine.ModelListPath + FormSetup.strSelectedName + "\\", UcDefine.strCaliper, ModelToolName.Text);
                }
                else
                    return;
            }
            else
            {
                if (MessageBox.Show("기존 캘리퍼 이름이 같습니다 덮어쓰시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    SaveCaliperParam(index);
                else
                    return;
            }

            ImageManager.Save_ImageFile(UcDefine.ModelListPath + FormSetup.strSelectedName + "\\MasterImage.bmp", ToolCaliper.SetupDisplay.Image);
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