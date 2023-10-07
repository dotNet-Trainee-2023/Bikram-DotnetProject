using AutoMapper;
using MovieAppAPI.Data;
using MovieAppAPI.Dto;
using MovieAppAppication.Interface.IRepository;
using MovieAppDomain;

namespace MovieAppAPI.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
      
        public CommentService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> AddCommentAsync(CommentCreateDto commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);
            await _unitOfWork.CommentRepo.CreateCommentAsync(comment);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCommentAsync(int commentId)
        {
            await _unitOfWork.CommentRepo.DeleteCommentAsync(commentId);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<List<CommentDto>> GetAllCommentAsync()
        {
            var comment = await _unitOfWork.CommentRepo.GetAllCommentAsync();

            var commentDto = _mapper.Map<List<CommentDto>>(comment);
            return commentDto;
        }

        public async Task<CommentDto> GetCommentAsync(int commentId)
        {
            var comment = await _unitOfWork.CommentRepo.GetByCommentIdAsync(commentId);
            var commentDto = _mapper.Map<CommentDto>(comment);
            return commentDto;
        }

        public async Task<bool> UpdateCommentAsync(CommentDto commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);

            await _unitOfWork.CommentRepo.UpdateCommentAsync(comment);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
