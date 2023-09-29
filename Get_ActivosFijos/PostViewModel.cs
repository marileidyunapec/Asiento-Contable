using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Get_ActivosFijos
{
    internal class PostViewModel
    {
       
        public int IdAsiento { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaAsiento { get; set; }
        public string CuentaContable { get; set; }
        public string TipoMovimiento { get; set; }
        public decimal MontoMovimiento { get; set; }

    }
}
