﻿using System;
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
                tbPrice.Text = Stock.stockProduct[indexCad].Price.ToString();
                tbQuant.Text = Stock.stockProduct[indexCad].QTDE.ToString();
                tbName.Text = Stock.stockProduct[indexCad].ProductName;
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
                Stock.products.RemoveAt(indexCad);
                Stock.stockProduct.RemoveAt(indexCad);
                
                tbName.Text = "";
                tbQuant.Text = "";
                tbPrice.Text = "";

                SaveInTXT.WriteTXT();
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
                        Stock.stockProduct.Add(new StockProduct());
                        int i = Stock.stockProduct.Count() - 1;
                        Stock.stockProduct[i].ID = quantProds;
                        Stock.stockProduct[i].ProductName = tbName.Text;
                        Stock.stockProduct[i].QTDE = Convert.ToSingle(tbQuant.Text);
                        Stock.stockProduct[i].Price = Convert.ToSingle(tbPrice.Text);
                        quantProds++;
                        tbName.Text = "";
                        tbQuant.Text = "";
                        tbPrice.Text = "";
                        SaveInTXT.WriteTXT();
                        DrawNewProduct();
                        this.Close();
                        break;
                    case 1:
                        Stock.stockProduct[indexCad].QTDE = Convert.ToSingle(tbQuant.Text);
                        Stock.stockProduct[indexCad].Price = Convert.ToSingle(tbPrice.Text);
                        Stock.stockProduct[indexCad].ProductName = tbName.Text;
                        tbName.Text = "";
                        tbQuant.Text = "";
                        tbPrice.Text = "";
                        SaveInTXT.WriteTXT();
                        Stock.FilterAndDrawItens();
                        this.Close();
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Invalid imput format", "Invalid imput", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void DrawNewProduct()
        { 
            Stock.products.Add(new Products());
            int index = Stock.stockProduct.Count() - 1;
            Stock.products[index].ID = Stock.stockProduct[index].ID;
            Stock.products[index].ProductName = Stock.stockProduct[index].ProductName;
            Stock.products[index].QTDE = Stock.stockProduct[index].QTDE;
            Stock.products[index].Price = Stock.stockProduct[index].Price;
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
    }
}
