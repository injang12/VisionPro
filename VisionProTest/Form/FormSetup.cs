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

        private readonly ImageManager _ImageManager = new ImageManager();
        private readonly INIFiles _INIFiles = new INIFiles();

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

            _INIFiles.Set_INI_Path(listPath);

            if (!File.Exists(listPath))
            {
                using (File.Create(listPath))
                {
                }
                _INIFiles.WriteValue("COMMON", "Total", "0");
            }

            cogDisplaySetup.Image = _ImageManager.Load_ImageFile(Application.StartupPath + "\\Images\\Sample1.bmp");

            double count = Convert.ToDouble(_INIFiles.ReadValue("COMMON", "Total"));

            FolderList.Items.Clear();

            for (int i = 0; i < count; i++)
            {
                string[] arrData = new string[3];

                arrData[0] = (FolderList.Items.Count + 1).ToString();
                arrData[1] = _INIFiles.ReadValue($"Folder{i}", "Name");
                arrData[2] = _INIFiles.ReadValue($"Folder{i}", "Tool");

                FolderList.Items.Add(new ListViewItem(arrData));
            }
        }

        public string SelectModel()
        {
            return strSelectedName;
        }

        public void ToolListSave(string _toolName)
        {
            ModelToolList.Items.Add(_toolName);
        }

        public void ToolListLoad(string _toolName)    // ModelToolList에 아이템 추가 안됨
        {
            if (!string.IsNullOrEmpty(_toolName))
            {
                string[] row = { _toolName };
                ListViewItem item = new ListViewItem(row);
                ModelToolList.Items.Add(item);
            }
        }

        public void SelectToolRun(ICogImage image, CogDisplay display)
        {
            if (image == null || display == null)
                return;

            display.StaticGraphics.Clear();

            string path = folderPath + $"\\{strSelectedName}\\";
            string iniPath = path + "ToolParam.ini";

            if (!File.Exists(iniPath))
                return;

            _FormToolPattern = new FormToolPattern();
            _FormToolCaliper = new FormToolCaliper();

            _INIFiles.Set_INI_Path(iniPath);

            int count = Convert.ToInt16(_INIFiles.ReadValue("COMMON", "Total"));
            bool isRun = true;

            for (int i = 0; i < count; i++)
            {
                _INIFiles.Set_INI_Path(iniPath);

                string tool = _INIFiles.ReadValue($"{i + 1}", "Tool");
                string name = _INIFiles.ReadValue($"{i + 1}", "Name");
                int total;

                switch (tool)
                {
                    case "PMAlign":
                        _INIFiles.Set_INI_Path(path + "PMAlign.ini");
                        total = Convert.ToInt16(_INIFiles.ReadValue("COMMON", "Total"));

                        for (int j = 0; j < total; j++)
                        {
                            if (name == _INIFiles.ReadValue($"PATTERN{j + 1}", "Name"))
                            {
                                _FormToolPattern.LoadParam(j);
                                _FormToolPattern.Train_Pattern(true, image);
                                isRun = _FormToolPattern.StartRun(image, display);
                                break;
                            }
                        }
                        break;
                    case "Caliper":
                        _INIFiles.Set_INI_Path(path + "Caliper.ini");
                        total = Convert.ToInt16(_INIFiles.ReadValue("COMMON", "Total"));

                        for (int j = 0; j < total; j++)
                        {
                            if (name == _INIFiles.ReadValue($"CALIPER{j + 1}", "Name"))
                            {
                                _FormToolCaliper.LoadParam(j);
                                isRun = _FormToolCaliper.StartRun(image, display);
                                break;
                            }
                        }
                        break;
                }
                if (!isRun)
                    break;
            }
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (FolderList.SelectedItems.Count == 0)
                return;

            strSelectedName = FolderList.SelectedItems[0].SubItems[1].Text;

            cogDisplaySetup.StaticGraphics.Clear();
            cogDisplaySetup.InteractiveGraphics.Clear();

            txtSelectName.Text = strSelectedName;

            ToolLoadManager toolLoad = new ToolLoadManager();
            ToolSaveManager toolSave = new ToolSaveManager();
            toolLoad.SelectModel(strSelectedName);
            toolSave.SelectModel(strSelectedName);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtName.Text == null)
                return;

            _INIFiles.Set_INI_Path(listPath);

            int count = Convert.ToInt16(_INIFiles.ReadValue("COMMON", "Total"));

            _INIFiles.WriteValue("COMMON", "Total", $"{count + 1}");
            _INIFiles.WriteValue("Folder" + $"{count}", "Name", txtName.Text);

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

                cogDisplaySetup.StaticGraphics.Clear();
                cogDisplaySetup.InteractiveGraphics.Clear();
                _FormToolPattern?.Dispose();
                _FormToolCaliper?.Dispose();

                txtSelectName.Text = "EMPTY";
            }

            var selectModel = FolderList.SelectedItems[0];

            int selectIndex = selectModel.Index;
            selectModel.Remove();

            for (int i = selectIndex; i < FolderList.Items.Count; i++)
            {
                FolderList.Items[i].SubItems[0].Text = (i + 1).ToString();
            }

            _INIFiles.Set_INI_Path(listPath);

            _INIFiles.WriteValue("COMMON", "Total", FolderList.Items.Count.ToString());

            for (int i = 0; i < FolderList.Items.Count; i++)
            {
                ListViewItem item = FolderList.Items[i];

                _INIFiles.WriteValue("Folder" + i, "Name", item.SubItems[1].Text);
            }

            for (int j = FolderList.Items.Count; j < FolderList.Items.Count + 1; j++)
            {
                _INIFiles.WriteValue("Folder" + j, null, null);
            }

            Directory.Delete(strPath, true);
        }

        private void BtnPMAlignToolLoad_Click(object sender, EventArgs e)
        {
            _FormToolPattern?.Dispose();
            _FormToolCaliper?.Dispose();

            FormToolPattern.CogDisplay = cogDisplaySetup;
            FormToolPattern.ModelName = strSelectedName;

            cogDisplaySetup.InteractiveGraphics.Clear();
            cogDisplaySetup.StaticGraphics.Clear();

            _FormToolPattern = new FormToolPattern
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            panel2.Controls.Add(_FormToolPattern);
            _FormToolPattern.Show();

            ModelToolList.Items.Clear();
            string iniPath = folderPath + $"\\{strSelectedName}\\PMAlign.ini";

            _INIFiles.Set_INI_Path(iniPath);

            if (!File.Exists(iniPath))
            {
                using (FileStream fs = File.Create(iniPath))
                {
                }
                _INIFiles.WriteValue("COMMON", "Total", "0");
            }

            int count = Convert.ToInt16(_INIFiles.ReadValue("COMMON", "Total"));

            for (int i = 0; i < count; i++)
            {
                toolName = _INIFiles.ReadValue("PATTERN" + (i + 1), "Name");

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

            _FormToolCaliper = new FormToolCaliper();
            _FormToolCaliper.SetStrName(strSelectedName);
            _FormToolCaliper.SetDisplay(cogDisplaySetup);

            _FormToolCaliper = new FormToolCaliper
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            panel2.Controls.Add(_FormToolCaliper);
            _FormToolCaliper.Show();

            ModelToolList.Items.Clear();
            string iniPath = folderPath + $"\\{strSelectedName}\\Caliper.ini";
            int count;

            _INIFiles.Set_INI_Path(iniPath);

            if (File.Exists(iniPath))
                count = Convert.ToInt16(_INIFiles.ReadValue("COMMON", "Total"));
            else
                return;

            for (int i = 0; i < count; i++)
            {
                toolName = _INIFiles.ReadValue("CALIPER" + (i + 1), "Name");

                if (!string.IsNullOrEmpty(toolName))
                {
                    ToolListLoad(toolName);
                }
            }

            txtToolName.Text = "Caliper";
        }

        private void BtnAcquire_Click(object sender, EventArgs e)
        {
            CameraManager _Camera = new CameraManager();
            _Camera.AcquireStart(cogDisplaySetup, 15, 0, 0);
        }

        private void BtnImageLoad_Click(object sender, EventArgs e)
        {
            _ImageManager.LoadImage(cogDisplaySetup);
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
                cogDisplaySetup.Image = _ImageManager.Load_ImageFile(imgPath);

            if (selectedIndex != -1)
            {
                if (txtToolName.Text == "PMAlign")
                    _FormToolPattern.PatternRegist(Convert.ToInt16(selectedIndex));
                else if (txtToolName.Text == "Caliper")
                    _FormToolCaliper.CaliperRegist(Convert.ToInt16(selectedIndex));
            }
        }
    }
}