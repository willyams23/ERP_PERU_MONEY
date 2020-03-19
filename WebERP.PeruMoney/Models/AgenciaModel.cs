using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebERP.PeruMoney.Models
{
    public class AgenciaModel
    {
        public int IdAgencia { get; set; }

        [DataType(DataType.Text)]
        [MaxLength(100), MinLength(3)]
        [Required(ErrorMessage = "* Ingrese Agencia")]
        public string Agencia { get; set; }


        [Range(1, 2100, ErrorMessage = "* Seleccione Distrito")]
        public int IdUbigeo { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public int Estado { get; set; }
        public string UserReg { get; set; }
        public DateTime FecReg { get; set; }
        public string UserMod { get; set; }
        public DateTime FecMod { get; set; }


        [DataType(DataType.Text)]
        [MaxLength(4), MinLength(2)]
        [Required(ErrorMessage = "* Seleccione Departamento")]
        public string IdDepartamento { get; set; }
        
        public string Departamento { get; set; }

        [DataType(DataType.Text)]
        [MaxLength(6), MinLength(4)]
        [Required(ErrorMessage = "* Seleccione Provincia")]
        public string IdProvincia { get; set; }
        
        public string Provincia { get; set; }
        public string Distrito { get; set; }

        [NotMapped]
        public List<UbigeoModel> DepartamentoList { get; set; }

        [NotMapped]
        public List<UbigeoModel> ProvinciaList { get; set; }

        [NotMapped]
        public List<UbigeoModel> DistritoList { get; set; }
    }
}