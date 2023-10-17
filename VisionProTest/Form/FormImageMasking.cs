using System;
using System.Windows.Forms;

namespace VisionProTest
{
    public partial class FormImageMasking : Form
    {
        private static bool isMask = false;

        public FormImageMasking()
        {
            InitializeComponent();
        }

        public bool SelectedMasking()
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