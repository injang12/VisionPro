using Cognex.VisionPro;
using ImageFileManager;

using System;
using System.IO;
using System.Windows.Forms;

namespace VisionProTest
{
    public partial class FormImageMasking : Form
    {
        public static ICogImage MaskingImage { get; set; }

        private static readonly ImageManager Image_Manager = new ImageManager();

        private static bool isMask = false;

        private static string ModelListPath { get; set; } = Application.StartupPath + $"\\CONFIG\\ModelList\\{FormToolPattern.ModelName}\\";

        public FormImageMasking()
        {
            InitializeComponent();
        }

        public static CogImage8Grey Load_MaskImage(string _name)
        {
            if (!File.Exists(ModelListPath + $"\\Mask_{_name}.bmp"))
                return null;

            CogImage8Grey MaskImage = (CogImage8Grey)Image_Manager.Load_ImageFile(ModelListPath + $"\\Mask_{_name}.bmp");

            return MaskImage;
        }

        public static bool ImageMasking(ICogImage Image, string ModelToolName)
        {
            FormImageMasking _FormImageMasking = new FormImageMasking();

            _FormImageMasking.cogImageMaskingEditV2.Image = null;
            _FormImageMasking.cogImageMaskingEditV2.MaskImage = Load_MaskImage(ModelToolName);
            _FormImageMasking.cogImageMaskingEditV2.Image = Image;
            _FormImageMasking.ShowDialog();

            if (_FormImageMasking.SelectedMasking())
            {
                MaskingImage = _FormImageMasking.cogImageMaskingEditV2.MaskImage;
                return true;
            }
            else
                return false;
        }

        private bool SelectedMasking()
        {
            return isMask;
        }

        private void FormImageMasking_Load(object sender, EventArgs e)
        {
            isMask = false;
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            isMask = true;
            Close();
        }
    }
}