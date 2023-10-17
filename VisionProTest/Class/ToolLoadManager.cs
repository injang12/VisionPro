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

        private static string toolName;

        private readonly string path = Application.StartupPath + "\\CONFIG\\ModelList\\";
        private static string INIPath;

        public static void SetINIPath(int _tool)
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

        public static void GetSearchRegion(int _tool, int _index)
        {
            switch (_tool)
            {
                case 0:
                    FormToolPattern.SearchRegion_Rect.CenterX = Convert.ToDouble(INIFiles.ReadValue($"SERACH_REGION_RECT{_index + 1}", "CenterX"));
                    FormToolPattern.SearchRegion_Rect.CenterY = Convert.ToDouble(INIFiles.ReadValue($"SERACH_REGION_RECT{_index + 1}", "CenterY"));
                    FormToolPattern.SearchRegion_Rect.SideXLength = Convert.ToDouble(INIFiles.ReadValue($"SERACH_REGION_RECT{_index + 1}", "Width"));
                    FormToolPattern.SearchRegion_Rect.SideYLength = Convert.ToDouble(INIFiles.ReadValue($"SERACH_REGION_RECT{_index + 1}", "Height"));
                    FormToolPattern.SearchRegion_Rect.Rotation = Convert.ToDouble(INIFiles.ReadValue($"SERACH_REGION_RECT{_index + 1}", "Rotation"));
                    break;
                case 1:
                    FormToolCaliper.SearchRegion_Rect.CenterX = Convert.ToDouble(INIFiles.ReadValue($"SERACH_REGION_RECT{_index + 1}", "CenterX"));
                    FormToolCaliper.SearchRegion_Rect.CenterY = Convert.ToDouble(INIFiles.ReadValue($"SERACH_REGION_RECT{_index + 1}", "CenterY"));
                    FormToolCaliper.SearchRegion_Rect.SideXLength = Convert.ToDouble(INIFiles.ReadValue($"SERACH_REGION_RECT{_index + 1}", "Width"));
                    FormToolCaliper.SearchRegion_Rect.SideYLength = Convert.ToDouble(INIFiles.ReadValue($"SERACH_REGION_RECT{_index + 1}", "Height"));
                    FormToolCaliper.SearchRegion_Rect.Rotation = Convert.ToDouble(INIFiles.ReadValue($"SERACH_REGION_RECT{_index + 1}", "Rotation"));
                    break;
            }
        }

        public static void GetTrainRegion(int _index)
        {
            FormToolPattern.TrainRegion_Rect.CenterX = Convert.ToDouble(INIFiles.ReadValue($"TRAIN_REGION_RECTANGLE{_index + 1}", "CenterX"));
            FormToolPattern.TrainRegion_Rect.CenterY = Convert.ToDouble(INIFiles.ReadValue($"TRAIN_REGION_RECTANGLE{_index + 1}", "CenterY"));
            FormToolPattern.TrainRegion_Rect.SideXLength = Convert.ToDouble(INIFiles.ReadValue($"TRAIN_REGION_RECTANGLE{_index + 1}", "Width"));
            FormToolPattern.TrainRegion_Rect.SideYLength = Convert.ToDouble(INIFiles.ReadValue($"TRAIN_REGION_RECTANGLE{_index + 1}", "Height"));
            FormToolPattern.TrainRegion_Rect.Rotation = Convert.ToDouble(INIFiles.ReadValue($"TRAIN_REGION_RECTANGLE{_index + 1}", "Rotation"));
        }

        public static string GetThreshold(int _index)
        {
            return INIFiles.GetParam($"{toolName}{_index + 1}", "Threshold", "0.5");
        }

        public static string GetAngleLow(int _index)
        {
            return INIFiles.GetParam($"{toolName}{_index + 1}", "AngleLow", "0");
        }

        public static string GetAngleHigh(int _index)
        {
            return INIFiles.GetParam($"{toolName}{_index + 1}", "AngleHigh", "0");
        }

        public static string GetScaleLow(int _index)
        {
            return INIFiles.GetParam($"{toolName}{_index + 1}", "ScaleLow", "1");
        }

        public static string GetScaleHigh(int _index)
        {
            return INIFiles.GetParam($"{toolName}{_index + 1}", "ScaleHigh", "1");
        }

        public static string GetApprox(int _index)
        {
            return INIFiles.GetParam($"{toolName}{_index + 1}", "Approx", "1");
        }

        public static bool GetIsHighSensitivity(int _index)
        {
            return Convert.ToBoolean(INIFiles.GetParam($"{toolName}{_index + 1}", "HighSensitivity", "False"));
        }

        public static string GetModelToolName(int _index)
        {
            return INIFiles.ReadValue($"{toolName}{_index + 1}", "Name");
        }

        public static bool GetMode(int _index)
        {
            if (INIFiles.ReadValue($"MODE{_index + 1}", "Type") == "Single")
                return false;
            else
                return true;
        }

        public static int GetEdge1Polarity(int _index)
        {
            switch (INIFiles.ReadValue($"Edge1_{_index + 1}", "Polarity"))
            {
                case "Dark to Light":
                    return 0;
                case "Light to Dark":
                    return 1;
                default:
                    return 2;
            }
        }

        public static int GetEdge2Polarity(int _index)
        {
            switch (INIFiles.ReadValue($"Edge2_{_index + 1}", "Polarity"))
            {
                case "Dark to Light":
                    return 0;
                case "Light to Dark":
                    return 1;
                default:
                    return 2;
            }
        }

        public static string GetFilterSize(int _index)
        {
            return INIFiles.ReadValue($"CALIPER{_index + 1}", "FilterSize");
        }

        public static string GetEdgePairWidth(int _index)
        {
            return INIFiles.ReadValue($"CALIPER{_index + 1}", "Edge Pair Width");
        }

        public void SelectModel(string selectModel)
        {
            INIPath = Path.Combine(path, selectModel);
        }
    }
}