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

        public void Limpiar()
        {
            ((TextBox)Nombretxt).Text = string.Empty;
            ((TextBox)PersonaIdtxt).Text = string.Empty;
            SexoDDw.SelectedIndex = 0;
            TelefonoGv.DataSource = null;
            TipoTelefonoDDL.SelectedIndex = 0;
            ((TextBox)Telefonotxt).Text = string.Empty;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (PersonaIdtxt.Text=="")
            {
                Personas persona;
                if (Session["persona"] == null)
                    Session["persona"] = new Personas();
                persona = (Personas)Session["persona"];

                persona.Nombres = Nombretxt.Text;
                persona.Sexo = SexoDDw.Text;


              
                if (persona.Insertar())
                {
                    Response.Write("<script>alert('Insertado Correctamente')</script>");

                    Limpiar();
                }
            }
            else
            {
                Personas persona;
                if (Session["persona"] == null)
                    Session["persona"] = new Personas();

                persona = (Personas)Session["persona"];

                int id;
                int.TryParse(PersonaIdtxt.Text, out id);
                persona.PersonaId = id;
                persona.Nombres = Nombretxt.Text;
                persona.Sexo = SexoDDw.Text;
                if (Nombretxt.Text != "")
                {
                    if (persona.Editar())
                    {
                        Response.Write("<script>alert('se a editado correctamente')</script>");
                        Limpiar();
                    }
                }
            }
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
        
        public void TelefonoGv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew")) {
                
                PersonasTelefonos telefono = new PersonasTelefonos();
                
                telefono.Telefono = Telefonotxt.Text;
                telefono.TipoTelefono = TipoTelefonoDDL.Text;

                this.GuardarLista(telefono);

                this.TelefonoGv.DataSource = this.ObtenerLista();
                this.TelefonoGv.DataBind();
                TipoTelefonoDDL.SelectedIndex = 0;
            }
        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void BuscarBtn_Click(object sender, EventArgs e)
        {
            Personas persona;
            if (Session["persona"] == null)
                Session["persona"] = new Personas();
            persona = (Personas)Session["persona"];
           
            int id;
            int.TryParse(PersonaIdtxt.Text, out id);
            persona.Buscar(id);
            Session["persona"] = persona;
            Nombretxt.Text = persona.Nombres;
            SexoDDw.Text = persona.Sexo;

            
            foreach (PersonasTelefonos p in persona.telefono)
            {

                this.GuardarLista(p);
            }
            this.TelefonoGv.DataSource = this.ObtenerLista();
            this.TelefonoGv.DataBind();


        }

        protected void SexoDDw_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void EliminarBtn_Click(object sender, EventArgs e)
        {
            Personas persona = new Personas(); 
            int id;
            int.TryParse(PersonaIdtxt.Text, out id);
            if (persona.Buscar(id))
            {
                if (persona.Eliminar())
                {
                    Response.Write("<script>alert('Se elimino correctamente')</script>");
                    Limpiar();
                }
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Personas persona;

            if (Session["persona"] == null)
                Session["persona"] = new Personas();


            persona = (Personas)Session["persona"];

            persona.AgregarTelefono(Telefonotxt.Text, TipoTelefonoDDL.Text);
            Session["persona"]=persona;

            PersonasTelefonos telefono = new PersonasTelefonos();

                telefono.Telefono = Telefonotxt.Text;
                telefono.TipoTelefono = TipoTelefonoDDL.Text;

                this.GuardarLista(telefono);

                this.TelefonoGv.DataSource = persona.telefono;
                this.TelefonoGv.DataSource = this.ObtenerLista();
                this.TelefonoGv.DataBind();
               
            
        }
    }
}