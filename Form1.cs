using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab02_2
{
    public partial class frmQuanLySinhVien_Load : Form
    {
        public frmQuanLySinhVien_Load()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void frmQuanLySinhVien_Load_Load(object sender, EventArgs e)
        {
            cmbKhoa.SelectedIndex = 0;
        }

        private int GetSeletedRow(string mssv)
        {
            for (int i = 0; i < dgvStudent.Rows.Count; i++)
            {
                if(dgvStudent.Rows[i].Cells[0].Value != null)
                {
                    if(dgvStudent.Rows[i].Cells[0].Value.ToString() == mssv)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        private void InsertUpdate(int selectedRow)
        {
            dgvStudent.Rows[selectedRow].Cells[0].Value = txtStudentID.Text;
            dgvStudent.Rows[selectedRow].Cells[1].Value = txtFullname.Text;
            dgvStudent.Rows[selectedRow].Cells[2].Value = rdoNu.Checked ? "Nữ " : "Nam";
            dgvStudent.Rows[selectedRow].Cells[3].Value =
            float.Parse(txtdtb.Text).ToString();
            dgvStudent.Rows[selectedRow].Cells[4].Value = cmbKhoa.Text;
         }
        private void sum()
        {
            int sNu = 0, sNa = 0;
            for (int i=0;i < dgvStudent.Rows.Count; i++)
            {
                if(dgvStudent.Rows[i].Cells[0].Value != null)
                {
                    if(dgvStudent.Rows[i].Cells[2].Value.ToString() == "Nữ")
                    {
                        sNu++;
                    }
                    else
                    {
                        sNa++;
                    }
                }
            }
            txtSumNu.Text = sNu.ToString();
            txtSumNam.Text = sNa.ToString();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStudentID.Text == "" || txtFullname.Text == "" || txtdtb.Text == "")
                    throw new Exception("Bạn chưa nhập đủ thông tin");

                int selectedRow = GetSeletedRow(txtStudentID.Text);
                if (selectedRow == -1)
                {
                    selectedRow = dgvStudent.Rows.Add();
                    InsertUpdate(selectedRow);
                    MessageBox.Show("Them Sinh Vien thanh Cong!", "Thong Bao", MessageBoxButtons.OK);
                    sum();
                }
                else
                {
                    InsertUpdate(selectedRow);
                    MessageBox.Show("Sua sinh vien moi thanh cong!", "Thong Bao", MessageBoxButtons.OK);
                    sum();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int seletedRow = GetSeletedRow(txtStudentID.Text);
                if(seletedRow == -1)
                {
                    throw new Exception("Khong tim thay mssv can xoa!");
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Ban co muon xoa ?", "YES/NO", MessageBoxButtons.YesNo);
                    if(dr == DialogResult.Yes)
                    {
                        dgvStudent.Rows.RemoveAt(seletedRow);
                        MessageBox.Show("Xoa xinh vien thanh cong!", "Thong bao", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvStudent.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    dgvStudent.CurrentRow.Selected = true;
                    txtStudentID.Text = dgvStudent.Rows[e.RowIndex].Cells["dgvMSSV"].FormattedValue.ToString();
                    txtFullname.Text = dgvStudent.Rows[e.RowIndex].Cells["dgvName"].FormattedValue.ToString();
                    txtdtb.Text = dgvStudent.Rows[e.RowIndex].Cells["dgvDTB"].FormattedValue.ToString();

                    if (dgvStudent.Rows[e.RowIndex].Cells["dgvGioitinh"].FormattedValue.ToString() == "Nữ")
                    {
                        rdoNu.Checked = true;
                    }
                    else
                    {
                        rdoNam.Checked = true;
                    }

                    cmbKhoa.SelectedItem = dgvStudent.Rows[e.RowIndex].Cells["dgvKhoa"].FormattedValue.ToString();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
