using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace AgenciaNoticasN
{
    public partial class Login : System.Web.UI.Page
    {
        private PessoaBLL bll = new PessoaBLL();
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string respLogin = bll.validarLogin(Login1.UserName, Login1.Password);

            if (respLogin.Equals(""))
            {
                Session["email"] = Login1.UserName;
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