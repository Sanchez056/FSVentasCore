﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FSVentasCore.Models
{
    public class TipoUsuarios
    {
        [Key]
        public int TipoId { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = "Introducir el Nombre de Tipo de Usuarios")]
        public string Nombre { get; set; }

    }
}
