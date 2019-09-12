using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class MovimentoVO : GeralVO
    {
        public int CodigoMovimento { get; set; }
        public int TipoMovimento { get; set; }
        public DateTime DataMovimento { get; set; }
        public decimal ValorMovimento { get; set; }
        public string ObsMovimento { get; set; }
        public int CodigoCategoria { get; set; }
        public int CodigoEmpresa { get; set; }
        public string Empresa { get; set; }
        public string Categoria { get; set; }
        public string NomeTipo { get; set; }
    }
}
