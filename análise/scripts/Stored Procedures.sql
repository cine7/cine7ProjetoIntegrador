create procedure sp_SelectFeed
	@usuario nvarchar(256)
as
begin
	SELECT post_id,
		   descricao,
		   Filme.filme_name,
		   Post.usuario
	from Post

	INNER JOIN Usuario on Usuario.usuario = Post.usuario
	INNER JOIN Segue on Segue.usuarioSeguido = Usuario.usuario 
	INNER JOIN Filme on Filme.filme_id = Post.filme_id

	WHERE Segue.usuarioSeguidor = @usuario

	ORDER BY dataHora desc
end

exec sp_SelectFeed 'oii'

create procedure sp_SelectPost
	@usuario nvarchar(256)
as
begin
	SELECT post_id,
		   descricao,
		   Filme.filme_name,
		   Post.usuario
	from Post

	INNER JOIN Usuario on Usuario.usuario = Post.usuario
	INNER JOIN Filme on Filme.filme_id = Post.filme_id

	WHERE Usuario.usuario = @usuario

	ORDER BY dataHora desc
end

exec sp_SelectPost 'oii'

create procedure sp_SelectFavoritosUsuario
	@usuario nvarchar(256)
as
begin
	Select top 2 Filme.caminhoImagem from RelacaoFavorito INNER JOIN Filme on Filme.filme_id = RelacaoFavorito.filme_id
    where usuario = @usuario
	ORDER BY media desc
end

create procedure sp_SelectVistosUsuario
	@usuario nvarchar(256)
as
begin
	Select top 2 Filme.caminhoImagem from RelacaoVisto INNER JOIN Filme on Filme.filme_id = RelacaoVisto.filme_id
    where usuario = @usuario
	ORDER BY media desc
end

create procedure sp_SelectInteressesUsuario
	@usuario nvarchar(256)
as
begin
	Select top 2 Filme.caminhoImagem from RelacaoInteresse INNER JOIN Filme on Filme.filme_id = RelacaoInteresse.filme_id
    where usuario = @usuario
	ORDER BY media desc
end


create procedure sp_SelectFavoritosUsuarioTodos
	@usuario nvarchar(256)
as
begin
	Select Filme.caminhoImagem, Filme.filme_name from RelacaoFavorito INNER JOIN Filme on Filme.filme_id = RelacaoFavorito.filme_id
    where usuario = @usuario
	ORDER BY media desc
end

create procedure sp_SelectVistosUsuarioTodos
	@usuario nvarchar(256)
as
begin
	Select Filme.caminhoImagem, Filme.filme_name from RelacaoVisto INNER JOIN Filme on Filme.filme_id = RelacaoVisto.filme_id
    where usuario = @usuario
	ORDER BY media desc
end

create procedure sp_SelectInteressesUsuarioTodos
	@usuario nvarchar(256)
as
begin
	Select Filme.caminhoImagem, Filme.filme_name from RelacaoInteresse INNER JOIN Filme on Filme.filme_id = RelacaoInteresse.filme_id
    where usuario = @usuario
	ORDER BY media desc
end