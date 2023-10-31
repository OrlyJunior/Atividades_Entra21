insert into contatos(nome, email, numero)
values('jonas','jonas@gmail.com','(47)98432-1756');

insert into locais(nome, rua, numero)
values('Campo de Futebol','Rua XV', 154);

insert into compromissos(descricao, data, hora, contatos_id, locais_id)
values('Jogar volei','2022-10-18','18:00:00',1,1);

CREATE TABLE contatosN (
    CONSTRAINT fk_contatos FOREIGN KEY (contatos_idN)
	REFERENCES contatos (id),
        
	CONSTRAINT fk_locais FOREIGN KEY (locais_idN)
	REFERENCES locais (id)
);

select descricao, data, email, rua
from compromissos, contatos, locais
where compromissos.contatos_id = contatos.id
and compromissos.locais_id = locais.id;

update compromissos
set descricao = 'Jogar futebol'
where id = 1;

select * from contatos;

insert into compromissos(descricao, data, hora, locais_id, contatos_id)
values('Jogar futebol', '2023-04-21', '13:00:00', 1, 1);

delete from compromissos
where id = 1;

truncate compromissos;

truncate table compromissos;