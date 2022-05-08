using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using StudentFC;
namespace Đồ_án_cuối_kì
{

    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static IStudent st;
        public static TcpClientChannel channel = new TcpClientChannel();
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FmConnect());
        }
    }
}
