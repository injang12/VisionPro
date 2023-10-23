using Cognex.VisionPro;
using Cognex.VisionPro.Display;

using ImageFileManager;
using INIFileManager;
using Cameras;

using System;
using System.IO;
using System.Windows.Forms;

namespace VisionProTest
{
    public partial class FormSetup : Form
    {
        private FormToolPattern _FormToolPattern;
        private FormToolCaliper _FormToolCaliper;

        private static string strSelectedName;
        private string toolName;
        private static int selectedIndex;

        private readonly string folderPath = Application.StartupPath + "\\CONFIG\\ModelList";
        private readonly string listPath = Application.StartupPath + "\\CONFIG\\List.ini";

        public FormSetup()
        {
            InitializeComponent();
        }

        public void Setup_Load()
        {
            CenterToScreen();
            Show();

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            INIFiles.Set_INI_Path(listPath);

            if (!File.Exists(listPath))
            {
                using (File.Create(listPath))
                {
                }
                INIFiles.WriteValue("COMMON", "Total", "0");
            }

            cogDisplaySetup.Image = ImageManager.Load_ImageFile(Application.StartupPath + "\\Images\\Sample1.bmp");

            double count = Convert.ToDouble(INIFiles.ReadValue("COMMON", "Total"));

            FolderList.Items.Clear();

            for (int i = 0; i < count; i++)
            {
                string[] arrData = new string[3];

                arrData[0] = (FolderList.Items.Count + 1).ToString();
                arrData[1] = INIFiles.ReadValue($"Folder{i}", "Name");
                arrData[2] = INIFiles.ReadValue($"Folder{i}", "Tool");

                FolderList.Items.Add(new ListViewItem(arrData));
            }
        }

        public string SelectModel()
        {
            return strSelectedName;
        }

        public void ToolListLoad(string _toolName)
        {
            if (!string.IsNullOrEmpty(_toolName))
            {
                string[] row = { _toolName };
                ListViewItem item = new ListViewItem(row);
                ModelToolList.Items.Add(item);
            }
        }

