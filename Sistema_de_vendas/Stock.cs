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
    public partial class Stock : Form
    {
        public Stock()
        {
            InitializeComponent();
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            //Create random products for debugging
            //CriarProdutos();
            FilterAndDrawItens();
        }

        public static string nameFilter = "", orderBy = "id";
        public static int searchType, open = 0, i;
        public static List<Products> products = new List<Products>();
        public static List<StockProduct> stockProduct = new List<StockProduct>();

        //Create random products for debugging
        private void CriarProdutos()
        {
            if (open == 0)
            {
                for (int i = 0; i < 1000; i++)
                {
                    stockProduct.Add(new StockProduct());
                    stockProduct[i].ID = i + 1;
                    stockProduct[i].ProductName = $"Produto {i + 1}";
                    stockProduct[i].QTDE = i + 1;
                    stockProduct[i].Price = Convert.ToSingle(i + 1);
                }
                open = 1;
            }
        }

        public static void FilterAndDrawItens()
        {
            flowPanelStock.Controls.Clear();
            SaveInTXT.ReadTXT();

            if (orderBy == "id")
            {
                OrderByID();
            }
            else if (orderBy == "name")
            {
                OrderByName();
            }
            else if (orderBy == "quant")
            {
                OrderByQuant();
            }
            else if (orderBy == "price")
            {
                orderByPrice();
            }

            int count = 0;
            try
            {
                Main.mainProgressBar.Maximum = stockProduct.Count();

                for (int i = 0; i < stockProduct.Count(); i++)
                {
                    products.Add(new Products());
                    products[i].ID = stockProduct[i].ID;
                    products[i].ProductName = stockProduct[i].ProductName;
                    products[i].QTDE = stockProduct[i].QTDE;
                    products[i].Price = stockProduct[i].Price;

                    if (nameFilter != "")
                    {
                        if (searchType == 0 && products[i].ProductName.ToLower().Contains(nameFilter.ToLower()))
                        {
                            if ((count % 2) == 0)
                            {
                                products[i].BackColor = Color.DarkCyan;
                            }
                            else
                            {
                                products[i].BackColor = Color.LightSeaGreen;
                            }
                            count++;
                            flowPanelStock.Controls.Add(products[i]);
                        }
                        if (searchType == 1 && products[i].ProductName.ToLower().StartsWith(nameFilter.ToLower()))
                        {
                            if ((count % 2) == 0)
                            {
                                products[i].BackColor = Color.DarkCyan;
                            }
                            else
                            {
                                products[i].BackColor = Color.LightSeaGreen;
                            }
                            count++;
                            flowPanelStock.Controls.Add(products[i]);
                        }
                    }
                    else
                    {
                        if ((i % 2) == 0)
                        {
                            products[i].BackColor = Color.DarkCyan;
                        }
                        else
                        {
                            products[i].BackColor = Color.LightSeaGreen;
                        }
                        flowPanelStock.Controls.Add(products[i]);
                    }

                    Main.mainProgressBar.Value = i;
                }

                Main.mainProgressBar.Value = 0;
            }
            catch { }
        }

        private void tbNameFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchType = 1;
                nameFilter = tbNameFilter.Text;
                FilterAndDrawItens();
            }
        }

        private void tbNameFilterFlex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchType = 0;
                nameFilter = tbNameFilterFlex.Text;
                FilterAndDrawItens();
            }
        }

        private void tbNameFilterFlex_Enter(object sender, EventArgs e)
        {
            if (tbNameFilterFlex.Text == "NAME FLEXIBLE")
            {
                tbNameFilterFlex.Text = "";
                tbNameFilterFlex.ForeColor = Color.Black;
                tbNameFilter.ForeColor = Color.FromArgb(100, 114, 114, 114);
                tbNameFilter.Text = "NAME RESTRICTED";
            }
        }

        private void tbNameFilterFlex_Leave(object sender, EventArgs e)
        {
            if (tbNameFilterFlex.Text == "")
            {
                tbNameFilterFlex.ForeColor = Color.FromArgb(100, 114, 114, 114);
                tbNameFilterFlex.Text = "NAME FLEXIBLE";
            }
        }

        private void tbNameFilter_Enter(object sender, EventArgs e)
        {
            if (tbNameFilter.Text == "NAME RESTRICTED")
            {
                tbNameFilter.Text = "";
                tbNameFilter.ForeColor = Color.Black;
                tbNameFilterFlex.ForeColor = Color.FromArgb(100, 114, 114, 114);
                tbNameFilterFlex.Text = "NAME FLEXIBLE";
            }
        }

        private void tbNameFilter_Leave(object sender, EventArgs e)
        {
            if (tbNameFilter.Text == "")
            {
                tbNameFilter.ForeColor = Color.FromArgb(100, 114, 114, 114);
                tbNameFilter.Text = "NAME RESTRICTED";
            }
        }

        private void Stock_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Parent = null;
            e.Cancel = true;
            this.Hide();
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            CadProducts.mode = 0;
            SaveInTXT.ReadTXT();
            CadProducts cadProducts = new CadProducts();
            cadProducts.Show();
        }

        private void Stock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnID_Click(object sender, EventArgs e)
        {
            orderBy = "id";
            FilterAndDrawItens();
        }

        private static void OrderByID()
        {
            stockProduct = stockProduct.OrderBy(w => w.ID).ToList();
        }

        private void btnProductName_Click(object sender, EventArgs e)
        {
            orderBy = "name";
            FilterAndDrawItens();
        }

        private static void OrderByName()
        {
            stockProduct = stockProduct.OrderBy(w => w.ProductName).ToList();
        }

        private void btnQuant_Click(object sender, EventArgs e)
        {
            orderBy = "quant";
            FilterAndDrawItens();
        }

        private static void OrderByQuant()
        {
            stockProduct = stockProduct.OrderBy(w => w.QTDE).ToList();
        }

        private void btnPrice_Click(object sender, EventArgs e)
        {
            orderBy = "price";
            FilterAndDrawItens();
        }

        private static void orderByPrice()
        {
            stockProduct = stockProduct.OrderBy(w => w.Price).ToList();
        }
    }

    public class StockProduct
    {
        public int ID;
        public string ProductName;
        public float QTDE, Price;
    }
}
