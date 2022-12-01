using ASM_FINAL_LOITQPH26025.A.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_FINAL_LOITQPH26025.A.DAL.Repositories
{
    internal class StudentRepository
    {
        ASMFINAL_NET103Context context = new ASMFINAL_NET103Context();  
        public List<Student> GetAll()
        {
            return context.Students.ToList();
        }
        public bool Delete(Guid? id)
        {
            if (id == null) return false;
            var a = context.Students.FirstOrDefault(x => x.Id == id);
            context.Update(a);
            context.SaveChanges();
            return true;

        }
        public bool Add(Student student)
        {
            if (student == null) return false;
            context.Add(student);
            context.SaveChanges();
            return true ;
        }
        public bool Edit(Guid? id,Student student)
        {
            if (student == null) return false;
            var a = context.Students.FirstOrDefault(x => x.Id == id);
            a.MaSv = student.MaSv;
            a.HoTen = student.HoTen;
            a.SoDt = student.SoDt;
            a.Hinh = student.Hinh;
            a.Gioitinh = student.Gioitinh;
            a.DiaChi = student.DiaChi;
            context.Update(a);
            context.SaveChanges();
            return true;

        }
    }
}
