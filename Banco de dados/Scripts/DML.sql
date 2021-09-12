USE Senai_Ofertas

INSERT INTO Produto ( IdTipoProduto, IdUsuario, NomeProduto, LinkProduto, ImagemProduto, Descricao, Preco, Quantidade) 
VALUES			(1, 2,'Controle Play 5','https://www.americanas.com.br/produto/3297085366?opn=YSMESP&sellerid=02&epar=bp_pl_00_go_gm_jogos_todas_geral_gmv&WT.srch=1&acc=e789ea56094489dffd798f86ff51c7a9&i=5612cbe46ed24cafb5cae011&o=60a6a4f4f8e95eac3d85e0a8&gclid=CjwKCAjwhOyJBhA4EiwAEcJdcWM0fGSCFGdSkgGVe_rEZMYzpXOSvLaSn1EHClE627HC3n_JqtDIqxoCvFMQAvD_BwE','https://images-americanas.b2w.io/produtos/01/00/img/3297085/4/3297085403_1SZ.jpg','Console Microsoft','500',50),
				(1, 2,'Console Play 5', 'https://www.americanas.com.br/produto/3297085366?opn=YSMESP&sellerid=02&epar=bp_pl_00_go_gm_jogos_todas_geral_gmv&WT.srch=1&acc=e789ea56094489dffd798f86ff51c7a9&i=5612cbe46ed24cafb5cae011&o=60a6a4f4f8e95eac3d85e0a8&gclid=CjwKCAjwhOyJBhA4EiwAEcJdcWM0fGSCFGdSkgGVe_rEZMYzpXOSvLaSn1EHClE627HC3n_JqtDIqxoCvFMQAvD_BwE', 'https://images-americanas.b2w.io/produtos/01/00/img/3297085/4/3297085403_1SZ.jpg','Console Sony','5000',10),
				(1, 2,'Xbox Series X', 'https://www.americanas.com.br/produto/3297085366?opn=YSMESP&sellerid=02&epar=bp_pl_00_go_gm_jogos_todas_geral_gmv&WT.srch=1&acc=e789ea56094489dffd798f86ff51c7a9&i=5612cbe46ed24cafb5cae011&o=60a6a4f4f8e95eac3d85e0a8&gclid=CjwKCAjwhOyJBhA4EiwAEcJdcWM0fGSCFGdSkgGVe_rEZMYzpXOSvLaSn1EHClE627HC3n_JqtDIqxoCvFMQAvD_BwE', 'https://images-americanas.b2w.io/produtos/01/00/img/3297085/4/3297085403_1SZ.jpg','Console Microsoft','4500',10)
;

INSERT INTO Usuario ( Nome, Senha, Email, Telefone, CPF, CNPJ) 
VALUES			('João','joao12345','joao@gmail.com','11973290257','56798709892', '98745632000145'),
				('Lameck','Lameck12345','Lameck@gmail.com','11993785259','58791700692', '69757612000115')
;

INSERT INTO TipoProduto ( NomeTipoProduto)
VALUES			('Eletrônicos'),
				('Alimentos'),
				('Vestuário')
;

INSERT INTO Reserva ( IdProduto, IdUsuario, Quantidade, PrecoTotal) 
VALUES			(2,2,2,'1000'),
				(3,2,1,'5000'),
				(4,2,1,'4500')
;