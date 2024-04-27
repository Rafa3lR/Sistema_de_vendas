﻿using System;
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
    public partial class Products : UserControl
    {
        public Products()
        {
            InitializeComponent();
        }

        private string _productname;
        private int _index;
        public static int index;

        private void btnProducts_Click(object sender, EventArgs e)
        {
            try
            {
                index = _index;
                if (Stock.stockProduct[index].openEdit == 0)
                {
                    Stock.stockProduct[index].openEdit = 1;
                    SaveInTXT.WriteTXT();
                    CadProducts.mode = 1;
                    CadProducts cadProducts = new CadProducts();
                    cadProducts.Show();
                }
                else
                {
                    MessageBox.Show("Product already opened to edit!", "Already opened!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch { }
        }

        private void Products_Load(object sender, EventArgs e)
        {
            lblID.Parent = btnProducts;
            lblID.BackColor = Color.Transparent;
            lblProductName.Parent = btnProducts;
            lblProductName.BackColor = Color.Transparent;
            lblQuant.Parent = btnProducts;
            lblQuant.BackColor = Color.Transparent;
            lblPrice.Parent = btnProducts;
            lblPrice.BackColor = Color.Transparent;
        }

        private void lblID_Click(object sender, EventArgs e)
        {
            try
            {
                index = _index;
                if (Stock.stockProduct[index].openEdit == 0)
                {
                    Stock.stockProduct[index].openEdit = 1;
                    SaveInTXT.WriteTXT();
                    CadProducts.mode = 1;
                    CadProducts cadProducts = new CadProducts();
                    cadProducts.Show();
                }
                else
                {
                    MessageBox.Show("Product already opened to edit!", "Already opened!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch { }
        }

        private void lblProductName_Click(object sender, EventArgs e)
        {
            try
            {
                index = _index;
                if (Stock.stockProduct[index].openEdit == 0)
                {
                    Stock.stockProduct[index].openEdit = 1;
                    SaveInTXT.WriteTXT();
                    CadProducts.mode = 1;
                    CadProducts cadProducts = new CadProducts();
                    cadProducts.Show();
                }
                else
                {
                    MessageBox.Show("Product already opened to edit!", "Already opened!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch { }
        }

        private void lblQuant_Click(object sender, EventArgs e)
        {
            try
            {
                index = _index;
                if (Stock.stockProduct[index].openEdit == 0)
                {
                    Stock.stockProduct[index].openEdit = 1;
                    SaveInTXT.WriteTXT();
                    CadProducts.mode = 1;
                    CadProducts cadProducts = new CadProducts();
                    cadProducts.Show();
                }
                else
                {
                    MessageBox.Show("Product already opened to edit!", "Already opened!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch { }
        }

        private void lblPrice_Click(object sender, EventArgs e)
        {
            try
            {
                index = _index;
                if (Stock.stockProduct[index].openEdit== 0)
                {
                    Stock.stockProduct[index].openEdit= 1;
                    SaveInTXT.WriteTXT();
                    CadProducts.mode = 1;
                    CadProducts cadProducts = new CadProducts();
                    cadProducts.Show();
                }
                else
                {
                    MessageBox.Show("Product already opened to edit!", "Already opened!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch { }
        }

        private void lblID_MouseMove(object sender, MouseEventArgs e)
        {
            btnProducts.BackColor = Color.DimGray;
        }

        private void lblID_MouseLeave(object sender, EventArgs e)
        {
            btnProducts.BackColor = Color.Transparent;
        }

        private void lblProductName_MouseMove(object sender, MouseEventArgs e)
        {
            btnProducts.BackColor = Color.DimGray;
        }

        private void lblProductName_MouseLeave(object sender, EventArgs e)
        {
            btnProducts.BackColor = Color.Transparent;
        }

        private void lblQuant_MouseMove(object sender, MouseEventArgs e)
        {
            btnProducts.BackColor = Color.DimGray;
        }

        private void lblQuant_MouseLeave(object sender, EventArgs e)
        {
            btnProducts.BackColor = Color.Transparent;
        }

        private void lblPrice_MouseMove(object sender, MouseEventArgs e)
        {
            btnProducts.BackColor = Color.DimGray;
        }

        private void lblPrice_MouseLeave(object sender, EventArgs e)
        {
            btnProducts.BackColor = Color.Transparent;
        }

        public int Index
        {
            set { _index = value; }
        }
        public int ID
        {
            set { lblID.Text = value.ToString(); }
        }

        public string ProductName
        {
            get { return _productname; }
            set { _productname = value; lblProductName.Text = value; }
        }

        public float QTDE
        {
            set { lblQuant.Text = value.ToString(); }
        }

        public float Price
        {
            set { lblPrice.Text = value.ToString(); }
        }
    }
}
