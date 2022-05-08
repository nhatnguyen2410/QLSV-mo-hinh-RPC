using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentFC;
namespace DeTaiCuoiKi
{
    class StudentServer : MarshalByRefObject, IStudent
    {
        public List<Student> DSSV()
        {
            List<Student> listStudents = new List<Student>();
            listStudents.Add(new Student { MSSV = "N18DCCN141", Hoten = "Nguyen Long Nhat", Lop = "D18CQCP02-N", DiaChi = "Quan 9 HCM", SDT = "093214652", DiemTongKet = 6.7 });
            listStudents.Add(new Student { MSSV = "N18DCCN121", Hoten = "Nguyen Van Nam", Lop = "D18CQCP02-N", DiaChi = "Quan 8 HCM", SDT = "0932146234", DiemTongKet = 7.7 });
            listStudents.Add(new Student { MSSV = "N18DCCN151", Hoten = "Nguyen Thi Ha", Lop = "D18CQCP02-N", DiaChi = "Quan 1 HCM", SDT = "093221452", DiemTongKet = 6.2 });
            listStudents.Add(new Student { MSSV = "N18DCCN180", Hoten = "Le Ba Khanh", Lop = "D18CQCP02-N", DiaChi = "Quan 2 HCM", SDT = "0932146675", DiemTongKet = 10 });
            listStudents.Add(new Student { MSSV = "N18DCCN191", Hoten = "Luong Dinh Khang", Lop = "D18CQCP02-N", DiaChi = "Quan 3 HCM", SDT = "025214652", DiemTongKet = 1.1 });

            return listStudents;
        }


        public void delete(ref List<Student> st, string mssv)
        {
            Student s = st.FirstOrDefault(i => i.MSSV == mssv);
            st.Remove(s);
        }

        public int insert(ref List<Student> st, Student sv)
        {
            foreach (Student item in st)
            {
                if (item.MSSV == sv.MSSV)
                {
                    return 1;
                }
            }
            st.Insert(st.Count, sv);
            return 0;
        }

        public void edit(ref List<Student> st, Student sv)
        {
            int index = st.FindIndex(x => x.MSSV == sv.MSSV);
            st[index].Hoten = sv.Hoten;
            st[index].Lop = sv.Lop;
            st[index].SDT = sv.SDT;
            st[index].DiaChi = sv.DiaChi;
            st[index].DiemTongKet = sv.DiemTongKet;
        }
    }
}
