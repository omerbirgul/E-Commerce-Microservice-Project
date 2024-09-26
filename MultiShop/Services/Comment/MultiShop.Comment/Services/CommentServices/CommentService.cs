using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Context;
using MultiShop.Comment.Dtos.UserCommentDtos;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly CommentContext _commentContext;

        public CommentService(CommentContext commentContext)
        {
            _commentContext = commentContext;
        }

        public  async Task CreateUserCommentAsync(CreateUserCommentDto createUserCommentDto)
        {
            UserComment userComment = new UserComment
            {
                FullName = createUserCommentDto.FullName,
                Email = createUserCommentDto.Email,
                ImageUrl = createUserCommentDto.ImageUrl,
                CommentDetail = createUserCommentDto.CommentDetail,
                Rating = createUserCommentDto.Rating,
                CreatedDate = createUserCommentDto.CreatedDate,
                Status = createUserCommentDto.Status,
                ProductId = createUserCommentDto.ProductId,
            };

             await _commentContext.AddAsync(userComment);
            await _commentContext.SaveChangesAsync();
        }

        public async Task DeleteUserCommentAsync(string id)
        {
            var value = await _commentContext.userComments.FindAsync(id);
            _commentContext.Remove(id);
        }

        public async Task<List<GetByProductIdUserCommentDto>> GetUserCommentByProductIdAsync(string id)
        {
            var values = await _commentContext.userComments.Where(x => x.ProductId == id).ToListAsync();
            var result = values.Select(x => new GetByProductIdUserCommentDto
            {
                FullName = x.FullName,
                Email = x.Email,
                ImageUrl = x.ImageUrl,
                CommentDetail = x.CommentDetail,
                Rating = x.Rating,
                CreatedDate = x.CreatedDate,
                Status = x.Status,
                ProductId = x.ProductId,
            }).ToList();
            return result;
        }

        public async Task UpdateUserCommentAsync(UpdateUserCommentDto updateUserCommentDto)
        {
            UserComment userComment = new UserComment
            {
                FullName = updateUserCommentDto.FullName,
                Email = updateUserCommentDto.Email,
                ImageUrl = updateUserCommentDto.ImageUrl,
                CommentDetail = updateUserCommentDto.CommentDetail,
                Rating = updateUserCommentDto.Rating,
                CreatedDate = updateUserCommentDto.CreatedDate,
                Status = updateUserCommentDto.Status,
                ProductId = updateUserCommentDto.ProductId,
            };
            _commentContext.userComments.Update(userComment);
            await _commentContext.SaveChangesAsync();
        }

        public async Task<List<ResultUserCommentDto>> UserCommentListAsync()
        {
            var values = await _commentContext.userComments.ToListAsync();
            var result = values.Select(x => new ResultUserCommentDto
            {
                FullName = x.FullName,
                Email = x.Email,
                ImageUrl = x.ImageUrl,
                CommentDetail = x.CommentDetail,
                Rating = x.Rating,
                CreatedDate = x.CreatedDate,
                Status = x.Status,
                ProductId = x.ProductId,
            }).ToList();
            return result;
        }
    }
}
