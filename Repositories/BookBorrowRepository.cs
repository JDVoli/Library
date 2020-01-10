﻿using System;
using System.Threading.Tasks;
using Library.Entities;
using Library.Models.DTO;
using Library.Repositories.Interfaces;

namespace Library.Repositories
{
    public class BookBorrowRepository : BaseRepository, IBookBorrowRepository
    {
        public BookBorrowRepository(LibraryContext context) : base(context)
        {
        }

        public async Task<BookBorrow> AddBookBorrow(BookBorrowDto borrow)
        {
            var res = await _context.BookBorrow.AddAsync(new BookBorrow
            {
                IdUser = borrow.IdUser,
                IdBook =  borrow.IdBook,
                BorrowDate = DateTime.Now,
                Comments = borrow.Comment
            });

            await _context.SaveChangesAsync();

            return res.Entity;
        }
    }
}
