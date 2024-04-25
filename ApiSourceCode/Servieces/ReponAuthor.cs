using ApiSourceCode.Data;
using ApiSourceCode.Models.Domain;

using ApiSourceCode.Models.Domain;
namespace ApiSourceCode.Servieces
{
    public class ReponAuthor : InterAuthor
    {
       protected readonly AppDbContext _appDbContext;
        public ReponAuthor(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public AddAuthorDTO AddAuthor(AddAuthorDTO author)
        {
            var au = new Authors
            {
                FullName = author.FullName,
            };
           _appDbContext.Authors.Add(au);
            _appDbContext.SaveChanges();
            return new AddAuthorDTO
            {

                FullName = au.FullName,
            };
           
        }

        public void DeleteAuthor(int id)
        {
            var au=_appDbContext.Authors.SingleOrDefault(a => a.Id == id);
            if (au != null)
            {
                _appDbContext.Remove(au);
                _appDbContext.SaveChanges();
            }
           
        }

        public List<AuthorDTO> GetAllAuthor()
        {
            var l = _appDbContext.Authors.Select(a => new AuthorDTO
            {
                Id=a.Id,
                FullName=a.FullName,

            });
            return l.ToList();
        }

        public AuthorDTO GetAuthor(int id)
        {
            var au=_appDbContext.Authors.SingleOrDefault(a => a.Id == id);
            if (au != null)
            {
                return new AuthorDTO
                {
                    Id = au.Id,
                    FullName = au.FullName,
                };
            }
            return null;
        }

        public AuthorDTO UpdateAuthor(AuthorDTO author)
        {
            var au=_appDbContext.Authors.SingleOrDefault(a=>a.Id == author.Id);
            if (au != null)
            {
                au.FullName = author.FullName;
                _appDbContext.SaveChanges();
            }
            return null;
        }
    }
}
