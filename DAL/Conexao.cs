using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Conexao
    {
        public static string StringDeConexao
        {
            //Banco web
            get { return @"Data Source=WILLIAM_NB\MSSQLSERVEREXP; Initial Catalog=AgenciaNoticias; User Id=AgenciaNoticias; Password=eternidade77; Integrated Security=True"; }

            //get { return "server=WILLIAM_NB\MSSQLSERVEREXP;database=AgenciaNoticias;user=AgenciaNoticias;pwd=eternidade77"; }

            //Banco local
            //get { return "Data Source=10.2.20.80;Initial Catalog=Conc3_Novo;User ID=Delphi;Password=#des@735#"; }

        }
    }
}
