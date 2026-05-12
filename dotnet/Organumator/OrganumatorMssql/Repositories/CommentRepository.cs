using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrganumatorMssql.Data;
using OrganumatorMssql.Dtos.Comment;
using OrganumatorMssql.Interfaces;
using OrganumatorMssql.Models;

namespace OrganumatorMssql.Repositories
{
    public class CommentRepository : ICommentsRepository
    {

        private readonly ApplicationDbContext _applicationDbContext;
        public CommentRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Comment> CreateAsync(Comment comment)
        {
            await _applicationDbContext.Comments.AddAsync(comment);
            await _applicationDbContext.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var comment = await _applicationDbContext.Comments.FirstOrDefaultAsync(c => c.Id == id);
            if (comment == null)
            {
                return null;
            }
            _applicationDbContext.Comments.Remove(comment);
            await _applicationDbContext.SaveChangesAsync();
            return comment;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _applicationDbContext.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _applicationDbContext.Comments.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Comment?> UpdateAsync(int id, Comment comment)
        {
            var existingComment = await _applicationDbContext.Comments.FirstOrDefaultAsync(c => c.Id == id);
            if (existingComment == null)
            {
                return null;
            }

            existingComment.Title = comment.Title;
            existingComment.Content = comment.Content;

            await _applicationDbContext.SaveChangesAsync();

            return existingComment;

        }
    }
}