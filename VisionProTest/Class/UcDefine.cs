using System.IO;
using System.Windows.Forms;

namespace VisionProTest
{
    class UcDefine
    {
        public const int MAX_ITEM_INSPECT = 2;
        public const int MAX_CAMERA = 1;
        public const int MAX_QUEUE = 10;
        public const int MAX_STEP = 16;

        public const int PMAlign = 0;
        public const int Caliper = 1;
        public const int OCRMax = 2;

        public static string ModelListPath;

        public const string Acquire = "Acquire";
        public const string Live = "Live";

        static UcDefine()
        {
            ModelListPath = Path.Combine(Application.StartupPath, "CONFIG\\ModelList\\");
        }
    }
}