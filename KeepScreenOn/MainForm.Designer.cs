using KeepScreenOn.Utils;

namespace KeepScreenOn
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            timer = new System.Windows.Forms.Timer(components);
            contextMenuStrip = new ContextMenuStrip(components);
            tsmiKeepScreenOn = new ToolStripMenuItem();
            tsmiAutoKeepScreenOn = new ToolStripMenuItem();
            tsmiAutoStart = new ToolStripMenuItem();
            tsmiCloseNotice = new ToolStripMenuItem();
            tsmiAbout = new ToolStripMenuItem();
            tsmiExit = new ToolStripMenuItem();
            notifyIcon = new NotifyIcon(components);
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // MainForm
            // 
            ClientSize = new Size(0, 0);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            ShowInTaskbar = false;
            Text = "防止屏幕锁定小工具";
            WindowState = FormWindowState.Minimized;
            FormClosed += MainForm_FormClosed;
            Load += MainForm_Load;
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = ConfigHelper.Instance.AppConfig.Configs.PressKeyInterval;
            timer.Tick += Timer_Tick;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { tsmiKeepScreenOn, tsmiAutoKeepScreenOn, tsmiAutoStart, tsmiCloseNotice, tsmiAbout, tsmiExit });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(233, 114);
            // 
            // tsmiKeepScreenOn
            // 
            tsmiKeepScreenOn.Name = "tsmiKeepScreenOn";
            tsmiKeepScreenOn.Size = new Size(232, 22);
            tsmiKeepScreenOn.Text = "防止屏幕锁定";
            tsmiKeepScreenOn.Click += TsmiKeepScreenOnClick;
            // 
            // tsmiAutoKeepScreenOn
            // 
            tsmiAutoKeepScreenOn.Name = "tsmiAutoKeepScreenOn";
            tsmiAutoKeepScreenOn.Size = new Size(232, 22);
            tsmiAutoKeepScreenOn.Text = "启动后自动开启防止屏幕锁定";
            tsmiAutoKeepScreenOn.Click += TsmiAutoKeepScreenOnClick;
            // 
            // tsmiAutoStart
            // 
            tsmiAutoStart.Name = "tsmiAutoStart";
            tsmiAutoStart.Size = new Size(232, 22);
            tsmiAutoStart.Text = "开机自启动";
            tsmiAutoStart.Click += TsmiAutoStartClick;
            // 
            // tsmiCloseNotice
            // 
            tsmiCloseNotice.Name = "tsmiCloseNotice";
            tsmiCloseNotice.Size = new Size(232, 22);
            tsmiCloseNotice.Text = "关闭通知";
            tsmiCloseNotice.Click += TsmiCloseNoticeClick;
            // 
            // tsmiAbout
            // 
            tsmiAbout.Name = "tsmiAbout";
            tsmiAbout.Size = new Size(232, 22);
            tsmiAbout.Text = "关于";
            tsmiAbout.Click += TsmiAboutClick;
            // 
            // tsmiExit
            // 
            tsmiExit.Name = "tsmiExit";
            tsmiExit.Size = new Size(232, 22);
            tsmiExit.Text = "退出";
            tsmiExit.Click += TsmiExitClick;
            // 
            // notifyIcon
            // 
            notifyIcon.ContextMenuStrip = contextMenuStrip;
            notifyIcon.Icon = Icon;
            notifyIcon.Text = "防止屏幕锁定小工具";
            notifyIcon.Visible = true;
        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem tsmiKeepScreenOn;
        private ToolStripMenuItem tsmiAutoKeepScreenOn;
        private ToolStripMenuItem tsmiAutoStart;
        private ToolStripMenuItem tsmiCloseNotice;
        private ToolStripMenuItem tsmiAbout;
        private ToolStripMenuItem tsmiExit;
        private NotifyIcon notifyIcon;
    }
}
