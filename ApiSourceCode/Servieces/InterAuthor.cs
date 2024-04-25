using ApiSourceCode.Models.Domain;

namespace ApiSourceCode.Servieces
{
    public interface InterAuthor
    {
        public List<AuthorDTO> GetAllAuthor();
        public AuthorDTO GetAuthor(int id);
        public AddAuthorDTO AddAuthor(AddAuthorDTO author);
        public void DeleteAuthor(int id);
        public AuthorDTO UpdateAuthor(AuthorDTO author);
    }
}
