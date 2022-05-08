using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using StudentFC;
namespace DeTaiCuoiKi
{
    public partial class fmServer : Form
    {
        public fmServer()
        {
            InitializeComponent();
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            try
            {
                String port = txtPort.Text;
                int p = int.Parse(port);
                TcpServerChannel channel = new TcpServerChannel(p);
                ChannelServices.RegisterChannel(channel, false);
                RemotingConfiguration.RegisterWellKnownServiceType(typeof(StudentServer), "Nhathk", WellKnownObjectMode.SingleCall);
                txtND.Text = "Server khởi động thành công.\nĐang chờ kết nối...";
            }
            catch
            {
                txtND.Text = "Không thể khởi động được server! Xin hãy kiểm tra lại port.";
            }
        }
    }
}
