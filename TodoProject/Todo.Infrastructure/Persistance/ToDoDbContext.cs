using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Infrastructure.Persistance;

public partial class ToDoDbContext : DbContext
{
    public ToDoDbContext()
    {
    }

    public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TodoComment> TodoComments { get; set; }

    public virtual DbSet<TodoItem> TodoItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoComment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("TodoComment_pkey");

            entity.ToTable("TodoComment");

            entity.Property(e => e.CommentId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("comment_ID");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.TodoItemId).HasColumnName("todoItem_ID");

            entity.HasOne(d => d.TodoItem).WithMany(p => p.TodoComments)
                .HasForeignKey(d => d.TodoItemId)
                .HasConstraintName("fk_todoitem_ID");
        });

        modelBuilder.Entity<TodoItem>(entity =>
        {
            entity.HasKey(e => e.TodoId).HasName("TodoItem_pkey");

            entity.ToTable("TodoItem");

            entity.HasIndex(e => new { e.Title, e.Category }, "uq_title_category").IsUnique();

            entity.Property(e => e.TodoId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("todo_ID");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.Color).HasColumnName("color");
            entity.Property(e => e.CreateAt).HasColumnName("create_at");
            entity.Property(e => e.IsCompleted).HasColumnName("is_completed");
            entity.Property(e => e.Title).HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
