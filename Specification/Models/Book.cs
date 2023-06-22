using Specification.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Specification.Models
{
    public class Book : BaseEntity
    {
        public Book()
        {
            
        }
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
