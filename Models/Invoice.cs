using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DMS_3.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("PatientId")]
        public int? PatientId { get; set; }
        public decimal PrimaryFees { get; set; }
        public decimal AdditionalFees { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        [ForeignKey("PatientId")]
        public Patient? Patient { get; set; }
    }
}
