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
            int max = Stock.ID.Count();
            for (int i = 0; i < max; i++)
            {
                Stock.ID.RemoveAt(0);
                Stock.ProductName.RemoveAt(0);
                Stock.QTDE.RemoveAt(0);
                Stock.Price.RemoveAt(0);
                Stock.openEdit.RemoveAt(0);
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
                while ((ID = sr.ReadLine()) != null)
                {
                    Stock.ID.Add(Convert.ToInt32(ID));
                    Stock.openEdit.Add(0);
                }
            }

            StreamWriter ProductName1 = new StreamWriter("ProductName.txt", true);
            ProductName1.Close();
            using (StreamReader sr = new StreamReader("ProductName.txt"))
            {
                string ProductName;
                while ((ProductName = sr.ReadLine()) != null)
                {
                    Stock.ProductName.Add(ProductName);
                }
            }

            StreamWriter QTDE1 = new StreamWriter("QTDE.txt", true);
            QTDE1.Close();
            using (StreamReader sr = new StreamReader("QTDE.txt"))
            {
                string QTDE;
                while ((QTDE = sr.ReadLine()) != null)
                {
                    Stock.QTDE.Add(Convert.ToSingle(QTDE));
                }
            }

            StreamWriter Price1 = new StreamWriter("Price.txt", true);
            Price1.Close();
            using (StreamReader sr = new StreamReader("Price.txt"))
            {
                string Price;
                while ((Price = sr.ReadLine()) != null)
                {
                    Stock.Price.Add(Convert.ToSingle(Price));
                }
            }

            StreamWriter openEdit1 = new StreamWriter("OpenEdit.txt", true);
            openEdit1.Close();
            using (StreamReader sr = new StreamReader("OpenEdit.txt"))
            {
                string openEdit;
                while ((openEdit = sr.ReadLine()) != null)
                {
                    Stock.openEdit.Add(Convert.ToInt32(openEdit));
                }
            }
        }

        public static void WriteTXT()
        {
            int index = 0;
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

            foreach (int x in Stock.ID)
            {
                using (StreamWriter sw = new StreamWriter("ID.txt", true))
                {
                    sw.WriteLine(x);
                }
                
                using (StreamWriter sw = new StreamWriter("ProductName.txt", true))
                {
                    sw.WriteLine(Stock.ProductName[index]);
                }
                
                using (StreamWriter sw = new StreamWriter("QTDE.txt", true))
                {
                    sw.WriteLine(Stock.QTDE[index]);
                }
                
                using (StreamWriter sw = new StreamWriter("Price.txt", true))
                {
                    sw.WriteLine(Stock.Price[index]);
                }

                using (StreamWriter sw = new StreamWriter("OpenEdit.txt", true))
                {
                    sw.WriteLine(Stock.openEdit[index]);
                }

                index++;
            }
        }
    }
}
