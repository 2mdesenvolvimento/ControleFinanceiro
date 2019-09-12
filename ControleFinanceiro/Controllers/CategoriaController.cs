using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VO;

namespace ControleFinanceiro.Controllers
{
    public class CategoriaController : Controller
    {
        private void MontarTitulo(int tipo)
        {
            switch (tipo)
            {
                case 1:
                    ViewBag.titulo = "Nova Categoria";
                    ViewBag.subtitulo = "Cadastre aqui sua categoria";
                    break;
                case 2:
                    ViewBag.titulo = "Alterar Categoria";
                    ViewBag.subtitulo = "Altera aqui sua categoria";
                    break;
                case 3:
                    ViewBag.titulo = "Consulta Categoria";
                    ViewBag.subtitulo = "Consulta aqui sua categoria";
                    break;
            }
        }

        // GET: Categoria
        public ActionResult Cadastrar()
        {
            MontarTitulo(1);
            return View();
        }

        public ActionResult Consultar()
        {
            CarregarCategoria();

            MontarTitulo(3);

            return View();
        }
        public ActionResult Gravar(int? cod, string nome_categoria)
        {
            if(nome_categoria.Trim() == "")
            {
                ViewBag.ret = 0;
            }
            else
            {
                CategoriaVO vo = new CategoriaVO();
                CategoriaDAO dao = new CategoriaDAO();

                vo.NomeCategoria = nome_categoria.Trim();
                vo.Codigo = (cod != null ? Convert.ToInt32(cod) : 0);
                vo.CodigoUsuario = 1;

                ViewBag.ret = (cod != null ? dao.AlterarCategoria(vo) : dao.InserirCategoria(vo));
            }
            MontarTitulo(cod == null ? 1 : 2);
            return View(cod == null ? "Cadastrar" : "Alterar");
        }

        public ActionResult Alterar(int? Codigo)
        {
            if(Codigo == null || Codigo == 0)
            {
                CarregarCategoria();
                MontarTitulo(3);
                return View("Consultar");
            }

            //Irá pesquisar no banco e o resultado será exibido aqui!
            CategoriaDAO dao = new CategoriaDAO();

            CategoriaVO objCategoria = dao.DetalheCategoria(Convert.ToInt32(Codigo), 1);

            if(objCategoria.Codigo == 0)
            {
                MontarTitulo(3);
                return View("Consultar");
            }

            ViewBag.codigo = objCategoria.Codigo;
            ViewBag.Nome_categoria = objCategoria.NomeCategoria;

            MontarTitulo(2);
            return View();
        }
        private void CarregarCategoria()
        {
            CategoriaDAO dao = new CategoriaDAO();
            List<CategoriaVO> lstCategorias = dao.ConsultarCategoria(1);
            ViewBag.ListaCategoria = lstCategorias;
        }
    }
}