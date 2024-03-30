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
            PopulateItens();
        }

        private string nameFilter = "";
        public int searchType, open = 0;
        public static List<int> ID = new List<int>();
        public static List<string> ProductName = new List<string>();
        public static List<float> QTDE = new List<float>();
        public static List<float> Price = new List<float>();
        public static List<Products> products = new List<Products>();

        //Create random products for debugging
        private void CriarProdutos()
        {
            if (open == 0)
            {
                for (int i = 0; i < 1000; i++)
                {
                    ID.Add(i + 1);
                    ProductName.Add($"Produto {i + 1}");
                    QTDE.Add(i + 1);
                    Price.Add(Convert.ToSingle(i + 1));
                }
                open = 1;
            }
        }

        public void PopulateItens()
        {
            flowPanelStock.Controls.Clear();

            int count = 0;
            int i = 0;
            try
            {
                foreach (int x in ID)
                {
                    products.Add(new Products());
                    products[i].ID = x;
                    products[i].ProductName = ProductName[i];
                    products[i].QTDE = QTDE[i];
                    products[i].Price = Price[i];
                    products[i].Index = i;

                    if (nameFilter != "")
                    {
                        if (searchType == 0 && products[i].ProductName.Contains(nameFilter))
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
                        if (searchType == 1 && products[i].ProductName.StartsWith(nameFilter))
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

                    i++;
                }
            }
            catch { }
        }

        private void tbNameFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchType = 1;
                nameFilter = tbNameFilter.Text;
                PopulateItens();
            }
        }

        private void tbNameFilterFlex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchType = 0;
                nameFilter = tbNameFilterFlex.Text;
                PopulateItens();
            }
        }

        private void tbNameFilterFlex_Enter(object sender, EventArgs e)
        {
            tbNameFilter.Text = "";
        }

        private void tbNameFilter_Enter(object sender, EventArgs e)
        {
            tbNameFilterFlex.Text = "";
        }

        private void Stock_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Parent = null;
            e.Cancel = true;
            this.Hide();
        }

        private void btnID_Click(object sender, EventArgs e)
        {
            /*List<int> idTemp = new List<int>();
            List<string> nameTemp = new List<string>();
            List<int> qtdeTemp = new List<int>();
            List<float> priceTemp = new List<float>();

            foreach (int x in ID)
            {
                idTemp.Add(x);
            }

            idTemp.Sort();

            foreach (int x in idTemp)
            {
                int index = ID.IndexOf(x);
                nameTemp.Add(ProductName[index]);
                qtdeTemp.Add(QTDE[index]);
                priceTemp.Add(Price[index]);
            }

            int i = 0;
            foreach (int x in idTemp)
            {
                ID[i] = x;
                ProductName[i] = nameTemp[i];
                QTDE[i] = qtdeTemp[i];
                Price[i] = priceTemp[i];
                i++;
            }*/

            PopulateItens();
        }

        private void btnProductName_Click(object sender, EventArgs e)
        {
            /*List<int> idTemp = new List<int>();
            List<string> nameTemp = new List<string>();
            List<int> qtdeTemp = new List<int>();
            List<float> priceTemp = new List<float>();

            foreach (string x in ProductName)
            {
                nameTemp.Add(x);
            }

            nameTemp.Sort();

            foreach (string x in nameTemp)
            {
                int index = ProductName.IndexOf(x);
                idTemp.Add(ID[index]);
                qtdeTemp.Add(QTDE[index]);
                priceTemp.Add(Price[index]);
            }

            int i = 0;
            foreach (string x in nameTemp)
            {
                ID[i] = idTemp[i];
                ProductName[i] = x;
                QTDE[i] = qtdeTemp[i];
                Price[i] = priceTemp[i];
                i++;
            }*/

            PopulateItens();
        }

        private void btnQuant_Click(object sender, EventArgs e)
        {
            /*List<int> idTemp = new List<int>();
            List<string> nameTemp = new List<string>();
            List<int> qtdeTemp = new List<int>();
            List<float> priceTemp = new List<float>();

            foreach (int x in QTDE)
            {
                qtdeTemp.Add(x);
            }

            qtdeTemp.Sort();

            foreach (int x in qtdeTemp)
            {
                int index = QTDE.IndexOf(x);
                nameTemp.Add(ProductName[index]);
                idTemp.Add(ID[index]);
                priceTemp.Add(Price[index]);
            }

            int i = 0;
            foreach (int x in qtdeTemp)
            {
                ID[i] = idTemp[i];
                ProductName[i] = nameTemp[i];
                QTDE[i] = x;
                Price[i] = priceTemp[i];
                i++;
            }*/

            PopulateItens();
        }

        private void btnPrice_Click(object sender, EventArgs e)
        {
            /*List<int> idTemp = new List<int>();
            List<string> nameTemp = new List<string>();
            List<int> qtdeTemp = new List<int>();
            List<float> priceTemp = new List<float>();

            foreach (float x in Price)
            {
                priceTemp.Add(x);
            }

            priceTemp.Sort();

            foreach (float x in priceTemp)
            {
                int index = Price.IndexOf(Convert.ToInt32(x));
                nameTemp.Add(ProductName[index]);
                idTemp.Add(ID[index]);
                qtdeTemp.Add(QTDE[index]);
            }

            int i = 0;
            foreach (float x in priceTemp)
            {
                ID[i] = idTemp[i];
                ProductName[i] = nameTemp[i];
                QTDE[i] = qtdeTemp[i];
                Price[i] = x;
                i++;
            }*/

            PopulateItens();
        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            CadProducts.mode = 0;
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
    }
}
