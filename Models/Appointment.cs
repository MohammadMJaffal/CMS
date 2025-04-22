using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DMS_3.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("DoctorId")]
        public int? DoctorId { get; set; }
        [Required]
        [ForeignKey("PatientId")]
        public int? PatientId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Status { get; set; } = "Pending";

        [ForeignKey("DoctorId")]
        public Doctor? Doctor { get; set; }

        [ForeignKey("PatientId")]
        public Patient? Patient { get; set; }
    }
}
