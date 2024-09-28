using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Context;
using MultiShop.Comment.Dtos.UserCommentDtos;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly CommentContext _commentContext;
        private readonly IMapper _mapper;

        public CommentService(CommentContext commentContext, IMapper mapper)
        {
            _commentContext = commentContext;
            _mapper = mapper;
        }

        public async Task CreateUserCommentAsync(CreateUserCommentDto createUserCommentDto)
        {
            var value = _mapper.Map<UserComment>(createUserCommentDto);
            await _commentContext.UserComments.AddAsync(value);
            await _commentContext.SaveChangesAsync();
        }

        public async Task DeleteUserCommentAsync(int id)
        {
            var value = await _commentContext.UserComments.FindAsync(id);
            _commentContext.UserComments.Remove(value);
            await _commentContext.SaveChangesAsync();
        }

        public async Task<GetByIdCommentDto> GetCommentByIdAsync(int id)
        {
            var value = await _commentContext.UserComments.FindAsync(id);
            return _mapper.Map<GetByIdCommentDto>(value);
        }

        public async Task<List<ResultUserCommentDto>> GetUserCommentByProductIdAsync(string id)
        {
            var values = await _commentContext.UserComments.Where(x => x.ProductId == id).ToListAsync();
            return _mapper.Map<List<ResultUserCommentDto>>(values);
        }

        public async Task UpdateUserCommentAsync(UpdateUserCommentDto updateUserCommentDto)
        {
            var value = _mapper.Map<UserComment>(updateUserCommentDto);
            _commentContext.UserComments.Update(value);
            await _commentContext.SaveChangesAsync();
        }

        public async Task<List<ResultUserCommentDto>> UserCommentListAsync()
        {
            var values = await _commentContext.UserComments.ToListAsync();
            return _mapper.Map<List<ResultUserCommentDto>>(values);
        }
    }
}
