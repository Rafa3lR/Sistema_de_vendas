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
    public partial class Sales : Form
    {
        public Sales()
        {
            InitializeComponent();
        }

        private void tbClienteFilterFlex_Enter(object sender, EventArgs e)
        {
            if (tbClienteFilterFlex.Text == "NAME FLEXIBLE")
            {
                tbClienteFilterFlex.Text = "";
                tbClienteFilterFlex.ForeColor = Color.Black;
                tbClienteFilterRestricted.ForeColor = Color.FromArgb(100, 114, 114, 114);
                tbClienteFilterRestricted.Text = "NAME RESTRICTED";
            }
        }

        private void tbClienteFilterFlex_Leave(object sender, EventArgs e)
        {
            if (tbClienteFilterFlex.Text == "")
            {
                tbClienteFilterFlex.ForeColor = Color.FromArgb(100, 114, 114, 114);
                tbClienteFilterFlex.Text = "NAME FLEXIBLE";
            }
        }

        private void tbClienteFilterRestricted_Enter(object sender, EventArgs e)
        {
            if (tbClienteFilterRestricted.Text == "NAME RESTRICTED")
            {
                tbClienteFilterRestricted.Text = "";
                tbClienteFilterRestricted.ForeColor = Color.Black;
                tbClienteFilterFlex.ForeColor = Color.FromArgb(100, 114, 114, 114);
                tbClienteFilterFlex.Text = "NAME FLEXIBLE";
            }
        }

        private void tbClienteFilterRestricted_Leave(object sender, EventArgs e)
        {
            if (tbClienteFilterRestricted.Text == "")
            {
                tbClienteFilterRestricted.ForeColor = Color.FromArgb(100, 114, 114, 114);
                tbClienteFilterRestricted.Text = "NAME RESTRICTED";
            }
        }

        private void Sales_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Parent = null;
            e.Cancel = true;
            this.Hide();
        }

        private void Sales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}