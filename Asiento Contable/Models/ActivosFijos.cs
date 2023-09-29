using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asiento_Contable.Models
{
    public class ActivosFijos
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int IdAsiento { get; set; }

        [Required]
        [StringLength(50)]
        public string Descripcion { get; set; }

        public DateTime FechaAsiento { get; set; }

        [Required]
        [StringLength(15)]
        public string CuentaContable { get; set; }

        [Required]
        [StringLength(2)]
        public string TipoMovimiento { get; set; }

        public decimal MontoMovimiento { get; set; }


        public ActivosFijos()
        {

        }

    }
}
