namespace PowerProfileSwitcher
{
    partial class UserInterface
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripMenuItem monitorOff;
            System.Windows.Forms.ToolStripMenuItem screensaver;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
            System.Windows.Forms.ToolStripMenuItem exit;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInterface));
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.preventMonitorOff = new System.Windows.Forms.ToolStripMenuItem();
            this.preventStandby = new System.Windows.Forms.ToolStripMenuItem();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            monitorOff = new System.Windows.Forms.ToolStripMenuItem();
            screensaver = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            exit = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // monitorOff
            // 
            monitorOff.Name = "monitorOff";
            monitorOff.Size = new System.Drawing.Size(214, 22);
            monitorOff.Text = "Turn off &display";
            monitorOff.Click += new System.EventHandler(this.monitorOff_Click);
            // 
            // screensaver
            // 
            screensaver.Name = "screensaver";
            screensaver.Size = new System.Drawing.Size(214, 22);
            screensaver.Text = "Start s&creensaver";
            screensaver.Click += new System.EventHandler(this.screensaver_Click);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(211, 6);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(211, 6);
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(211, 6);
            // 
            // exit
            // 
            exit.Name = "exit";
            exit.Size = new System.Drawing.Size(214, 22);
            exit.Text = "&Exit";
            exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            monitorOff,
            screensaver,
            toolStripSeparator1,
            this.preventMonitorOff,
            this.preventStandby,
            toolStripSeparator2,
            toolStripSeparator3,
            exit});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(215, 132);
            // 
            // preventMonitorOff
            // 
            this.preventMonitorOff.CheckOnClick = true;
            this.preventMonitorOff.Name = "preventMonitorOff";
            this.preventMonitorOff.Size = new System.Drawing.Size(214, 22);
            this.preventMonitorOff.Text = "&Prevent turning off display";
            this.preventMonitorOff.Click += new System.EventHandler(this.preventItem_Click);
            // 
            // preventStandby
            // 
            this.preventStandby.CheckOnClick = true;
            this.preventStandby.Name = "preventStandby";
            this.preventStandby.Size = new System.Drawing.Size(214, 22);
            this.preventStandby.Text = "Prevent &standby";
            this.preventStandby.Click += new System.EventHandler(this.preventItem_Click);
            // 
            // trayIcon
            // 
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "PowerProfileSwitcher";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDown);
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "UserInterface";
            this.Size = new System.Drawing.Size(295, 201);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem preventMonitorOff;
        private System.Windows.Forms.ToolStripMenuItem preventStandby;
        private System.Windows.Forms.NotifyIcon trayIcon;
    }
}
