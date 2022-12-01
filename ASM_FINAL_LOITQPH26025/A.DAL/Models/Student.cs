using System;
using System.Collections.Generic;

#nullable disable

namespace ASM_FINAL_LOITQPH26025.A.DAL.Models
{
    public partial class Student
    {
        public Student()
        {
            Grades = new HashSet<Grade>();
        }

        public Guid Id { get; set; }
        public string MaSv { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string SoDt { get; set; }
        public int Gioitinh { get; set; }
        public string DiaChi { get; set; }
        public byte[] Hinh { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
    }
}
