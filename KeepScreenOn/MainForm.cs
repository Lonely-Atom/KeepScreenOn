using KeepScreenOn.Utils;
using System.Text;

namespace KeepScreenOn
{
    public partial class MainForm : Form
    {
        // 全局快捷键对象
        private readonly GlobalHotkeyHelper? globalHotkeyKeepScreenOn;

        public MainForm()
        {
            InitializeComponent();

            #region 初始读取配置文件并进行相关设置
            // 关闭通知配置
            EnableCloseNotice(ConfigHelper.Instance.AppConfig.Configs.CloseNotice, true);
            // 开机自启动配置
            EnableAutoStart(ConfigHelper.Instance.AppConfig.Configs.AutoStart, true);
            // 启动后自动开启防止屏幕锁定
            EnableAutoKeepScreenOn(ConfigHelper.Instance.AppConfig.Configs.AutoKeepScreenOn, true);
            // 第一次显示关于配置
            if (ConfigHelper.Instance.AppConfig.Configs.FirstShowAbout)
            {
                ShowAbout();
                ConfigHelper.Instance.AppConfig.Configs.FirstShowAbout = false;
                ConfigHelper.Instance.UpdateConfig();
            }
            #endregion

            #region 注册全局快捷键：隐藏/显示任务栏
            globalHotkeyKeepScreenOn = new GlobalHotkeyHelper(
                GetHashCode(),
                KeepScreenOn
            );

            if (!globalHotkeyKeepScreenOn.RegisterHotKey(ConfigHelper.Instance.AppConfig.Hotkeys.KeepScreenOn))
                SendNotification(Text, $"【{ConfigHelper.Instance.AppConfig.Hotkeys.KeepScreenOn}】热键注册失败!");
            #endregion

            #region 运行程序提示
            StringBuilder sb_msg = new();
            sb_msg.AppendLine("此软件无窗口，已运行在任务栏托盘中，可右键托盘中的图标打开菜单。\n");
            sb_msg.AppendLine("注意：请先详细阅读【关于】中的信息后再使用。");
            SendNotification(Text, sb_msg.ToString());
            #endregion

            #region 初始化隐藏/显示任务栏菜单项文本，防止在 Designer 中引用变量导致报错
            tsmiKeepScreenOn.Text = $"防止屏幕锁定 ({ConfigHelper.Instance.AppConfig.Hotkeys.KeepScreenOn})";
            #endregion
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
            // 释放全局快捷键
            globalHotkeyKeepScreenOn?.Dispose();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (tsmiKeepScreenOn.Checked)
                KeysPressHelper.PressScrollKey();
        }

        private void TsmiKeepScreenOnClick(object sender, EventArgs e)
        {
            KeepScreenOn();
        }

        private void TsmiAutoKeepScreenOnClick(object sender, EventArgs e)
        {
            EnableAutoKeepScreenOn(!tsmiAutoKeepScreenOn.Checked, false);
        }

        private void TsmiAutoStartClick(object sender, EventArgs e)
        {
            EnableAutoStart(!tsmiAutoStart.Checked, false);
        }

        private void TsmiCloseNoticeClick(object sender, EventArgs e)
        {
            EnableCloseNotice(!tsmiCloseNotice.Checked, false);
        }

        private void TsmiAboutClick(object sender, EventArgs e)
        {
            ShowAbout();
        }

        private void TsmiExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // 启用/关闭防止屏幕锁定
        private void KeepScreenOn()
        {
            tsmiKeepScreenOn.Checked = !tsmiKeepScreenOn.Checked;
            if (tsmiKeepScreenOn.Checked)
            {
                tsmiKeepScreenOn.Text = $"关闭防止屏幕锁定({ConfigHelper.Instance.AppConfig.Hotkeys.KeepScreenOn})";
                SendNotification(Text, "已启用防止屏幕锁定。");
            }
            else
            {
                tsmiKeepScreenOn.Text = $"防止屏幕锁定({ConfigHelper.Instance.AppConfig.Hotkeys.KeepScreenOn})";
                SendNotification(Text, "已关闭防止屏幕锁定。");
            }
        }

