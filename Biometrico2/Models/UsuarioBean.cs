using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Biometrico2.QPws;

namespace Biometrico2.Models
{
    public class UsuarioBean
    {
        public int IdEmpresa { get; set; }
        public int IdEmpresa_Real { get; set; }
        public int IdSector { get; set; }
        public int Legajo { get; set; }
        public int Habilitado { get; set; }

        public string password { get; set; }
        public string Nombre { get; set; }
        public string Apellido{ get; set; }
        public string Documento{ get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string FotoUsuario { get; set; }
        public string Observaciones { get; set; }

        public string Mensaje { get; set; }
        
    }
}