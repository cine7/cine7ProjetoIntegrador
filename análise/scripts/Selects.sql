-- SELECT nos posts de um usuário
SELECT descricao,
	   Filme.filme_name,
	   Post.usuario
from Post

INNER JOIN Usuario on Usuario.usuario = Post.usuario
INNER JOIN Filme on Filme.filme_id = Post.filme_id

WHERE Usuario.usuario = 'd'
	
-- SELECT nos posts dos usuários que um usuário segue
SELECT descricao,
	   Filme.filme_name,
	   Post.usuario
from Post

INNER JOIN Usuario on Usuario.usuario = Post.usuario
INNER JOIN Segue on Segue.usuarioSeguido = Usuario.usuario 
INNER JOIN Filme on Filme.filme_id = Post.filme_id

WHERE Segue.usuarioSeguidor = 'd'

-- SELECT nos seguidores
SELECT Usuario.nome as 'Seguidos por João Mendes'
from Segue

INNER JOIN Usuario on Usuario.usuario = Segue.usuarioSeguido

WHERE Segue.usuarioSeguidor = 'a'

SELECT Usuario.nome as 'Seguem Rute'
from Segue

INNER JOIN Usuario on Usuario.usuario = Segue.usuarioSeguidor

WHERE Segue.usuarioSeguido = 'b'

SELECT COUNT(avaliacao) FROM AvaliacaoComentario where avaliacao = 1 and comentario_id = 1092

--SELECT nas Avaliações de um Comentário
SELECT avaliacao,
	   Comentario.usuario as 'Usuario que comentou',
	   Comentario.descricao as 'Comentário',
	   AvaliacaoComentario.usuario as 'Usuário avaliador'
FROM AvaliacaoComentario

INNER JOIN Comentario on Comentario.comentario_id = AvaliacaoComentario.comentario_id

WHERE AvaliacaoComentario.comentario_id = 1

--SELECT nas Avaliações Positivas de um Comentário
SELECT avaliacao,
	   Comentario.usuario as 'Usuario que comentou',
	   Comentario.descricao as 'Comentário',
	   AvaliacaoComentario.usuario as 'Usuário avaliador'
FROM AvaliacaoComentario

INNER JOIN Comentario on Comentario.comentario_id = AvaliacaoComentario.comentario_id

WHERE AvaliacaoComentario.comentario_id = 1 and AvaliacaoComentario.avaliacao = 1

--SELECT nas Avaliações Negativas de um Comentário
SELECT avaliacao,
	   Comentario.usuario as 'Usuario que comentou',
	   Comentario.descricao as 'Comentário',
	   AvaliacaoComentario.usuario as 'Usuário avaliador'
FROM AvaliacaoComentario

INNER JOIN Comentario on Comentario.comentario_id = AvaliacaoComentario.comentario_id

WHERE AvaliacaoComentario.comentario_id = 1 and AvaliacaoComentario.avaliacao = 0