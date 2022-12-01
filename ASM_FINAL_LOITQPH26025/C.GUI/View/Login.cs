using ASM_FINAL_LOITQPH26025.A.DAL.Models;
using ASM_FINAL_LOITQPH26025.B.BUS.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASM_FINAL_LOITQPH26025.C.GUI.View
{
    public partial class Login : Form
    {
        UserService us = new UserService();
        private User user;
        public Login()
        {
            InitializeComponent();
            User user = new User();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (us.CheckEmtyDB())
            {
                MessageBox.Show("There is no Account exists in database, please create a new one");
            }
            else
            {
                User ur = us.CheckLogin(txt_username.Text, txt_password.Text );
                if (ur == null) MessageBox.Show("The Account does not exists!");
                else
                {    
                   if (ur.Role == "CanBo")
                    {
                        FrmQLSV frm = new FrmQLSV();
                        frm.ShowDialog();
                    }
                    else
                    {
                        FrmQLDiem frm = new FrmQLDiem();
                        frm.ShowDialog();
                    } 
                        
                }
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
