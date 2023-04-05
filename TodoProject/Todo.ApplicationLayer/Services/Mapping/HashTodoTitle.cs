using System;
using AutoMapper;
using Todo.ApplicationLayer.Services.Hashing;
using Todo.Contracts.DTO.Export;
using Todo.Domain.Entities;

namespace Todo.ApplicationLayer.Services.Mapping
{
    public class HashTodoTitle : IMappingAction<TodoItem, TodoItemDetails>
    {
        private readonly IHasher hasher;

        public HashTodoTitle(IHasher hasher)
        {
            this.hasher = hasher;
        }

        public void Process(TodoItem source, TodoItemDetails destination, ResolutionContext context)
        {
            destination.Hash = hasher.HashString(source.Title);
        }
    }
}