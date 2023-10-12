using MovieAppAPI.Dto;

namespace MovieAppAPI.Services
{
    public interface ICommentService
    {
        Task<List<CommentDto>> GetAllCommentAsync();

        Task<CommentDto> GetCommentAsync(int commentId);

        Task<bool> CreateMovieCommentAsync(CommentCreateDto commentDto);

        Task<bool> UpdateCommentAsync(CommentDto commentDto);

        Task<bool> DeleteCommentAsync(int commentId);
        Task<List<CommentDto>> GetMovieCommentAsync(int MovieId);

        Task<bool> AddMovieCommentAsync(int MovieId, CommentCreateDto commentDto);
    }
}
