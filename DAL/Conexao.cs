﻿using System;
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
            //get { return @"Data Source=WILLIAM_NB\MSSQLSERVEREXP; Initial Catalog=AgenciaNoticias; User Id=AgenciaNoticias; Password=eternidade77; Integrated Security=True"; }

            //Banco local
            get { return @"Data Source=WKSDES08; Initial Catalog=AgenciaNoticias; User Id=AgenciaNoticias; Password=eternidade77"; }

        }
    }
}