        // 设置是否启动后自动开启防止屏幕锁定
        private void EnableAutoKeepScreenOn(bool enable, bool isInit)
        {
            tsmiAutoKeepScreenOn.Checked = enable;

            if (enable)
            {
                tsmiAutoKeepScreenOn.Text = "取消启动后自动开启防止屏幕锁定";
                if (!isInit)
                    SendNotification(Text, "已设置启动后自动开启防止屏幕锁定！");
                else
                    KeepScreenOn();
            }
            else
            {
                tsmiAutoKeepScreenOn.Text = "启动后自动开启防止屏幕锁定";
                if (!isInit)
                    SendNotification(Text, "已取消启动后自动开启防止屏幕锁定！");
            }

            if (!isInit)
            {
                ConfigHelper.Instance.AppConfig.Configs.AutoKeepScreenOn = enable;
                ConfigHelper.Instance.UpdateConfig();
            }
        }

        // 设置是否开机自启动
        private void EnableAutoStart(bool enable, bool isInit)
        {
            tsmiAutoStart.Checked = enable;

            if (enable)
            {
                AutoStartHelper.SetStartup(Text);
                tsmiAutoStart.Text = "取消开机自启动";
                if (!isInit)
                    SendNotification(Text, "已设置开机自启动！");
            }
            else
            {
                AutoStartHelper.UnsetStartup(Text);
                tsmiAutoStart.Text = "开机自启动";
                if (!isInit)
                    SendNotification(Text, "已取消开机自启动！");
            }

            if (!isInit)
            {
                ConfigHelper.Instance.AppConfig.Configs.AutoStart = enable;
                ConfigHelper.Instance.UpdateConfig();
            }
        }

        // 设置是否关闭通知
        private void EnableCloseNotice(bool enable, bool isInit)
        {
            tsmiCloseNotice.Checked = enable;

            if (enable)
                tsmiCloseNotice.Text = "开启通知";
            else
                tsmiCloseNotice.Text = "关闭通知";

            if (!isInit)
            {
                ConfigHelper.Instance.AppConfig.Configs.CloseNotice = enable;
                ConfigHelper.Instance.UpdateConfig();
            }
        }

        // 显示关于
        private static void ShowAbout()
        {
            StringBuilder sb_msg = new();
            sb_msg.AppendLine("【软件名】：防止屏幕锁定小工具\n");

            sb_msg.AppendLine("【重要提醒】：");
            sb_msg.AppendLine("    1. 本软件为免费提供，作者为「LonelyAtom」。任何索要付费购买此软件的行为均为欺诈。请勿向任何第三方支付费用，以免受到欺骗。");
            sb_msg.AppendLine("    2. 本软件受到版权保护，并且仅限于合法获得许可的用户使用。未经授权的复制、分发或盗版行为将依法追究其法律责任。\n");

            sb_msg.AppendLine("【重要说明】：");
            sb_msg.AppendLine("    1. 此软件无窗口，运行后将自动收到任务栏托盘中。");
            sb_msg.AppendLine("    2. 此软件适用于Windows系统设置中锁屏睡眠等相关功能由组织管理员控制，无法自行修改的场景。");
            sb_msg.AppendLine("    3. 启用后默认通过每隔30秒自动按下Ctrl键来保持屏幕不锁定。\n");

            sb_msg.AppendLine("【快捷键】（可在 appsettings.json 文件中修改）：");
            sb_msg.AppendLine($"    1. 防止屏幕锁定：【{ConfigHelper.Instance.AppConfig.Hotkeys.KeepScreenOn}】\n");

            sb_msg.AppendLine("【作者】：LonelyAtom");

            MessageBox.Show(sb_msg.ToString(), "关于", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 发送通知
        private void SendNotification(string title, string text)
        {
            if (!tsmiCloseNotice.Checked)
            {
                notifyIcon.BalloonTipTitle = title;
                notifyIcon.BalloonTipText = text;
                notifyIcon.ShowBalloonTip(2000);
            }
        }
    }
}