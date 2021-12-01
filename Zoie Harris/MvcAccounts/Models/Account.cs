using System.ComponentModel.DataAnnotations;

namespace MvcAccount.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string? Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public string? Password { get; set; }
        public decimal Age { get; set; }
    }
}