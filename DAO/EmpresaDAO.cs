using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;


namespace DAO
{
    public class EmpresaDAO : Conexao
    {

        public int InserirEmpresa(EmpresaVO objEmpresa)
        {
            MySqlConnection con = MinhaConexao();
            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Procedure.InserirEmpresa;
            cmd.Connection =con;

            cmd.Parameters.AddWithValue("p_nome_empresa", objEmpresa.NomeEmpresa);
            cmd.Parameters.AddWithValue("p_endereco_empresa", objEmpresa.EnderecoEmpresa);
            cmd.Parameters.AddWithValue("p_telefone_empresa", objEmpresa.TelefoneEmpresa);
            cmd.Parameters.AddWithValue("p_id_usuario", objEmpresa.CodigoUsuario);

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
                if(cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
            }
        }
        public int AlterarEmpresa(EmpresaVO objEmpresa)
        {
            MySqlConnection con = MinhaConexao();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Procedure.AlterarEmpresa;
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("p_nome_empresa", objEmpresa.NomeEmpresa);
            cmd.Parameters.AddWithValue("p_endereco_empresa", objEmpresa.EnderecoEmpresa);
            cmd.Parameters.AddWithValue("p_telefone_empresa", objEmpresa.TelefoneEmpresa);
            cmd.Parameters.AddWithValue("p_id_empresa", objEmpresa.CodigoEmpresa);

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
                if(cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
            }
        }
        public List<EmpresaVO> ConsultarEmpresa(int codLogado)
        {
            MySqlConnection con = MinhaConexao();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Procedure.ConsultarEmpresa;
            cmd.Connection = con;

            List<EmpresaVO> lstRetorno = new List<EmpresaVO>();

            cmd.Parameters.AddWithValue("p_id_usuario", codLogado);

            try
            {
                cmd.Connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    EmpresaVO vo = new EmpresaVO();

                    vo.CodigoEmpresa = Convert.ToInt32(dr["id_empresa"]);
                    vo.NomeEmpresa = dr["nome_empresa"].ToString();
                    vo.EnderecoEmpresa = dr["endereco_empresa"].ToString();
                    vo.TelefoneEmpresa = dr["telefone_empresa"].ToString();


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

        public EmpresaVO DetalheEmpresa(int CodEmpresa, int codUsuario)
        {
            MySqlConnection con = MinhaConexao();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Procedure.DetalheEmpresa;
            cmd.Connection = con;

            EmpresaVO objEmpresa = new EmpresaVO();

            cmd.Parameters.AddWithValue("p_id_empresa", CodEmpresa);
            cmd.Parameters.AddWithValue("p_id_usuario", codUsuario);

            try
            {
                cmd.Connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    objEmpresa.CodigoEmpresa = Convert.ToInt32(dr["id_empresa"]);
                    objEmpresa.EnderecoEmpresa = dr["endereco_empresa"].ToString();
                    objEmpresa.NomeEmpresa = dr["nome_empresa"].ToString();
                    objEmpresa.TelefoneEmpresa = dr["telefone_empresa"].ToString();
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
            return objEmpresa;
        }
    }
}
