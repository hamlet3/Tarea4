using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tarea4
{
    public partial class Default : System.Web.UI.Page
    {
        public Personas persona = new Personas();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            persona.Nombres = Nombretxt.Text;
            persona.Sexo = SexoDDw.Text;
            persona.Insertar();
            
        }

        protected void Agregarbtn_Click(object sender, EventArgs e)
        {
            persona.AgregarTelefono(TipoTelefonotxt.Text, Telefonotxt.Text);

            foreach(var telefonos in persona.telefono)
            {
                TelefonoLb.Items.Add(telefonos.Telefono + "  " + telefonos.TipoTelefono);
            }
        }

        protected void TelefonoLb_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void BorrarBtn_Click(object sender, EventArgs e)
        {
            TelefonoLb.Items.Remove(TelefonoLb.SelectedValue);
        }

        protected void Nombretxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}