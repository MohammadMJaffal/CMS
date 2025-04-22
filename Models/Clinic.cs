namespace DMS_3.Models
{
    public class Clinic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
