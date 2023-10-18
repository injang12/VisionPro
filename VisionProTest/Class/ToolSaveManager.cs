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
        public static string ModelName { get; set; }

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

        public static void SaveParam(string toolName, int _tool, string _type = null)
        {
            int total = 0;
            int index = 0;
            bool isOverlap = false;

            switch (_tool)
            {
                case UcDefine.PMAlign:
                    string patternPath = Application.StartupPath + $"\\CONFIG\\ModelList\\{ModelName}";
                    
                    if (!Directory.Exists(patternPath))
                        Directory.CreateDirectory(patternPath);

                    if (!File.Exists(patternPath + "\\PMAlign.ini"))
                    {
                        using (FileStream fs = File.Create(patternPath + "\\PMAlign.ini"))
                        {
                            // 파일 스트림을 열고 사용한 후에 닫습니다.
                        }
                        INIFiles.Set_INI_Path($"{patternPath}\\PMAlign.ini");

                        INIFiles.WriteValue("COMMON", "Total", "0");
                    }
                    else
                    {
                        INIFiles.Set_INI_Path($"{patternPath}\\PMAlign.ini");
                        total = Convert.ToInt16(INIFiles.ReadValue("COMMON", "Total"));
                    }

                    for (int i = 0; i < total; i++)
                    {
                        string strName = INIFiles.ReadValue($"PATTERN{i + 1}", "Name");

                        if (strName == toolName)
                        {
                            isOverlap = true;
                            index = i + 1;
                            break;
                        }
                    }

                    if (!isOverlap)
                    {
                        if (MessageBox.Show("패턴을 새로 추가 하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            total++;
                            INIFiles.WriteValue("COMMON", "Total", Convert.ToString(total));

                            INIFiles.WriteValue("TRAIN_REGION_RECTANGLE" + total, "CenterX", Convert.ToString(TrainRegion_Rect.CenterX));
                            INIFiles.WriteValue("TRAIN_REGION_RECTANGLE" + total, "CenterY", Convert.ToString(TrainRegion_Rect.CenterY));
                            INIFiles.WriteValue("TRAIN_REGION_RECTANGLE" + total, "Width", Convert.ToString(TrainRegion_Rect.SideXLength));
                            INIFiles.WriteValue("TRAIN_REGION_RECTANGLE" + total, "Height", Convert.ToString(TrainRegion_Rect.SideYLength));
                            INIFiles.WriteValue("TRAIN_REGION_RECTANGLE" + total, "Rotation", Convert.ToString(TrainRegion_Rect.Rotation));

                            INIFiles.WriteValue("SERACH_REGION_RECT" + total, "CenterX", Convert.ToString(SearchRegion_Rect.CenterX));
                            INIFiles.WriteValue("SERACH_REGION_RECT" + total, "CenterY", Convert.ToString(SearchRegion_Rect.CenterY));
                            INIFiles.WriteValue("SERACH_REGION_RECT" + total, "Width", Convert.ToString(SearchRegion_Rect.SideXLength));
                            INIFiles.WriteValue("SERACH_REGION_RECT" + total, "Height", Convert.ToString(SearchRegion_Rect.SideYLength));
                            INIFiles.WriteValue("SERACH_REGION_RECT" + total, "Rotation", Convert.ToString(SearchRegion_Rect.Rotation));

                            INIFiles.WriteValue("PATTERN" + total, "Name", Convert.ToString(toolName));
                            INIFiles.WriteValue("PATTERN" + total, "HighSensitivity", Convert.ToString(IsHighSensitivity));
                            INIFiles.WriteValue("PATTERN" + total, "Accept_Threshold", Threshold);
                            INIFiles.WriteValue("PATTERN" + total, "AngleLow", AngleLow);
                            INIFiles.WriteValue("PATTERN" + total, "AngleHigh", AngleHigh);
                            INIFiles.WriteValue("PATTERN" + total, "ScaleLow", ScaleLow);
                            INIFiles.WriteValue("PATTERN" + total, "ScaleHigh", ScaleHigh);
                            INIFiles.WriteValue("PATTERN" + total, "Approx", Approx);
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("기존 패턴과 이름이 같습니다 덮어쓰시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            INIFiles.WriteValue("TRAIN_REGION_RECTANGLE" + index, "CenterX", Convert.ToString(TrainRegion_Rect.CenterX));
                            INIFiles.WriteValue("TRAIN_REGION_RECTANGLE" + index, "CenterY", Convert.ToString(TrainRegion_Rect.CenterY));
                            INIFiles.WriteValue("TRAIN_REGION_RECTANGLE" + index, "Width", Convert.ToString(TrainRegion_Rect.SideXLength));
                            INIFiles.WriteValue("TRAIN_REGION_RECTANGLE" + index, "Height", Convert.ToString(TrainRegion_Rect.SideYLength));
                            INIFiles.WriteValue("TRAIN_REGION_RECTANGLE" + index, "Rotation", Convert.ToString(TrainRegion_Rect.Rotation));

                            INIFiles.WriteValue("SERACH_REGION_RECT" + index, "CenterX", Convert.ToString(SearchRegion_Rect.CenterX));
                            INIFiles.WriteValue("SERACH_REGION_RECT" + index, "CenterY", Convert.ToString(SearchRegion_Rect.CenterY));
                            INIFiles.WriteValue("SERACH_REGION_RECT" + index, "Width", Convert.ToString(SearchRegion_Rect.SideXLength));
                            INIFiles.WriteValue("SERACH_REGION_RECT" + index, "Height", Convert.ToString(SearchRegion_Rect.SideYLength));
                            INIFiles.WriteValue("SERACH_REGION_RECT" + index, "Rotation", Convert.ToString(SearchRegion_Rect.Rotation));

                            INIFiles.WriteValue("PATTERN" + index, "HighSensitivity", Convert.ToString(IsHighSensitivity));
                            INIFiles.WriteValue("PATTERN" + index, "Threshold", Threshold);
                            INIFiles.WriteValue("PATTERN" + index, "AngleLow", AngleLow);
                            INIFiles.WriteValue("PATTERN" + index, "AngleHigh", AngleHigh);
                            INIFiles.WriteValue("PATTERN" + index, "ScaleLow", ScaleLow);
                            INIFiles.WriteValue("PATTERN" + index, "ScaleHigh", ScaleHigh);
                            INIFiles.WriteValue("PATTERN" + index, "Approx", Approx);
                        }
                    }
                    break;
                case UcDefine.Caliper:
                    string caliperPath = Application.StartupPath + $"\\CONFIG\\ModelList\\{ModelName}";

                    if (!Directory.Exists(caliperPath))
                        Directory.CreateDirectory(caliperPath);

                    if (!File.Exists(caliperPath + "\\Caliper.ini"))
                    {
                        using (FileStream fs = File.Create(caliperPath + "\\Caliper.ini"))
                        {
                            // 파일 스트림을 열고 사용한 후에 닫습니다.
                        }
                        INIFiles.Set_INI_Path($"{caliperPath}\\Caliper.ini");

                        INIFiles.WriteValue("COMMON", "Total", "0");
                    }
                    else
                    {
                        INIFiles.Set_INI_Path($"{caliperPath}\\Caliper.ini");
                        total = Convert.ToInt16(INIFiles.ReadValue("COMMON", "Total"));
                    }

                    for (int i = 0; i < total; i++)
                    {
                        if (INIFiles.ReadValue($"CALIPER{i + 1}", "Name") == toolName)
                        {
                            isOverlap = true;
                            index = i + 1;
                            break;
                        }
                    }

                    if (!isOverlap)
                    {
                        if (MessageBox.Show("캘리퍼을 새로 추가 하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            total++;
                            INIFiles.Set_INI_Path($"{caliperPath}\\Caliper.ini");
                            INIFiles.WriteValue("COMMON", "Total", Convert.ToString(total));
                            INIFiles.WriteValue($"MODE{total}", "Type", _type);

                            INIFiles.WriteValue($"SERACH_REGION_RECT{total}", "CenterX", Convert.ToString(SearchRegion_Rect.CenterX));
                            INIFiles.WriteValue($"SERACH_REGION_RECT{total}", "CenterY", Convert.ToString(SearchRegion_Rect.CenterY));
                            INIFiles.WriteValue($"SERACH_REGION_RECT{total}", "Width", Convert.ToString(SearchRegion_Rect.SideXLength));
                            INIFiles.WriteValue($"SERACH_REGION_RECT{total}", "Height", Convert.ToString(SearchRegion_Rect.SideYLength));
                            INIFiles.WriteValue($"SERACH_REGION_RECT{total}", "Rotation", Convert.ToString(SearchRegion_Rect.Rotation));

                            INIFiles.WriteValue($"Edge1_{total}", "Polarity", Polarity);
                            INIFiles.WriteValue($"Edge2_{total}", "Polarity", Polarity2);

                            INIFiles.WriteValue($"CALIPER{total}", "Name", toolName);
                            INIFiles.WriteValue($"CALIPER{total}", "Threshold", Threshold);
                            INIFiles.WriteValue($"CALIPER{total}", "FilterSize", FilterSize);
                            INIFiles.WriteValue($"CALIPER{total}", "Edge Pair Width", EdgePairWidth);
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("기존 캘리퍼 이름이 같습니다 덮어쓰시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            INIFiles.Set_INI_Path($"{caliperPath}\\Caliper.ini");
                            INIFiles.WriteValue($"MODE{total}", "Type", _type);

                            INIFiles.WriteValue($"SERACH_REGION_RECT{index}", "CenterX", Convert.ToString(SearchRegion_Rect.CenterX));
                            INIFiles.WriteValue($"SERACH_REGION_RECT{index}", "CenterY", Convert.ToString(SearchRegion_Rect.CenterY));
                            INIFiles.WriteValue($"SERACH_REGION_RECT{index}", "Width", Convert.ToString(SearchRegion_Rect.SideXLength));
                            INIFiles.WriteValue($"SERACH_REGION_RECT{index}", "Height", Convert.ToString(SearchRegion_Rect.SideYLength));
                            INIFiles.WriteValue($"SERACH_REGION_RECT{index}", "Rotation", Convert.ToString(SearchRegion_Rect.Rotation));

                            INIFiles.WriteValue($"Edge1_{index}", "Polarity", Polarity);
                            INIFiles.WriteValue($"Edge2_{index}", "Polarity", Polarity2);

                            INIFiles.WriteValue($"CALIPER{index}", "Threshold", Threshold);
                            INIFiles.WriteValue($"CALIPER{index}", "FilterSize", FilterSize);
                            INIFiles.WriteValue($"CALIPER{index}", "Edge Pair Width", EdgePairWidth);
                        }
                    }
                    break;
            }
        }
    }
}