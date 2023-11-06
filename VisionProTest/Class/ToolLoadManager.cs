using INIFileManager;

using System;

namespace VisionProTest
{
    internal class ToolLoadManager
    {
        private static string toolName;

        public static void SetINIPath(int _tool)
        {
            switch (_tool)
            {
                case UcDefine.PMAlign:
                    INIFiles.Set_INI_Path($"{UcDefine.ModelListPath + "\\" + FormSetup.strSelectedName}\\PMAlign.ini");
                    toolName = "PMAlign";
                    break;
                case UcDefine.Caliper:
                    INIFiles.Set_INI_Path($"{UcDefine.ModelListPath + "\\" + FormSetup.strSelectedName}\\Caliper.ini");
                    toolName = "Caliper";
                    break;
            }
        }

        public static void LoadSearchRegion(int _tool, int _index)
        {
            switch (_tool)
            {
                case UcDefine.PMAlign:
                    ToolPattern.SearchRegion_Rect.CenterX = Convert.ToDouble(INIFiles.ReadValue($"SERACH_REGION_RECT{_index + 1}", "CenterX"));
                    ToolPattern.SearchRegion_Rect.CenterY = Convert.ToDouble(INIFiles.ReadValue($"SERACH_REGION_RECT{_index + 1}", "CenterY"));
                    ToolPattern.SearchRegion_Rect.SideXLength = Convert.ToDouble(INIFiles.ReadValue($"SERACH_REGION_RECT{_index + 1}", "Width"));
                    ToolPattern.SearchRegion_Rect.SideYLength = Convert.ToDouble(INIFiles.ReadValue($"SERACH_REGION_RECT{_index + 1}", "Height"));
                    ToolPattern.SearchRegion_Rect.Rotation = Convert.ToDouble(INIFiles.ReadValue($"SERACH_REGION_RECT{_index + 1}", "Rotation"));
                    break;
                case UcDefine.Caliper:
                    ToolCaliper.SearchRegion_Rect.CenterX = Convert.ToDouble(INIFiles.ReadValue($"SERACH_REGION_RECT{_index + 1}", "CenterX"));
                    ToolCaliper.SearchRegion_Rect.CenterY = Convert.ToDouble(INIFiles.ReadValue($"SERACH_REGION_RECT{_index + 1}", "CenterY"));
                    ToolCaliper.SearchRegion_Rect.SideXLength = Convert.ToDouble(INIFiles.ReadValue($"SERACH_REGION_RECT{_index + 1}", "Width"));
                    ToolCaliper.SearchRegion_Rect.SideYLength = Convert.ToDouble(INIFiles.ReadValue($"SERACH_REGION_RECT{_index + 1}", "Height"));
                    ToolCaliper.SearchRegion_Rect.Rotation = Convert.ToDouble(INIFiles.ReadValue($"SERACH_REGION_RECT{_index + 1}", "Rotation"));
                    break;
            }
        }

        public static void LoadTrainRegion(int _index)
        {
            ToolPattern.TrainRegion_Rect.CenterX = Convert.ToDouble(INIFiles.ReadValue($"TRAIN_REGION_RECTANGLE{_index + 1}", "CenterX"));
            ToolPattern.TrainRegion_Rect.CenterY = Convert.ToDouble(INIFiles.ReadValue($"TRAIN_REGION_RECTANGLE{_index + 1}", "CenterY"));
            ToolPattern.TrainRegion_Rect.SideXLength = Convert.ToDouble(INIFiles.ReadValue($"TRAIN_REGION_RECTANGLE{_index + 1}", "Width"));
            ToolPattern.TrainRegion_Rect.SideYLength = Convert.ToDouble(INIFiles.ReadValue($"TRAIN_REGION_RECTANGLE{_index + 1}", "Height"));
            ToolPattern.TrainRegion_Rect.Rotation = Convert.ToDouble(INIFiles.ReadValue($"TRAIN_REGION_RECTANGLE{_index + 1}", "Rotation"));
        }

        public static string LoadThreshold(int _index)
        {
            return INIFiles.GetParam($"{toolName}{_index + 1}", "Threshold", "0.5");
        }

        public static string LoadAngleLow(int _index)
        {
            return INIFiles.GetParam($"{toolName}{_index + 1}", "AngleLow", "0");
        }

        public static string LoadAngleHigh(int _index)
        {
            return INIFiles.GetParam($"{toolName}{_index + 1}", "AngleHigh", "0");
        }

        public static string LoadScaleLow(int _index)
        {
            return INIFiles.GetParam($"{toolName}{_index + 1}", "ScaleLow", "1");
        }

        public static string LoadScaleHigh(int _index)
        {
            return INIFiles.GetParam($"{toolName}{_index + 1}", "ScaleHigh", "1");
        }

        public static string LoadApprox(int _index)
        {
            return INIFiles.GetParam($"{toolName}{_index + 1}", "Approx", "1");
        }

        public static bool LoadIsHighSensitivity(int _index)
        {
            return Convert.ToBoolean(INIFiles.GetParam($"{toolName}{_index + 1}", "HighSensitivity", "False"));
        }

        public static string LoadModelToolName(int _index)
        {
            return INIFiles.ReadValue($"{toolName}{_index + 1}", "Name");
        }

        public static bool LoadMode(int _index)
        {
            return INIFiles.ReadValue($"MODE{_index + 1}", "Type") != "Single";
        }

        public static int LoadEdge1Polarity(int _index)
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

        public static int LoadEdge2Polarity(int _index)
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

        public static string LoadFilterSize(int _index)
        {
            return INIFiles.GetParam($"Caliper{_index + 1}", "FilterSize", "2");
        }

        public static string LoadEdgePairWidth(int _index)
        {
            return INIFiles.ReadValue($"Caliper{_index + 1}", "Edge Pair Width");
        }
    }
}