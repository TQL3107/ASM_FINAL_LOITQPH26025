using ASM_FINAL_LOITQPH26025.A.DAL.Models;
using ASM_FINAL_LOITQPH26025.B.BUS.Services;
using ASM_FINAL_LOITQPH26025.B.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace ASM_FINAL_LOITQPH26025.C.GUI.View
{
    public partial class FrmQLDiem : Form
    {
        StudentService _sv = new StudentService();
        GradeService _gr = new GradeService();
        List<GradeView> _grades = new List<GradeView>();
        private Grade gr;
        public Guid SelectID;
        public FrmQLDiem()
        {
            InitializeComponent();
            loaddata();
        }
        public void loaddata()
        {
            dtg_show.ColumnCount = 6;
            dtg_show.Columns[0].Name = "Id";
            dtg_show.Columns[0].Visible = false;
            dtg_show.Columns[1].Name = "Mã";
            dtg_show.Columns[2].Name = "Tên";
            dtg_show.Columns[3].Name = "Tiếng Anh";
            dtg_show.Columns[4].Name = "Tin";
            dtg_show.Columns[5].Name = "GDTC";
            dtg_show.Rows.Clear();
            foreach(var item in _gr.ShowViews().OrderBy(x =>x.grade.MaSv))
            {
                dtg_show.Rows.Add(item.grade.Id,item.grade.MaSv,item.student.HoTen,item.grade.TiengAnh,item.grade.TinHoc,item.grade.Gdtc);
            }    
        }

        private void dtg_show_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rd = e.RowIndex;
            if (rd == -1) return;
            SelectID = Guid.Parse(Convert.ToString(dtg_show.Rows[rd].Cells[0].Value));
            tb_ma.Text = Convert.ToString(dtg_show.Rows[rd].Cells[1].Value);
            lb_hoten.Text = Convert.ToString(dtg_show.Rows[rd].Cells[2].Value);
            tb_tienganh.Text = Convert.ToString(dtg_show.Rows[rd].Cells[3].Value);
            tb_tin.Text = Convert.ToString(dtg_show.Rows[rd].Cells[4].Value);
            tb_gdtc.Text = Convert.ToString(dtg_show.Rows[rd].Cells[5].Value);
           
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            loaddata();
            gr = null;
            tb_ma.Text = "";
            lb_hoten.Text = "";
            tb_tienganh.Text = "";
            tb_tin.Text = "";
            tb_gdtc.Text = "";
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn muốn thêm không", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show(_gr.Create(new Grade()
                {
                    Id = Guid.NewGuid(),
                    MaSv = "PH" + Convert.ToString(_gr.ShowAll()
                      .Max(c => Convert.ToInt32(c.MaSv.Substring(2, c.MaSv.Length - 3)) + 1)),
                    TiengAnh = Convert.ToInt32(tb_tienganh.Text),
                    TinHoc = Convert.ToInt32(tb_tin.Text),
                    Gdtc = Convert.ToInt32(tb_gdtc.Text),
                }));
                loaddata();
            }
            else
            {

                return;

            }
        }

        private void btn_detele_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn muốn xóa không", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show(_gr.Delete(SelectID));
                loaddata();
            }
            else
            {
                return;
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn muốn sửa không", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show(_gr.Update(SelectID, new Grade()
                {
                    MaSv = tb_ma.Text,
                    TiengAnh = Convert.ToInt32(tb_tienganh.Text),
                    TinHoc = Convert.ToInt32(tb_tin.Text),
                    Gdtc = Convert.ToInt32(tb_gdtc.Text),
                }));
                loaddata();
            }
            else
            {

                return;

            }
        }

        private void lb_diemtb_TextChanged(object sender, EventArgs e)
        {
           
        }

       

        private void btn_search_Click(object sender, EventArgs e)
        {
            dtg_show.Columns[0].Name = "Id";
            dtg_show.Columns[0].Visible = false;
            dtg_show.Columns[1].Name = "Mã";
            dtg_show.Columns[2].Name = "Tên";
            dtg_show.Columns[3].Name = "Tiếng Anh";
            dtg_show.Columns[4].Name = "Tin";
            dtg_show.Columns[5].Name = "GDTC";
            dtg_show.Rows.Clear();
            _grades = _gr.ShowViews();
            if (lb_hoten.Text != "")
            {
                _grades = _grades.Where(p => p.student.HoTen.Contains(lb_hoten.Text)).ToList();
            }
            foreach (var item in _grades)
            {
                dtg_show.Rows.Add(item.grade.Id, item.grade.MaSv, item.student.HoTen, item.grade.TiengAnh, item.grade.TinHoc, item.grade.Gdtc);
            }
        }
    }
}
