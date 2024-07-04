namespace KeepScreenOn
{
    internal static class Program
    {
        // ���廥�����
        static readonly Mutex mutex = new(true, "23131D4A-3168-4182-B0F3-177E7EEF349B");

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // ����Ƿ��Ѿ���һ��ʵ��������
            if (!mutex.WaitOne(TimeSpan.Zero))
            {
                MessageBox.Show("Ӧ�ó����Ѿ��������С�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            // ���� Application.ApplicationExit �¼�
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
            Application.Run(new MainForm());
        }

        // �����˳��ص�����
        private static void OnApplicationExit(object? sender, EventArgs e)
        {
            // �ͷŻ������
            mutex.ReleaseMutex();
        }
    }
}