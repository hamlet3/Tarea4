﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Personas : ClaseMaestra
    {
        
        public int PersonaId { get; set; }
        public string Nombres { get; set; }
        public string Sexo { get; set; }
        ConexionDb conexion = new ConexionDb();
        
        public List<PersonasTelefonos> telefono { get; set; }
       
        public Personas(int personaId, string nombres, string sexo)
        {
            this.PersonaId = personaId;
            this.Nombres = nombres;
            this.Sexo = sexo;
        }

        public Personas(string nombre, string sexo)
        {
            this.Nombres = nombre;
            this.Sexo = sexo;
        }

        public Personas()
        {
            telefono = new List<PersonasTelefonos>();
        }

        public void AgregarTelefono(string Telefono, string TipoTelefono)
        {
            this.telefono.Add(new PersonasTelefonos( Telefono, TipoTelefono));
        }

        public override bool Insertar()
        {
            int retorno = 0;
            object identity;
            try
            {
                
                identity = conexion.ObtenerValor(String.Format("Insert into Personas (Nombre, Sexo) Values ('{0}','{1}') select @@Identity", this.Nombres, this.Sexo));

                
                int.TryParse(identity.ToString(), out retorno);

               
                
                    foreach (PersonasTelefonos numeros in this.telefono)
                    {
                        conexion.Ejecutar(String.Format("Insert into PersonasTelefonos (PersonaId, TipoTelefono, Telefono) Values ({0},'{1}','{2}')", retorno, numeros.TipoTelefono, numeros.Telefono));
                    }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno > 0;
        }

        public override bool Editar()
        {
            bool retorno = false;
            try
            {                                              
                retorno = conexion.Ejecutar(String.Format("Update Personas set Nombre='{0}', Sexo='{1}' where PersonaId={2}", this.Nombres, this.Sexo, this.PersonaId));
                if (retorno)
                {
                    conexion.Ejecutar(String.Format("Delete from PersonasTelefonos where PersonaId={0}", this.PersonaId));
                    foreach (PersonasTelefonos numeros in this.telefono)
                    {
                        conexion.Ejecutar(String.Format("Insert into PersonasTelefonos (PersonaId, TipoTelefono, Telefono) Values ({0},'{1}','{2}')", PersonaId, numeros.TipoTelefono, numeros.Telefono));
                    }
                }
            }
            catch (Exception ex) { throw ex; }
            return retorno;
        }

        public override bool Eliminar()
        {
            bool retorno = false;
            try
            {

              

                retorno = conexion.Ejecutar(String.Format("Delete from PersonasTelefonos where PersonaId={0}", this.PersonaId + ";"+"Delete from Personas where PersonaId="+ this.PersonaId));
                
     
            }
            catch (Exception ex) { throw ex; }
            return retorno;
        }

        public override bool Buscar(int IdBuscado)
        {
            DataTable dt = new DataTable();
            DataTable dtTelefonos = new DataTable();

            dt = conexion.ObtenerDatos("Select * from Personas where PersonaId=" + IdBuscado);
            if (dt.Rows.Count > 0)
            {
                this.PersonaId = (int)dt.Rows[0]["PersonaId"];
                this.Nombres = dt.Rows[0]["Nombre"].ToString();
                this.Sexo = dt.Rows[0]["Sexo"].ToString();

                dtTelefonos = conexion.ObtenerDatos(String.Format("Select * from PersonasTelefonos WHERE PersonaId=" + IdBuscado));

                foreach (DataRow row in dtTelefonos.Rows)
                {
                    this.AgregarTelefono(row["Telefono"].ToString(), row["TipoTelefono"].ToString());
                }
            }
            return dt.Rows.Count > 0;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            string ordenar = "";
            if (!Orden.Equals(""))
                ordenar = " orden by  " + Orden;
            return conexion.ObtenerDatos(("select " + Campos + " from Personas where " + Condicion + ordenar));
        }
    }
}