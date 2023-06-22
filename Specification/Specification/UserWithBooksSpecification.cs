using Specification.Models;
using Ardalis.Specification;

namespace Specification.Specification
{
    public class UserWithBooksSpecification : Specification<User>
    {
        public UserWithBooksSpecification(int userId) 
        {
            Query.Where(u => u.Id == userId).Include(u => u.Books);
        }
        public UserWithBooksSpecification() 
        {
            Query.Include(u => u.Books);
        }
    }
}
