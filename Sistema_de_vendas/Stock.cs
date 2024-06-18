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
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            dataGridViewProducts.DataSource = dtoProduct;

            orderByDescending.Clear();
            orderByDescending.Add(true);
            for (int i = 1; i < 4; i++)
            {
                orderByDescending.Add(false);
            }
        }

        public static string nameFilter = "", orderBy = "";
        public static int searchType, openCriarProdutos = 0, currentIndex = 0, quantProdToDraw = 1;
        public static List<dtoProduct> dtoProduct = new List<dtoProduct>();
        public static LinkedList<Products> products = new LinkedList<Products>();
        private static List<bool> orderByDescending = new List<bool>();
        public static dtoProduct selectedProducts;


        public static void RemoveAt<T>(LinkedList<T> lista, int index)
        {
            if (index < 0 || index >= lista.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index fora do intervalo da lista.");
            }

            LinkedListNode<T> current = lista.First;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            lista.Remove(current);
        }

        public static T productIndex<T>(LinkedList<T> lista, int index)
        {
            if (index < 0 || index >= lista.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index fora do intervalo da lista.");
            }

            LinkedListNode<T> current = lista.First;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current.Value;
        }

        public static int EncontrarIndice<T>(LinkedList<T> lista, T valor)
        {
            int index = 0;
            foreach (T item in lista)
            {
                if (EqualityComparer<T>.Default.Equals(item, valor))
                {
                    return index;
                }
                index++;
            }
            return -1;
        }

        private async void tbNameFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                currentIndex = 0;
                quantProdToDraw = 16;
                bllProduct bllProduct = new bllProduct();
                await bllProduct.SearchStrictAsync(tbNameFilter.Text);
                quantProdToDraw = 1;

                if (tbNameFilter.Text == "")
                {
                    tbNameFilter.ForeColor = Color.FromArgb(100, 114, 114, 114);
                    tbNameFilter.Text = "NAME RESTRICTED";
                    btnADD.Focus();
                }
            }
        }

        private async void tbNameFilterFlex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                currentIndex = 0;
                quantProdToDraw = 16;
                bllProduct bllProduct = new bllProduct();
                await bllProduct.SearchFlexibleAsync(tbNameFilterFlex.Text);
                quantProdToDraw = 1;

                if (tbNameFilterFlex.Text == "")
                {
                    tbNameFilterFlex.ForeColor = Color.FromArgb(100, 114, 114, 114);
                    tbNameFilterFlex.Text = "NAME FLEXIBLE";
                    btnADD.Focus();
                }
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
            quantProdToDraw = 16;
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
            quantProdToDraw = 16;
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
            quantProdToDraw = 16;
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
            quantProdToDraw = 16;
            quantProdToDraw = 1;
        }

        private static void OrderByPrice()
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

        private void dataGridViewProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedProducts = dataGridViewProducts.SelectedRows[0].DataBoundItem as dtoProduct;
            CadProducts.mode = 1;
            CadProducts cadProducts = new CadProducts();
            cadProducts.Show();
        }
    }
}
