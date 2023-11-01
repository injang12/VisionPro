using Cognex.VisionPro;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.PixelMap;
using Cognex.VisionPro.PMAlign;

using System.Drawing;
using System;

namespace VisionProTest
{
    internal class ToolPattern
    {
        public static ICogImage InputImage { get; set; }
        public static CogRecordDisplay SetupDisplay { get; set; } = new CogRecordDisplay();
        public static CogRectangleAffine TrainRegion_Rect { get; set; } = new CogRectangleAffine();
        public static CogRectangleAffine SearchRegion_Rect { get; set; } = new CogRectangleAffine();
        public static CogPMAlignTool PMAlignTool { get; set; } = new CogPMAlignTool();
        private static CogPixelMapTool PixelMapTool { get; set; } = new CogPixelMapTool();

        public static double Threshold { get; set; }
        public static double AngleLow { get; set; }
        public static double AngleHigh { get; set; }
        public static double ScaleLow { get; set; }
        public static double ScaleHigh { get; set; }
        public static double Approx { get; set; }

        private static void MainDisplay_Clear()
        {
            SetupDisplay.InteractiveGraphics.Clear();
            SetupDisplay.StaticGraphics.Clear();
        }

        public static void TrainRegion_Create()
        {
            if (SetupDisplay.Image == null)
                return;

            MainDisplay_Clear();

            TrainRegion_Rect.GraphicDOFEnable = CogRectangleAffineDOFConstants.All;
            TrainRegion_Rect.Interactive = true;
            SetupDisplay.InteractiveGraphics.Add(TrainRegion_Rect, null, false);
        }

        public static void Masking(ICogImage _maskImage)
        {
            if (SetupDisplay.Image == null)
                return;

            PMAlignTool.Pattern.TrainImageMask = (CogImage8Grey)_maskImage;
        }

        public static bool Train_Pattern(bool _highSensitivity, CogDisplay _display = null)
        {
            if (InputImage == null)
                return false;

            switch (InputImage.ToString())
            {
                case "Cognex.VisionPro.CogImage16Range":
                    PixelMapTool.InputImage = InputImage;
                    PixelMapTool.Run();

                    PMAlignTool.Pattern.TrainImage = PixelMapTool.OutputImage;
                    PMAlignTool.Pattern.TrainImage.SelectedSpaceName = "#";
                    break;

                case "Cognex.VisionPro.CogImage24PlanarColor":
                    PMAlignTool.Pattern.TrainImage = CogImageConvert.GetIntensityImage(InputImage, 0, 0, 
                        InputImage.Width, InputImage.Height);
                    break;

                default:
                    PMAlignTool.Pattern.TrainImage = InputImage;
                    break;
            }

            if (_highSensitivity)
            {
                PMAlignTool.Pattern.TrainAlgorithm = CogPMAlignTrainAlgorithmConstants.PatMaxHighSensitivity;
                PMAlignTool.RunParams.RunAlgorithm = CogPMAlignRunAlgorithmConstants.PatMax;
            }
            else
            {
                PMAlignTool.Pattern.TrainAlgorithm = CogPMAlignTrainAlgorithmConstants.PatMax;
                PMAlignTool.RunParams.RunAlgorithm = CogPMAlignRunAlgorithmConstants.PatMax;
            }

            PMAlignTool.Pattern.TrainRegion = TrainRegion_Rect;
            PMAlignTool.Pattern.Origin.TranslationX = TrainRegion_Rect.CenterX;
            PMAlignTool.Pattern.Origin.TranslationY = TrainRegion_Rect.CenterY;

            PMAlignTool.Pattern.TrainRegionMode = CogRegionModeConstants.PixelAlignedBoundingBoxAdjustMask;

            try
            {
                PMAlignTool.Pattern.Train();
            }
            catch
            {
                return false;
            }

            if (PMAlignTool.Pattern.Trained && _display != null)
            {
                _display.Fit();

                PMAlignTool.Pattern.GetTrainedPatternImage().SelectedSpaceName = "#";

                _display.Image = PMAlignTool.Pattern.GetTrainedPatternImage();
                _display.StaticGraphics.Clear();

                _display.StaticGraphics.AddList(PMAlignTool.Pattern.CreateGraphicsCoarse(CogColorConstants.Yellow), null);
                _display.StaticGraphics.AddList(PMAlignTool.Pattern.CreateGraphicsFine(CogColorConstants.Green), null);
            }

            return PMAlignTool.Pattern.Trained;
        }

