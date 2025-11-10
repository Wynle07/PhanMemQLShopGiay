using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiBanGiay
{
    public partial class Form_TaoHoaDon : Form
    {
        public Form_TaoHoaDon()
        {
            InitializeComponent();
        }

        private void btnXuatHD_Click(object sender, EventArgs e)
        {
            Form_HoaDon frm = new Form_HoaDon(); // Tạo form mới
            frm.Show();
        }
    }
}
