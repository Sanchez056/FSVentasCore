using FSVentasCore.Models.Dirreciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FSVentasCore.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        //-----------
        [Display(Name = "Introducir su Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        //-----------
        [Display(Name = "  Elegir su Sexo")]
        public string Sexo { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        //-----------
        [Display(Name = "Introducir Numero de Cedula")]
        public string Cedula { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        //-----------
        [Display(Name = " Elegir Su Provincia")]
        [ForeignKey("Provincias")]
        public int ProvinciaId { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        //---------
        [Display(Name = " Elegir Su Ciudad")]
        [ForeignKey("Ciudades")]
        public int CiudadId { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        //---------------
        [Display(Name = " Elegir Su Municipio")]
        [ForeignKey("Municipios")]
        public int MunicipioId { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        //-----
        [Display(Name = " Elegir Sector")]
        [ForeignKey("Sector")]
        public int SectorId { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        //-----------------------------------------------------------------
        [Display(Name = " Introducir Su Direccion")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = "Introducir su Telefono Recidencial")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = "Introducir su Numero  de Celular")]
        public string Celular { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy - mm - dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }



        public virtual Provincias Provincias { get; set; }
        public virtual Ciudades Ciudades { get; set; }
        public virtual Municipios Municipios { get; set; }
        public virtual Sector Sector { get; set; }
    }
}