        public static void SearchRegion_Create()
        {
            if (SetupDisplay.Image == null)
                return;

            MainDisplay_Clear();

            SearchRegion_Rect.GraphicDOFEnable = CogRectangleAffineDOFConstants.All;
            SearchRegion_Rect.Interactive = true;

            if (SearchRegion_Rect.SelectedColor == CogColorConstants.Red)
                SearchRegion_Rect.SelectedColor = CogColorConstants.Cyan;

            SetupDisplay.InteractiveGraphics.Add(SearchRegion_Rect, null, false);
        }

        public static bool Find_Run()
        {
            MainDisplay_Clear();

            if (!PMAlignTool.Pattern.Trained || SetupDisplay.Image == null)
                return false;

            PointF _ptResult = new PointF
            {
                X = 0,
                Y = 0
            };
            
            if (SetupDisplay.Image.ToString() == "Cognex.VisionPro.CogImage16Range")
            {
                PMAlignTool.InputImage = PixelMapTool.OutputImage;

                if (PMAlignTool.InputImage == null)
                    return false;

                PMAlignTool.InputImage.SelectedSpaceName = "#";
            }
            else
            {
                PMAlignTool.InputImage = SetupDisplay.Image;
            }

            PMAlignTool.RunParams.ZoneAngle.Configuration = CogPMAlignZoneConstants.LowHigh;
            PMAlignTool.RunParams.AcceptThreshold = Convert.ToDouble(Threshold);
            PMAlignTool.RunParams.ZoneAngle.Low = CogMisc.DegToRad(Convert.ToDouble(AngleLow));
            PMAlignTool.RunParams.ZoneAngle.High = CogMisc.DegToRad(Convert.ToDouble(AngleHigh));
            PMAlignTool.RunParams.ZoneScale.Low = Convert.ToDouble(ScaleLow);
            PMAlignTool.RunParams.ZoneScale.High = Convert.ToDouble(ScaleHigh);
            PMAlignTool.RunParams.ApproximateNumberToFind = Convert.ToInt16(Approx);

            PMAlignTool.SearchRegion = SearchRegion_Rect;

            PMAlignTool.Run();

            if (PMAlignTool.Results.Count <= 0)
            {
                SearchRegion_Rect.SelectedColor = CogColorConstants.Red;
                SearchRegion_Rect.XDirectionAdornment = CogRectangleAffineDirectionAdornmentConstants.None;
                SearchRegion_Rect.YDirectionAdornment = CogRectangleAffineDirectionAdornmentConstants.None;

                SetupDisplay.StaticGraphics.Add(SearchRegion_Rect, "");

                CogGraphicLabel ngLabelScore = new CogGraphicLabel
                {
                    Text = "NG",
                    X = 300,
                    Y = 200,
                    Color = CogColorConstants.Red,
                    Font = new Font("Tahoma", 50.11f)
                };

                SetupDisplay.StaticGraphics.Add(ngLabelScore, null);
                ngLabelScore.Dispose();

                return false;
            }

            for (int j = 0; j < PMAlignTool.Results.Count; j++)
            {
                if (PMAlignTool.Results[j].Score > PMAlignTool.RunParams.AcceptThreshold)
                {
                    CogCompositeShape m_ResultGraphic = PMAlignTool.Results[j].CreateResultGraphics(
                        CogPMAlignResultGraphicConstants.MatchRegion | CogPMAlignResultGraphicConstants.Origin);

                    CogTransform2DLinear m_ResultPos = PMAlignTool.Results[j].GetPose();

                    // 결과 
                    _ptResult.X = (float)m_ResultPos.TranslationX;
                    _ptResult.Y = (float)m_ResultPos.TranslationY;

                    SetupDisplay.StaticGraphics.Add(m_ResultGraphic, null);

                    CogGraphicLabel labelScore = new CogGraphicLabel
                    {
                        Text = $"{string.Format("{0:0}", PMAlignTool.Results[j].Score * 100)}" + ", " + _ptResult.X + ", " + _ptResult.Y,
                        X = _ptResult.X,
                        Y = _ptResult.Y + 100,
                        Color = CogColorConstants.Blue
                    };

                    SetupDisplay.StaticGraphics.Add(labelScore, null);

                    CogGraphicLabel okLabelScore = new CogGraphicLabel
                    {
                        Text = "OK",
                        X = 300,
                        Y = 200,
                        Color = CogColorConstants.Green,
                        Font = new Font("Tahoma", 50.11f)
                    };

                    SetupDisplay.StaticGraphics.Add(okLabelScore, null);

                    okLabelScore.Dispose();
                }
            }
            return true;
        }
    }
}