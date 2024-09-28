using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;

namespace Services
{
    public class BookManager : IBookService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public BookManager(IRepositoryManager repositoryManager, ILoggerService logger, IMapper mapper)
        {
            _manager = repositoryManager;
            _logger = logger;
            _mapper = mapper;
        }

        public Book CreateOneBook(Book book)
        {
            _manager.Book.CreateOneBook(book);
            _manager.Save();
            return book;
        }

        public void DeleteOneBook(int id, bool trackChanges)
        {
            var entity = _manager.Book.GetOneBookById(id, trackChanges);
            if (entity is null)
            {
                string message = $"Book with id:{id} could not be found.";
                _logger.LogInfo(message);
                throw new Exception(message);
            }

            _manager.Book.DeleteOneBook(entity);
            _manager.Save();
        }

        public IEnumerable<Book> GetAllBooks(bool trackChanges)
        {
            return _manager.Book.GetAllBooks(trackChanges);
        }

        public Book GetOneBook(int id, bool trackChanges)
        {
            return _manager.Book.GetOneBookById(id, trackChanges);
        }

        public object GetOneBookById(int id, bool v)
        {
            return _manager.Book.GetOneBookById(id, false);
        }

        public void UpdateOneBook(int id, BookDtoForUpdate bookDto, bool trackChanges)
        {
            var entity = _manager.Book.GetOneBookById(id, trackChanges);
            if (entity is null)
            {
                string msg = $"Book with id:{id} could not be found.";
                _logger.LogInfo(msg);
                throw new Exception(msg);
            }

            _mapper.Map(bookDto, entity);
            _manager.Book.Update(entity);
            _manager.Save();
        }

        // Eksik metodu ekleyin
        public void UpdateOneBook(int id, Book book)
        {
            var entity = _manager.Book.GetOneBookById(id, true);
            if (entity is null)
            {
                string msg = $"Book with id:{id} could not be found.";
                _logger.LogInfo(msg);
                throw new Exception(msg);
            }

            entity.Title = book.Title; // Örnek güncellemeler
            entity.Price = book.Price;

            _manager.Book.Update(entity);
            _manager.Save();
        }

        public void UpdateOneBook(int id, Book book, bool v)
        {
            throw new NotImplementedException();
        }

        Book IBookService.UpdateOneBook(int id, Book book)
        {
            throw new NotImplementedException();
        }
    }
}
