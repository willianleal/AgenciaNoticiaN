﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using POCO;

namespace BLL
{
    public class PessoaBLL
    {
        private PessoaDAL dao = null;

        public PessoaBLL()
        {
            dao = new PessoaDAL();
        }

        public bool inserir(int codPessoa, string nome, string funcao, string ddd, string telefone, string email, bool ativo, DateTime dataCadastro, string senha)
        {
            try
            {
                return dao.inserir(codPessoa, nome, funcao, ddd, telefone, email, ativo, dataCadastro, senha);
            }
            catch
            {
                return false;
            }
        }

        public bool alterar(int codPessoa, string nome, string funcao, string ddd, string telefone, string email, bool ativo, DateTime dataCadastro, string senha)
        {
            try
            {
                return dao.alterar(codPessoa, nome, funcao, ddd, telefone, email, ativo, dataCadastro, senha);
            }
            catch
            {
                return false;
            }
        }

        public bool deletar(int codPessoa)
        {
            try
            {
                return dao.deletar(codPessoa);
            }
            catch
            {
                return false;
            }
        }

        public List<Pessoa> listar(int codPessoa)
        {
            try
            {
                return dao.listar(codPessoa);
            }
            catch
            {
                return null;
            }
        }
        
        public string validarLogin(string email, string senha)
        {
            if (email.Equals("") || senha.Equals(""))
            {
                return "Preencha todos os campos";
            }
            else
            {
                string senhaCript = Util.GetMD5Hash(senha);
                return dao.validarAcesso(email, senhaCript);
            }
        }

    }
}
