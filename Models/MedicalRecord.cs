using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DMS_3.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("PatientId")]
        public int? PatientId { get; set; }
        public DateTime Date { get; set; }
        public string DiagnosisScan { get; set; }
        public DateTime NextSessionDate { get; set; }
        [ForeignKey("PatientId")]
        public Patient? Patient { get; set; }
        public ICollection<Report> Reports { get; set; }
    }
}
