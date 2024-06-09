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
        private int indexCad;

        public CadProducts()
        {
            InitializeComponent();
            if (mode == 1)
            {
                indexCad = Products.index;
                tbPrice.Text = Stock.dtoProduct[indexCad].Price.ToString();
                tbQuant.Text = Stock.dtoProduct[indexCad].QTDE.ToString();
                tbName.Text = Stock.dtoProduct[indexCad].ProductName;
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
                Stock.products.RemoveAt(indexCad);
                bllProduct.deletar(Stock.dtoProduct[indexCad]);
                Stock.dtoProduct.RemoveAt(indexCad);


                tbName.Text = "";
                tbQuant.Text = "";
                tbPrice.Text = "";

                Stock.flowPanelStock.Controls.RemoveAt(indexCad);
                this.Close();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                switch (mode)
                {
                    case 0:
                        CreateNewProductOnList();
                        tbName.Text = "";
                        tbQuant.Text = "";
                        tbPrice.Text = "";
                        DrawNewProduct();
                        this.Close();
                        break;
                    case 1:
                        UpdateProductList();
                        tbName.Text = "";
                        tbQuant.Text = "";
                        tbPrice.Text = "";
                        Stock.currentIndex = 0;
                        Stock.quantProdToDraw = 15;
                        Stock.flowPanelStock.Controls.Clear();
                        Stock.FilterAndDrawItens(Stock.quantProdToDraw);
                        Stock.quantProdToDraw = 1;
                        this.Close();
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Invalid imput format", "Invalid imput", MessageBoxButtons.OK, MessageBoxIcon.Error);
                int i = Stock.dtoProduct.Count() - 1;
                Stock.dtoProduct.RemoveAt(i);
            }
        }

        private void UpdateProductList()
        {
            Stock.dtoProduct[indexCad].QTDE = Convert.ToSingle(tbQuant.Text);
            Stock.dtoProduct[indexCad].Price = Convert.ToSingle(tbPrice.Text);
            Stock.dtoProduct[indexCad].ProductName = tbName.Text;
            bllProduct.alterar(Stock.dtoProduct[indexCad]);
        }

        private void CreateNewProductOnList()
        {
            Stock.dtoProduct.Add(new dtoProduct());
            int i = Stock.dtoProduct.Count() - 1;
            Stock.dtoProduct[i].QTDE = Convert.ToSingle(tbQuant.Text);
            Stock.dtoProduct[i].Price = Convert.ToSingle(tbPrice.Text);
            Stock.dtoProduct[i].ID = quantProds;
            Stock.dtoProduct[i].ProductName = tbName.Text;
            bllProduct.inserir(Stock.dtoProduct[i]);
            quantProds++;
        }

        private static void DrawNewProduct()
        {
            Stock.products.Add(new Products());
            int index = Stock.dtoProduct.Count() - 1;
            Stock.products[index].ID = Stock.dtoProduct[index].ID;
            Stock.products[index].ProductName = Stock.dtoProduct[index].ProductName;
            Stock.products[index].QTDE = Stock.dtoProduct[index].QTDE;
            Stock.products[index].Price = Stock.dtoProduct[index].Price;
            if ((index % 2) == 0)
            {
                Stock.products[index].BackColor = Color.DarkCyan;
            }
            else
            {
                Stock.products[index].BackColor = Color.LightSeaGreen;
            }
            Stock.flowPanelStock.Controls.Add(Stock.products[index]);
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
