using Microsoft.EntityFrameworkCore;
using MovieAppAPI.Data;
using MovieAppAppication.Interface.IRepository;
using MovieAppDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppInfrastructure.Implementation.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly MovieDb _context;
        public CommentRepository(MovieDb context)
        {
            _context = context;
        }
        public async Task<bool> CreateCommentAsync(Comment commnt)
        {
            await _context.Comments.AddAsync(commnt);
            return true;
        }

        public async Task<bool> DeleteCommentAsync(int commentId)
        {
            var commentToDelete = await _context.Comments.FindAsync(commentId);

            if (commentToDelete != null)
            {
                _context.Comments.Remove(commentToDelete);
                return true;
            }
            return false;
        }

        public async Task<List<Comment>> GetAllCommentAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment> GetByCommentIdAsync(int commentId)
        {
            return await _context.Comments.FindAsync(commentId);
        }

        public async Task<List<Comment>> GetByMovieCommentIdAsync(int MovieId)
            {
            var comments = await _context.Comments
                .Where(c => c.MovieId == MovieId) 
                .ToListAsync();
            return comments;
         
        }
        public async Task<bool> CreateMovieCommentAsync(int MovieId, Comment comment)
        {
            comment.MovieId = MovieId;
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCommentAsync(Comment comment)
        {
            var existingcomment = await _context.Comments.FindAsync(comment.CommentId);

            if (existingcomment != null)
            {

                existingcomment.CommentDesc = comment.CommentDesc;
                return true;
            }
            return false;
        }
    }
}
