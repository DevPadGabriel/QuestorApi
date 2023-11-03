# QuestorApi

Scripts para criação da base de dados e tabelas:
*informações complementares da base estão na connection string no appsettings*

CREATE DATABASE "QuestorBase"
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'Portuguese_Brazil.1252'
    LC_CTYPE = 'Portuguese_Brazil.1252'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

CREATE TABLE IF NOT EXISTS public.banco
(
    id integer NOT NULL DEFAULT nextval('banco_id_seq'::regclass),
    nomebanco character varying(80) COLLATE pg_catalog."default" NOT NULL,
    codigobanco character varying(30) COLLATE pg_catalog."default" NOT NULL,
    percentualjuros numeric(5,2) NOT NULL,
    CONSTRAINT banco_pkey PRIMARY KEY (id)
)

CREATE TABLE IF NOT EXISTS public.boleto
(
    id integer NOT NULL DEFAULT nextval('boleto_id_seq'::regclass),
    nomepagador character varying(80) COLLATE pg_catalog."default" NOT NULL,
    cpfcnpjpagador character varying(18) COLLATE pg_catalog."default" NOT NULL,
    nomebeneficiario character varying(80) COLLATE pg_catalog."default" NOT NULL,
    cpfcnpjbeneficiario character varying(18) COLLATE pg_catalog."default" NOT NULL,
    valor numeric(12,4) NOT NULL,
    datavencimento date NOT NULL,
    observacao character varying(100) COLLATE pg_catalog."default",
    bancoid integer NOT NULL,
    CONSTRAINT boleto_pkey PRIMARY KEY (id),
    CONSTRAINT boleto_bancoid_fkey FOREIGN KEY (bancoid)
        REFERENCES public.banco (id) MATCH SIMPLE
        ON UPDATE CASCADE
        ON DELETE NO ACTION
)
