using KeepScreenOn.Utils;
using System.Text;

namespace KeepScreenOn
{
    public partial class MainForm : Form
    {
        // ȫ�ֿ�ݼ�����
        private readonly GlobalHotkeyHelper? globalHotkeyKeepScreenOn;

        public MainForm()
        {
            InitializeComponent();

            #region ��ʼ��ȡ�����ļ��������������
            // �ر�֪ͨ����
            EnableCloseNotice(ConfigHelper.Instance.AppConfig.Configs.CloseNotice, true);
            // ��������������
            EnableAutoStart(ConfigHelper.Instance.AppConfig.Configs.AutoStart, true);
            // �������Զ�������ֹ��Ļ����
            EnableAutoKeepScreenOn(ConfigHelper.Instance.AppConfig.Configs.AutoKeepScreenOn, true);
            // ��һ����ʾ��������
            if (ConfigHelper.Instance.AppConfig.Configs.FirstShowAbout)
            {
                ShowAbout();
                ConfigHelper.Instance.AppConfig.Configs.FirstShowAbout = false;
                ConfigHelper.Instance.UpdateConfig();
            }
            #endregion

            #region ע��ȫ�ֿ�ݼ�������/��ʾ������
            globalHotkeyKeepScreenOn = new GlobalHotkeyHelper(
                GetHashCode(),
                KeepScreenOn
            );

            if (!globalHotkeyKeepScreenOn.RegisterHotKey(ConfigHelper.Instance.AppConfig.Hotkeys.KeepScreenOn))
                SendNotification(Text, $"��{ConfigHelper.Instance.AppConfig.Hotkeys.KeepScreenOn}���ȼ�ע��ʧ��!");
            #endregion

            #region ���г�����ʾ
            StringBuilder sb_msg = new();
            sb_msg.AppendLine("������޴��ڣ��������������������У����Ҽ������е�ͼ��򿪲˵���\n");
            sb_msg.AppendLine("ע�⣺������ϸ�Ķ������ڡ��е���Ϣ����ʹ�á�");
            SendNotification(Text, sb_msg.ToString());
            #endregion

            #region ��ʼ������/��ʾ�������˵����ı�����ֹ�� Designer �����ñ������±���
            tsmiKeepScreenOn.Text = $"��ֹ��Ļ���� ({ConfigHelper.Instance.AppConfig.Hotkeys.KeepScreenOn})";
            #endregion
        }

        // ���ڼ����¼�
        private void MainForm_Load(object sender, EventArgs e)
        {
            // ��Ȼ���ڴ�С�Ѿ�����Ϊ 0�������ǻ��и��Ҵ��ڣ���ʹ�� Hide ��������
            Hide();
        }

        // ���ڹر��¼�
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // �ͷ�ȫ�ֿ�ݼ�
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

        // ����/�رշ�ֹ��Ļ����
        private void KeepScreenOn()
        {
            tsmiKeepScreenOn.Checked = !tsmiKeepScreenOn.Checked;
            if (tsmiKeepScreenOn.Checked)
            {
                tsmiKeepScreenOn.Text = $"�رշ�ֹ��Ļ����({ConfigHelper.Instance.AppConfig.Hotkeys.KeepScreenOn})";
                SendNotification(Text, "�����÷�ֹ��Ļ������");
            }
            else
            {
                tsmiKeepScreenOn.Text = $"��ֹ��Ļ����({ConfigHelper.Instance.AppConfig.Hotkeys.KeepScreenOn})";
                SendNotification(Text, "�ѹرշ�ֹ��Ļ������");
            }
        }

        // �����Ƿ��������Զ�������ֹ��Ļ����
        private void EnableAutoKeepScreenOn(bool enable, bool isInit)
        {
            tsmiAutoKeepScreenOn.Checked = enable;

            if (enable)
            {
                tsmiAutoKeepScreenOn.Text = "ȡ���������Զ�������ֹ��Ļ����";
                if (!isInit)
                    SendNotification(Text, "�������������Զ�������ֹ��Ļ������");
                else
                    KeepScreenOn();
            }
            else
            {
                tsmiAutoKeepScreenOn.Text = "�������Զ�������ֹ��Ļ����";
                if (!isInit)
                    SendNotification(Text, "��ȡ���������Զ�������ֹ��Ļ������");
            }

            if (!isInit)
            {
                ConfigHelper.Instance.AppConfig.Configs.AutoKeepScreenOn = enable;
                ConfigHelper.Instance.UpdateConfig();
            }
        }

        // �����Ƿ񿪻�������
        private void EnableAutoStart(bool enable, bool isInit)
        {
            tsmiAutoStart.Checked = enable;

            if (enable)
            {
                AutoStartHelper.SetStartup(Text);
                tsmiAutoStart.Text = "ȡ������������";
                if (!isInit)
                    SendNotification(Text, "�����ÿ�����������");
            }
            else
            {
                AutoStartHelper.UnsetStartup(Text);
                tsmiAutoStart.Text = "����������";
                if (!isInit)
                    SendNotification(Text, "��ȡ��������������");
            }

            if (!isInit)
            {
                ConfigHelper.Instance.AppConfig.Configs.AutoStart = enable;
                ConfigHelper.Instance.UpdateConfig();
            }
        }

        // �����Ƿ�ر�֪ͨ
        private void EnableCloseNotice(bool enable, bool isInit)
        {
            tsmiCloseNotice.Checked = enable;

            if (enable)
                tsmiCloseNotice.Text = "����֪ͨ";
            else
                tsmiCloseNotice.Text = "�ر�֪ͨ";

            if (!isInit)
            {
                ConfigHelper.Instance.AppConfig.Configs.CloseNotice = enable;
                ConfigHelper.Instance.UpdateConfig();
            }
        }

        // ��ʾ����
        private static void ShowAbout()
        {
            StringBuilder sb_msg = new();
            sb_msg.AppendLine("�������������ֹ��Ļ����С����\n");

            sb_msg.AppendLine("����Ҫ���ѡ���");
            sb_msg.AppendLine("    1. �����Ϊ����ṩ������Ϊ��LonelyAtom�����κ���Ҫ���ѹ�����������Ϊ��Ϊ��թ���������κε�����֧�����ã������ܵ���ƭ��");
            sb_msg.AppendLine("    2. ������ܵ���Ȩ���������ҽ����ںϷ������ɵ��û�ʹ�á�δ����Ȩ�ĸ��ơ��ַ��������Ϊ������׷���䷨�����Ρ�\n");

            sb_msg.AppendLine("����Ҫ˵������");
            sb_msg.AppendLine("    1. ������޴��ڣ����к��Զ��յ������������С�");
            sb_msg.AppendLine("    2. �����������Windowsϵͳ����������˯�ߵ���ع�������֯����Ա���ƣ��޷������޸ĵĳ�����");
            sb_msg.AppendLine("    3. ���ú�Ĭ��ͨ��ÿ��30���Զ�����Ctrl����������Ļ��������\n");

            sb_msg.AppendLine("����ݼ��������� appsettings.json �ļ����޸ģ���");
            sb_msg.AppendLine($"    1. ��ֹ��Ļ��������{ConfigHelper.Instance.AppConfig.Hotkeys.KeepScreenOn}��\n");

            sb_msg.AppendLine("�����ߡ���LonelyAtom");

            MessageBox.Show(sb_msg.ToString(), "����", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ����֪ͨ
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