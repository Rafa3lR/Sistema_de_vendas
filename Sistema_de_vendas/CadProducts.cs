using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_de_vendas
{
    public partial class CadProducts : Form
    {
        private int indexCad, indexProd;

        public CadProducts()
        {
            InitializeComponent();
            if (mode == 1)
            {
                indexCad = Products.indexCad;
                indexProd = Products.indexProd;
                tbPrice.Text = Stock.selectedProducts.Price.ToString();
                tbQuant.Text = Stock.selectedProducts.QTDE.ToString();
                tbName.Text = Stock.selectedProducts.ProductName.ToString();
            }
            else if (mode == 0)
            {
                btnDelete.Hide();
            }
        }

        public static int mode = 0;
        public static int quantProds = 1;
        bllProduct bllProduct = new bllProduct();

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult delete = MessageBox.Show("Are you sure?", "Delete product", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (delete == DialogResult.OK)
            {
                bllProduct.DeletarAsync(Stock.dtoProduct[indexCad]);
                Stock.dtoProduct.Remove(Stock.selectedProducts);

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
                if (tbName.Text != "")
                {
                    if (tbQuant.Text != "")
                    {
                        if (tbPrice.Text != "")
                        {
                            switch (mode)
                            {
                                case 0:
                                    CreateNewProductOnList();
                                    tbName.Text = "";
                                    tbQuant.Text = "";
                                    tbPrice.Text = "";
                                    this.Close();
                                    break;
                                case 1:
                                    UpdateProductList();
                                    tbName.Text = "";
                                    tbQuant.Text = "";
                                    tbPrice.Text = "";
                                    this.Close();
                                    break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("You must insert a price", "Price is null", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbPrice.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("You must insert a quantity", "Quant is null", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbQuant.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("You must insert a name", "Name is null", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbName.Focus();
                }
            }
            catch
            {
                MessageBox.Show("An error ocurred!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                int i = Stock.dtoProduct.Count() - 1;
                Stock.dtoProduct.RemoveAt(i);
            }
        }

        private void UpdateProductList()
        {
            int index = Stock.dtoProduct.IndexOf(Stock.selectedProducts);
            Stock.dtoProduct[index].QTDE = Convert.ToSingle(tbQuant.Text);
            Stock.dtoProduct[index].Price = Convert.ToSingle(tbPrice.Text);
            Stock.dtoProduct[index].ProductName = tbName.Text;
            bllProduct.AlterarAsync(Stock.dtoProduct[index]);
        }

        private void CreateNewProductOnList()
        {
            Stock.dtoProduct.Add(new dtoProduct());
            int i = Stock.dtoProduct.Count() - 1;
            Stock.dtoProduct[i].QTDE = Convert.ToSingle(tbQuant.Text);
            Stock.dtoProduct[i].Price = Convert.ToSingle(tbPrice.Text);
            Stock.dtoProduct[i].ID = quantProds;
            Stock.dtoProduct[i].ProductName = tbName.Text;
            bllProduct.InserirAsync(Stock.dtoProduct[i]);
            quantProds++;
        }

        private void CadProducts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void tbQuant_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46 && ch != 48 && ch != 57 && ch != ',')
            {
                e.Handled = true;
            }
        }

        private void tbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46 && ch != 48 && ch != 57 && ch != ',')
            {
                e.Handled = true;
            }
        }
    }
}
