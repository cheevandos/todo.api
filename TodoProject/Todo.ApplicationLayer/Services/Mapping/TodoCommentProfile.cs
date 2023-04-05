using AutoMapper;
using Todo.Contracts.DTO.Export;
using Todo.Contracts.DTO.Import;
using Todo.Domain.Entities;

namespace Todo.ApplicationLayer.Services.Mapping
{
    public class TodoCommentProfile : Profile
    {
        public TodoCommentProfile()
        {
            CreateMap<TodoCommentCreateRequest, TodoComment>();
            CreateMap<TodoComment, TodoCommentDetails>();
        }
    }
}