using Specification.Data;

namespace Specification.Models
{
    public class User : BaseEntity
    {
        public User()
        {
            
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
