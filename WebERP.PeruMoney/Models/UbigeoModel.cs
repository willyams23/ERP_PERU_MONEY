using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace WebERP.PeruMoney.Models
{
    public class UbigeoModel
    {
        public int IdUbigeo { get; set; }
        public string Ubigeo { get; set; }
        public string IdDepartamento { get; set; }
        public string Departamento { get; set; }
        public string IdProvincia { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }


    }
}