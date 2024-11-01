using ORM;


namespace Services.Book
{
    public interface IBookServices
    {
        public Task<IList<Livros>> GetBook();

        public Task<Livros?> GetBookPorId(int id);

        public Task<IEnumerable<Livros>> GetBookTittle(string tittle);

        public void AddBook(Livros book); 

        public void AddBooks(IEnumerable<Livros> books);

        public void EditBook(Livros book);

        public void DeleteBook(Livros book);

        //public Task<Livros?> ValidationAuthorExist(int id);
    }
}
