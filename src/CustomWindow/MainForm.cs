using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace CustomWindow
{
    public partial class MainForm : Form
    {
        private string softwareConfigPath = $@"{Environment.CurrentDirectory}\CustomWindowConfig.json";
        private SoftwareConfigEntity softwareConfig = new SoftwareConfigEntity();

        private int useAPI = 0;

        public MainForm()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.MinimumSize = new Size(this.Width, this.Height);
            ComboBox_UseAPI.SelectedIndex = useAPI;

            ReadConfig();
        }


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfig();
        }


        private void ReadConfig()
        {
            if (File.Exists(softwareConfigPath))
            {
                string str = File.ReadAllText(softwareConfigPath);

                softwareConfig = JsonSerializer.Deserialize<SoftwareConfigEntity>(str);

                this.Left = Convert.ToInt32(softwareConfig.X);
                this.Top = Convert.ToInt32(softwareConfig.Y);
                this.Width = Convert.ToInt32(softwareConfig.Width);
                this.Height = Convert.ToInt32(softwareConfig.Height);

                TextBox_FileName.Text = softwareConfig.FileName;
                TextBox_ModifyWidth.Text = softwareConfig.ModifyWidth.ToString();
                TextBox_ModifyHeight.Text = softwareConfig.ModifyHeight.ToString();

                useAPI = softwareConfig.UseAPI;
                ComboBox_UseAPI.SelectedIndex = useAPI;

                CheckBox_CenterScreen.Checked = softwareConfig.CenterScreen;

                bool withStartModify = softwareConfig.WithStartModify;
                CheckBox_WithStartModify.Checked = withStartModify;
                if (withStartModify)
                {
                    Modify(softwareConfig.FileName, softwareConfig.ModifyWidth, softwareConfig.ModifyHeight, softwareConfig.CenterScreen, true);
                }

                bool autoExit = softwareConfig.AutoExit;
                CheckBox_AutoExit.Checked = autoExit;
                if (autoExit)
                {
                    Environment.Exit(0);
                }

            }
        }

        private void SaveConfig()
        {
            softwareConfig.X = this.Left;
            softwareConfig.Y = this.Top;
            softwareConfig.Width = this.Width;
            softwareConfig.Height = this.Height;

            softwareConfig.FileName = TextBox_FileName.Text;
            softwareConfig.ModifyWidth = Convert.ToInt32(TextBox_ModifyWidth.Text);
            softwareConfig.ModifyHeight = Convert.ToInt32(TextBox_ModifyHeight.Text);
            softwareConfig.UseAPI = useAPI;
            softwareConfig.WithStartModify = CheckBox_WithStartModify.Checked;
            softwareConfig.AutoExit = CheckBox_AutoExit.Checked;
            softwareConfig.CenterScreen = CheckBox_CenterScreen.Checked;

            File.WriteAllText(softwareConfigPath, JsonSerializer.Serialize(softwareConfig), Encoding.UTF8);
        }


        public IntPtr GethWnd(string fileName)
        {
            IntPtr hWnd = IntPtr.Zero;

            if (File.Exists(fileName))
            {
                hWnd = GetProcessHandleByExePath(fileName);
            }
            else if (!string.IsNullOrEmpty(fileName))
            {
                hWnd = Win32API.FindWindow(null, fileName);
            }

            return hWnd;
        }

        public static IntPtr GetProcessHandleByExePath(string exePath)
        {
            // ��ȡ�����������еĽ���
            var processes = Process.GetProcesses();

            foreach (var process in processes)
            {
                try
                {
                    // �жϽ��̵��ļ�·���Ƿ���Ŀ��·��ƥ��
                    string processPath = process.MainModule.FileName;
                    if (string.Equals(processPath, exePath, StringComparison.OrdinalIgnoreCase))
                    {
                        // ���ؽ��̵� MainWindowHandle ���
                        return process.MainWindowHandle;
                        //return process.Handle;
                    }
                }
                catch (Exception ex)
                {
                    // ������ʽ���ģ��ʱ�����쳣��������Ȩ���������������˳�
                    Console.WriteLine("�޷����ʽ��� " + process.ProcessName + ": " + ex.Message);
                }
            }

            return IntPtr.Zero; // δ�ҵ�����
        }

        /// <summary>
        /// �޸Ĵ���
        /// </summary>
        public void Modify(string fileName, int newWidth, int newHeight, bool centerScreen = false, bool runFile = false)
        {
            if (runFile)
            {
                if (File.Exists(fileName))
                {
                    Process process = Process.Start(fileName);
                    process.WaitForInputIdle();
                }
            }

            IntPtr hWnd = GethWnd(fileName);

            if (hWnd != IntPtr.Zero)
            {
                int x = 0;
                int y = 0;

                if (centerScreen)
                {
                    int screenWidth = Screen.PrimaryScreen.Bounds.Width;
                    int screenHeight = Screen.PrimaryScreen.Bounds.Height;

                    x = (screenWidth - newWidth) / 2;
                    y = (screenHeight - newHeight) / 2;
                }
                else
                {
                    bool canGetWindowRect = Win32API.GetWindowRect(hWnd, out Win32API.RECT rect);

                    if (canGetWindowRect)
                    {
                        x = rect.Left;
                        y = rect.Top;
                    }
                    else
                    {
                        MessageBox.Show("�޷���ȡ���ڵĳߴ磬���������Ч��");
                        Trace.WriteLine("�޷���ȡ���ڵĳߴ磬���������Ч");
                    }
                    Trace.WriteLine($"����ԭʼλ�úͳߴ磺Left={rect.Left}, Top={rect.Top}, Width={rect.Right - rect.Left}, Height={rect.Bottom - rect.Top}");
                }

                int useAPIType = useAPI;//ComboBox_UseAPI.SelectedIndex;
                bool result = false;

                // ���ô��ڵ���ʽ
                Win32API.ShowWindow(hWnd, Win32API.SW_RESTORE);

                switch (useAPIType)
                {
                    case 0:
                        result = Win32API.MoveWindow(hWnd, x, y, newWidth, newHeight, true);
                        break;
                    case 1:
                        result = Win32API.SetWindowPos(hWnd, IntPtr.Zero, x, y, newWidth, newHeight, Win32API.SWP_NOZORDER);
                        break;
                }

                if (result)
                {
                    //MessageBox.Show("���ڴ�С�޸ĳɹ���");
                    Trace.WriteLine("���ڴ�С�޸ĳɹ�");
                }
                else
                {
                    MessageBox.Show("���ڴ�С�޸�ʧ�ܡ�");
                    Trace.WriteLine("���ڴ�С�޸�ʧ��");
                }
            }
            else
            {
                MessageBox.Show("δ�ҵ����ڡ�");
                Trace.WriteLine("δ�ҵ�����");
            }
        }

        private void Button_Select_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            DialogResult result = openFileDialog.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(openFileDialog.FileName))
                {
                    TextBox_FileName.Text = openFileDialog.FileName;
                }
            }
        }


        private void Button_SaveConfig_Click(object sender, EventArgs e)
        {
            SaveConfig();
        }


        private void Button_Modify_Click(object sender, EventArgs e)
        {
            string fileName = TextBox_FileName.Text;
            int newWidth = Convert.ToInt32(TextBox_ModifyWidth.Text);
            int newHeight = Convert.ToInt32(TextBox_ModifyHeight.Text);
            bool centerScreen = CheckBox_CenterScreen.Checked;

            Modify(fileName, newWidth, newHeight, centerScreen);
        }

        private void Button_StartModify_Click(object sender, EventArgs e)
        {
            string fileName = TextBox_FileName.Text;
            int newWidth = Convert.ToInt32(TextBox_ModifyWidth.Text);
            int newHeight = Convert.ToInt32(TextBox_ModifyHeight.Text);
            bool centerScreen = CheckBox_CenterScreen.Checked;

            Modify(fileName, newWidth, newHeight, centerScreen, true);
        }

        private void CheckBox_Notice_Click(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox.CheckState == CheckState.Checked)
            {
                MessageBox.Show("ע�⣺\r\n���ͬʱ��ѡ [����ʱ�Զ�Ӧ�óߴ�] �� [�޸ĺ��Զ��˳�] ���������������鿴���������Ӷ��޷�������������⡣\r\n\r\n����������£�\r\n[�Ƽ�] ɾ�����ͬĿ¼�µ� [CustomWindowConfig.json] �����ļ���������ý������á�\r\n[��Ҫһ������] ��������ļ��� \"autoExit:\" ��� true �޸�Ϊ false", "��Ҫ��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ComboBox_UseAPI_SelectedIndexChanged(object sender, EventArgs e)
        {
            useAPI = ComboBox_UseAPI.SelectedIndex;
        }
    }
}
