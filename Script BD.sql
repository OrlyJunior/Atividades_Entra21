create database mvcrud;

create table tb_contatos(
id int primary key auto_increment,
nomecontato varchar(40) not null,
email varchar(40) not null,
fone varchar(20) not null);

create table tb_locais(
id int primary key auto_increment,
nomelocal varchar(40) not null,
rua varchar(40) not null,
numero int not null,
bairro varchar(40) not null,
cidade varchar(40) not null,
cep varchar(40) not null,
estado varchar(40) not null);

create table tb_compromissos(
id int primary key auto_increment,
descricao varchar(40) not null,
data datetime not null,
localId int not null,
foreign key(localId) references tb_locais(id),
contatoId INT NOT NULL,
foreign key(contatoId) references tb_contatos(id),
status varchar(20) not null);