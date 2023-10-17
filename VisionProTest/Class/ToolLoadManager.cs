using INIFileManager;

using System.IO;
using System;
using System.Windows.Forms;
using Cognex.VisionPro;

namespace VisionProTest
{
    internal class ToolLoadManager
    {
        private readonly static CogRectangleAffine SearchRegion_Rect = new CogRectangleAffine();
        private readonly static CogRectangleAffine TrainRegion_Rect = new CogRectangleAffine();

        private bool caliperMode;
        private int polarity;
        private static string toolName;

        private readonly string path = Application.StartupPath + "\\CONFIG\\ModelList\\";
        private static string INIPath;

        public void SetINIPath(int _tool)
        {
            switch (_tool) // tool 경로 하나로 통합하기
            {
                case UcDefine.PMAlign:
                    INIFiles.Set_INI_Path($"{INIPath}\\PMAlign.ini");
                    toolName = "PATTERN";
                    break;
                case UcDefine.Caliper:
                    INIFiles.Set_INI_Path($"{INIPath}\\Caliper.ini");
                    toolName = "CALIPER";
                    break;
            }
        }

        public CogRectangleAffine GetSearchRegion(int _index)
        {
            SearchRegion_Rect.CenterX = Convert.ToDouble(INIFiles.ReadValue($"SERACH_REGION_RECT{_index + 1}", "CenterX"));
            SearchRegion_Rect.CenterY = Convert.ToDouble(INIFiles.ReadValue($"SERACH_REGION_RECT{_index + 1}", "CenterY"));
            SearchRegion_Rect.SideXLength = Convert.ToDouble(INIFiles.ReadValue($"SERACH_REGION_RECT{_index + 1}", "Width"));
            SearchRegion_Rect.SideYLength = Convert.ToDouble(INIFiles.ReadValue($"SERACH_REGION_RECT{_index + 1}", "Height"));
            SearchRegion_Rect.Rotation = Convert.ToDouble(INIFiles.ReadValue($"SERACH_REGION_RECT{_index + 1}", "Rotation"));

            return SearchRegion_Rect;
        }

        public CogRectangleAffine GetTrainRegion(int _index)
        {
            TrainRegion_Rect.CenterX = Convert.ToDouble(INIFiles.ReadValue($"TRAIN_REGION_RECTANGLE{_index + 1}", "CenterX"));
            TrainRegion_Rect.CenterY = Convert.ToDouble(INIFiles.ReadValue($"TRAIN_REGION_RECTANGLE{_index + 1}", "CenterY"));
            TrainRegion_Rect.SideXLength = Convert.ToDouble(INIFiles.ReadValue($"TRAIN_REGION_RECTANGLE{_index + 1}", "Width"));
            TrainRegion_Rect.SideYLength = Convert.ToDouble(INIFiles.ReadValue($"TRAIN_REGION_RECTANGLE{_index + 1}", "Height"));
            TrainRegion_Rect.Rotation = Convert.ToDouble(INIFiles.ReadValue($"TRAIN_REGION_RECTANGLE{_index + 1}", "Rotation"));

            return TrainRegion_Rect;
        }

        public string GetThreshold(int _index)
        {
            return INIFiles.GetParam($"{toolName}{_index + 1}", "Threshold", "0.5");
        }

        public string GetAngleLow(int _index)
        {
            return INIFiles.GetParam($"{toolName}{_index + 1}", "AngleLow", "0");
        }

        public string GetAngleHigh(int _index)
        {
            return INIFiles.GetParam($"{toolName}{_index + 1}", "AngleHigh", "0");
        }

        public string GetScaleLow(int _index)
        {
            return INIFiles.GetParam($"{toolName}{_index + 1}", "ScaleLow", "1");
        }

        public string GetScaleHigh(int _index)
        {
            return INIFiles.GetParam($"{toolName}{_index + 1}", "ScaleHigh", "1");
        }

        public string GetApprox(int _index)
        {
            return INIFiles.GetParam($"{toolName}{_index + 1}", "Approx", "1");
        }

        public bool GetIsHighSensitivity(int _index)
        {
            return Convert.ToBoolean(INIFiles.GetParam($"{toolName}{_index + 1}", "HighSensitivity", "False"));
        }

        public string GetModelToolName(int _index)
        {
            return INIFiles.ReadValue($"{toolName}{_index + 1}", "Name");
        }

        public bool GetMode(int _index)
        {
            switch (INIFiles.ReadValue($"MODE{_index + 1}", "Type"))
            {
                case "Single":
                    caliperMode = false;
                    break;
                default:
                    caliperMode = true;
                    break;
            }

            return caliperMode;
        }

        public int GetEdge1Polarity(int _index)
        {
            switch (INIFiles.ReadValue($"Edge1_{_index + 1}", "Polarity"))
            {
                case "Dark to Light":
                    polarity = 0;
                    break;
                case "Light to Dark":
                    polarity = 1;
                    break;
                default:
                    polarity = 2;
                    break;
            }

            return polarity;
        }

        public int GetEdge2Polarity(int _index)
        {
            switch (INIFiles.ReadValue($"Edge2_{_index + 1}", "Polarity"))
            {
                case "Dark to Light":
                    polarity = 0;
                    break;
                case "Light to Dark":
                    polarity = 1;
                    break;
                default:
                    polarity = 2;
                    break;
            }

            return polarity;
        }

        public string GetFilterSize(int _index)
        {
            return INIFiles.ReadValue($"CALIPER{_index + 1}", "FilterSize");
        }

        public string GetEdgePairWidth(int _index)
        {
            return INIFiles.ReadValue($"CALIPER{_index + 1}", "Edge Pair Width");
        }

        public void SelectModel(string selectModel)
        {
            INIPath = Path.Combine(path, selectModel);
        }
    }
}