create schema agenda;

create table compromisso(
id int primary key auto_increment not null,
compromisso varchar(45),
descricao varchar(100),
local varchar(45) not null,
rua varchar(60),
numero int);

select * from contatos;

create table contatos(
id int primary key auto_increment not null,
nome varchar(45) not null,
email varchar(60),
telefone int not null);

insert into contatos(nome, email, telefone)
values('Júlio', 'julio@gmail.com', 456456-4);

create table compromisso_contatos(
	compromisso_id int not null,
    contatos_id int not null,
	constraint fk_compromisso foreign key(compromisso_id) references compromisso(id),
    constraint fk_contatos foreign key(contatos_id) references contatos(id)
);

insert into compromisso_contatos (compromisso_id, contatos_id)
VALUES (1, 3);

select compromisso, nome, email
from compromisso, contatos, compromisso_contatos
where compromisso_contatos.contatos_id = contatos.id
and compromisso_contatos.compromisso_id = compromisso.id;

insert into compromisso (nome, email, telefone)
VALUES ('jonas', 'jonasgmail.com', 123);