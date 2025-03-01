﻿using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _context;

        public BlogRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<Blog>> GetAuthorByBlogId(int id)
        {
            return await _context.Blogs.Include(b => b.Author).Where(b => b.Id == id).ToListAsync();
        }

        public async Task<List<Blog>> GetBlogsWithAuthors()
        {
            return await _context.Blogs.Include(x => x.Author).Include(y => y.BlogCategory).ToListAsync();
        }
        public async Task<List<Blog>> GetLast3BlogsWithAuthors()
        {
            return await _context.Blogs.Include(x => x.Author).OrderByDescending(x => x.Id).Take(3).ToListAsync();
        }

       
    }
}
