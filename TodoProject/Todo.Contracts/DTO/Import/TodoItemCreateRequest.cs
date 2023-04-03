using System;
namespace Todo.Contracts.DTO.Import
{
    public record TodoItemCreateRequest(
        string Title,
        string Category,
        string Color
    );
}