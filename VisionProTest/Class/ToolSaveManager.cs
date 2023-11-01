using System.IO;
using System.Windows.Forms;
using System;

using INIFileManager;

using Cognex.VisionPro;

namespace VisionProTest
{
    internal class ToolSaveManager
    {
        public static CogRectangleAffine SearchRegion_Rect { get; set; } = new CogRectangleAffine();
        public static CogRectangleAffine TrainRegion_Rect { get; set; } = new CogRectangleAffine();

        public static string Threshold { get; set; }
        public static string AngleLow { get; set; }
        public static string AngleHigh { get; set; }
        public static string ScaleLow { get; set; }
        public static string ScaleHigh { get; set; }
        public static string Approx { get; set; }
        public static string IsHighSensitivity { get; set; }
        public static string Polarity { get; set; }
        public static string Polarity2 { get; set; }
        public static string FilterSize { get; set; }
        public static string EdgePairWidth { get; set; }

        private static int total = 0;
        private readonly static int index = 0;
        private readonly static bool isOverlap = false;

        public static void ToolParamSave(string path, string toolName, string name)
        {
            INIFiles.Set_INI_Path(path + "ToolParam.ini");

            if (!File.Exists(path + "ToolParam.ini"))
            {
                using (File.Create(path + "ToolParam.ini"))
                {
                }
                INIFiles.WriteValue("COMMON", "Total", "0");
            }

            int toolCount = Convert.ToInt16(INIFiles.ReadValue("COMMON", "Total"));

            toolCount++;
            INIFiles.WriteValue("COMMON", "Total", toolCount.ToString());
            INIFiles.WriteValue($"{toolCount}", "Tool", $"{toolName}");
            INIFiles.WriteValue($"{toolCount}", "Name", $"{name}");
        }

        public static void SaveTrainRegion(CogRectangleAffine trainRegion, int value)
        {
            INIFiles.WriteValue($"TRAIN_REGION_RECTANGLE{value}", "CenterX", Convert.ToString(trainRegion.CenterX));
            INIFiles.WriteValue($"TRAIN_REGION_RECTANGLE{value}", "CenterY", Convert.ToString(trainRegion.CenterY));
            INIFiles.WriteValue($"TRAIN_REGION_RECTANGLE{value}", "Width", Convert.ToString(trainRegion.SideXLength));
            INIFiles.WriteValue($"TRAIN_REGION_RECTANGLE{value}", "Height", Convert.ToString(trainRegion.SideYLength));
            INIFiles.WriteValue($"TRAIN_REGION_RECTANGLE{value}", "Rotation", Convert.ToString(trainRegion.Rotation));
        }

        public static void SaveSearchRegion(CogRectangleAffine searchRegion, int value)
        {
            INIFiles.WriteValue($"SERACH_REGION_RECT{value}", "CenterX", Convert.ToString(searchRegion.CenterX));
            INIFiles.WriteValue($"SERACH_REGION_RECT{value}", "CenterY", Convert.ToString(searchRegion.CenterY));
            INIFiles.WriteValue($"SERACH_REGION_RECT{value}", "Width", Convert.ToString(searchRegion.SideXLength));
            INIFiles.WriteValue($"SERACH_REGION_RECT{value}", "Height", Convert.ToString(searchRegion.SideYLength));
            INIFiles.WriteValue($"SERACH_REGION_RECT{value}", "Rotation", Convert.ToString(searchRegion.Rotation));
        }

        public static void SaveToolName(string name, int value)
        {
            INIFiles.WriteValue($"PMAlign{value}", "Name", Convert.ToString(name));
        }

        public static void SaveHighSensitivity(string highSensitivity,  int value)
        {
            INIFiles.WriteValue($"PMAlign{value}", "HighSensitivity", Convert.ToString(highSensitivity));
        }

        public static void SaveThreshold(string toolName, string threshold, int value)
        {
            INIFiles.WriteValue($"{toolName}{value}", "Threshold", threshold);
        }

        public static void SaveAngleLow(string angleLow, int value)
        {
            INIFiles.WriteValue($"PMAlign{value}", "AngleLow", angleLow);
        }

        public static void SaveAngleHigh(string angleHigh, int value)
        {
            INIFiles.WriteValue($"PMAlign{value}", "AngleHigh", angleHigh);
        }

        public static void SaveScaleLow(string scaleLow, int value)
        {
            INIFiles.WriteValue($"PMAlign{value}", "ScaleLow", scaleLow);
        }

        public static void SaveScaleHigh(string scaleHigh, int value)
        {
            INIFiles.WriteValue($"PMAlign{value}", "ScaleHigh", scaleHigh);
        }

        public static void SaveApprox(string approx, int value)
        {
            INIFiles.WriteValue($"PMAlign{value}", "Approx", approx);
        }

