using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Biometrico2.Models
{
    public class InsertaUsuarioDao :Conexion
    {
        public UsuarioBean sp_Biometrico_Insert_Nuevo_Empleado()
        {
            UsuarioBean usuBean = new UsuarioBean();
            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Biometrico_Insert_Nuevo_Empleado", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader data = cmd.ExecuteReader();
                if (data.Read())
                {
                    if(data["sRespuesta"].ToString() == "") { 

                        usuBean.IdEmpresa      = int.Parse(data["IdEmpresa"].ToString());
                        usuBean.IdEmpresa_Real = int.Parse(data["IdEmpresa_Real"].ToString());
                        usuBean.IdSector       = int.Parse(data["IdSector"].ToString());
                        usuBean.Legajo         = int.Parse(data["Nomina"].ToString());
                        usuBean.Habilitado     = int.Parse(data["Habilitado"].ToString());

                        usuBean.password      = data["Password"].ToString();
                        usuBean.Nombre        = data["Nombre"].ToString();
                        usuBean.Apellido      = data["Apellido"].ToString();
                        usuBean.Documento     = data["Curp"].ToString();
                        usuBean.Email         = data["email"].ToString();
                        usuBean.Telefono      = data["Telefono"].ToString();
                        usuBean.Direccion     = data["Direccion"].ToString();
                        usuBean.FotoUsuario   = data["FotoUsuario"].ToString();
                        usuBean.Observaciones = data["Observaciones"].ToString();
                    }else{
                        usuBean.Mensaje = data["sRespuesta"].ToString();

                    }

                }
                else
                {

                    usuBean.Mensaje = "Error, " + data["sRespuesta"].ToString() + " Verifique!";
                }
                cmd.Dispose();
                data.Close();
                conexion.Close();
            }
            catch (Exception e)
            {
                Console.Write(e);
                usuBean.Mensaje = "Error, " + e;
            }
            return usuBean;
        }

        public UsuarioBean sp_Biometrico_Update_Empleado(int empresa, int nomina)
        {
            UsuarioBean usuBean = new UsuarioBean();

            try
            {
                this.Conectar();
                SqlCommand cmd = new SqlCommand("sp_Biometrico_Update_Empleado", this.conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.Add(new SqlParameter("@ctrlEmpresa", empresa));
                cmd.Parameters.Add(new SqlParameter("@ctrlNomina", nomina));
                SqlDataReader data = cmd.ExecuteReader();

                if (data.Read())
                {
                    usuBean.Mensaje = data["sRespuesta"].ToString();
                }

                cmd.Dispose();
                data.Close();
                conexion.Close();
            }
            catch (Exception e)
            {
                Console.Write(e);
            }

            return usuBean;
        }
    }
}
