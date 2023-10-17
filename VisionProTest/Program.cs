using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace VisionProTest
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ko-KR");
            //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ko-KR");
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

            Cognex.VisionPro.CogVisionToolMultiThreading.ThreadCountMode = Cognex.VisionPro.CogVisionToolMultiThreadingThreadCountModeConstants.HardwareDefined;
            Cognex.VisionPro.CogVisionToolMultiThreading.Enable = true;

            Process[] _process;
            _process = Process.GetProcessesByName("VisionPro Test");

            if (_process.Length > 1)
            {
                MessageBox.Show("프로그램이 이미 실행 중입니다.");
                foreach (Process process in _process)
                {
                    process.Kill();
                }
            }
            else
            {
                Application.Run(new FormMain());
            }
            if (Application.MessageLoop == true)
                Application.Exit();
            else
                Environment.Exit(0);
        }
    }
}