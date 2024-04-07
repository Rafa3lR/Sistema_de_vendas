namespace Sistema_de_vendas
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            SaveInTXT.ReadTXT();
        }

        private Stock stock = new Stock();
        private Sales sales = new Sales();

        private void btnSales_Click(object sender, EventArgs e)
        {
            sales.Show();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            stock.Show();
        }
    }
}
