using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FSVentasCore.Models
{
    public class Proveedores
    {
        [Key]
        public int ProveedorId { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = "Introducir su Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = "Introducir la Marca de Articulo")]
        public int MarcaId { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = " Elegir Su Provincia")]
        public int ProvinciaId { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = " Elegir Su Ciudad")]
        public int CiudadId { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = " Elegir Su Municipio")]
        public int MunicipioId { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = "Introducir su Direccion")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = "Introducir su Numero Telefono ")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = "Introducir su Numero de Fax")]
        public string Fax { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = "Introducir su Correo Eletronico")]
        public string Correo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy - mm - dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
    }
}
