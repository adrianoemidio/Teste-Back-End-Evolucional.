-- Não executar este aqrquivo.Este aquivo é apenas para referência.
-- Para gerar as tabelas no banco de dados utlize Migration.
-- Para saber mais, consulte README.md


-- [projeto-evolucional].dbo.Aluno definition

-- Drop table

-- DROP TABLE [projeto-evolucional].dbo.Aluno GO

CREATE TABLE [projeto-evolucional].dbo.Aluno (
	AlunoID bigint IDENTITY(1,1) NOT NULL,
	Nome nvarchar(450) COLLATE Latin1_General_CI_AS NOT NULL UNIQUE,
	CONSTRAINT PK_Aluno PRIMARY KEY (AlunoID)
) GO
 CREATE  UNIQUE NONCLUSTERED INDEX IX_Aluno_Nome ON dbo.Aluno (  Nome ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ]  GO;


-- [projeto-evolucional].dbo.Notas definition

-- Drop table

-- DROP TABLE [projeto-evolucional].dbo.Notas GO

CREATE TABLE [projeto-evolucional].dbo.Notas (
	NotasID bigint IDENTITY(1,1) NOT NULL,
	AlunoID bigint NOT NULL,
	Matematica float NOT NULL,
	Portugues float NOT NULL,
	Historia float NOT NULL,
	Geografia float NOT NULL,
	Ingles float NOT NULL,
	Biologia float NOT NULL,
	Filosofia float NOT NULL,
	Fisica float NOT NULL,
	Quimica float NOT NULL,
	CONSTRAINT PK_Notas PRIMARY KEY (NotasID)
) GO
 CREATE NONCLUSTERED INDEX IX_Notas_AlunoID ON dbo.Notas (  AlunoID ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ]  GO;


-- [projeto-evolucional].dbo.Notas foreign keys

ALTER TABLE [projeto-evolucional].dbo.Notas ADD CONSTRAINT FK_Notas_Aluno_AlunoID FOREIGN KEY (AlunoID) REFERENCES [projeto-evolucional].dbo.Aluno(AlunoID) ON DELETE CASCADE GO;




-- [projeto-evolucional].dbo.AspNetUsers definition

-- Drop table

-- DROP TABLE [projeto-evolucional].dbo.AspNetUsers GO

CREATE TABLE [projeto-evolucional].dbo.AspNetUsers (
	Id nvarchar(450) COLLATE Latin1_General_CI_AS NOT NULL,
	Discriminator nvarchar COLLATE Latin1_General_CI_AS NOT NULL,
	UserName nvarchar(256) COLLATE Latin1_General_CI_AS NULL,
	NormalizedUserName nvarchar(256) COLLATE Latin1_General_CI_AS NULL,
	Email nvarchar(256) COLLATE Latin1_General_CI_AS NULL,
	NormalizedEmail nvarchar(256) COLLATE Latin1_General_CI_AS NULL,
	EmailConfirmed bit NOT NULL,
	PasswordHash nvarchar COLLATE Latin1_General_CI_AS NULL,
	SecurityStamp nvarchar COLLATE Latin1_General_CI_AS NULL,
	ConcurrencyStamp nvarchar COLLATE Latin1_General_CI_AS NULL,
	PhoneNumber nvarchar COLLATE Latin1_General_CI_AS NULL,
	PhoneNumberConfirmed bit NOT NULL,
	TwoFactorEnabled bit NOT NULL,
	LockoutEnd datetimeoffset NULL,
	LockoutEnabled bit NOT NULL,
	AccessFailedCount int NOT NULL,
	CONSTRAINT PK_AspNetUsers PRIMARY KEY (Id)
) GO
 CREATE NONCLUSTERED INDEX EmailIndex ON dbo.AspNetUsers (  NormalizedEmail ASC  )  
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ]  GO
 CREATE  UNIQUE NONCLUSTERED INDEX UserNameIndex ON dbo.AspNetUsers (  NormalizedUserName ASC  )  
	 WHERE  ([NormalizedUserName] IS NOT NULL)
	 WITH (  PAD_INDEX = OFF ,FILLFACTOR = 100  ,SORT_IN_TEMPDB = OFF , IGNORE_DUP_KEY = OFF , STATISTICS_NORECOMPUTE = OFF , ONLINE = OFF , ALLOW_ROW_LOCKS = ON , ALLOW_PAGE_LOCKS = ON  )
	 ON [PRIMARY ]  GO;
