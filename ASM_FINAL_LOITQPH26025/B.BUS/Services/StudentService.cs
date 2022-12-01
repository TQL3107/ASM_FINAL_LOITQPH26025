using ASM_FINAL_LOITQPH26025.A.DAL.Models;
using ASM_FINAL_LOITQPH26025.A.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_FINAL_LOITQPH26025.B.BUS.Services
{
    internal class StudentService
    {
        StudentRepository sv = new StudentRepository();
        public List<Student> ShowAll()
        {
            return sv.GetAll();
        }
        public string Delete(Guid? id)
        {
            sv.Delete(id);
            return "Xóa điểm thành công";
        }
        public string Create(Student student)
        {
            if (student == null) return "Thêm mới thất bại";
            sv.Add(student);
            return "Thêm mới thành công";
        }
        public string Update(Guid? id,Student student)
        {
            sv.Edit(id, student);
            return "Sửa thành công";
        }
    }
}
