using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class Pessoa
    {
        public int codPessoa { get; set; }

        public string nome { get; set; }

        public string funcao { get; set; }

        public string ddd { get; set; }

        public string telefone { get; set; }

        public string email { get; set; }

        public bool ativo { get; set; }

        public DateTime dataCadastro { get; set; }

        public string senha { get; set; }

        public bool administrador { get; set; }
    }
}
