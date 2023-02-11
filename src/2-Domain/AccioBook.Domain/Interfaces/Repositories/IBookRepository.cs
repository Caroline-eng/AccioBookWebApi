﻿using AccioBook.Domain.Entities;

namespace AccioBook.Domain.Interfaces.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IQueryable<Book>> GetAllWithAuthorAndGenreAsync();
        Task<IQueryable<Book>> GetBooksByAuthorAsync(string authorName);
        Task<IQueryable<Book>> GetBooksByTitleAsync(string bookTitle);
    }
}
