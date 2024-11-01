using ORM;

namespace Services.Author
{
    public interface IAuthorServices
    {
        public Task<IList<Autor>> GetAuthor();

        public Task<Autor?> GetAuthorPorId(int id);

        public Task<IEnumerable<Autor>> GetAuthorName(string nome);

        public void AddAuthor(Autor author);

        public void AddAuthors(IEnumerable<Autor> author);
        
        public void EditAuthor(Autor author);

        public void DeleteAuthor(Autor author);
    }
}
