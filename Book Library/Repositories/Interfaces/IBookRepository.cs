using System.Collections.Generic;
using System.Threading.Tasks;
using Book_Library.Data;
using Book_Library.Models.DTOs;

namespace Book_Library.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<Book> AddBookAsync(BookDto book);
        Task<Book> UpdateBookAsync(int id, BookDto book);
        Task DeleteBookAsync(int id);
        Task SaveChangesAsync();
    }

}
