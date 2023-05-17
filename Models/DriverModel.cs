using System.ComponentModel.DataAnnotations.Schema;

namespace Formula.App.Models
{
    [Table("drivers")]
    public class Driver
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid DriverNumber { get; set; }
        public string? Team { get; set; }

    }
}