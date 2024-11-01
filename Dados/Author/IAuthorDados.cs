using ORM;
using Microsoft.EntityFrameworkCore;

namespace Dados.Author
{
    public interface IAuthorDados
    {
        public DbSet<Autor> GetAuthor();
        
        public void AddAuthor(Autor author);

        public void AddAuthors(IEnumerable<Autor> author);

        public void EditAddAuthor(Autor author);

        public void DeleteAddAuthor(Autor author);
    }
}
