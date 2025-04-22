using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DMS_3.Models
{
    public class Report
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("MedicalRecordId")]
        public int? MedicalRecordId { get; set; }
        public DateTime Date { get; set; }
        public string DiagnosisScan { get; set; }
        [ForeignKey("MedicalRecordId")]
        public MedicalRecord? MedicalRecord { get; set; }
    }
}
