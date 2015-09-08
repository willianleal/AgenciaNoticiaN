using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class Secao
    {
        public int codSecao { get; set; }

        public string nome { get; set; }

        public int codPessoa_Gerente { get; set; }

        public DateTime dataCadastro { get; set; }

        //Transients
        public string Gerente { get; set; }
    }
}
