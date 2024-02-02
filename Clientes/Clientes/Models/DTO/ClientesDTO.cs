using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Clientes.Models.DTO
{
    public class ClientesDTO
    {

        public int CodigoCliente { get; set; }
        [Required]
        [StringLength(255)]
        public string NombreCliente { get; set; }
        [Required]
        [StringLength(255)]
        public string CiudadCliente { get; set; }
        [Required]
        [StringLength(255)]
        public string Direccion { get; set; }
        [Required]
        [StringLength(255)]
        [Phone]
        public string Telefono { get; set; }
    }
}