INSERT INTO public."TodoItem"
(
    title,
    create_at,
    is_completed,
    category,
    color
)
VALUES
(
    'Create a ticket',
    current_timestamp,
    false,
    'analytics',
    'red'
);

INSERT INTO public."TodoComment"
(
    content,
    "todoItem_ID"
)
VALUES
( 'comment_1', 1),
( 'comment_2', 1),
( 'comment_3', 1)