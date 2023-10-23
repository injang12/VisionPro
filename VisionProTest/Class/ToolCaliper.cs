using Cognex.VisionPro;
using Cognex.VisionPro.Caliper;
using Cognex.VisionPro.Display;

using System.Drawing;
using System;
using System.IO;

namespace VisionProTest
{
    internal class ToolCaliper
    {
        public static ICogImage InputImage { get; set; }
        public static CogRecordDisplay SetupDisplay { get; set; } = new CogRecordDisplay();
        public static CogRectangleAffine SearchRegion_Rect { get; set; } = new CogRectangleAffine();
        public static CogCaliperTool CaliperTool { get; set; } = new CogCaliperTool();

        public static bool DoubleEdge { get; set; }
        public static int Polarity { get; set; }
        public static int Polarity2 { get; set; }
        public static double Threshold { get; set; }
        public static double FilterSize { get; set; }
        public static double EdgePairWidth { get; set; }

        public static void SearchRegion_Create()
        {
            if (SetupDisplay.Image == null)
                return;

            MainDisplay_Clear();

            SearchRegion_Rect.GraphicDOFEnable = CogRectangleAffineDOFConstants.All;
            SearchRegion_Rect.Interactive = true;
            SearchRegion_Rect.XDirectionAdornment = CogRectangleAffineDirectionAdornmentConstants.SolidArrow;
            SearchRegion_Rect.YDirectionAdornment = CogRectangleAffineDirectionAdornmentConstants.Arrow;
            SearchRegion_Rect.SelectedSpaceName = "#";
            SearchRegion_Rect.SelectedColor = CogColorConstants.Blue;

            SetupDisplay.StaticGraphics.Clear();
            SetupDisplay.InteractiveGraphics.Clear();

            if (!File.Exists(UcDefine.ModelListPath + FormSetup.strSelectedName + "\\Caliper.ini"))
            {
                SearchRegion_Rect.CenterX = 500;
                SearchRegion_Rect.CenterY = 500;
                SearchRegion_Rect.SideXLength = 200;
                SearchRegion_Rect.SideYLength = 200;
                SearchRegion_Rect.Rotation = 0;
            }

            SetupDisplay.InteractiveGraphics.Add(SearchRegion_Rect, null, false);
        }

        public static bool Find_Run(CogDisplay display)
        {
            MainDisplay_Clear();

            Polarity++;

            CaliperTool.InputImage = InputImage;
            CaliperTool.Region = SearchRegion_Rect;

            CaliperTool.RunParams.ContrastThreshold = Convert.ToDouble(Threshold);
            CaliperTool.RunParams.FilterHalfSizeInPixels = Convert.ToInt32(FilterSize);
            CaliperTool.RunParams.Edge0Polarity = (CogCaliperPolarityConstants)Polarity;

            switch (DoubleEdge)
            {
                case true:
                    Polarity2++;

                    CaliperTool.RunParams.EdgeMode = CogCaliperEdgeModeConstants.Pair;
                    CaliperTool.RunParams.Edge1Polarity = (CogCaliperPolarityConstants)Polarity2;
                    CaliperTool.RunParams.Edge0Position = -1 * (Convert.ToDouble(EdgePairWidth) / 2);
                    CaliperTool.RunParams.Edge1Position = Convert.ToDouble(EdgePairWidth) / 2;
                    break;
                case false:
                    CaliperTool.RunParams.EdgeMode = CogCaliperEdgeModeConstants.SingleEdge;
                    break;
            }

            CaliperTool.LastRunRecordDiagEnable = CogCaliperLastRunRecordDiagConstants.TransformedRegionPixels;

            CaliperTool.Run();

            if (CaliperTool.Results.Count <= 0 || CaliperTool.Results == null)
            {
                SearchRegion_Rect.SelectedColor = CogColorConstants.Red;
                SearchRegion_Rect.XDirectionAdornment = CogRectangleAffineDirectionAdornmentConstants.None;
                SearchRegion_Rect.YDirectionAdornment = CogRectangleAffineDirectionAdornmentConstants.None;

                display.StaticGraphics.Add(SearchRegion_Rect, "");

                CogGraphicLabel ngLabelScore = new CogGraphicLabel
                {
                    Text = "NG",
                    X = 300,
                    Y = 200,
                    Color = CogColorConstants.Red,
                    Font = new Font("Tahoma", 50.11f)
                };

                display.StaticGraphics.Add(ngLabelScore, null);
                ngLabelScore.Dispose();

                return false;
            }

            CogCompositeShape doubleEdgeGrapic = CaliperTool.Results[0].CreateResultGraphics(CogCaliperResultGraphicConstants.All);
            display.StaticGraphics.Add(doubleEdgeGrapic, "");

            CogGraphicLabel okLabelScore = new CogGraphicLabel
            {
                Text = "OK",
                X = 300,
                Y = 200,
                Color = CogColorConstants.Green,
                Font = new Font("Tahoma", 50.11f)
            };

            display.StaticGraphics.Add(okLabelScore, null);
            okLabelScore.Dispose();

            return true;
        }

        private static void MainDisplay_Clear()
        {
            SetupDisplay.InteractiveGraphics.Clear();
            SetupDisplay.StaticGraphics.Clear();
        }
    }
}