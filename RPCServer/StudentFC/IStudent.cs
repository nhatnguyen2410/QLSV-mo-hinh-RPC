using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentFC
{
    public interface IStudent
    {
        List<Student> DSSV();
        void delete(ref List<Student> st, string mssv);
        int insert(ref List<Student> st, Student sv);
        void edit(ref List<Student> st, Student sv);
    }
}
