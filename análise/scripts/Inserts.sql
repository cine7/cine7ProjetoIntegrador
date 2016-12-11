-- INSERT nos usuários
INSERT INTO Usuario(usuario, nome, email, dataNascimento, pais, senha, sexo)
	   VALUES('a', 'João Mendes', 'mendeslopes.joao@gmail.com', '20140424', 'Brasil', 'a', 'Masculino')
INSERT INTO Usuario(usuario, nome, email, dataNascimento, pais, senha, sexo)
	   VALUES('b', 'Rute Barbalho', 'rute@gmail.com', '20140324', 'Brasil', 'b', 'Feminino')
INSERT INTO Usuario(usuario, nome, email, dataNascimento, pais, senha, sexo)
	   VALUES('c', 'Clara Bandeira', 'clara@gmail.com', '20140224', 'Brasil', 'c', 'Feminino')
INSERT INTO Usuario(usuario, nome, email, dataNascimento, pais, senha, sexo)
	   VALUES('d', 'Gabriel Cardoso Melita', 'gc@gmail.com', '19990108', 'Brasil', 'd', 'Masculino')

-- INSERT nos filmes
INSERT INTO Filme(filme_name, ano, sinopse, diretor, produtora, duracao)
	   VALUES('Pulp Fiction', 1994, 'Melhor Filme', 'Quentin Tarantino', 'MIRAMAX', 144)
INSERT INTO Filme(filme_name, ano, sinopse, diretor, produtora, duracao)
	   VALUES('Forrest Gump', 1994, 'Mais amor', 'Robert Zemckys', 'Paramount', 142)

-- INSERT nos filmes com caminhoCaminhoImagem
INSERT INTO Filme(filme_name, ano, sinopse, diretor, produtora, duracao, caminhoImagem)
	   VALUES('Mad Max', 2016, 'Após ser capturado por Immortan Joe, um guerreiro das estradas chamado Max (Tom Hardy) se vê no meio de uma guerra mortal, iniciada pela Imperatriz Furiosa (Charlize Theron) na tentativa se salvar um grupo de garotas. Também tentanto fugir, Max aceita ajudar Furiosa em sua luta contra Joe e se vê dividido entre mais uma vez seguir sozinho seu caminho ou ficar com o grupo.', 'Frank Miller', 'Village Roadshow Pictures', 120, '~/Imagens/Filmes/MadMax.jpg')
INSERT INTO Filme(filme_name, ano, sinopse, diretor, produtora, duracao, caminhoImagem)
	   VALUES('Madagascar', 2005, 'O leão Alex (Ben Stiller) é a grande atração do zoológico do Central Park, em Nova York. Ele e seus melhores amigos, a zebra Marty (Chris Rock), a girafa Melman (David Schwimmer) e a hipopótamo Gloria (Jada Pinkett Smith), sempre passaram a vida em cativeiro e desconhecem o que é morar na selva. Curioso em saber o que há por trás dos muros do zoo, Marty decide fugir e explorar o mundo. Ao perceberem, Alex, Gloria e Melman decidem partir à sua procura. O trio encontra Marty na estação Grand Central do metrô, mas antes que consigam voltar para casa são atingidos por dardos tranquilizantes e capturados. Embarcados em um navio rumo à África, eles acabam na ilha de Madagascar, onde precisam encontrar meios de sobrevivência em uma selva verdadeira.', 'Eric Darnell e Tom McGrath', 'DreamWorks Animation', 86, '~/Imagens/Filmes/Madagascar.jpg')
INSERT INTO Filme(filme_name, ano, sinopse, diretor, produtora, duracao, caminhoImagem)
	   VALUES('Grease', 1978, 'Na Califórnia na década de 50, Danny (John Travolta) e Sandy (Olivia Newton-John), um casal de estudantes, trocam juras de amor mas se separam, pois ela voltará para a Austrália. Entretanto, os planos mudam e Sandy por acaso se matricula na escola de Danny. Para fazer gênero ele infantilmente lhe dá uma esnobada, mas os dois continuam apaixonados, apesar do relacionamento ter ficado em crise. Esta trama serve como pano de fundo para retratar o comportamento dos jovens da época.', 'Legal', 'Village Roadshow Pictures', 110, '~/Imagens/Filmes/Grease.jpg')



-- INSERT relações
INSERT INTO RelacaoFavorito(filme_id, usuario)
	   VALUES(1, 'a')
INSERT INTO Post(tipo, filme_id, usuario)
	   VALUES(1, 1, 'a')

INSERT INTO RelacaoInteresse(filme_id, usuario)
	   VALUES(2, 'a')
INSERT INTO Post(tipo, filme_id, usuario)
	   VALUES(2, 2, 'a')

INSERT INTO RelacaoAvaliacao(avaliacao, filme_id, usuario)
	   VALUES(7, 1, 'b')
INSERT INTO Post(tipo, filme_id, usuario)
	   VALUES(4, 1, 'b')

INSERT INTO RelacaoAvaliacao(avaliacao, filme_id, usuario)
	   VALUES(7, 2, 'b')
INSERT INTO Post(tipo, filme_id, usuario)
	   VALUES(4, 2, 'b')

INSERT INTO RelacaoVisto(filme_id, usuario)
	   VALUES(2, 'c')
INSERT INTO Post(tipo, filme_id, usuario)
	   VALUES(3, 2, 'c')

INSERT INTO RelacaoVisto(filme_id, usuario)
	   VALUES(1, 'd')
INSERT INTO Post(tipo, filme_id, usuario)
	   VALUES(3, 1, 'd')
INSERT INTO RelacaoInteresse(filme_id, usuario)
	   VALUES(2, 'd')
INSERT INTO Post(tipo, filme_id, usuario)
	   VALUES(2, 2, 'd')

--INSERT em Comentários
INSERT INTO Comentario(descricao, filme_id, usuario)
		VALUES('Meu filme favorito', 1, 'a')
INSERT INTO Comentario(descricao, filme_id, usuario)
		VALUES('Overrated', 1, 'a')

--INSERT nas avaliações de um comentário
INSERT INTO AvaliacaoComentario(avaliacao, comentario_id, usuario) VALUES(0, 2, 'a')

INSERT INTO AvaliacaoComentario(avaliacao, comentario_id, usuario) VALUES(1, 1, 'd')

INSERT INTO AvaliacaoComentario(avaliacao, comentario_id, usuario) VALUES(1, 1, 'c')

INSERT INTO AvaliacaoComentario(avaliacao, comentario_id, usuario) VALUES(0, 1, 'b')

-- INSERT seguir
INSERT INTO Segue(usuarioSeguido, usuarioSeguidor)
	   VALUES('b', 'a')
INSERT INTO Segue(usuarioSeguido, usuarioSeguidor)
	   VALUES('c', 'a')
INSERT INTO Segue(usuarioSeguido, usuarioSeguidor)
	   VALUES('a', 'd')
INSERT INTO Segue(usuarioSeguido, usuarioSeguidor)
	   VALUES('b', 'd')