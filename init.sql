CREATE TABLE IF NOT EXISTS public.people
(
    Id integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    Name character varying(250) COLLATE pg_catalog."default" NOT NULL,
    Nickname character varying(150) COLLATE pg_catalog."default" NOT NULL,
    Birthdate date NOT NULL,
    Stack character varying(500) COLLATE pg_catalog."default",
    ExternalId uuid NOT NULL DEFAULT gen_random_uuid(),
    CONSTRAINT people_pkey PRIMARY KEY (Id),
    CONSTRAINT ix_nickname_unique UNIQUE (Nickname)
)

TABLESPACE pg_default;

CREATE UNIQUE INDEX IF NOT EXISTS ix_nick_unique
    ON public.people USING btree
    (Nickname COLLATE pg_catalog."default" ASC NULLS LAST)
    TABLESPACE pg_default;