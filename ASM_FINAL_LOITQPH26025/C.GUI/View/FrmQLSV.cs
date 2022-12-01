using ASM_FINAL_LOITQPH26025.A.DAL.Models;
using ASM_FINAL_LOITQPH26025.B.BUS.Services;
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
    public partial class FrmQLSV : Form
    {
        StudentService sv = new StudentService();
        public Student st;
        public Guid? SelectID;
        public FrmQLSV()
        {
            InitializeComponent();
            loaddata();
        }
        public void loaddata()
        {
            dtg_show.ColumnCount = 8;
            dtg_show.Columns[0].Name = "Id";
            dtg_show.Columns[0].Visible = false; 
            dtg_show.Columns[1].Name = "Mã";
            dtg_show.Columns[2].Name = "Tên sinh viên ";
            dtg_show.Columns[3].Name = "Email";
            dtg_show.Columns[4].Name = "Sđt";
            dtg_show.Columns[5].Name = "Giới tính";
            dtg_show.Columns[6].Name = "Ảnh";
            dtg_show.Columns[7].Name = "Địa chỉ";
            dtg_show.Rows.Clear();
            var lstsv = sv.ShowAll();
            foreach (var item in lstsv)
            {
                dtg_show.Rows.Add(item.Id,item.MaSv, item.HoTen, item.Email, item.SoDt, item.Gioitinh == 0 ? "Nam" : "Nữ", item.Hinh, item.DiaChi);
            }
        }

        private void dtg_show_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rd = e.RowIndex;
            if (rd == -1 ) return;
            //sv = sv.ShowAll().FirstOrDefault(x => x.Id == Guid.Parse(Convert.ToString(dtg_show.Rows[rd].Cells[0].Value)));
            SelectID = Guid.Parse(Convert.ToString(dtg_show.Rows[rd].Cells[0].Value));
            tb_ma.Text = Convert.ToString(dtg_show.Rows[rd].Cells[1].Value);
            tb_name.Text = Convert.ToString(dtg_show.Rows[rd].Cells[2].Value);
            tb_mail.Text = Convert.ToString(dtg_show.Rows[rd].Cells[3].Value);
            tb_sdt.Text = Convert.ToString(dtg_show.Rows[rd].Cells[4].Value);
            rd_nam.Checked = Convert.ToString(dtg_show.Rows[rd].Cells[5].Value) == "Nam";
            rd_nu.Checked = Convert.ToString(dtg_show.Rows[rd].Cells[5].Value) == "Nữ";
            // pic_Anh.Image = Image.FromStream(new MemoryStream((byte[])dtg_show.Rows[rd].Cells[6].Value));
            pic_Anh.SizeMode = PictureBoxSizeMode.StretchImage;
            tb_diachi.Text = Convert.ToString(dtg_show.Rows[rd].Cells[7].Value);
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            loaddata();
            st = null;
            tb_ma.Text = "";
            tb_name.Text = "";
            tb_mail.Text = "";
            tb_sdt.Text = "";
            rd_nam.Checked = false;
            rd_nu.Checked = false;
            pic_Anh.Image = null;
            tb_diachi.Text = "";
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn muốn thêm không", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show(sv.Create(new Student()
                {
                    Id =  Guid.NewGuid(),
                    MaSv = "PH" + Convert.ToString(sv.ShowAll()
                      .Max(c => Convert.ToInt32(c.MaSv.Substring(2, c.MaSv.Length - 3)) + 1)),
                    HoTen = tb_name.Text,
                    Email = tb_mail.Text,
                    SoDt = tb_sdt.Text,
                    Gioitinh = rd_nam.Checked ? 0 : 1 ,
                    Hinh = (byte[])(new ImageConverter().ConvertTo(pic_Anh.Image, typeof(byte[]))),
                    DiaChi = tb_diachi.Text,
                }));
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
                MessageBox.Show(sv.Update(SelectID,new Student()
                {
                    MaSv = tb_ma.Text,
                    HoTen = tb_name.Text,
                    Email = tb_mail.Text,
                    SoDt = tb_sdt.Text,
                    Gioitinh = rd_nam.Checked ? 0 : 1,
                    Hinh = (byte[])(new ImageConverter().ConvertTo(pic_Anh.Image, typeof(byte[]))),
                    DiaChi = tb_diachi.Text,
                }));
                loaddata();
            }
            else
            {

                return;

            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn muốn xóa không", "Thông báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show(sv.Delete(SelectID));
                loaddata();
            }
            else
            {
                return;
            }
        }

        private void pic_Anh_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            try
            {

                if (open.ShowDialog() == DialogResult.OK)
                {
                    pic_Anh.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic_Anh.Image = Image.FromFile(open.FileName);
                    //LinkImage = open.FileName;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(Convert.ToString(ex.Message), "Liên hệ với Lợi để khắc phục");
            }
        }
    }
}
