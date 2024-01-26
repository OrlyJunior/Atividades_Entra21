create database api;

create table tb_users(
id int auto_increment primary key,
nome varchar(100) not null,
roles varchar(25) not null,
senha varchar(50) not null);

insert into tb_users(nome, roles, senha)values("Admin", "Administrador", 123);