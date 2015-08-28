using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCO
{
    public class Comentario
    {
        public int codComentario { get; set; }

        public int codMateria { get; set; }

        public int codPessoa { get; set; }

        public string titulo { get; set; }

        public string comentario { get; set; }

        public DateTime dataCadastro { get; set; }
    }
}
