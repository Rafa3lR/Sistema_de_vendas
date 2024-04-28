using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_vendas
{
    internal class SaveInTXT
    {
        public static void ReadTXT()
        {
            int max = Stock.stockProduct.Count();
            for (int i = 0; i < max; i++)
            {
                Stock.stockProduct.RemoveAt(0);
            }

            StreamWriter quantProd1 = new StreamWriter("quantProd.txt", true);
            quantProd1.Close();
            using (StreamReader sr = new StreamReader("quantProd.txt"))
            {
                string quantProd;
                while ((quantProd = sr.ReadLine()) != null)
                {
                    CadProducts.quantProds = Convert.ToInt32(quantProd);
                }
            }

            StreamWriter ID1 = new StreamWriter("ID.txt", true);
            ID1.Close();
            using (StreamReader sr = new StreamReader("ID.txt"))
            {
                string ID;
                int i = 0;
                while ((ID = sr.ReadLine()) != null)
                {
                    Stock.stockProduct.Add(new StockProduct());
                    Stock.stockProduct[i].ID = Convert.ToInt32(ID);
                    i++;
                }
            }

            StreamWriter ProductName1 = new StreamWriter("ProductName.txt", true);
            ProductName1.Close();
            using (StreamReader sr = new StreamReader("ProductName.txt"))
            {
                string ProductName;
                int i = 0;
                while ((ProductName = sr.ReadLine()) != null)
                {
                    Stock.stockProduct[i].ProductName = ProductName;
                    i++;
                }
            }

            StreamWriter QTDE1 = new StreamWriter("QTDE.txt", true);
            QTDE1.Close();
            using (StreamReader sr = new StreamReader("QTDE.txt"))
            {
                string QTDE;
                int i = 0;
                while ((QTDE = sr.ReadLine()) != null)
                {
                    Stock.stockProduct[i].QTDE = Convert.ToSingle(QTDE);
                    i++;
                }
            }

            StreamWriter Price1 = new StreamWriter("Price.txt", true);
            Price1.Close();
            using (StreamReader sr = new StreamReader("Price.txt"))
            {
                string Price;
                int i = 0;
                while ((Price = sr.ReadLine()) != null)
                {
                    Stock.stockProduct[i].Price = Convert.ToSingle(Price);
                    i++;
                }
            }
        }

        public static void WriteTXT()
        {
            StreamWriter ID1 = new StreamWriter("ID.txt", false);
            ID1.Close();
            StreamWriter ProductName1 = new StreamWriter("ProductName.txt", false);
            ProductName1.Close();
            StreamWriter QTDE1 = new StreamWriter("QTDE.txt", false);
            QTDE1.Close();
            StreamWriter Price1 = new StreamWriter("Price.txt", false);
            Price1.Close();
            StreamWriter quantProd1 = new StreamWriter("quantProd.txt", false);
            quantProd1.Close();
            StreamWriter openEdit1 = new StreamWriter("OpenEdit.txt", false);
            openEdit1.Close();

            using (StreamWriter sw = new StreamWriter("quantProd.txt", true))
            {
                sw.WriteLine(CadProducts.quantProds);
            }

            for (int i = 0; i < Stock.stockProduct.Count(); i++)
            {
                using (StreamWriter sw = new StreamWriter("ID.txt", true))
                {
                    sw.WriteLine(Stock.stockProduct[i].ID);
                }
                
                using (StreamWriter sw = new StreamWriter("ProductName.txt", true))
                {
                    sw.WriteLine(Stock.stockProduct[i].ProductName);
                }
                
                using (StreamWriter sw = new StreamWriter("QTDE.txt", true))
                {
                    sw.WriteLine(Stock.stockProduct[i].QTDE);
                }
                
                using (StreamWriter sw = new StreamWriter("Price.txt", true))
                {
                    sw.WriteLine(Stock.stockProduct[i].Price);
                }
            }
        }
    }
}
