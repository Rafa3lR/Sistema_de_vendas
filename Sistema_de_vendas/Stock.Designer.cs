namespace Sistema_de_vendas
{
    partial class Stock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            btnADD = new Button();
            panel1 = new Panel();
            tbNameFilterFlex = new TextBox();
            tbNameFilter = new TextBox();
            dtoProductBindingSource = new BindingSource(components);
            dataGridViewProducts = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtoProductBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).BeginInit();
            SuspendLayout();
            // 
            // btnADD
            // 
            btnADD.BackColor = SystemColors.ButtonFace;
            btnADD.FlatAppearance.MouseOverBackColor = Color.LightSteelBlue;
            btnADD.FlatStyle = FlatStyle.Flat;
            btnADD.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnADD.Location = new Point(11, -1);
            btnADD.Name = "btnADD";
            btnADD.Size = new Size(90, 32);
            btnADD.TabIndex = 0;
            btnADD.Text = "ADD";
            btnADD.UseVisualStyleBackColor = false;
            btnADD.Click += btnADD_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(76, 0, 0);
            panel1.Controls.Add(tbNameFilterFlex);
            panel1.Controls.Add(btnADD);
            panel1.Controls.Add(tbNameFilter);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(884, 32);
            panel1.TabIndex = 1;
            // 
            // tbNameFilterFlex
            // 
            tbNameFilterFlex.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tbNameFilterFlex.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            tbNameFilterFlex.ForeColor = Color.FromArgb(114, 114, 114);
            tbNameFilterFlex.Location = new Point(731, 2);
            tbNameFilterFlex.Name = "tbNameFilterFlex";
            tbNameFilterFlex.Size = new Size(142, 25);
            tbNameFilterFlex.TabIndex = 4;
            tbNameFilterFlex.Text = "NAME FLEXIBLE";
            tbNameFilterFlex.TextChanged += tbNameFilterFlex_TextChanged;
            tbNameFilterFlex.Enter += tbNameFilterFlex_Enter;
            tbNameFilterFlex.KeyDown += tbNameFilterFlex_KeyDown;
            tbNameFilterFlex.Leave += tbNameFilterFlex_Leave;
            // 
            // tbNameFilter
            // 
            tbNameFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            tbNameFilter.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            tbNameFilter.ForeColor = Color.FromArgb(114, 114, 114);
            tbNameFilter.Location = new Point(583, 2);
            tbNameFilter.Name = "tbNameFilter";
            tbNameFilter.Size = new Size(142, 25);
            tbNameFilter.TabIndex = 1;
            tbNameFilter.Text = "NAME RESTRICTED";
            tbNameFilter.TextChanged += tbNameFilter_TextChanged;
            tbNameFilter.Enter += tbNameFilter_Enter;
            tbNameFilter.KeyDown += tbNameFilter_KeyDown;
            tbNameFilter.Leave += tbNameFilter_Leave;
            // 
            // dtoProductBindingSource
            // 
            dtoProductBindingSource.DataSource = typeof(dtoProduct);
            // 
            // dataGridViewProducts
            // 
            dataGridViewCellStyle1.BackColor = Color.DarkCyan;
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.DimGray;
            dataGridViewProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewProducts.BorderStyle = BorderStyle.None;
            dataGridViewProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.LightSeaGreen;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9.75F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = Color.DimGray;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewProducts.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewProducts.Dock = DockStyle.Fill;
            dataGridViewProducts.Location = new Point(0, 32);
            dataGridViewProducts.Margin = new Padding(0);
            dataGridViewProducts.MultiSelect = false;
            dataGridViewProducts.Name = "dataGridViewProducts";
            dataGridViewProducts.ReadOnly = true;
            dataGridViewProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewProducts.Size = new Size(884, 504);
            dataGridViewProducts.TabIndex = 3;
            dataGridViewProducts.CellClick += dataGridViewProducts_CellClick;
            // 
            // Stock
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 536);
            Controls.Add(dataGridViewProducts);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            KeyPreview = true;
            Name = "Stock";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Stock";
            TopMost = true;
            FormClosing += Stock_FormClosing;
            Load += Stock_Load;
            KeyDown += Stock_KeyDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtoProductBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProducts).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnADD;
        private Panel panel1;
        private TextBox tbNameFilter;
        private TextBox tbNameFilterFlex;
        private BindingSource dtoProductBindingSource;
        public DataGridView dataGridViewProducts;
    }
}