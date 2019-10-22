using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Biometrico2.Models
{
    public class Conexion
    {
        static readonly string Server = "192.168.51.4";
        //static readonly string Server = "JOCAMPOPC";
        static readonly string Db = "biometrico";
        static readonly string User = "sa";
        static readonly string Pass = "sE/10120";
        //static readonly string Pass = "sa";

        protected SqlConnection conexion { get; set; }

        protected SqlConnection Conectar()
        {
            try
            {
                conexion = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + Db + ";User ID=" + User + ";Password=" + Pass + ";Integrated Security=False;");
                conexion.Open();
                return conexion;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}