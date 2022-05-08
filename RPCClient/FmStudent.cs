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
using System.Text.RegularExpressions;
using StudentFC;

namespace Đồ_án_cuối_kì
{
    public partial class FmStudent : Form
    {
        int action = 0;
        public FmStudent()
        {
            InitializeComponent();
        }


        List<Student> newlist = new List<Student>(Program.st.DSSV());

        private void FmStudent_Load(object sender, EventArgs e)
        {

            GV_SV.DataSource = newlist;
            GV_SV.ReadOnly = true;
            txtMSSV.DataBindings.Clear();
            txtMSSV.DataBindings.Add("text", GV_SV.DataSource, "MSSV");
            txtHoTen.DataBindings.Clear();
            txtHoTen.DataBindings.Add("text", GV_SV.DataSource, "HoTen");
            txtLop.DataBindings.Clear();
            txtLop.DataBindings.Add("text", GV_SV.DataSource, "Lop");
            txtDC.DataBindings.Clear();
            txtDC.DataBindings.Add("text", GV_SV.DataSource, "DiaChi");
            txtSDT.DataBindings.Clear();
            txtSDT.DataBindings.Add("text", GV_SV.DataSource, "SDT");
            txtDTK.DataBindings.Clear();
            txtDTK.DataBindings.Add("text", GV_SV.DataSource, "DiemTongKet");
            btnLuu.Enabled = false;
        }


        private void FmStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            ChannelServices.UnregisterChannel(Program.channel);
        }



        private void btnExit_Click(object sender, EventArgs e)
        {
            if (action == 1 || action == 2)
            {
                panel1.Enabled = false;
                GV_SV.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnThem.Enabled = true;
                btnLuu.Enabled = false;
                FmStudent_Load(sender, e);
                action = 0;
            }
            else
            {
                if (MessageBox.Show("Bạn chắc chắn muốn thoát chương trình?\n", "Thông báo",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    this.Close();
                }

            }


        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Double DTK = double.Parse(txtDTK.Text);

            if (txtMSSV.Text.Equals(""))
            {
                MessageBox.Show("Không được để trống mã sinh viên!\n", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMSSV.Focus();
                return;
            }
            else if (txtHoTen.Text.Equals(""))
            {
                MessageBox.Show("Không được để trống họ và tên!\n", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoTen.Focus();
                return;

            }
            else if (txtLop.Text.Equals(""))
            {
                MessageBox.Show("Không được để trống mã lớp!\n", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLop.Focus();
                return;

            }
            else if(DTK<0 ||DTK>10)
            {
                MessageBox.Show("Số điểm không hợp lệ vui lòng nhập lại!\n", "Thông báo",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLop.Focus();
                return;
            }    
            else if (txtSDT.Text.Equals(""))
            {
                MessageBox.Show("Không được để trống mã SDT!\n", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT.Focus();
                return;

            }
            else if (txtDTK.Text.Equals(""))
            {
                MessageBox.Show("Không được để trống mã điểm trung bình!\n", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDTK.Focus();
                return;

            }
            else if (txtDC.Text.Equals(""))
            {
                MessageBox.Show("Không được để trống mã địa chỉ!\n", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDC.Focus();
                return;

            }
           
            else if (!Regex.IsMatch(txtMSSV.Text, "^[a-zA-Z0-9]*$"))
            {
                MessageBox.Show("Định dạng mã sinh viên không đúng! Xin kiểm tra lại!\n", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMSSV.Focus();
                return;

            }
            else if (Regex.IsMatch(txtHoTen.Text, "^[0-9]$"))
            {
                MessageBox.Show("Định dạng họ tên không đúng! Xin kiểm tra lại!\n", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoTen.Focus();
                return;

            }
            else if (!Regex.IsMatch(txtLop.Text, "^[a-zA-Z0-9-]*$"))
            {
                MessageBox.Show("Định dạng mã lớp không đúng! Xin kiểm tra lại!\n", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLop.Focus();
                return;

            }
            else if (!Regex.IsMatch(txtSDT.Text, "^[0]{1}[0-9]{9}$"))
            {
                MessageBox.Show("Định dạng số điện thoại không đúng! Xin kiểm tra lại!\n", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSDT.Focus();
                return;

            }
            else if (!Regex.IsMatch(txtDTK.Text, "[0-9.]"))
            {
                MessageBox.Show("Định dạng điểm tổng kết không đúng! Xin kiểm tra lại!\n", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDTK.Focus();
                return;

            }
            if (action == 1)
            {
                Student sv = new Student { MSSV = txtMSSV.Text.ToUpper(), Hoten = txtHoTen.Text, Lop = txtLop.Text, DiaChi = txtDC.Text, SDT = txtSDT.Text, DiemTongKet = Double.Parse(txtDTK.Text) };

                if (Program.st.insert(ref newlist, sv) == 1)
                {
                    MessageBox.Show("Mã sinh viên bị trùng không thể thêm!\n", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else

                {
                    MessageBox.Show("Thêm sinh viên thành công!\n", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            else if (action == 2)
            {

                Student sv = new Student { MSSV = txtMSSV.Text, Hoten = txtHoTen.Text, Lop = txtLop.Text, DiaChi = txtDC.Text, SDT = txtSDT.Text, DiemTongKet = Double.Parse(txtDTK.Text) };
                Program.st.edit(ref newlist, sv);
                MessageBox.Show("Hiệu chỉnh sinh viên thành công!\n", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            GV_SV.Enabled = true;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            panel1.Enabled = false;
            GV_SV.DataBindings.Clear();
            FmStudent_Load(sender, e);
            GV_SV.ClearSelection();
            if (action == 1)
            {
                GV_SV.Rows[GV_SV.RowCount - 1].Selected = true;
            }

            action = 0;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            string mssv = txtMSSV.Text;
            Program.st.delete(ref newlist, mssv);
            if (MessageBox.Show("Bạn chắc chắn muốn xoá sinh viên này?\n", "Thông báo",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GV_SV.DataBindings.Clear();
                FmStudent_Load(sender, e);
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            action = 1;
            btnThem.Enabled = false;
            panel1.Enabled = true;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            GV_SV.Enabled = false;
            txtMSSV.Enabled = true;
            txtMSSV.Text = "";
            txtHoTen.Text = "";
            txtLop.Text = "";
            txtSDT.Text = "";
            txtDC.Text = "";
            txtDTK.Text = "";
            txtDTK.DataBindings.Clear();
            txtSDT.DataBindings.Clear();
            txtDC.DataBindings.Clear();
            txtLop.DataBindings.Clear();
            txtHoTen.DataBindings.Clear();
            txtMSSV.DataBindings.Clear();


        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            panel1.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            GV_SV.Enabled = false;
            txtMSSV.Enabled = false;
            action = 2;
        }

        private void GV_SV_SelectionChanged(object sender, EventArgs e)
        {

        }
    }
}
