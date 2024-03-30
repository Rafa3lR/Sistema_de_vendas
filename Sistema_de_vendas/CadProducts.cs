using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_vendas
{
    public partial class CadProducts : Form
    {
        public CadProducts()
        {
            InitializeComponent();
            if (mode == 1)
            {
                tbPrice.Text = Stock.Price[Products.index].ToString();
                tbQuant.Text = Stock.QTDE[Products.index].ToString();
                tbName.Text = Stock.ProductName[Products.index];
            }
            else if (mode == 0)
            {
                btnDelete.Hide();
            }
        }

        public static int mode = 0;
        private int quantProds = 1;

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult delete = MessageBox.Show("Are you sure?", "Delete product", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (delete == DialogResult.OK)
            {
                Stock.ID.RemoveAt(Products.index);
                Stock.ProductName.RemoveAt(Products.index);
                Stock.QTDE.RemoveAt(Products.index);
                Stock.Price.RemoveAt(Products.index);

                SaveInTXT.WriteTXT();

                tbName.Text = "";
                tbQuant.Text = "";
                tbPrice.Text = "";
                this.Close();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (mode == 0)
                {
                    Stock.ID.Add(quantProds);
                    Stock.QTDE.Add(Convert.ToSingle(tbQuant.Text));
                    Stock.Price.Add(Convert.ToSingle(tbPrice.Text));
                    Stock.ProductName.Add(tbName.Text);
                }
                else if (mode == 1)
                {
                    Stock.QTDE[Products.index] = Convert.ToSingle(tbQuant.Text);
                    Stock.Price[Products.index] = Convert.ToSingle(tbPrice.Text);
                    Stock.ProductName[Products.index] = tbName.Text;
                }

                SaveInTXT.WriteTXT();

                tbName.Text = "";
                tbQuant.Text = "";
                tbPrice.Text = "";
                this.Close();
            }
            catch { MessageBox.Show("Invalid imput format", "Invalid imput", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void CadProducts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
