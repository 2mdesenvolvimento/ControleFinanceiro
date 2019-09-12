using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class EmpresaVO : GeralVO
    {
        public int CodigoEmpresa { get; set; }
        public string NomeEmpresa { get; set; }
        public string EnderecoEmpresa { get; set; }
        public string TelefoneEmpresa { get; set; }
    }
}
