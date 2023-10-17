using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisionProTest
{
    public partial class FormDisplay : Form
    {
        private readonly TaskCompletionSource<(int, int)> userInput = new TaskCompletionSource<(int, int)>();

        public FormDisplay()
        {
            InitializeComponent();
        }

        public void Display_Load()
        {
            CenterToScreen();
            this.TopMost = true;
            ShowDialog();
        }

        public void OnOKButtonPressed(int number1, int number2)
        {
            userInput.SetResult((number1, number2));
        }

        public Task<(int, int)> WaitForUserInput()
        {
            return userInput.Task;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (userInput != null && int.TryParse(TxtDisplayH.Text, out int number1) &&
            int.TryParse(TxtDisplayW.Text, out int number2))
            {
                if (number1 < 1)
                    number1 = 1;
                else if (number1 > 4)
                    number1 = 4;

                if (number2 < 1)
                    number2 = 1;
                else if (number2 > 4)
                    number2 = 4;

                OnOKButtonPressed(number1, number2);
                Hide();
            }
            else
            {
                MessageBox.Show("정수만 입력해 주세요.");
            }
        }
    }
}