using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace StockServer
{

    public partial class Form1 : Form
    {
        private StockDataServer dataServer;
        private Logger logger;
        public Form1()
        {
            InitializeComponent();
            logger = new Logger("logfile.txt");
            // 初始化数据服务器
            dataServer = new StockDataServer(logger);
            btnStartServer.BackColor = Color.Gray;
        }
        private void btnStartServer_Click(object sender, EventArgs e)
        {     
            string server = txtBoxIP.Text;
            string portText = txtBoxPort.Text;
            // 检查服Server地址和port是否有效
            if (!IsValidIPAddress(server))
            {
                MessageBox.Show("無效的伺服器IP。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(portText, out int port) || port < 0 || port > 65535)
            {
                MessageBox.Show("無效的port號碼。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dataServer.StartServer(server, port);
            // 更改按钮颜色为绿色
            btnStartServer.BackColor = Color.Green;

            // 禁用按钮，防止重复点击
            btnStartServer.Enabled = false;
        }
        // 验证IP地址格式是否正确
        private bool IsValidIPAddress(string ipAddress)
        {
            return IPAddress.TryParse(ipAddress, out _);
        }

        private void SocketServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataServer?.StopServer();
        }
    }    
}