        public static void SaveParam(string toolName, int _tool, string Type = null)
        {
            switch (_tool)
            {
                case UcDefine.PMAlign:
                    //FileExistsAndCreate(UcDefine.strPMAlign);

                    //if (!isOverlap)
                    //{
                    //    if (MessageBox.Show("패턴을 새로 추가 하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    //    {
                    //        total++;
                    //        INIFiles.WriteValue("COMMON", "Total", Convert.ToString(total));

                    //        PMAlignSaveData(total);
                    //    }
                    //}
                    //else
                    //{
                    //    if (MessageBox.Show("기존 패턴과 이름이 같습니다 덮어쓰시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    //        PMAlignSaveData(index);
                    //}

                    //void PMAlignSaveData(int index)
                    //{
                    //    INIFiles.WriteValue($"TRAIN_REGION_RECTANGLE{index}", "CenterX", Convert.ToString(TrainRegion_Rect.CenterX));
                    //    INIFiles.WriteValue($"TRAIN_REGION_RECTANGLE{index}", "CenterY", Convert.ToString(TrainRegion_Rect.CenterY));
                    //    INIFiles.WriteValue($"TRAIN_REGION_RECTANGLE{index}", "Width", Convert.ToString(TrainRegion_Rect.SideXLength));
                    //    INIFiles.WriteValue($"TRAIN_REGION_RECTANGLE{index}", "Height", Convert.ToString(TrainRegion_Rect.SideYLength));
                    //    INIFiles.WriteValue($"TRAIN_REGION_RECTANGLE{index}", "Rotation", Convert.ToString(TrainRegion_Rect.Rotation));

                    //    INIFiles.WriteValue($"SERACH_REGION_RECT{index}", "CenterX", Convert.ToString(SearchRegion_Rect.CenterX));
                    //    INIFiles.WriteValue($"SERACH_REGION_RECT{index}", "CenterY", Convert.ToString(SearchRegion_Rect.CenterY));
                    //    INIFiles.WriteValue($"SERACH_REGION_RECT{index}", "Width", Convert.ToString(SearchRegion_Rect.SideXLength));
                    //    INIFiles.WriteValue($"SERACH_REGION_RECT{index}", "Height", Convert.ToString(SearchRegion_Rect.SideYLength));
                    //    INIFiles.WriteValue($"SERACH_REGION_RECT{index}", "Rotation", Convert.ToString(SearchRegion_Rect.Rotation));

                    //    INIFiles.WriteValue($"PMAlign{index}", "Name", Convert.ToString(toolName));
                    //    INIFiles.WriteValue($"PMAlign{index}", "HighSensitivity", Convert.ToString(IsHighSensitivity));
                    //    INIFiles.WriteValue($"PMAlign{index}", "Accept_Threshold", Threshold);
                    //    INIFiles.WriteValue($"PMAlign{index}", "AngleLow", AngleLow);
                    //    INIFiles.WriteValue($"PMAlign{index}", "AngleHigh", AngleHigh);
                    //    INIFiles.WriteValue($"PMAlign{index}", "ScaleLow", ScaleLow);
                    //    INIFiles.WriteValue($"PMAlign{index}", "ScaleHigh", ScaleHigh);
                    //    INIFiles.WriteValue($"PMAlign{index}", "Approx", Approx);
                    //}
                    break;
                case UcDefine.Caliper:
                    //FileExistsAndCreate(UcDefine.strCaliper);

                    if (!isOverlap)
                    {
                        if (MessageBox.Show("캘리퍼을 새로 추가 하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            total++;
                            INIFiles.WriteValue("COMMON", "Total", Convert.ToString(total));

                            CaliperSaveData(total);
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("기존 캘리퍼 이름이 같습니다 덮어쓰시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            CaliperSaveData(index);
                    }

                    void CaliperSaveData(int index)
                    {
                        INIFiles.WriteValue($"MODE{index}", "Type", Type);

                        INIFiles.WriteValue($"SERACH_REGION_RECT{index}", "CenterX", Convert.ToString(SearchRegion_Rect.CenterX));
                        INIFiles.WriteValue($"SERACH_REGION_RECT{index}", "CenterY", Convert.ToString(SearchRegion_Rect.CenterY));
                        INIFiles.WriteValue($"SERACH_REGION_RECT{index}", "Width", Convert.ToString(SearchRegion_Rect.SideXLength));
                        INIFiles.WriteValue($"SERACH_REGION_RECT{index}", "Height", Convert.ToString(SearchRegion_Rect.SideYLength));
                        INIFiles.WriteValue($"SERACH_REGION_RECT{index}", "Rotation", Convert.ToString(SearchRegion_Rect.Rotation));

                        INIFiles.WriteValue($"Edge1_{index}", "Polarity", Polarity);
                        INIFiles.WriteValue($"Edge2_{index}", "Polarity", Polarity2);

                        INIFiles.WriteValue($"Caliper{index}", "Name", toolName);
                        INIFiles.WriteValue($"Caliper{index}", "Threshold", Threshold);
                        INIFiles.WriteValue($"Caliper{index}", "FilterSize", FilterSize);
                        INIFiles.WriteValue($"Caliper{index}", "Edge Pair Width", EdgePairWidth);
                    }
                    break;
            }
        }

        //private static void FileExistsAndCreate(string toolName)
        //{
        //    string ModelPath = $"{UcDefine.ModelListPath + FormSetup.strSelectedName}\\";

        //    if (!Directory.Exists(ModelPath))
        //        Directory.CreateDirectory(ModelPath);

        //    ModelPath += toolName + ".ini";

        //    if (!File.Exists(ModelPath))
        //    {
        //        using (FileStream fs = File.Create(ModelPath))
        //        {
        //        }
        //        INIFiles.Set_INI_Path(ModelPath);

        //        INIFiles.WriteValue("COMMON", "Total", "0");
        //    }
        //    else
        //    {
        //        INIFiles.Set_INI_Path(ModelPath);
        //        total = Convert.ToInt16(INIFiles.ReadValue("COMMON", "Total"));
        //    }

        //    for (int i = 0; i < total; i++)
        //    {
        //        if (INIFiles.ReadValue($"{toolName + i + 1}", "Name") == toolName)
        //        {
        //            isOverlap = true;
        //            index = i + 1;
        //            break;
        //        }
        //    }
        //}
    }
}