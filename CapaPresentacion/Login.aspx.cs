using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidades;
using CapaLogicaNegocio;

namespace CapaPresentacion
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            // Ya tengo los datos que corresponden para el login
            Empleado objEmpleado = EmpleadoLN.getInstance().AccesoSistema(txtUsuario.Text, txtPassword.Text);

            if (objEmpleado != null)
            {
                // significa que si ha accedido a la base de datos y que a su vez ha traido un objeto
                Response.Write("<script>alert('USUARIO CORRECTO.')</script>");
                Response.Redirect("PanelGeneral.aspx");
            }
            else
            {
                Response.Write("<script>alert('USUARIO INCORRECTO.')</script>");
            }
        }
    }
}