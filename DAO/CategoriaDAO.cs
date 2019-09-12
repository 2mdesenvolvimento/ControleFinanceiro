using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAO
{
    public class CategoriaDAO : Conexao
    {
        public int InserirCategoria(CategoriaVO objCategoria)
        {
            //Criar variavel para receber obj de conexao

            MySqlConnection con = MinhaConexao();

            //criar o objeto de instruções
            MySqlCommand cmd = new MySqlCommand();

            //Configura as instruções
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Procedure.InserirCategoria;
            cmd.Connection = MinhaConexao();

            //Configurar os vvalores para ser passar para a proc
            cmd.Parameters.AddWithValue("p_nome_categoria", objCategoria.NomeCategoria);
            cmd.Parameters.AddWithValue("p_id_usuario", objCategoria.CodigoUsuario);

            try
            {
                //Abrir conexao
                cmd.Connection.Open();
                //executar
                cmd.ExecuteNonQuery();

                return 1;
            }
            catch 
            {

                return -1;
            }
            finally
            {
                if(cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }

            }

        }

        public int AlterarCategoria(CategoriaVO objCategoria)
        {
            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Procedure.AlterarCategoria;
            cmd.Connection = MinhaConexao();

            cmd.Parameters.AddWithValue("p_id_categoria", objCategoria.Codigo);
            cmd.Parameters.AddWithValue("p_nome_categoria", objCategoria.NomeCategoria);

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                return 1;

            }
            catch 
            {
                return -1;
            }
            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
            }
        }
        public List<CategoriaVO> ConsultarCategoria(int codLogado)
        {
            MySqlConnection con = MinhaConexao();

            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Procedure.ConsultarCategoria;
            cmd.Connection = con;

            List<CategoriaVO> lstRetorno = new List<CategoriaVO>();

            cmd.Parameters.AddWithValue("p_idusuario", codLogado);

            try
            {
                cmd.Connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    CategoriaVO vo = new CategoriaVO();

                    vo.Codigo = Convert.ToInt32(dr["id_categoria"]);
                    vo.NomeCategoria = dr["nome_categoria"].ToString();

                    lstRetorno.Add(vo);
                }
                if (dr.HasRows)
                {
                    dr.Close();
                }
            }
            catch 
            {
                return null;
            }
            finally
            {
                if(cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
            }
            return lstRetorno;
        }
        public CategoriaVO DetalheCategoria(int codCategoria, int v)
        {
            MySqlConnection con = MinhaConexao();

            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Procedure.DetalheCategoria;
            cmd.Connection = con;

            CategoriaVO objCategoria = new CategoriaVO();

            cmd.Parameters.AddWithValue("p_id_usuario", codCategoria);
            cmd.Parameters.AddWithValue("p_id_cat", codCategoria);

            try
            {
                cmd.Connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    objCategoria.Codigo = Convert.ToInt32(dr["id_categoria"]);
                    objCategoria.NomeCategoria = dr["nome_categoria"].ToString();
                }
                if (dr.HasRows)
                {
                    dr.Close();
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                if(cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
            }
            return objCategoria;
        }
    }
}
