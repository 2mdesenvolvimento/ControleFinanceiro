using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DAO
{
    public class Conexao
    {
        string strCon = "Server=LocalHost; database=db_financeiro; uid=root; password=mar15l82";

        public MySqlConnection MinhaConexao()
        {
            MySqlConnection con = new MySqlConnection(strCon);

            return con;
        }
    }
}
