using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDoanhThu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        Modify modify =new Modify();
        QuanLyDoanhThu quanLy;

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                
                dataGridView1.DataSource = modify.Table("Select * from CLB");

            }catch(Exception ex) 
            {
                MessageBox.Show("Có lỗi xảy ra!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            DeleteTextBoxes();
        }

        private void comboBox_CLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox_CLB.SelectedIndex == 0)
            {
                textBox_GiaVe.Text = "10";
                textBox_TenNuoc.Text = "ANH";
            }
            if (comboBox_CLB.SelectedIndex == 1)
            {
                textBox_GiaVe.Text = "12";
                textBox_TenNuoc.Text = "PHÁP";
            }
            if (comboBox_CLB.SelectedIndex == 2)
            {
                textBox_GiaVe.Text = "10";
                textBox_TenNuoc.Text = "TÂY BAN NHA";
            }
            if (comboBox_CLB.SelectedIndex == 3)
            {
                textBox_GiaVe.Text = "7";
                textBox_TenNuoc.Text = "BỒ ĐÀO NHA";
            }
            if (comboBox_CLB.SelectedIndex == 4)
            {
                textBox_GiaVe.Text = "12";
                textBox_TenNuoc.Text = "Ý";
            }
            if (comboBox_CLB.SelectedIndex == 5)
            {
                textBox_GiaVe.Text = "10";
                textBox_TenNuoc.Text = "TÂY BAN NHA";
            }
            if (comboBox_CLB.SelectedIndex == 6)
            {
                textBox_GiaVe.Text = "10";
                textBox_TenNuoc.Text = "ĐỨC";
            }
            if (comboBox_CLB.SelectedIndex == 7)
            {
                textBox_GiaVe.Text = "11";
                textBox_TenNuoc.Text = "Ý";
            }
        }

        private void textBox_SLVe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled= true;
            }
        }



        private void DeleteTextBoxes()
        {
            comboBox_CLB.SelectedIndex = -1;
            textBox_GiaVe.Text = "";
            textBox_SLVe.Text = "";
            textBox_TenNuoc.Text = "";

        }


        private bool CheckTextBoxes()
        {
            if(comboBox_CLB.SelectedIndex == -1) { MessageBox.Show("Mời chọn câu lạc bộ"); return false; }
            if (textBox_SLVe.Text == "") { MessageBox.Show("Mời nhập số lượng vé"); return false; }
            return true;
        }


        public void GetValuesTextBoxes()
        {
            string _tenCLB = comboBox_CLB.Text;
            string _tenNuoc = textBox_TenNuoc.Text;
            int _slVe = int.Parse(textBox_SLVe.Text);
            double _giaVe = double.Parse(textBox_GiaVe.Text);
            quanLy = new QuanLyDoanhThu(_tenCLB, _tenNuoc, _slVe, _giaVe);
        }

        private void button_Them_Click(object sender, EventArgs e)
        {
            if(CheckTextBoxes())
            {
                GetValuesTextBoxes();
                string query = "Insert into CLB values('" + quanLy.TenCLB + "',N'" + quanLy.TenNuoc + "'," + quanLy.SlVe + "," + quanLy.GiaVe + "," + quanLy.DoanhThu() + ")";
                try
                {

                    if(MessageBox.Show("Bạn có thực sự muốn thêm","Xác nhận",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        modify.Command(query);
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form1_Load(sender, e);
                    }    
                    

                }
                catch(Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void button_Sua_Click(object sender, EventArgs e)
        {
            if (CheckTextBoxes())
            {
                GetValuesTextBoxes();
                string query = "Update CLB set TenNuoc = N'" + quanLy.TenNuoc + "', SoLuongVe = " + quanLy.SlVe + ", GiaVe =" + quanLy.GiaVe + ", TongTien = " + quanLy.DoanhThu() + "where TenCauLacBo ='" + quanLy.TenCLB + "'";
                try
                {

                    if (MessageBox.Show("Bạn có thực sự muốn sửa thông tin", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        modify.Command(query);
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form1_Load(sender, e);
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                comboBox_CLB.SelectedItem = dataGridView1.Rows[0].Cells[0].Value.ToString();
                textBox_TenNuoc.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
                textBox_SLVe.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
                textBox_GiaVe.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
            }

        }

        private void button_Xoa_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                string choose = dataGridView1.SelectedCells[0].Value.ToString();
                string query = "Delete CLB where TenCauLacBo ='" + choose + "'";
                try
                {

                    if (MessageBox.Show("Bạn có thực sự muốn xóa thông tin", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        modify.Command(query);
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form1_Load(sender, e);
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }    

            
        }

        private void textBox_TimKiem_TextChanged(object sender, EventArgs e)
        {
            if(textBox_TimKiem.Text == "")
            {
                Form1_Load(sender, e);
            }
            else
            {
                string query = "select * from CLB where TenCauLacBo like '%" + textBox_TimKiem.Text+ "%'";
                dataGridView1.DataSource = modify.Table(query);

            }    
        }

        private void button_Thoat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có thực sự muốn thoát ?","Xác nhận",MessageBoxButtons.YesNo, MessageBoxIcon.Information) ==DialogResult.Yes)
            {
                Application.Exit();
            }    
        }
    }
}
