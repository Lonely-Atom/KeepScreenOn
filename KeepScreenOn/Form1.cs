using Utils;

namespace KeepScreenOn
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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
                tsmiEnable.Text = "�ر�";
            else
                tsmiEnable.Text = "����";
        }

        private void TsmiExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}