using AutoMapper;
using Todo.Contracts.DTO.Export;
using Todo.Contracts.DTO.Import;
using Todo.Domain.Entities;

namespace Todo.ApplicationLayer.Services.Mapping
{
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            CreateMap<TodoItemCreateRequest, TodoItem>();

            CreateMap<TodoItem, TodoItemDetails>()
                .ForMember(
                    dest => dest.Comments,
                    options => options.MapFrom(src =>
                        src.TodoComments == null
                        ? null
                        : src.TodoComments.Select(comment =>
                            new TodoCommentDetails(comment.CommentId, comment.Content)
                        )
                    )
                );
        }
    }
}