using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThinkSharp.Licensing;
using ThinkSharp.Licensing.Shared.Test;


namespace TestLicensing
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LicTest test = new LicTest();
            test.TestSerialize_Without();

            var hardwareID = HardwareIdentifier.ForCurrentComputer();
            string dataFolder = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), hardwareID);
            string licPath = System.IO.Path.Combine(dataFolder, "mvt.lic");
            if (System.IO.File.Exists(licPath))
            {
                string strContent = System.IO.File.ReadAllText(licPath);
                if (LicTest.AssertSerializationWorks(strContent))
                    Application.Run(new Form1());
            }
            else
            {
                AboutLicenseBox box = new AboutLicenseBox();
                box.ShowDialog();
            }
        }
    }
}
