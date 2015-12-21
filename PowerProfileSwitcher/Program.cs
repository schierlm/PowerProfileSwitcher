using System;
using System.Windows.Forms;

namespace PowerProfileSwitcher
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
            Application.Run(new Context());
        }
    }

    public class Context : ApplicationContext
    {
        private UserInterface ui;

        public Context()
        {
            ui = new UserInterface();
        }

        void Exit(object sender, EventArgs e)
        {
            ui.exit_Click(null, null);
        }
    }
}
