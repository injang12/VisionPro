using System.IO;
using System.Windows.Forms;
using System;

using INIFileManager;

using Cognex.VisionPro;

namespace VisionProTest
{
    internal class ToolSaveManager
    {
        private static CogRectangleAffine SearchRegion_Rect = new CogRectangleAffine();
        private static CogRectangleAffine TrainRegion_Rect = new CogRectangleAffine();

        private string threshold;
        private string angleLow;
        private string angleHigh;
        private string scaleLow;
        private string scaleHigh;
        private string approx;
        private string isHighSensitivity;
        private string polarity;
        private string polarity2;
        private string filterSize;
        private string edgePairWidth;

        private static string selectModelName;

        public void SetSearchRegion(CogRectangleAffine _searchRegion)
        {
            SearchRegion_Rect = _searchRegion;
        }

        public void SetTrainRegion(CogRectangleAffine _trainRegion)
        {
            TrainRegion_Rect = _trainRegion;
        }

        public void SetThreshold(string _threshold)
        {
            threshold = _threshold;
        }

        public void SetAngleLow(string _angleLow)
        {
            angleLow = _angleLow;
        }

        public void SetAngleHigh(string _angleHigh)
        {
            angleHigh = _angleHigh;
        }

        public void SetScaleLow(string _scaleLow)
        {
            scaleLow = _scaleLow;
        }

        public void SetScaleHigh(string _scaleHigh)
        {
            scaleHigh = _scaleHigh;
        }

        public void SetApprox(string _approx)
        {
            approx = _approx;
        }

        public void SetIsHighSensitivity(string _isHighSensitivity)
        {
            isHighSensitivity = _isHighSensitivity;
        }

        public void SetEdge1Polarity(string _polarity)
        {
            polarity = _polarity;
        }

        public void SetEdge2Polarity(string _polarity)
        {
            polarity2 = _polarity;
        }

        public void SetFilterSize(string _filterSize)
        {
            filterSize = _filterSize;
        }

        public void SetEdgePairWidth(string _edgePairWidth)
        {
            edgePairWidth = _edgePairWidth;
        }

        public void ToolParamSave(string path, string toolName, string name)
        {
            INIFiles _INIFiles = new INIFiles();

            _INIFiles.Set_INI_Path(path + "ToolParam.ini");

            if (!File.Exists(path + "ToolParam.ini"))
            {
                using (File.Create(path + "ToolParam.ini"))
                {
                }
                _INIFiles.WriteValue("COMMON", "Total", "0");
            }

            int toolCount = Convert.ToInt16(_INIFiles.ReadValue("COMMON", "Total"));

            toolCount++;
            _INIFiles.WriteValue("COMMON", "Total", toolCount.ToString());
            _INIFiles.WriteValue($"{toolCount}", "Tool", $"{toolName}");
            _INIFiles.WriteValue($"{toolCount}", "Name", $"{name}");
        }

        public void SelectModel(string _modelName)
        {
            selectModelName = _modelName;
        }

