using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FSVentasCore.Models.Dirreciones
{
    public class Sector
    {
        [Key]
        public  int  SectorId { get; set; }
        public  string Nombre { get; set; }

    }
}
