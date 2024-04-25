using ApiSourceCode.Data;
using ApiSourceCode.Models.Domain;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading;
using static System.Reflection.Metadata.BlobBuilder;
using Microsoft.EntityFrameworkCore;
using System;
using Humanizer.Localisation;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace ApiSourceCode.Servieces
{
    public class ReponBook: InterBook
    {
        protected readonly AppDbContext _appDbContext;
        public ReponBook(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public BookDTO AddBook(BookDTO book)
        {
            var au = new Book
            {
                
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateAdded = book.DateAdded,
                Rate= book.Rate,
                Genre= book.Genre,
                CoverUrl= book.CoverUrl,
                DateRead= book.DateRead,
                PublisherID= book.PublisherID,
               
            };
            _appDbContext.Books.Add(au);
            _appDbContext.SaveChanges();
            foreach(var id in book.AuthorId)
            {
                var ba = new Book_Author
                {
                    Id = book.Id,
                    AuthorId = id
                };
            }
            return new BookDTO
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateAdded = book.DateAdded,
                Rate = book.Rate,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                DateRead = book.DateRead,
                PublisherID = book.PublisherID,
            };
        }

        public void DeleteBook(int id)
        {
            var au = _appDbContext.Books.SingleOrDefault(a => a.Id == id);
            if (au != null)
            {
                _appDbContext.Remove(au);
                _appDbContext.SaveChanges();
            }
        }

        public List<BookDTO> GetAllBook()
        {
            var l = _appDbContext.Books.Select(book => new BookDTO
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateAdded = (DateTime)book.DateAdded,
                Rate = (bool)book.IsRead ? book.Rate.Value : null,
                Genre=  book.Genre,
               CoverUrl = book.CoverUrl,
                DateRead= (DateTime)book.DateRead,
                PublisherID = book.PublisherID,
                AuthorId=book.Book_Authors.Select(a=>a.Author.Id).ToList(),
                AuthorName=book.Book_Authors.Select(a=>a.Author.FullName).ToList(),
            }).ToList();
            return l;
        }

        public BookDTO GetBook(int id)
        {
            var au = _appDbContext.Books.SingleOrDefault(a => a.Id == id);
            if (au != null)
            {
                return new BookDTO
                {
                    Id = au.Id,
                    Title = au.Title,
                    Description = au.Description,
                    IsRead = au.IsRead,
                    DateAdded = (DateTime)au.DateAdded,
                    Rate = au.Rate,
                    Genre = au.Genre,
                    CoverUrl = au.CoverUrl,
                    DateRead = (DateTime)au.DateRead,
                    PublisherID = au.PublisherID,
                    AuthorId = au.Book_Authors.Select(a => a.Author.Id).ToList(),
                    AuthorName = au.Book_Authors.Select(a => a.Author.FullName).ToList(),
                };
            }
            return null;
        }

        public BookDTO UpdateBook(BookDTO book)
        {
            var au = _appDbContext.Books.SingleOrDefault(a => a.Id == book.Id);
            if (au != null)
            {
                
                _appDbContext.SaveChanges();
            }
            return null;
        }

        //mới vừa thêm
        public BookDTO AddBookWithAuthors(BookDTO book)
        {
            var _book = new Book
            {
                Title = book.Title,
                Description = book.Description,
                IsRead=book.IsRead,
                Rate = book.Rate,
                Genre=book.Genre,
                CoverUrl = book.CoverUrl,
                DateAdded = book.DateAdded,
                PublisherID=book.PublisherID,

            };


            _appDbContext.Books.Add(_book);
            _appDbContext.SaveChanges();
            foreach (var id in book.AuthorId)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = id,
                };
                _appDbContext.Books_Authors.Add(_book_author);
                _appDbContext.SaveChanges();

            }

            return book;

        }




    }
}
