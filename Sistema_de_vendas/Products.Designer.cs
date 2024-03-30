namespace Sistema_de_vendas
{
    partial class Products
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnProducts = new Button();
            lblID = new Label();
            lblProductName = new Label();
            lblQuant = new Label();
            lblPrice = new Label();
            SuspendLayout();
            // 
            // btnProducts
            // 
            btnProducts.BackColor = Color.Transparent;
            btnProducts.Dock = DockStyle.Fill;
            btnProducts.FlatAppearance.BorderSize = 0;
            btnProducts.FlatAppearance.MouseDownBackColor = Color.DimGray;
            btnProducts.FlatAppearance.MouseOverBackColor = Color.DimGray;
            btnProducts.FlatStyle = FlatStyle.Flat;
            btnProducts.ImageAlign = ContentAlignment.MiddleLeft;
            btnProducts.Location = new Point(0, 0);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(738, 31);
            btnProducts.TabIndex = 10;
            btnProducts.TextAlign = ContentAlignment.MiddleLeft;
            btnProducts.UseVisualStyleBackColor = false;
            btnProducts.Click += btnProducts_Click;
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Location = new Point(12, 7);
            lblID.Name = "lblID";
            lblID.Size = new Size(20, 17);
            lblID.TabIndex = 11;
            lblID.Text = "ID";
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(51, 7);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(92, 17);
            lblProductName.TabIndex = 12;
            lblProductName.Text = "Product Name";
            // 
            // lblQuant
            // 
            lblQuant.AutoSize = true;
            lblQuant.Location = new Point(585, 7);
            lblQuant.Name = "lblQuant";
            lblQuant.Size = new Size(43, 17);
            lblQuant.TabIndex = 13;
            lblQuant.Text = "Quant";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(671, 7);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(36, 17);
            lblPrice.TabIndex = 14;
            lblPrice.Text = "Price";
            // 
            // Products
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkCyan;
            Controls.Add(lblPrice);
            Controls.Add(lblQuant);
            Controls.Add(lblProductName);
            Controls.Add(lblID);
            Controls.Add(btnProducts);
            ForeColor = SystemColors.HighlightText;
            Margin = new Padding(0);
            Name = "Products";
            Size = new Size(738, 31);
            Load += Products_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnProducts;
        private Label lblID;
        private Label lblProductName;
        private Label lblQuant;
        private Label lblPrice;
    }
}
