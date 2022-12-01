using System;
using System.Collections.Generic;

#nullable disable

namespace ASM_FINAL_LOITQPH26025.A.DAL.Models
{
    public partial class Grade
    {
        public Guid Id { get; set; }
        public string MaSv { get; set; }
        public int TiengAnh { get; set; }
        public int TinHoc { get; set; }
        public int Gdtc { get; set; }

        public virtual Student MaSvNavigation { get; set; }
    }
}
