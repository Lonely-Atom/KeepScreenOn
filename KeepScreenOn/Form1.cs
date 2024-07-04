using Utils;

namespace KeepScreenOn
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // 窗口加载事件
        private void MainForm_Load(object sender, EventArgs e)
        {
            // 虽然窗口大小已经设置为 0，但还是会有个灰窗口，需使用 Hide 方法隐藏
            Hide();
        }

        // 窗口关闭事件
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (tsmiEnable.Checked)
                KeysPressHelper.PressControlKey();
        }

        private void TsmiEnableClick(object sender, EventArgs e)
        {
            tsmiEnable.Checked = !tsmiEnable.Checked;
            if (tsmiEnable.Checked)
                tsmiEnable.Text = "关闭";
            else
                tsmiEnable.Text = "启用";
        }

        private void TsmiExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}