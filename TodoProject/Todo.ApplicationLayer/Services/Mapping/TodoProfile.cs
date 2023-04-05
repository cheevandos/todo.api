using AutoMapper;
using System.ComponentModel;
using Todo.Contracts.DTO.Export;
using Todo.Contracts.DTO.Import;
using Todo.Domain.Entities;
using Todo.Domain.Enums;

namespace Todo.ApplicationLayer.Services.Mapping
{
    public class TodoProfile : Profile
    {
        public TodoProfile()
        {
            CreateMap<string, TodoCategory?>().ConvertUsing(src => ConvertEnum<TodoCategory>(src));
            CreateMap<string, TodoColor?>().ConvertUsing(src => ConvertEnum<TodoColor>(src));

            CreateMap<TodoItemUpdateRequest, TodoItem>();
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
                )
                .AfterMap<HashTodoTitle>();
        }

        private static T ConvertEnum<T>(in string value) where T : struct
        {
            if (!Enum.TryParse(value, out T parsedValue))
            {
                throw new InvalidEnumArgumentException(value);
            }
            return parsedValue;
        }
    }
}