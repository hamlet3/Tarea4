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
            if (!IsPostBack)
            {
                this.TelefonoGv.DataSource = ObtenerNuevaLista();
                this.TelefonoGv.DataBind();
            }
        }

        public List<PersonasTelefonos> ObtenerNuevaLista() {
            List<PersonasTelefonos> lista = new List<PersonasTelefonos>();

            PersonasTelefonos telefono1 = new PersonasTelefonos();

            

            lista.Add(telefono1);

            return lista;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            persona.Nombres = Nombretxt.Text;
            persona.Sexo = SexoDDw.Text;
            
            
            foreach (GridViewRow row in TelefonoGv.Rows)
            {
                persona.AgregarTelefono(1, row.Cells[0].Text, row.Cells[1].Text);
                
            }

            persona.Insertar();

        }


        protected void Nombretxt_TextChanged(object sender, EventArgs e)
        {

        }

       

        protected void TelefonoGv_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        private List<PersonasTelefonos> GuardarLista(PersonasTelefonos telefono)
        {
            if (Session["lista"] == null)
            {
                List<PersonasTelefonos> telefono2 = this.ObtenerNuevaLista();
                telefono2.Add(telefono);
                Session["lista"] = telefono2;
            }else
            {
                List<PersonasTelefonos> telefono2 = (List<PersonasTelefonos>)Session["lista"];
                telefono2.Add(telefono);
                Session["lista"] = telefono2;
            }
            return (List<PersonasTelefonos>)Session["lista"];
        }



        private List<PersonasTelefonos> ObtenerLista()
        {
            if (Session["lista"] == null)
            {
                return this.ObtenerNuevaLista();
            }
            else
                return (List<PersonasTelefonos>)Session["lista"];
        }

        protected void TelefonoGv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew")) {
                TextBox Telefonotxt = (TextBox)TelefonoGv.FooterRow.FindControl("Telefonotxt");
                TextBox TipoTelefonotxt = (TextBox)TelefonoGv.FooterRow.FindControl("TipoTelefonotxt");

                PersonasTelefonos telefono = new PersonasTelefonos();

                telefono.Telefono = Telefonotxt.Text;
                telefono.TipoTelefono = TipoTelefonotxt.Text;

                this.GuardarLista(telefono);

                this.TelefonoGv.DataSource = this.ObtenerLista();
                this.TelefonoGv.DataBind();
            }
        }   
    }
}