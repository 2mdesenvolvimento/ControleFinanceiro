using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VO;

namespace ControleFinanceiro.Controllers
{
    public class EmpresaController : Controller
    {
        private void MontarTitulo(int tipo)
        {
            switch (tipo)
            {
                case 1:
                    ViewBag.titulo = "Cadastrar Empresa";
                    ViewBag.subtitulo = "Cadastre aqui suas empresas";
                    break;
                case 2:
                    ViewBag.titulo = "Alterar Empresa";
                    ViewBag.subtitulo = "Altere aqui suas empresas";
                    break;
                case 3:
                    ViewBag.titulo = "Consultar Empresa";
                    ViewBag.subtitulo = "Consulte aqui suas empresas";
                    break;
            }
        }

        // GET: Empresa
        public ActionResult Cadastrar()
        {
            MontarTitulo(1);
            return View();
        }
        public ActionResult Alterar(int? cod_empresa)
        {
            if(cod_empresa == null || cod_empresa == 0)
            {
                CarregarEmpresa();
                MontarTitulo(3);
                return View("Consultar");
            }

            EmpresaDAO dao = new EmpresaDAO();
            EmpresaVO vo = dao.DetalheEmpresa(Convert.ToInt32(cod_empresa), 1);

            ViewBag.cod_empresa = vo.CodigoEmpresa;
            ViewBag.nome_empresa = vo.NomeEmpresa;
            ViewBag.endereco_empresa = vo.EnderecoEmpresa;
            ViewBag.telefone_empresa = vo.TelefoneEmpresa;
            MontarTitulo(2);
            return View();
        }
        public ActionResult Consultar()
        {
            CarregarEmpresa();
            MontarTitulo(3);
            return View();
        }
        public ActionResult Gravar(int? cod_empresa, string nome_empresa, string endereco_empresa, string telefone_empresa)
        {
            if(nome_empresa.Trim() == "" || endereco_empresa.Trim() == "" || telefone_empresa.Trim() == "")
            {
                ViewBag.ret = 0;
            }
            else
            {
                EmpresaVO vo = new EmpresaVO();
                EmpresaDAO dao = new EmpresaDAO();

                vo.CodigoEmpresa = cod_empresa == null ? 0 : Convert.ToInt32(cod_empresa);
                vo.CodigoUsuario = 1;
                vo.EnderecoEmpresa = endereco_empresa;
                vo.NomeEmpresa = nome_empresa;
                vo.TelefoneEmpresa = telefone_empresa;

                if(cod_empresa != null)
                {
                    ViewBag.ret = dao.AlterarEmpresa(vo);

                    ViewBag.cod_empresa = cod_empresa;
                    ViewBag.nome_empresa = nome_empresa;
                    ViewBag.telefone_empresa = telefone_empresa;
                    ViewBag.endereco_empresa = endereco_empresa;
                }
                else
                {
                    ViewBag.ret = dao.InserirEmpresa(vo);
                }


                ViewBag.ret = dao.InserirEmpresa(vo);
            }

            MontarTitulo(cod_empresa == null ? 1 : 2);
            return View(cod_empresa == null ? "Cadastrar" : "Alterar");
        }

        private void CarregarEmpresa()
        {
            EmpresaDAO dao = new EmpresaDAO();
            ViewBag.ListaEmpresa = dao.ConsultarEmpresa(1);
        }
    }

}