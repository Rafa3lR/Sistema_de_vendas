using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
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
            flowPanelStock.MouseWheel += new MouseEventHandler(OnMouseWheel);
            flowPanelStock.Scroll += new ScrollEventHandler(OnScroll);
            flowPanelStock.VerticalScroll.Visible = false;
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            orderByDescending.Clear();
            orderByDescending.Add(true);
            for (int i = 1; i < 4; i++)
            {
                orderByDescending.Add(false);
            }
            FilterAndDrawItens(quantProdToDraw);
            FilterAndDrawItens(quantProdToDraw);
        }

        public static string nameFilter = "", orderBy = "";
        public static int searchType, openCriarProdutos = 0, currentIndex = 0, quantProdToDraw = 1;
        public static List<dtoProduct> dtoProduct = new List<dtoProduct>();
        private static List<bool> orderByDescending = new List<bool>();

        public static void FilterAndDrawItens(int count)
        {            
            if (orderBy == "id")
            {
                OrderByID();
                orderBy = "";
            }
            else if (orderBy == "name")
            {
                OrderByName();
                orderBy = "";
            }
            else if (orderBy == "quant")
            {
                OrderByQuant();
                orderBy = "";
            }
            else if (orderBy == "price")
            {
                orderByPrice();
                orderBy = "";
            }

            int itemsToLoad = Math.Min(count, dtoProduct.Count() - currentIndex);


            int count1 = 0;
            try
            {
                for (int i = currentIndex; i < currentIndex + itemsToLoad; i++)
                {
                    if (currentIndex < 15)
                    {
                        quantProdToDraw = 15;
                    }
                    else
                    {
                        quantProdToDraw = 1;
                    }
                    Products products = new Products();
                    products.ID = dtoProduct[i].ID;
                    products.ProductName = dtoProduct[i].ProductName;
                    products.QTDE = dtoProduct[i].QTDE;
                    products.Price = dtoProduct[i].Price;

                    if ((i % 2) == 0)
                    {
                        products.BackColor = Color.DarkCyan;
                    }
                    else
                    {
                        products.BackColor = Color.LightSeaGreen;
                    }
                    flowPanelStock.Controls.Add(products);

                    if (currentIndex > 16)
                    {
                        flowPanelStock.Controls.RemoveAt(0);
                    }
                }

                currentIndex += itemsToLoad;
            }
            catch { }
        }

        private void LoadPreviousItems(int count)
        {
            if (currentIndex > 16)
            {
                int quant = 16;
                currentIndex -= count;
                if (currentIndex < 0)
                {
                    currentIndex = 0;
                }

                int itemsToLoad = Math.Min(count, currentIndex);
                int count1 = 0;

                try
                {
                    for (int i = currentIndex; i < currentIndex + itemsToLoad; i++)
                    {
                        Products products = new Products();
                        products.ID = dtoProduct[currentIndex - quant].ID;
                        products.ProductName = dtoProduct[currentIndex - quant].ProductName;
                        products.QTDE = dtoProduct[i].QTDE;
                        products.Price = dtoProduct[currentIndex - quant].Price;
                        if ((i % 2) == 0)
                        {
                            products.BackColor = Color.DarkCyan;
                        }
                        else
                        {
                            products.BackColor = Color.LightSeaGreen;
                        }
                        flowPanelStock.Controls.RemoveAt(flowPanelStock.Controls.Count - 1);
                        flowPanelStock.Controls.Add(products);
                        flowPanelStock.Controls.SetChildIndex(products, 0);                        
                    }
                }
                catch { }
            }
        }

        private void tbNameFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                /*searchType = 1;
                nameFilter = tbNameFilter.Text;
                currentIndex = 0;
                quantProdToDraw = 150;
                flowPanelStock.Controls.Clear();
                FilterAndDrawItens(quantProdToDraw);
                quantProdToDraw = 1;*/
            }
        }

        private void tbNameFilterFlex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                /*searchType = 0;
                nameFilter = tbNameFilterFlex.Text;
                currentIndex = 0;
                quantProdToDraw = 150;
                flowPanelStock.Controls.Clear();
                FilterAndDrawItens(quantProdToDraw);
                quantProdToDraw = 1;*/
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
            currentIndex = 0;
            quantProdToDraw = 15;
            flowPanelStock.Controls.Clear();
            FilterAndDrawItens(quantProdToDraw);
            quantProdToDraw = 1;
        }

        private static void OrderByID()
        {
            if (orderByDescending[0])
            {
                dtoProduct = dtoProduct.OrderByDescending(w => w.ID).ToList();
                orderByDescending[0] = false;
                orderByDescending[1] = false;
                orderByDescending[2] = false;
                orderByDescending[3] = false;

            }
            else
            {
                dtoProduct = dtoProduct.OrderBy(w => w.ID).ToList();
                orderByDescending[0] = true;
                orderByDescending[1] = false;
                orderByDescending[2] = false;
                orderByDescending[3] = false;
            }
        }

        private void btnProductName_Click(object sender, EventArgs e)
        {
            orderBy = "name";
            currentIndex = 0;
            quantProdToDraw = 15;
            flowPanelStock.Controls.Clear();
            FilterAndDrawItens(quantProdToDraw);
            quantProdToDraw = 1;
        }

        private static void OrderByName()
        {
            if (orderByDescending[1])
            {
                dtoProduct = dtoProduct.OrderByDescending(w => w.ProductName).ToList();
                orderByDescending[0] = false;
                orderByDescending[1] = false;
                orderByDescending[2] = false;
                orderByDescending[3] = false;
            }
            else
            {
                dtoProduct = dtoProduct.OrderBy(w => w.ProductName).ToList();
                orderByDescending[0] = false;
                orderByDescending[1] = true;
                orderByDescending[2] = false;
                orderByDescending[3] = false;
            }
        }

        private void btnQuant_Click(object sender, EventArgs e)
        {
            orderBy = "quant";
            currentIndex = 0;
            quantProdToDraw = 15;
            flowPanelStock.Controls.Clear();
            FilterAndDrawItens(quantProdToDraw);
            quantProdToDraw = 1;
        }

        private static void OrderByQuant()
        {
            if (orderByDescending[2])
            {
                dtoProduct = dtoProduct.OrderByDescending(w => w.QTDE).ToList();
                orderByDescending[0] = false;
                orderByDescending[1] = false;
                orderByDescending[2] = false;
                orderByDescending[3] = false;
            }
            else
            {
                dtoProduct = dtoProduct.OrderBy(w => w.QTDE).ToList();
                orderByDescending[0] = false;
                orderByDescending[1] = false;
                orderByDescending[2] = true;
                orderByDescending[3] = false;
            }
        }

        private void btnPrice_Click(object sender, EventArgs e)
        {
            orderBy = "price";
            currentIndex = 0;
            quantProdToDraw = 15;
            flowPanelStock.Controls.Clear();
            FilterAndDrawItens(quantProdToDraw);
            quantProdToDraw = 1;
        }

        private static void orderByPrice()
        {
            if (orderByDescending[3])
            {
                dtoProduct = dtoProduct.OrderByDescending(w => w.Price).ToList();
                orderByDescending[0] = false;
                orderByDescending[1] = false;
                orderByDescending[2] = false;
                orderByDescending[3] = false;
            }
            else
            {
                dtoProduct = dtoProduct.OrderBy(w => w.Price).ToList();
                orderByDescending[0] = false;
                orderByDescending[1] = false;
                orderByDescending[2] = false;
                orderByDescending[3] = true;
            }
        }

        private void tbNameFilter_TextChanged(object sender, EventArgs e)
        {
            if (tbNameFilter.Text == "")
            {
                nameFilter = tbNameFilter.Text;
            }
        }

        private void tbNameFilterFlex_TextChanged(object sender, EventArgs e)
        {
            if (tbNameFilter.Text == "")
            {
                nameFilter = tbNameFilter.Text;
            }
        }

        private async void OnMouseWheel(object sender, MouseEventArgs e)
        {
            await Task.Delay(10);

            var maxScroll = flowPanelStock.VerticalScroll.Maximum - flowPanelStock.ClientSize.Height;
            var PercentScroll = (int)(maxScroll * 1);
            if (flowPanelStock.VerticalScroll.Value >= PercentScroll)
            {
                FilterAndDrawItens(quantProdToDraw);
            }
            else if (flowPanelStock.VerticalScroll.Value == 0)
            {
                LoadPreviousItems(quantProdToDraw);
            }
        }

        private void OnScroll(object sender, ScrollEventArgs e)
        {
            var maxScroll = flowPanelStock.VerticalScroll.Maximum - flowPanelStock.ClientSize.Height;
            var PercentScroll = (int)(maxScroll * 1);
            if (flowPanelStock.VerticalScroll.Value >= PercentScroll)
            {
                FilterAndDrawItens(quantProdToDraw);
            }
            else if (flowPanelStock.VerticalScroll.Value == 0)
            {
                LoadPreviousItems(quantProdToDraw);
            }
        }
    }
}
