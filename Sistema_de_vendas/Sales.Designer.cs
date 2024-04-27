namespace Sistema_de_vendas
{
    partial class Sales
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
            panel1 = new Panel();
            button1 = new Button();
            tbClienteFilterRestricted = new TextBox();
            tbClienteFilterFlex = new TextBox();
            flowPanelSales = new FlowLayoutPanel();
            panel2 = new Panel();
            label3 = new Label();
            label2 = new Label();
            dateTimeFilterEnd = new DateTimePicker();
            dateTimeFilterStart = new DateTimePicker();
            label1 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(76, 0, 0);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(909, 32);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ButtonFace;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            button1.Location = new Point(165, 0);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(75, 32);
            button1.TabIndex = 0;
            button1.Text = "ADD";
            button1.UseVisualStyleBackColor = false;
            // 
            // tbClienteFilterRestricted
            // 
            tbClienteFilterRestricted.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            tbClienteFilterRestricted.ForeColor = Color.FromArgb(114, 114, 114);
            tbClienteFilterRestricted.Location = new Point(0, 48);
            tbClienteFilterRestricted.Name = "tbClienteFilterRestricted";
            tbClienteFilterRestricted.Size = new Size(165, 25);
            tbClienteFilterRestricted.TabIndex = 1;
            tbClienteFilterRestricted.Text = "NAME RESTRICTED";
            tbClienteFilterRestricted.Enter += tbClienteFilterRestricted_Enter;
            tbClienteFilterRestricted.Leave += tbClienteFilterRestricted_Leave;
            // 
            // tbClienteFilterFlex
            // 
            tbClienteFilterFlex.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            tbClienteFilterFlex.ForeColor = Color.FromArgb(114, 114, 114);
            tbClienteFilterFlex.Location = new Point(0, 79);
            tbClienteFilterFlex.Name = "tbClienteFilterFlex";
            tbClienteFilterFlex.Size = new Size(165, 25);
            tbClienteFilterFlex.TabIndex = 2;
            tbClienteFilterFlex.Text = "NAME FLEXIBLE";
            tbClienteFilterFlex.Enter += tbClienteFilterFlex_Enter;
            tbClienteFilterFlex.Leave += tbClienteFilterFlex_Leave;
            // 
            // flowPanelSales
            // 
            flowPanelSales.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowPanelSales.AutoScroll = true;
            flowPanelSales.BackColor = Color.LightSteelBlue;
            flowPanelSales.Font = new Font("Segoe UI", 9.75F);
            flowPanelSales.Location = new Point(165, 32);
            flowPanelSales.Margin = new Padding(0);
            flowPanelSales.Name = "flowPanelSales";
            flowPanelSales.Size = new Size(744, 459);
            flowPanelSales.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel2.BackColor = Color.FromArgb(76, 0, 0);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(dateTimeFilterEnd);
            panel2.Controls.Add(dateTimeFilterStart);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(tbClienteFilterFlex);
            panel2.Controls.Add(tbClienteFilterRestricted);
            panel2.Location = new Point(0, 32);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(165, 459);
            panel2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.HighlightText;
            label3.Location = new Point(3, 251);
            label3.Name = "label3";
            label3.Size = new Size(89, 21);
            label3.TabIndex = 5;
            label3.Text = "Final date:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.HighlightText;
            label2.Location = new Point(3, 197);
            label2.Name = "label2";
            label2.Size = new Size(99, 21);
            label2.TabIndex = 3;
            label2.Text = "Inicial date:";
            // 
            // dateTimeFilterEnd
            // 
            dateTimeFilterEnd.Format = DateTimePickerFormat.Short;
            dateTimeFilterEnd.Location = new Point(0, 275);
            dateTimeFilterEnd.Name = "dateTimeFilterEnd";
            dateTimeFilterEnd.Size = new Size(165, 25);
            dateTimeFilterEnd.TabIndex = 6;
            // 
            // dateTimeFilterStart
            // 
            dateTimeFilterStart.Format = DateTimePickerFormat.Short;
            dateTimeFilterStart.Location = new Point(0, 221);
            dateTimeFilterStart.Name = "dateTimeFilterStart";
            dateTimeFilterStart.Size = new Size(165, 25);
            dateTimeFilterStart.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.HighlightText;
            label1.Location = new Point(31, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 32);
            label1.TabIndex = 0;
            label1.Text = "FILTERS";
            // 
            // Sales
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(909, 490);
            Controls.Add(panel2);
            Controls.Add(flowPanelSales);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            KeyPreview = true;
            Name = "Sales";
            Text = "Sales";
            TopMost = true;
            FormClosing += Sales_FormClosing;
            KeyDown += Sales_KeyDown;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private FlowLayoutPanel flowPanelSales;
        private Button button1;
        private TextBox tbClienteFilterFlex;
        private TextBox tbClienteFilterRestricted;
        private Panel panel2;
        private Label label1;
        private DateTimePicker dateTimeFilterStart;
        private DateTimePicker dateTimeFilterEnd;
        private Label label3;
        private Label label2;
    }
}