        public void SelectToolRun(CogDisplay display)
        {
            display.StaticGraphics.Clear();

            string path = folderPath + $"\\{strSelectedName}\\";
            string iniPath = path + "ToolParam.ini";

            if (!File.Exists(iniPath))
                return;

            INIFiles.Set_INI_Path(iniPath);

            int count = Convert.ToInt16(INIFiles.ReadValue("COMMON", "Total"));
            bool isRun = true;

            for (int i = 0; i < count; i++)
            {
                INIFiles.Set_INI_Path(iniPath);

                string tool = INIFiles.ReadValue($"{i + 1}", "Tool");
                string name = INIFiles.ReadValue($"{i + 1}", "Name");
                int total;

                switch (tool)
                {
                    case "PMAlign":
                        INIFiles.Set_INI_Path(path + "PMAlign.ini");
                        total = Convert.ToInt16(INIFiles.ReadValue("COMMON", "Total"));

                        for (int j = 0; j < total; j++)
                        {
                            if (name == INIFiles.ReadValue($"PATTERN{j + 1}", "Name"))
                            {
                                FormToolPattern.Pattern_Param(j);
                                ToolPattern.Train_Pattern(Convert.ToBoolean(INIFiles.ReadValue($"PATTERN{j + 1}", "HighSensitivity")));
                                isRun = ToolPattern.Find_Run();
                                break;
                            }
                        }
                        break;
                    case "Caliper":
                        INIFiles.Set_INI_Path(path + "Caliper.ini");
                        total = Convert.ToInt16(INIFiles.ReadValue("COMMON", "Total"));

                        for (int j = 0; j < total; j++)
                        {
                            if (name == INIFiles.ReadValue($"CALIPER{j + 1}", "Name"))
                            {
                                FormToolCaliper.Caliper_Param(j);
                                isRun = ToolCaliper.Find_Run(display);
                                break;
                            }
                        }
                        break;
                }
                if (!isRun)
                    break;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
                return;

            INIFiles.Set_INI_Path(listPath);

            int count = Convert.ToInt16(INIFiles.ReadValue("COMMON", "Total"));

            INIFiles.WriteValue("COMMON", "Total", $"{count + 1}");
            INIFiles.WriteValue("Folder" + $"{count}", "Name", txtName.Text);

            Directory.CreateDirectory(folderPath + $"\\{txtName.Text}");

            string[] arrData = new string[2];

            arrData[0] = (FolderList.Items.Count + 1).ToString();
            arrData[1] = txtName.Text;

            FolderList.Items.Add(new ListViewItem(arrData));
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (FolderList.SelectedItems.Count == 0 || MessageBox.Show("선택한 모델을 삭제하시겠습니까?", "확인", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            string strName = FolderList.SelectedItems[0].SubItems[1].Text;
            string strPath = folderPath + $"\\{strName}";

            if (strName == txtSelectName.Text)
            {
                if (MessageBox.Show("현재 열려있는 모델입니다.\n삭제 하시겠습니까?", "확인", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                    return;

                cogDisplaySetup.Image = null;
                FormToolPattern.TrainDisplay.Image = null;
                ModelToolList.Items.Clear();

                txtSelectName.Text = "EMPTY";
            }

            var selectModel = FolderList.SelectedItems[0];

            int selectIndex = selectModel.Index;
            selectModel.Remove();

            for (int i = selectIndex; i < FolderList.Items.Count; i++)
            {
                FolderList.Items[i].SubItems[0].Text = (i + 1).ToString();
            }

            INIFiles.Set_INI_Path(listPath);

            INIFiles.WriteValue("COMMON", "Total", FolderList.Items.Count.ToString());

            for (int i = 0; i < FolderList.Items.Count; i++)
            {
                ListViewItem item = FolderList.Items[i];

                INIFiles.WriteValue("Folder" + i, "Name", item.SubItems[1].Text);
            }

            for (int j = FolderList.Items.Count; j < FolderList.Items.Count + 1; j++)
            {
                INIFiles.WriteValue("Folder" + j, null, null);
            }

            Directory.Delete(strPath, true);
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (FolderList.SelectedItems.Count == 0)
                return;

            ModelToolList.Items.Clear();

            strSelectedName = FolderList.SelectedItems[0].SubItems[1].Text;

            cogDisplaySetup.StaticGraphics.Clear();
            cogDisplaySetup.InteractiveGraphics.Clear();

            txtSelectName.Text = strSelectedName;

            ToolLoadManager.ModelName = strSelectedName;
            ToolSaveManager.ModelName = strSelectedName;
        }

        private void BtnPMAlignToolLoad_Click(object sender, EventArgs e)
        {
            _FormToolPattern?.Dispose();
            _FormToolCaliper?.Dispose();

            FormToolPattern.ModelName = strSelectedName;
            ToolPattern.SetupDisplay = cogDisplaySetup;

            cogDisplaySetup.InteractiveGraphics.Clear();
            cogDisplaySetup.StaticGraphics.Clear();

            _FormToolPattern = new FormToolPattern
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            ToolPanel.Controls.Add(_FormToolPattern);
            _FormToolPattern.Show();

            ModelToolList.Items.Clear();
            string iniPath = folderPath + $"\\{strSelectedName}\\PMAlign.ini";

            INIFiles.Set_INI_Path(iniPath);

            if (!File.Exists(iniPath))
            {
                using (FileStream fs = File.Create(iniPath))
                {
                }
                INIFiles.WriteValue("COMMON", "Total", "0");
            }

            int count = Convert.ToInt16(INIFiles.ReadValue("COMMON", "Total"));

            for (int i = 0; i < count; i++)
            {
                toolName = INIFiles.ReadValue("PATTERN" + (i + 1), "Name");

                if (!string.IsNullOrEmpty(toolName))
                {
                    ToolListLoad(toolName);
                }
            }

            txtToolName.Text = "PMAlign";
        }

        private void BtnCaliperToolLoad_Click(object sender, EventArgs e)
        {
            _FormToolPattern?.Dispose();
            _FormToolCaliper?.Dispose();

            FormToolCaliper.ModelName = strSelectedName;
            ToolCaliper.SetupDisplay = cogDisplaySetup;

            _FormToolCaliper = new FormToolCaliper
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            ToolPanel.Controls.Add(_FormToolCaliper);
            _FormToolCaliper.Show();

            ModelToolList.Items.Clear();
            string iniPath = folderPath + $"\\{strSelectedName}\\Caliper.ini";

            INIFiles.Set_INI_Path(iniPath);

            if (!File.Exists(iniPath))
            {
                using (FileStream fs = File.Create(iniPath))
                {
                }
                INIFiles.WriteValue("COMMON", "Total", "0");
            }

            int count = Convert.ToInt16(INIFiles.ReadValue("COMMON", "Total"));

            for (int i = 0; i < count; i++)
            {
                toolName = INIFiles.ReadValue("CALIPER" + (i + 1), "Name");

                if (!string.IsNullOrEmpty(toolName))
                {
                    ToolListLoad(toolName);
                }
            }

            txtToolName.Text = "Caliper";
        }

        private void BtnAcquire_Click(object sender, EventArgs e)
        {
            if (txtToolName.Text == "Empty")
            {
                MessageBox.Show("Tool을 먼저 불러와 주세요.");
               return;
            }

            CameraManager.AcquireStart(cogDisplaySetup, 15, 0, 0);   // exp, bright, contrast 값 변수로 받기
        }

        private void BtnImageLoad_Click(object sender, EventArgs e)
        {
            if (txtToolName.Text == "Empty")
            {
                MessageBox.Show("Tool을 먼저 불러와 주세요.");
                return;
            }

            ImageManager.LoadImage(cogDisplaySetup);
            if (txtToolName.Text == "PMAlign")
                ToolPattern.InputImage = cogDisplaySetup.Image;
            else if (txtToolName.Text == "Caliper")
                ToolCaliper.InputImage = cogDisplaySetup.Image;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            _FormToolPattern?.Dispose();
            _FormToolCaliper?.Dispose();
            Hide();
        }

        private void ModelToolList_SelectedIndexChanged(object sender, EventArgs e)
        {
            cogDisplaySetup.StaticGraphics.Clear();
            cogDisplaySetup.InteractiveGraphics.Clear();

            string imgPath = folderPath + $"\\{strSelectedName}\\MasterImage.bmp";
            selectedIndex = -1;
            if (ModelToolList.SelectedItems.Count > 0)
            {
                selectedIndex = ModelToolList.SelectedIndices[0];
            }

            if (File.Exists(imgPath))
            {
                cogDisplaySetup.Image = ImageManager.Load_ImageFile(imgPath);

                if (txtToolName.Text == "PMAlign")
                    ToolPattern.InputImage = cogDisplaySetup.Image;
                else if (txtToolName.Text == "Caliper")
                    ToolCaliper.InputImage = cogDisplaySetup.Image;
            }

            if (selectedIndex != -1)
            {
                if (txtToolName.Text == "PMAlign")
                    _FormToolPattern.PatternRegist(Convert.ToInt16(selectedIndex));
                else if (txtToolName.Text == "Caliper")
                    _FormToolCaliper.CaliperRegist(Convert.ToInt16(selectedIndex));
            }
        }

        private void BtnToolDelete_Click(object sender, EventArgs e)
        {
            if (selectedIndex == -1)
            {
                MessageBox.Show("툴이 선택되지 않았습니다.");
                return;
            }
            if (MessageBox.Show("선택한 툴을 삭제하시겠습니까?", "확인", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            string strToolName = txtToolName.Text;
            string strPath = folderPath + $"\\{txtSelectName.Text}";

            INIFiles.Set_INI_Path(strPath + $"\\{strToolName}.ini");
            string _toolName = INIFiles.ReadValue($"PATTERN{selectedIndex + 1}", "Name");

            int toolTotal = Convert.ToInt16(INIFiles.ReadValue("COMMON", "Total"));
            INIFiles.WriteValue("COMMON", "Total", $"{toolTotal - 1}");

            if (strToolName == "PMAlign")
            {
                for (int i = 0; i < toolTotal; i++)
                {
                    if (i >= selectedIndex)
                    {
                        string[] regionKeys = { "CenterX", "CenterY", "Width", "Height", "Rotation" };
                        string[] patternKeys = { "Name", "HighSensitivity", "Accept_Threshold", "AngleLow",
                            "AngleHigh", "ScaleLow", "ScaleHigh", "Approx" };

                        foreach (string key in regionKeys)
                        {
                            string trainValue = INIFiles.ReadValue($"TRAIN_REGION_RECTANGLE{i + 2}", key);
                            string searchValue = INIFiles.ReadValue($"SERACH_REGION_RECT{i + 2}", key);

                            INIFiles.WriteValue($"TRAIN_REGION_RECTANGLE{i + 1}", key, trainValue);
                            INIFiles.WriteValue($"SERACH_REGION_RECT{i + 1}", key, searchValue);
                        }

                        foreach (string key in patternKeys)
                        {
                            string tempValue = INIFiles.ReadValue($"PATTERN{i + 2}", key);
                            INIFiles.WriteValue($"PATTERN{i + 1}", key, tempValue);
                        }
                    }
                }

                INIFiles.WriteValue($"TRAIN_REGION_RECTANGLE{toolTotal}", null, null);
                INIFiles.WriteValue($"SERACH_REGION_RECT{toolTotal}", null, null);
                INIFiles.WriteValue($"PATTERN{toolTotal}", null, null);

                File.Delete($"{strPath}\\Mask_pattern{selectedIndex + 1}.bmp");

                INIFiles.Set_INI_Path(strPath + "\\ToolParam.ini");

                int toolParamTotal = Convert.ToInt16(INIFiles.ReadValue("COMMON", "Total"));
                int index = -1;

                for (int i = 0; i < toolParamTotal; i++)
                {
                    string strName = INIFiles.ReadValue($"{i + 1}", "Name");
                    if (strName == _toolName)
                    {
                        index = i + 1;

                        INIFiles.WriteValue("COMMON", "Total", $"{toolParamTotal - 1}");
                        break;
                    }
                }

                for (int i = index; i < toolParamTotal; i++)
                {
                    string strtemp1 = INIFiles.ReadValue($"{i + 1}", "Tool");
                    string strtemp2 = INIFiles.ReadValue($"{i + 1}", "Name");

                    INIFiles.WriteValue($"{i}", "Tool", strtemp1);
                    INIFiles.WriteValue($"{i}", "Name", strtemp2);
                }

                INIFiles.WriteValue($"{toolParamTotal}", null, null);

                ModelToolList.SelectedItems[0].Remove();
            }
            else if (strToolName == "Caliper")
            {
                for (int i = 0; i < toolTotal; i++)
                {
                    if (i >= selectedIndex)
                    {
                        string[] regionKeys = { "CenterX", "CenterY", "Width", "Height", "Rotation" };
                        string[] caliperKeys = { "Name", "Threshold", "FilterSize", "Edge Pair Width" };

                        foreach (string key in regionKeys)
                        {
                            string searchValue = INIFiles.ReadValue($"SERACH_REGION_RECT{i + 2}", key);
                            INIFiles.WriteValue($"SERACH_REGION_RECT{i + 1}", key, searchValue);
                        }

                        foreach (string key in caliperKeys)
                        {
                            string tempValue = INIFiles.ReadValue($"MODE{i + 2}", "Type");
                            INIFiles.WriteValue($"MODE{i + 1}", "Type", tempValue);

                            tempValue = INIFiles.ReadValue($"Edge1_{i + 2}", "Polarity");
                            INIFiles.WriteValue($"Edge1_{i + 1}", "Polarity", tempValue);

                            tempValue = INIFiles.ReadValue($"Edge2_{i + 2}", "Polarity");
                            INIFiles.WriteValue($"Edge2_{i + 1}", "Polarity", tempValue);

                            tempValue = INIFiles.ReadValue($"CALIPER{i + 2}", key);
                            INIFiles.WriteValue($"CALIPER{i + 1}", key, tempValue);
                        }
                    }
                }

                INIFiles.WriteValue($"MODE{toolTotal}", null, null);
                INIFiles.WriteValue($"SERACH_REGION_RECT{toolTotal}", null, null);
                INIFiles.WriteValue($"Edge1_{toolTotal}", null, null);
                INIFiles.WriteValue($"Edge2_{toolTotal}", null, null);
                INIFiles.WriteValue($"CALIPER{toolTotal}", null, null);

                INIFiles.Set_INI_Path(strPath + "\\ToolParam.ini");

                int toolParamTotal = Convert.ToInt16(INIFiles.ReadValue("COMMON", "Total"));
                int index = -1;

                for (int i = 0; i < toolParamTotal; i++)
                {
                    string strName = INIFiles.ReadValue($"{i + 1}", "Name");
                    if (strName == _toolName)
                    {
                        index = i + 1;

                        INIFiles.WriteValue("COMMON", "Total", $"{toolParamTotal - 1}");
                        break;
                    }
                }

                for (int i = index; i < toolParamTotal; i++)
                {
                    string strtemp1 = INIFiles.ReadValue($"{i + 1}", "Tool");
                    string strtemp2 = INIFiles.ReadValue($"{i + 1}", "Name");

                    INIFiles.WriteValue($"{i}", "Tool", strtemp1);
                    INIFiles.WriteValue($"{i}", "Name", strtemp2);
                }

                INIFiles.WriteValue($"{toolParamTotal}", null, null);

                ModelToolList.SelectedItems[0].Remove();
            }
        }
    }
}