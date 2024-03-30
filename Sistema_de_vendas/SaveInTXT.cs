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
            StreamWriter ID1 = new StreamWriter("ID.txt", true);
            ID1.Close();
            using (StreamReader sr = new StreamReader("ID.txt"))
            {
                string ID;
                while ((ID = sr.ReadLine()) != null)
                {
                    Stock.ID.Add(Convert.ToInt32(ID));
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

            foreach (int x in Stock.ID)
            {
                using (StreamWriter sw = new StreamWriter("ID.txt", true))
                {
                    sw.WriteLine(Stock.ID[index]);
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

                index++;
            }
        }
    }
}
