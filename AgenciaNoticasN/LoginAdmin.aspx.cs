using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace AgenciaNoticasN
{
    public partial class LoginAdmin : System.Web.UI.Page
    {
        private PessoaBLL bll = new PessoaBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string respLogin = bll.validarLogin(Login1.UserName, Login1.Password, true);
            //string senha = "eternidade77";
            //string email = "willianleal@gmail.com";
            //string respLogin = bll.validarLogin(email, senha, true);

            if (respLogin.Equals(""))
            {
                Session["email"] = Login1.UserName;
                //Session["email"] = email;
                e.Authenticated = true;
            }
            else
            {
                Login1.FailureText = respLogin;
                Login1.DataBind();
                e.Authenticated = false;
            }        
        }
    }
}