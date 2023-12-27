using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace StockServer
{

    public partial class Form1 : Form
    {
        private StockDataServer dataServer;
        public Form1()
        {
            InitializeComponent();
            // 初始化数据服务器
            dataServer = new StockDataServer();
            btnStartServer.BackColor = Color.Gray;
        }
        private void btnStartServer_Click(object sender, EventArgs e)
        {
            string ip = txtBoxIP.Text;
            int port = int.Parse(txtBoxPort.Text);
            dataServer.StartServer(ip, port);
            // 更改按钮颜色为绿色
            btnStartServer.BackColor = Color.Green;

            // 禁用按钮，防止重复点击
            btnStartServer.Enabled = false;
        }

        private void SocketServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataServer?.StopServer();
        }
    }    
}
