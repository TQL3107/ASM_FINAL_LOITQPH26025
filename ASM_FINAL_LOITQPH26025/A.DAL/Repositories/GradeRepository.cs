using ASM_FINAL_LOITQPH26025.A.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_FINAL_LOITQPH26025.A.DAL.Repositories
{
    internal class GradeRepository
    {
        ASMFINAL_NET103Context context = new ASMFINAL_NET103Context();
        public GradeRepository()
        {
                
        }
        public List<Grade> GetAll()
        {
            return context.Grades.ToList();
        }
        public bool Delete(Guid ? id )
        {
            if (id == null) return false;
            var a = context.Grades.FirstOrDefault(x => x.Id == id);
            context.Update(a);
            context.SaveChanges();
            return true;
        }
        public bool Add(Grade grade)
        {
            if (grade == null) return false;    
            context.Add(grade);
            context.SaveChanges();
            return true;
        }
        public bool Edit(Guid ? id, Grade grade)
        {
            if (grade == null) return false;
            var a = context.Grades.FirstOrDefault(x => x.Id == id);
            a.MaSv = grade.MaSv;
            a.TinHoc = grade.TinHoc;
            a.TiengAnh = grade.TiengAnh;
            a.Gdtc = grade.Gdtc;
            context.Update(a);
            context.SaveChanges();
            return true;
        }
      
    }
}
