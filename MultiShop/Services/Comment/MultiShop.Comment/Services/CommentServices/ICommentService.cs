using MultiShop.Comment.Dtos.UserCommentDtos;

namespace MultiShop.Comment.Services.CommentServices
{
    public interface ICommentService
    {
        Task<List<ResultUserCommentDto>> UserCommentListAsync();
        Task CreateUserCommentAsync(CreateUserCommentDto createUserCommentDto);
        Task UpdateUserCommentAsync(UpdateUserCommentDto updateUserCommentDto);
        Task DeleteUserCommentAsync(string id);
        Task<List<GetByProductIdUserCommentDto>> GetUserCommentByProductIdAsync(string id);
    }
}
