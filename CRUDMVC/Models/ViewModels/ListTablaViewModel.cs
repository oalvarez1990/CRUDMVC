﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDMVC.Models.ViewModels
{
    public class ListTablaViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public DateTime fecha_Nacimiento { get; set; }
    }
}