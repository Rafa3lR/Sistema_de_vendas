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
        private int indexCad;

        public CadProducts()
        {
            InitializeComponent();
            if (mode == 1)
            {
                indexCad = Products.index;
                tbPrice.Text = Stock.Price[indexCad].ToString();
                tbQuant.Text = Stock.QTDE[indexCad].ToString();
                tbName.Text = Stock.ProductName[indexCad];
            }
            else if (mode == 0)
            {
                btnDelete.Hide();
            }
        }

        public static int mode = 0;
        public static int quantProds = 1;

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult delete = MessageBox.Show("Are you sure?", "Delete product", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (delete == DialogResult.OK)
            {
                Stock.ID.RemoveAt(indexCad);
                Stock.ProductName.RemoveAt(indexCad);
                Stock.QTDE.RemoveAt(indexCad);
                Stock.Price.RemoveAt(indexCad);
                Stock.openEdit.RemoveAt(indexCad);

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
                    Stock.QTDE.Add(Convert.ToSingle(tbQuant.Text));
                    Stock.Price.Add(Convert.ToSingle(tbPrice.Text));
                    Stock.ID.Add(quantProds);
                    Stock.ProductName.Add(tbName.Text);
                    Stock.openEdit.Add(0);
                }
                else if (mode == 1)
                {
                    Stock.QTDE[indexCad] = Convert.ToSingle(tbQuant.Text);
                    Stock.Price[indexCad] = Convert.ToSingle(tbPrice.Text);
                    Stock.ProductName[indexCad] = tbName.Text;
                }

                quantProds++;

                SaveInTXT.WriteTXT();

                tbName.Text = "";
                tbQuant.Text = "";
                tbPrice.Text = "";

                this.Close();
            }
            catch
            {
                MessageBox.Show("Invalid imput format", "Invalid imput", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CadProducts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void CadProducts_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Stock.ID.Count > 0)
            {
                Stock.openEdit[indexCad] = 0;
                SaveInTXT.WriteTXT();
            }

            Stock.PopulateItens();
        }
    }
}
