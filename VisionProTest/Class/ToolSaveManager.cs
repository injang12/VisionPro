using System.IO;
using System.Windows.Forms;
using System;

using INIFileManager;

using Cognex.VisionPro;

namespace VisionProTest
{
    internal class ToolSaveManager
    {
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

        public static void SaveToolName(string toolName, string name, int value)
        {
            INIFiles.WriteValue($"{toolName}{value}", "Name", Convert.ToString(name));
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

        public static void SaveEdgeType(bool check, int value)
        {
            string type = "Single";

            if(check)
                type = "Double";
                
            INIFiles.WriteValue($"MODE{value}", "Type", type);
        }

        public static void SaveEdgePolarity(string edgePolarity, int value, int index)
        {
            INIFiles.WriteValue($"Edge{index}_{value}", "Polarity", edgePolarity);
        }

        public static void SaveFilterSize(string filterSize, int value)
        {
            INIFiles.WriteValue($"Caliper{value}", "FilterSize", filterSize);
        }

        public static void SaveEdgePairWidth(string edgePairWidth, int value)
        {
            INIFiles.WriteValue($"Caliper{value}", "Edge Pair Width", edgePairWidth);
        }
    }
}