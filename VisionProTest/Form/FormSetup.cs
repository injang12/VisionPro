﻿using ImageFileManager;
using INIFileManager;
using Cameras;

using System;
using System.IO;
using System.Windows.Forms;
using Cognex.VisionPro;

namespace VisionProTest
{
    public partial class FormSetup : Form
    {
        private FormToolPattern _FormToolPattern;
        private FormToolCaliper _FormToolCaliper;

        public static int selectedIndex;
        public static string strSelectedName;
        private string toolName;

        public FormSetup()
        {
            InitializeComponent();
        }

        public void Setup_Load()
        {
            CenterToScreen();
            Show();

            if (!Directory.Exists(UcDefine.ModelListPath))
                Directory.CreateDirectory(UcDefine.ModelListPath);

            INIFiles.Set_INI_Path(UcDefine.ListINIPath);

            if (!File.Exists(UcDefine.ListINIPath))
            {
                using (File.Create(UcDefine.ListINIPath))
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

        public static string SelectModel()
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

        public static void SelectToolRun(CogRecordDisplay display)
        {
            display.StaticGraphics.Clear();

            string path = UcDefine.ModelListPath + $"\\{strSelectedName}\\";
            string iniPath = path + "ToolParam.ini";
            string ImagePath = path + "MasterImage.bmp";

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

                        ToolPattern.InputImage = ImageManager.Load_ImageFile(ImagePath);

                        for (int j = 0; j < total; j++)
                        {
                            if (name == INIFiles.ReadValue($"{UcDefine.strPMAlign}{j + 1}", "Name"))
                            {
                                FormToolPattern.Pattern_Param(j);
                                ToolPattern.Train_Pattern(Convert.ToBoolean(INIFiles.ReadValue($"{UcDefine.strPMAlign}{j + 1}", "HighSensitivity")));

                                isRun = ToolPattern.Find_Run(display);
                                break;
                            }
                        }
                        break;
                    case "Caliper":
                        INIFiles.Set_INI_Path(path + "Caliper.ini");
                        total = Convert.ToInt16(INIFiles.ReadValue("COMMON", "Total"));

                        ToolCaliper.InputImage = ImageManager.Load_ImageFile(ImagePath);

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
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                INIFiles.Set_INI_Path(UcDefine.ListINIPath);

                int count = Convert.ToInt16(INIFiles.ReadValue("COMMON", "Total"));

                INIFiles.WriteValue("COMMON", "Total", $"{count + 1}");
                INIFiles.WriteValue("Folder" + $"{count}", "Name", txtName.Text);

                Directory.CreateDirectory(UcDefine.ModelListPath + $"\\{txtName.Text}");

                string[] arrData = new string[2];

                arrData[0] = (FolderList.Items.Count + 1).ToString();
                arrData[1] = txtName.Text;

                FolderList.Items.Add(new ListViewItem(arrData));
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (FolderList.SelectedItems.Count == 0 || MessageBox.Show("선택한 모델을 삭제하시겠습니까?", "확인", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            string strName = FolderList.SelectedItems[0].SubItems[1].Text;
            string strPath = UcDefine.ModelListPath + $"\\{strName}";

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

            INIFiles.Set_INI_Path(UcDefine.ListINIPath);

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
        }

        private void BtnPMAlignToolLoad_Click(object sender, EventArgs e)
        {
            _FormToolPattern?.Dispose();
            _FormToolCaliper?.Dispose();

            ToolPattern.SetupDisplay = cogDisplaySetup;
            ToolPattern.InputImage = cogDisplaySetup.Image;

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
            string iniPath = UcDefine.ModelListPath + $"\\{strSelectedName}\\PMAlign.ini";

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
                toolName = INIFiles.ReadValue(UcDefine.strPMAlign + (i + 1), "Name");

                if (!string.IsNullOrEmpty(toolName))
                {
                    ToolListLoad(toolName);
                }
            }

            txtToolName.Text = UcDefine.strPMAlign;
        }

        private void BtnCaliperToolLoad_Click(object sender, EventArgs e)
        {
            _FormToolPattern?.Dispose();
            _FormToolCaliper?.Dispose();

            ToolCaliper.SetupDisplay = cogDisplaySetup;
            ToolCaliper.InputImage = cogDisplaySetup.Image;

            _FormToolCaliper = new FormToolCaliper
            {
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            ToolPanel.Controls.Add(_FormToolCaliper);
            _FormToolCaliper.Show();

            ModelToolList.Items.Clear();
            string iniPath = UcDefine.ModelListPath + $"\\{strSelectedName}\\Caliper.ini";

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

            txtToolName.Text = UcDefine.strCaliper;
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
            if (txtToolName.Text == UcDefine.strPMAlign)
                ToolPattern.InputImage = cogDisplaySetup.Image;
            else if (txtToolName.Text == UcDefine.strCaliper)
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

            string imgPath = UcDefine.ModelListPath + $"\\{strSelectedName}\\MasterImage.bmp";
            selectedIndex = -1;
            if (ModelToolList.SelectedItems.Count > 0)
            {
                selectedIndex = ModelToolList.SelectedIndices[0];
            }

            if (File.Exists(imgPath))
            {
                cogDisplaySetup.Image = ImageManager.Load_ImageFile(imgPath);

                if (txtToolName.Text == UcDefine.strPMAlign)
                    ToolPattern.InputImage = cogDisplaySetup.Image;
                else if (txtToolName.Text == UcDefine.strCaliper)
                    ToolCaliper.InputImage = cogDisplaySetup.Image;
            }

            if (selectedIndex != -1)
            {
                if (txtToolName.Text == UcDefine.strPMAlign)
                    _FormToolPattern.LoadParam(Convert.ToInt16(selectedIndex));
                else if (txtToolName.Text == UcDefine.strCaliper)
                {
                    if (File.Exists(UcDefine.ModelListPath + "\\" + strSelectedName + "\\Caliper.ini"))
                    {
                        _FormToolCaliper.LoadParam(Convert.ToInt16(selectedIndex));
                    }
                }
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
            string strPath = UcDefine.ModelListPath + $"\\{txtSelectName.Text}";

            INIFiles.Set_INI_Path(strPath + $"\\{strToolName}.ini");

            int toolTotal = Convert.ToInt16(INIFiles.ReadValue("COMMON", "Total"));
            INIFiles.WriteValue("COMMON", "Total", $"{toolTotal - 1}");

            if (strToolName == UcDefine.strPMAlign)
            {
                string toolPMAlignName = INIFiles.ReadValue($"{UcDefine.strPMAlign}{selectedIndex + 1}", "Name");
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
                            string tempValue = INIFiles.ReadValue($"{UcDefine.strPMAlign}{i + 2}", key);
                            INIFiles.WriteValue($"{UcDefine.strPMAlign}{i + 1}", key, tempValue);
                        }
                    }
                }

                INIFiles.WriteValue($"TRAIN_REGION_RECTANGLE{toolTotal}", null, null);
                INIFiles.WriteValue($"SERACH_REGION_RECT{toolTotal}", null, null);
                INIFiles.WriteValue($"{UcDefine.strPMAlign}{toolTotal}", null, null);

                File.Delete($"{strPath}\\Mask_{ModelToolList.SelectedItems[0].Text}.bmp");

                INIFiles.Set_INI_Path(strPath + "\\ToolParam.ini");

                int toolParamTotal = Convert.ToInt16(INIFiles.ReadValue("COMMON", "Total"));
                int index = -1;

                for (int i = 0; i < toolParamTotal; i++)
                {
                    string strName = INIFiles.ReadValue($"{i + 1}", "Name");
                    if (strName == toolPMAlignName)
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
            else if (strToolName == UcDefine.strCaliper)
            {
                string toolCaliperName = INIFiles.ReadValue($"{UcDefine.strCaliper}{selectedIndex + 1}", "Name");
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
                    if (strName == toolCaliperName)
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