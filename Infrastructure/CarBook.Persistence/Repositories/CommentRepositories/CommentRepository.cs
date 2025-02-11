using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository<T> : IGenericRepository<Comment>
    {
        private readonly CarBookContext _context;
        public CommentRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Comment entity)
        {
            _context.Comments.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.Select(x => new Comment
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                CreatedTime = x.CreatedTime,
                Content = x.Content,
                BlogId = x.BlogId,
            }).ToListAsync();
        }

        public async Task<Comment> GetByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<List<Comment>> GetCommentsByBlogIdAsync(int id)
        {
            return await _context.Set<Comment>().Where(x => x.BlogId == id).ToListAsync();
        }

        public async Task RemoveAsync(Comment entity)
        {
            var value = await _context.Comments.FindAsync(entity.Id);
            _context.Comments.Remove(value);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateAsync(Comment entity)
        {
            _context.Comments.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
