CREATE TABLE IF NOT EXISTS public."TodoItem"
(
    "todo_ID" bigint NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 9223372036854775807 CACHE 1 ),
    title text COLLATE pg_catalog."default" NOT NULL,
    create_at timestamp with time zone NOT NULL,
    is_completed boolean NOT NULL DEFAULT false,
    category text COLLATE pg_catalog."default" NOT NULL,
    color text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "TodoItem_pkey" PRIMARY KEY ("todo_ID"),
    CONSTRAINT uq_title_category UNIQUE (title, category)
)

CREATE TABLE IF NOT EXISTS public."TodoComment"
(
    "comment_ID" bigint NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 9223372036854775807 CACHE 1 ),
    content text COLLATE pg_catalog."default" NOT NULL,
    "todoItem_ID" bigint NOT NULL,
    CONSTRAINT "TodoComment_pkey" PRIMARY KEY ("comment_ID"),
    CONSTRAINT "fk_todoitem_ID" FOREIGN KEY ("todoItem_ID")
        REFERENCES public."TodoItem" ("todo_ID") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)

CREATE TABLE IF NOT EXISTS public."HttpLog"
(
    "LogID" bigint NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 9223372036854775807 CACHE 1 ),
    "ApplicationName" text COLLATE pg_catalog."default",
    "LogDate" time with time zone NOT NULL,
    "LogLevel" text COLLATE pg_catalog."default" NOT NULL,
    "LogMessage" text COLLATE pg_catalog."default" NOT NULL,
    "LoggerType" text COLLATE pg_catalog."default",
    CONSTRAINT "HttpLogs_pkey" PRIMARY KEY ("LogID")
)