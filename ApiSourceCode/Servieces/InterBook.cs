using ApiSourceCode.Models.Domain;

namespace ApiSourceCode.Servieces
{
    public interface InterBook
    {
        public List<BookDTO> GetAllBook();
        public BookDTO GetBook(int id);
        public BookDTO AddBook(  BookDTO book);
        public void DeleteBook(int id);
        public BookDTO UpdateBook(BookDTO book);
    }
}
