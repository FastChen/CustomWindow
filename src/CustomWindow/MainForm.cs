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
            // 获取所有正在运行的进程
            var processes = Process.GetProcesses();

            foreach (var process in processes)
            {
                try
                {
                    // 判断进程的文件路径是否与目标路径匹配
                    string processPath = process.MainModule.FileName;
                    if (string.Equals(processPath, exePath, StringComparison.OrdinalIgnoreCase))
                    {
                        // 返回进程的 MainWindowHandle 句柄
                        return process.MainWindowHandle;
                        //return process.Handle;
                    }
                }
                catch (Exception ex)
                {
                    // 如果访问进程模块时出现异常，可能是权限问题或进程正在退出
                    Console.WriteLine("无法访问进程 " + process.ProcessName + ": " + ex.Message);
                }
            }

            return IntPtr.Zero; // 未找到进程
        }

        /// <summary>
        /// 修改窗口
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
                        MessageBox.Show("无法获取窗口的尺寸，句柄可能无效。");
                        Trace.WriteLine("无法获取窗口的尺寸，句柄可能无效");
                    }
                    Trace.WriteLine($"窗口原始位置和尺寸：Left={rect.Left}, Top={rect.Top}, Width={rect.Right - rect.Left}, Height={rect.Bottom - rect.Top}");
                }

                int useAPIType = useAPI;//ComboBox_UseAPI.SelectedIndex;
                bool result = false;

                // 设置窗口的样式
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
                    //MessageBox.Show("窗口大小修改成功。");
                    Trace.WriteLine("窗口大小修改成功");
                }
                else
                {
                    MessageBox.Show("窗口大小修改失败。");
                    Trace.WriteLine("窗口大小修改失败");
                }
            }
            else
            {
                MessageBox.Show("未找到窗口。");
                Trace.WriteLine("未找到窗口");
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
                MessageBox.Show("注意：\r\n如果同时勾选 [启动时自动应用尺寸] 与 [修改后自动退出] 会遇到不能正常查看到软件界面从而无法配置软件的问题。\r\n\r\n解决方案如下：\r\n[推荐] 删除软件同目录下的 [CustomWindowConfig.json] 配置文件对软件配置进行重置。\r\n[需要一定经验] 或打开配置文件将 \"autoExit:\" 后的 true 修改为 false", "重要提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ComboBox_UseAPI_SelectedIndexChanged(object sender, EventArgs e)
        {
            useAPI = ComboBox_UseAPI.SelectedIndex;
        }
    }
}
