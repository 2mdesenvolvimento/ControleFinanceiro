using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VO;

namespace ControleFinanceiro.Controllers
{
    public class MovimentoController : Controller
    {
        private void MontarTitulo(int tipo)
        {
            switch (tipo)
            {
                case 1:
                    ViewBag.titulo = "Realizar Movimento";
                    ViewBag.subtitulo = "Realize aqui o movimento";
                    break;
                case 2:
                    ViewBag.titulo = "Alterar Movimento";
                    ViewBag.subtitulo = "Realize aqui alteração dos movimentos";
                    break;
                case 3:
                    ViewBag.titulo = "Consultar Movimento";
                    ViewBag.subtitulo = "Realize aqui consulta dos movimentos";
                    break;
            }
        }
        // GET: Movimento
        public ActionResult ConsultarMovimento()
        {
            MontarTitulo(3);
            return View();
        }

        public ActionResult RealizarMovimento()
        {
            MontarTitulo(1);
            CarregarCombos();
            return View();
        }

        public ActionResult AlterarMovimento(int? cod)
        {
            if (cod == null || cod == 0)
            {
                MontarTitulo(3);
                return View("ConsultarMovimento");
            }

            MontarTitulo(2);
            return View();
        }

        public ActionResult Gravar(int? cod, string categoria_movimento, string data_movimento, string valor_movimento, string tipo_movimento, string empresa_movimento, string obs_movimento)
        {
            if (tipo_movimento == "" || categoria_movimento == "" || empresa_movimento == "" || data_movimento == "")
            {
                ViewBag.ret = 0;
            }
            else
            {
                MovimentoDAO dao = new MovimentoDAO();
                MovimentoVO vo = new MovimentoVO();

                vo.TipoMovimento = Convert.ToInt32(tipo_movimento); 
                vo.DataMovimento = Convert.ToDateTime(data_movimento); 
                vo.ValorMovimento = Convert.ToDecimal(valor_movimento); 
                vo.ObsMovimento = obs_movimento; 
                vo.CodigoEmpresa = Convert.ToInt32(empresa_movimento); 
                vo.CodigoCategoria = Convert.ToInt32(categoria_movimento); 
                vo.CodigoMovimento = (cod == null ? 0 : Convert.ToInt32(cod));
                vo.CodigoUsuario = 1;

                
                if(cod == null)
                {
                    ViewBag.ret = dao.RealizarMovimento(vo);
                }
                else
                {
                    ViewBag.ret = dao.AlterarMovimento(vo);

                    ViewBag.Tipo = tipo_movimento;
                    ViewBag.Data = data_movimento;
                    ViewBag.Valor = valor_movimento;
                    ViewBag.Empresa = empresa_movimento;
                    ViewBag.Obs = obs_movimento;
                    ViewBag.Categoria = categoria_movimento;
                    ViewBag.Codigo = cod;
                }
            }
            CarregarCombos();
            MontarTitulo(cod == null ? 1 : 2);
            return View(cod == null ? "RealizarMovimento" : "AlterarMovimento");
        }
        public ActionResult PesquisarMovimento(string data_inicial, string data_final, string tipo_movimento)
        {
            if(data_final == "" || data_inicial == "")
            {
                ViewBag.ret = 0;
            }
            else
            {
                MovimentoDAO dao = new MovimentoDAO();

                List<MovimentoVO> lst = dao.ConsultarMovimento(1, Convert.ToInt32(tipo_movimento), Convert.ToDateTime(data_inicial), Convert.ToDateTime(data_final));

                ViewBag.ListaMovimento = lst;
            }
            MontarTitulo(3);
            return View("ConsultarMovimento");
        }
        private void CarregarCategoria()
        {
            CategoriaDAO dao = new CategoriaDAO();
            List<CategoriaVO> lst = dao.ConsultarCategoria(1);
            ViewBag.ListaCategoria = lst;
        }
        private void CarregarEmpresa()
        {
            EmpresaDAO dao = new EmpresaDAO();
            List<EmpresaVO> lst = dao.ConsultarEmpresa(1);
            ViewBag.ListaEmpresa = lst;
        }
        private void CarregarCombos()
        {
            CarregarCategoria();
            CarregarEmpresa();
        }
    }
}