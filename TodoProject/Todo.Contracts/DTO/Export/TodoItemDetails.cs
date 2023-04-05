namespace Todo.Contracts.DTO.Export
{
    public class TodoItemDetails
    {
        public long TodoId { get; set; }
        public string Title { get; set; } = null!;
        public bool IsCompleted { get; set; }
        public DateTime CreateAt { get; set; }
        public string Category { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string Hash { get; set; } = null!;
        public List<TodoCommentDetails> Comments { get; set; } = null!;
    }
}