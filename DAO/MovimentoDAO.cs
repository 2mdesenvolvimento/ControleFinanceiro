using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using VO;

namespace DAO
{
    public class MovimentoDAO : Conexao
    {
        public int RealizarMovimento(MovimentoVO objMovimento)
        {
            MySqlConnection con = MinhaConexao();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Procedure.InserirMovimento;
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("p_tipo_movimento", objMovimento.TipoMovimento);
            cmd.Parameters.AddWithValue("p_datamovimento", objMovimento.DataMovimento);
            cmd.Parameters.AddWithValue("p_valor_movimmento", objMovimento.ValorMovimento);
            cmd.Parameters.AddWithValue("p_obs_Movimento", objMovimento.ObsMovimento);
            cmd.Parameters.AddWithValue("p_idcategoria", objMovimento.CodigoCategoria);
            cmd.Parameters.AddWithValue("p_idempresa", objMovimento.CodigoEmpresa);
            cmd.Parameters.AddWithValue("p_idusuario", objMovimento.CodigoUsuario);

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
        public int AlterarMovimento(MovimentoVO objMovimento)
        {
            MySqlConnection con = MinhaConexao();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Procedure.AlterarMovimento;
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("p_tipo_movimento", objMovimento.TipoMovimento);
            cmd.Parameters.AddWithValue("p_datamovimento", objMovimento.DataMovimento);
            cmd.Parameters.AddWithValue("p_valor_movimmento", objMovimento.ValorMovimento);
            cmd.Parameters.AddWithValue("p_obs_Movimento", objMovimento.ObsMovimento);
            cmd.Parameters.AddWithValue("p_idcategoria", objMovimento.CodigoCategoria);
            cmd.Parameters.AddWithValue("p_idempresa", objMovimento.CodigoEmpresa);
            cmd.Parameters.AddWithValue("p_id_movimento", objMovimento.CodigoMovimento);

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
        public List<MovimentoVO>ConsultarMovimento(int CodLogado, int tipo, DateTime dtInicial, DateTime dtFinal)
        {
            MySqlConnection con = MinhaConexao();
            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = Procedure.ConsultarMovimento;
            cmd.Connection = con;

            List<MovimentoVO> lstRetorno = new List<MovimentoVO>();

            cmd.Parameters.AddWithValue("p_id_usuario", CodLogado);
            cmd.Parameters.AddWithValue("p_tipo", tipo);
            cmd.Parameters.AddWithValue("p_data_inicial", dtInicial);
            cmd.Parameters.AddWithValue("p_data_final", dtFinal);

            try
            {
                cmd.Connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    MovimentoVO vo = new MovimentoVO();

                    vo.Empresa = dr["nome_empresa"].ToString();
                    vo.Categoria = dr["nome_categoria"].ToString();
                    vo.DataMovimento = Convert.ToDateTime(dr["data_movimento"]);
                    vo.NomeTipo = (dr["tipo_movimento"].ToString() == "1" ? "Entrada" : "Saída");
                    vo.ValorMovimento = Convert.ToDecimal(dr["valor_movimento"]);
                    vo.CodigoMovimento = Convert.ToInt32(dr["id_movimento"]);

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
    }
}
