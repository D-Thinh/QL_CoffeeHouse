using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_AN
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 loginForm = new Form1();
            var loginResult = loginForm.ShowDialog();

            if (loginResult == DialogResult.OK)
                Application.Run(new frmDieu_huong(Form1.taikhoan));
        }

    }
}
