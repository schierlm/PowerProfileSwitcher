using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PowerProfileSwitcher
{
    public partial class UserInterface : UserControl
    {
        public UserInterface()
        {
            InitializeComponent();
        }

        private void trayIcon_MouseDown(object sender, MouseEventArgs e)
        {
            bool[] state = ApiCalls.GetGlobalExecutionState();
            UpdateText(preventMonitorOff, state[0]);
            UpdateText(preventStandby, state[1]);
            while (contextMenu.Items.Count > 8)
            {
                contextMenu.Items.RemoveAt(contextMenu.Items.Count - 3);
            }
            var schemeItems = new List<ToolStripMenuItem>();
            Guid activeScheme = ApiCalls.ActivePowerScheme;
            var schemes = ApiCalls.GetPowerSchemes();
            foreach (var guid in schemes.Keys)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(schemes[guid], null, powerScheme_Click);
                item.Tag = guid;
                if (guid == activeScheme)
                {
                    item.Checked = true;
                }
                schemeItems.Add(item);
            }
            schemeItems.Sort((x, y) => x.Text.CompareTo(y.Text));
            foreach (var item in schemeItems)
            {
                contextMenu.Items.Insert(contextMenu.Items.Count - 2, item);
            }
            contextMenu.Show(Cursor.Position.X, Cursor.Position.Y);
        }

        private void UpdateText(ToolStripMenuItem item, bool prevented)
        {
            var text = item.Text;
            text = text.Replace(" [Prevented]", "");
            if (prevented) text += " [Prevented]";
            item.Text = text;
        }

        private void monitorOff_Click(object sender, EventArgs e)
        {
            ApiCalls.PowerOffDisplay();
        }

        private void screensaver_Click(object sender, EventArgs e)
        {
            ApiCalls.StartScreensaver();
        }

        public void exit_Click(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
        }

        private void preventItem_Click(object sender, EventArgs e)
        {
            ApiCalls.SetLocalExecutionState(preventMonitorOff.Checked, preventStandby.Checked);
        }

        private void powerScheme_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mi = (ToolStripMenuItem)sender;
            ApiCalls.ActivePowerScheme = (Guid)mi.Tag;
        }
    }
}
