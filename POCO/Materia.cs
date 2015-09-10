using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class Materia
    {
        public int codMateria { get; set; }

        public int codPessoa_Jornalista { get; set; }

        public int codPessoa_Revisor { get; set; }

        public int codPessoa_Publicador { get; set; }

        public string nome { get; set; }

        public string materiaEscrita { get; set; }

        public int codSecao { get; set; }

        public string status { get; set; }

        public DateTime dataCadastro { get; set; }

        public DateTime dataAtualizacao { get; set; }

        public string revisao { get; set; }

        //Transients
        public string Jornalista { get; set; }
        
        public string Revisor { get; set; }

        public string Publicador { get; set; }

        public string Gerente { get; set; }
    }
}
