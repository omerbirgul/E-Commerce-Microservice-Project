using MultiShop.DtoLayer.CommentDtos;

namespace MultiShop.WebUI.Services.CommentServices
{
    public interface ICommentService
    {
        Task<List<ResultCommentDto>> UserCommentListAsync();
        Task<GetByIdCommentDto> GetCommentByIdAsync(int id);
        Task CreateUserCommentAsync(CreateCommentDto createCommentDto);
        Task UpdateUserCommentAsync(UpdateCommentDto updateUserCommentDto);
        Task DeleteUserCommentAsync(int id);
        Task<List<ResultCommentDto>> GetUserCommentByProductIdAsync(string id);
    }
}
