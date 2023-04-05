using System;
namespace Todo.Contracts.DTO.Import
{
    public record TodoItemUpdateRequest(
        long TodoId,
        string Title
    );
}