        public void SaveParam(string toolName, int _tool, string _type = null)
        {
            INIFiles _INIFiles = new INIFiles();

            int total = 0;
            int index = 0;
            bool isOverlap = false;

            switch (_tool)
            {
                case UcDefine.PMAlign:
                    string patternPath = Application.StartupPath + $"\\CONFIG\\ModelList\\{selectModelName}";
                    
                    if (!Directory.Exists(patternPath))
                        Directory.CreateDirectory(patternPath);

                    if (!File.Exists(patternPath + "\\PMAlign.ini"))
                    {
                        using (FileStream fs = File.Create(patternPath + "\\PMAlign.ini"))
                        {
                            // 파일 스트림을 열고 사용한 후에 닫습니다.
                        }
                        _INIFiles.Set_INI_Path($"{patternPath}\\PMAlign.ini");

                        _INIFiles.WriteValue("COMMON", "Total", "0");
                    }
                    else
                    {
                        _INIFiles.Set_INI_Path($"{patternPath}\\PMAlign.ini");
                        total = Convert.ToInt16(_INIFiles.ReadValue("COMMON", "Total"));
                    }

                    for (int i = 0; i < total; i++)
                    {
                        string strName = _INIFiles.ReadValue($"PATTERN{i + 1}", "Name");

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
                            _INIFiles.WriteValue("COMMON", "Total", Convert.ToString(total));

                            _INIFiles.WriteValue("TRAIN_REGION_RECTANGLE" + total, "CenterX", Convert.ToString(TrainRegion_Rect.CenterX));
                            _INIFiles.WriteValue("TRAIN_REGION_RECTANGLE" + total, "CenterY", Convert.ToString(TrainRegion_Rect.CenterY));
                            _INIFiles.WriteValue("TRAIN_REGION_RECTANGLE" + total, "Width", Convert.ToString(TrainRegion_Rect.SideXLength));
                            _INIFiles.WriteValue("TRAIN_REGION_RECTANGLE" + total, "Height", Convert.ToString(TrainRegion_Rect.SideYLength));
                            _INIFiles.WriteValue("TRAIN_REGION_RECTANGLE" + total, "Rotation", Convert.ToString(TrainRegion_Rect.Rotation));

                            _INIFiles.WriteValue("SERACH_REGION_RECT" + total, "CenterX", Convert.ToString(SearchRegion_Rect.CenterX));
                            _INIFiles.WriteValue("SERACH_REGION_RECT" + total, "CenterY", Convert.ToString(SearchRegion_Rect.CenterY));
                            _INIFiles.WriteValue("SERACH_REGION_RECT" + total, "Width", Convert.ToString(SearchRegion_Rect.SideXLength));
                            _INIFiles.WriteValue("SERACH_REGION_RECT" + total, "Height", Convert.ToString(SearchRegion_Rect.SideYLength));
                            _INIFiles.WriteValue("SERACH_REGION_RECT" + total, "Rotation", Convert.ToString(SearchRegion_Rect.Rotation));

                            _INIFiles.WriteValue("PATTERN" + total, "Name", Convert.ToString(toolName));
                            _INIFiles.WriteValue("PATTERN" + total, "HighSensitivity", Convert.ToString(isHighSensitivity));
                            _INIFiles.WriteValue("PATTERN" + total, "Accept_Threshold", threshold);
                            _INIFiles.WriteValue("PATTERN" + total, "AngleLow", angleLow);
                            _INIFiles.WriteValue("PATTERN" + total, "AngleHigh", angleHigh);
                            _INIFiles.WriteValue("PATTERN" + total, "ScaleLow", scaleLow);
                            _INIFiles.WriteValue("PATTERN" + total, "ScaleHigh", scaleHigh);
                            _INIFiles.WriteValue("PATTERN" + total, "Approx", approx);
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("기존 패턴과 이름이 같습니다 덮어쓰시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            _INIFiles.WriteValue("TRAIN_REGION_RECTANGLE" + index, "CenterX", Convert.ToString(TrainRegion_Rect.CenterX));
                            _INIFiles.WriteValue("TRAIN_REGION_RECTANGLE" + index, "CenterY", Convert.ToString(TrainRegion_Rect.CenterY));
                            _INIFiles.WriteValue("TRAIN_REGION_RECTANGLE" + index, "Width", Convert.ToString(TrainRegion_Rect.SideXLength));
                            _INIFiles.WriteValue("TRAIN_REGION_RECTANGLE" + index, "Height", Convert.ToString(TrainRegion_Rect.SideYLength));
                            _INIFiles.WriteValue("TRAIN_REGION_RECTANGLE" + index, "Rotation", Convert.ToString(TrainRegion_Rect.Rotation));

                            _INIFiles.WriteValue("SERACH_REGION_RECT" + index, "CenterX", Convert.ToString(SearchRegion_Rect.CenterX));
                            _INIFiles.WriteValue("SERACH_REGION_RECT" + index, "CenterY", Convert.ToString(SearchRegion_Rect.CenterY));
                            _INIFiles.WriteValue("SERACH_REGION_RECT" + index, "Width", Convert.ToString(SearchRegion_Rect.SideXLength));
                            _INIFiles.WriteValue("SERACH_REGION_RECT" + index, "Height", Convert.ToString(SearchRegion_Rect.SideYLength));
                            _INIFiles.WriteValue("SERACH_REGION_RECT" + index, "Rotation", Convert.ToString(SearchRegion_Rect.Rotation));

                            _INIFiles.WriteValue("PATTERN" + index, "HighSensitivity", Convert.ToString(isHighSensitivity));
                            _INIFiles.WriteValue("PATTERN" + index, "Threshold", threshold);
                            _INIFiles.WriteValue("PATTERN" + index, "AngleLow", angleLow);
                            _INIFiles.WriteValue("PATTERN" + index, "AngleHigh", angleHigh);
                            _INIFiles.WriteValue("PATTERN" + index, "ScaleLow", scaleLow);
                            _INIFiles.WriteValue("PATTERN" + index, "ScaleHigh", scaleHigh);
                            _INIFiles.WriteValue("PATTERN" + index, "Approx", approx);
                        }
                    }
                    break;
                case UcDefine.Caliper:
                    string caliperPath = Application.StartupPath + $"\\CONFIG\\ModelList\\{selectModelName}";

                    if (!Directory.Exists(caliperPath))
                        Directory.CreateDirectory(caliperPath);

                    if (!File.Exists(caliperPath + "\\Caliper.ini"))
                    {
                        using (FileStream fs = File.Create(caliperPath + "\\Caliper.ini"))
                        {
                            // 파일 스트림을 열고 사용한 후에 닫습니다.
                        }
                        _INIFiles.Set_INI_Path($"{caliperPath}\\Caliper.ini");

                        _INIFiles.WriteValue("COMMON", "Total", "0");
                    }
                    else
                    {
                        _INIFiles.Set_INI_Path($"{caliperPath}\\Caliper.ini");
                        total = Convert.ToInt16(_INIFiles.ReadValue("COMMON", "Total"));
                    }

                    for (int i = 0; i < total; i++)
                    {
                        if (_INIFiles.ReadValue($"CALIPER{i + 1}", "Name") == toolName)
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
                            _INIFiles.Set_INI_Path($"{caliperPath}\\Caliper.ini");
                            _INIFiles.WriteValue("COMMON", "Total", Convert.ToString(total));
                            _INIFiles.WriteValue($"MODE{total}", "Type", _type);

                            _INIFiles.WriteValue($"SERACH_REGION_RECT{total}", "CenterX", Convert.ToString(SearchRegion_Rect.CenterX));
                            _INIFiles.WriteValue($"SERACH_REGION_RECT{total}", "CenterY", Convert.ToString(SearchRegion_Rect.CenterY));
                            _INIFiles.WriteValue($"SERACH_REGION_RECT{total}", "Width", Convert.ToString(SearchRegion_Rect.SideXLength));
                            _INIFiles.WriteValue($"SERACH_REGION_RECT{total}", "Height", Convert.ToString(SearchRegion_Rect.SideYLength));
                            _INIFiles.WriteValue($"SERACH_REGION_RECT{total}", "Rotation", Convert.ToString(SearchRegion_Rect.Rotation));

                            _INIFiles.WriteValue($"Edge1_{total}", "Polarity", polarity);
                            _INIFiles.WriteValue($"Edge2_{total}", "Polarity", polarity2);

                            _INIFiles.WriteValue($"CALIPER{total}", "Name", toolName);
                            _INIFiles.WriteValue($"CALIPER{total}", "Threshold", threshold);
                            _INIFiles.WriteValue($"CALIPER{total}", "FilterSize", filterSize);
                            _INIFiles.WriteValue($"CALIPER{total}", "Edge Pair Width", edgePairWidth);
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("기존 캘리퍼 이름이 같습니다 덮어쓰시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            _INIFiles.Set_INI_Path($"{caliperPath}\\Caliper.ini");
                            _INIFiles.WriteValue($"MODE{total}", "Type", _type);

                            _INIFiles.WriteValue($"SERACH_REGION_RECT{index}", "CenterX", Convert.ToString(SearchRegion_Rect.CenterX));
                            _INIFiles.WriteValue($"SERACH_REGION_RECT{index}", "CenterY", Convert.ToString(SearchRegion_Rect.CenterY));
                            _INIFiles.WriteValue($"SERACH_REGION_RECT{index}", "Width", Convert.ToString(SearchRegion_Rect.SideXLength));
                            _INIFiles.WriteValue($"SERACH_REGION_RECT{index}", "Height", Convert.ToString(SearchRegion_Rect.SideYLength));
                            _INIFiles.WriteValue($"SERACH_REGION_RECT{index}", "Rotation", Convert.ToString(SearchRegion_Rect.Rotation));

                            _INIFiles.WriteValue($"Edge1_{index}", "Polarity", polarity);
                            _INIFiles.WriteValue($"Edge2_{index}", "Polarity", polarity2);

                            _INIFiles.WriteValue($"CALIPER{index}", "Threshold", threshold);
                            _INIFiles.WriteValue($"CALIPER{index}", "FilterSize", filterSize);
                            _INIFiles.WriteValue($"CALIPER{index}", "Edge Pair Width", edgePairWidth);
                        }
                    }
                    break;
            }
        }
    }
}