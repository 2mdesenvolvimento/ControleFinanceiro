using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public static class Procedure
    {
        public static string ValidarLogin = "SP_VALIDAR_LOGIN";
        public static string NovaConta = "SP_INSERIR_NOVA_CONTA";
        public static string InserirMovimento = "SP_INSERIR_MOVIMENTO";
        public static string InserirEmpresa = "SP_INSERIR_EMPRESA";
        public static string InserirCategoria = "SP_INSERIR_CATEGORIA";
        public static string DetalheCategoria = "SP_DETALHE_CATEGORIA";
        public static string DetalheEmpresa = "SP_DETALHE_EMPRESA";
        public static string DetalheMovimento = "SP_DETALHE_MOVIMENTO";
        public static string ConsultarCategoria = "SP_CONSULTAR_CATEGORIA";
        public static string ConsultarEmpresa = "SP_CONSULTAR_EMPRESA";
        public static string ConsultarMovimento = "SP_CONSULTAR_MOVIMENTO";
        public static string ConsultarUsuario = "SP_CONSULTAR_USUARIO";
        public static string AlterarSenha = "SP_ALTERAR_SENHA";
        public static string AlterarMovimento = "SP_ALTERAR_MOVIMENTO";
        public static string AlterarEmpresa = "SP_ALTERAR_EMPRESA";
        public static string AlterarConta = "SP_ALTERAR_CONTA";
        public static string AlterarCategoria = "SP_ALTERAR_CATEGORIA";

    }
}
