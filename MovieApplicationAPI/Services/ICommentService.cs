using MovieAppAPI.Dto;

namespace MovieAppAPI.Services
{
    public interface ICommentService
    {
        Task<List<CommentDto>> GetAllCommentAsync();

        Task<CommentDto> GetCommentAsync(int commentId);

        Task<bool> AddCommentAsync(CommentCreateDto commentDto);

        Task<bool> UpdateCommentAsync(CommentDto commentDto);

        Task<bool> DeleteCommentAsync(int commentId);
    }
}
