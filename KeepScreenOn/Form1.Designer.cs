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
            tsmiEnable = new ToolStripMenuItem();
            tsmiExit = new ToolStripMenuItem();
            notifyIcon = new NotifyIcon(components);
            contextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // timer
            // 
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { tsmiEnable, tsmiExit });
            contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new Size(101, 48);
            // 
            // tsmiEnable
            // 
            tsmiEnable.Name = "tsmiEnable";
            tsmiEnable.Size = new Size(100, 22);
            tsmiEnable.Text = "启用";
            tsmiEnable.Click += TsmiEnableClick;
            // 
            // tsmiExit
            // 
            tsmiExit.Name = "tsmiExit";
            tsmiExit.Size = new Size(100, 22);
            tsmiExit.Text = "退出";
            tsmiExit.Click += TsmiExitClick;
            // 
            // notifyIcon
            // 
            notifyIcon.ContextMenuStrip = contextMenuStrip;
            notifyIcon.Icon = (Icon)resources.GetObject("$this.Icon");
            notifyIcon.Text = "防止屏幕休眠小工具";
            notifyIcon.Visible = true;
            // 
            // MainForm
            // 
            ClientSize = new Size(0, 0);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            ShowInTaskbar = false;
            Text = "防止屏幕休眠小工具";
            WindowState = FormWindowState.Minimized;
            FormClosed += MainForm_FormClosed;
            Load += MainForm_Load;
            contextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private ContextMenuStrip contextMenuStrip;
        private ToolStripMenuItem tsmiEnable;
        private ToolStripMenuItem tsmiExit;
        private NotifyIcon notifyIcon;
    }
}
