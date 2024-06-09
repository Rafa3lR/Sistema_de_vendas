using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_vendas
{
    internal class bllProduct
    {
        DAL db;

        public void inserir(dtoProduct dto)
        {
            db = new DAL();
            db.Conectar();
            string comando = $"call INSERIR_PRODUCT('{dto.ProductName}','{dto.QTDE}','{dto.Price}')";
            db.ExecutarComandoSQL(comando);
        }

        public void alterar(dtoProduct dto)
        {
            db = new DAL();
            db.Conectar();
            string comando = $"call ALTERAR_PRODUCT('{dto.ID}','{dto.ProductName}','{dto.QTDE}','{dto.Price}')";
            db.ExecutarComandoSQL(comando);
        }

        public void deletar(dtoProduct dto)
        {
            db = new DAL();
            db.Conectar();
            string comando = $"call DELETAR_PRODUCT('{dto.ID}')";
            db.ExecutarComandoSQL(comando);
        }

        public void selecionar()
        {
            db = new DAL();
            db.Conectar();

            string comando = "call SELECIONAR_TODOS_PRODUCT()";

            MySqlDataReader reader = db.RetDataReader(comando);


            Stock.dtoProduct.Clear();
            CadProducts.quantProds = 0;

            while (reader.Read())
            {
                Stock.dtoProduct.Add(new dtoProduct());
                int i = Stock.dtoProduct.Count - 1;
                Stock.dtoProduct[i].ID = reader.GetInt32(reader.GetOrdinal("ID_PRODUCTS"));
                Stock.dtoProduct[i].ProductName = reader.GetString(reader.GetOrdinal("NOME_PRODUCT"));
                Stock.dtoProduct[i].QTDE = reader.GetFloat(reader.GetOrdinal("QTDE_PRODUCT"));
                Stock.dtoProduct[i].Price = reader.GetFloat(reader.GetOrdinal("PRICE_PRODUCT"));

                CadProducts.quantProds = reader.GetInt32(reader.GetOrdinal("ID_PRODUCTS"));
                
            }

            CadProducts.quantProds++;

            reader.Close();
            db.Fechar();
        }
    }
}
