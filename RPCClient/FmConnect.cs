using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using StudentFC;
namespace Đồ_án_cuối_kì
{
    public partial class FmConnect : Form
    {
        public FmConnect()
        {
            InitializeComponent();
        }
        String host = "";
        String port = "";
        String query = "";


        private void btnConnect_Click(object sender, EventArgs e)
        {

            try
            {

                if (txtPort.Text == "" && txtServerHost.Text == "")
                {
                    MessageBox.Show("Không được để trống Thông tin\n", "Thông báo",
                           MessageBoxButtons.OK);
                    txtServerHost.Focus();

                }

                else if (txtPort.Text.Equals("") == true)
                {
                    MessageBox.Show("Không được để trống Port\n", "Thông báo",
                           MessageBoxButtons.OK);
                    txtPort.Focus();
                }
                else if (txtServerHost.Text.Equals("") == true)
                {
                    MessageBox.Show("Không được để trống Host\n", "Thông báo",
                           MessageBoxButtons.OK);
                    txtServerHost.Focus();

                }
                else
                {
                    host = txtServerHost.Text.Trim();
                    port = txtPort.Text.Trim();
                    query = "tcp://" + host + ":" + port + "/Nhathk";
                    ChannelServices.RegisterChannel(Program.channel, false);
                    IStudent iST = (IStudent)(Activator.GetObject(typeof(IStudent)
                                                , query));
                    Program.st = iST;
                    FmStudent fmst = new FmStudent();
                    MessageBox.Show("Kết nối thành công !\n", "Thông báo",
                            MessageBoxButtons.OK);
                    fmst.ShowDialog();


                }
            }
            catch
            {
                MessageBox.Show("Kết nối thất bại !\n", "Thông báo",
                            MessageBoxButtons.OK);
                ChannelServices.UnregisterChannel(Program.channel);
            }
        }

        private void FmConnect_Load(object sender, EventArgs e)
        {

        }
    }
}
