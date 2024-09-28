using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks(bool trackChanges);
        Book GetOneBook(int id,bool trackChanges);

        Book CreateOneBook(Book book);
        Book UpdateOneBook(int id,Book book);
        void DeleteOneBook(int id,bool trackChanges);
        object GetOneBookById(int id, bool v);
        void UpdateOneBook(int id,BookDtoForUpdate bookDto, bool v);
        void UpdateOneBook(int id, Book book, bool v);
    }
}
