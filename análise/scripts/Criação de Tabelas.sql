CREATE TABLE Usuario (
	usuario nvarchar(256) not null,
	nome varchar(100),
	email varchar(100),
	pais varchar(100),
	senha varchar(16),
	sexo varchar(10),
	caminhoImagem varchar(200),
	primary key(usuario)
)

CREATE TABLE Filme (
	filme_id int identity(1,1) not null,
	filme_name varchar(150) not null,
	ano int not null,
	sinopse varchar(1000) not null,
	diretor varchar(100) not null,
	produtora varchar(100) not null,
	duracao int not null,
	genero int null,
	media float null,
	caminhoImagem varchar(200) null,
	primary key(filme_id)
)

CREATE TABLE Comentario (
	comentario_id int identity(1,1) not null,
	descricao varchar(1000) not null,
	data datetime default getdate(),
	filme_id int not null,
	usuario nvarchar(256) not null,
	primary key(comentario_id),
	foreign key(filme_id) references Filme(filme_id),
	foreign key(usuario) references Usuario(usuario) 
)

CREATE TABLE RelacaoVisto (
	relacaovisto_id int identity(1,1) not null,
	dataHora datetime default getdate(),
	filme_id int not null,
	usuario nvarchar(256) not null,
	primary key(relacaovisto_id),
	foreign key(filme_id) references Filme(filme_id),
	foreign key(usuario) references Usuario(usuario) 
)

CREATE TABLE RelacaoFavorito (
	relacaofavorito_id int identity(1,1) not null,
	dataHora datetime default getdate(),
	filme_id int not null,
	usuario nvarchar(256) not null,
	primary key(relacaofavorito_id),
	foreign key(filme_id) references Filme(filme_id),
	foreign key(usuario) references Usuario(usuario) 
)

CREATE TABLE RelacaoInteresse (
	relacaointeresse_id int identity(1,1) not null,
	dataHora datetime default getdate(),
	filme_id int not null,
	usuario nvarchar(256) not null,
	primary key(relacaointeresse_id),
	foreign key(filme_id) references Filme(filme_id),
	foreign key(usuario) references Usuario(usuario) 
)

CREATE TABLE RelacaoAvaliacao (
	relacaoavaliacao_id int identity(1,1) not null,
	avaliacao int not null,
	dataHora datetime default getdate(),
	filme_id int not null,
	usuario nvarchar(256) not null,
	primary key(relacaoavaliacao_id),
	foreign key(filme_id) references Filme(filme_id),
	foreign key(usuario) references Usuario(usuario) 
)

CREATE TABLE Segue(
	segue_id int identity(1,1) not null,
	usuarioSeguido nvarchar(256) not null,
	usuarioSeguidor nvarchar(256) not null,
	foreign key(usuarioSeguidor) references Usuario(usuario),
	primary key(segue_id)
)

CREATE TABLE Post(
	post_id int identity(1,1) not null,
	tipo int not null,
	filme_id int not null,
	usuario nvarchar(256) not null,
	primary key(post_id),
	foreign key(filme_id) references Filme(filme_id),
	foreign key(usuario) references Usuario(usuario) 
)

CREATE TABLE AvaliacaoComentario (
	avaliacaocomentario_id int identity(1,1) not null,
	avaliacao bit,
	dataHora datetime default getdate(),
	comentario_id int not null,
	usuarioAvaliador nvarchar(256) not null,
	primary key(avaliacaocomentario_id),
	foreign key(comentario_id) references Comentario(comentario_id),
	foreign key(usuarioAvaliador) references Usuario(usuario),
)

CREATE TABLE AvaliacaoPost (
	avaliacaopost_id int identity(1,1) not null,
	avaliacao bit,
	dataHora datetime default getdate(),
	post_id int not null,
	usuarioavaliador nvarchar(256) not null,
	primary key(avaliacaopost_id),
	foreign key(post_id) references Post(post_id),
	foreign key(usuarioavaliador) references Usuario(usuario),
)

CREATE TABLE ComentarioPost (
	comentariopost_id int identity(1,1) not null,
	descricao varchar(1000),
	dataHora datetime default getdate(),
	post_id int not null,
	usuario nvarchar(256) not null,
	primary key(comentariopost_id),
	foreign key(post_id) references Post(post_id),
	foreign key(usuario) references Usuario(usuario),
)

CREATE TABLE AvaliacaoComentarioPost (
	avaliacaopost_id int identity(1,1) not null,
	avaliacao bit,
	dataHora datetime default getdate(),
	usuariocomentario_id nvarchar(256),
	filme_id int not null,
	usuarioavaliador nvarchar(256) not null,
	primary key(avaliacaopost_id),
	foreign key(filme_id) references Filme(filme_id),
	foreign key(usuarioavaliador) references Usuario(usuario) 
)