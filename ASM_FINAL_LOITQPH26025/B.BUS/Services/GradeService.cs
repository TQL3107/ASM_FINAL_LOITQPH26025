using ASM_FINAL_LOITQPH26025.A.DAL.Models;
using ASM_FINAL_LOITQPH26025.A.DAL.Repositories;
using ASM_FINAL_LOITQPH26025.B.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_FINAL_LOITQPH26025.B.BUS.Services
{
    internal class GradeService
    {
        GradeRepository rd = new GradeRepository();
        private List<GradeView> _lstgradeViews;
        StudentRepository str = new StudentRepository();
        public List <Grade> ShowAll()
        {
            return rd.GetAll();
        }
        public string Delete(Guid? id)
        {
            if (rd.Delete(id)) return "Xóa điểm thành công";
            else return "Xóa điểm thất bại";
        }
        public string Create(Grade grade)
        {
            if (grade == null) return "Thêm mới thất bại";
            rd.Add(grade);
            return "Thêm mới thành công";
        }
        public string Update(Guid? id,Grade grade)
        {
            rd.Edit(id,grade);
            return "Sửa thành công";
        }
        public List<GradeView> ShowViews()
        {
            _lstgradeViews = (from gr in ShowAll()
                              join st in str.GetAll() on gr.MaSv equals st.MaSv
                              select new GradeView
                              {
                                  grade = gr ,
                                  student = st,
                              }).ToList();
            return _lstgradeViews;
        }
       
    }
}
