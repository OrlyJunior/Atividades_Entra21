create table tb_fornecedor(
id int primary key auto_increment not null,
empresa varchar(45) not null);

create table tb_cliente(
id int primary key auto_increment not null,
cliente varchar(45) not null,
telefone int not null,
email varchar(45));

create table tb_produtos(
id int primary key auto_increment not null,
nome varchar(45) not null,
categoria varchar(45),
valor_unitario varchar(45) not null,
id_fornecedor int not null,
constraint fk_fornecedor foreign key(id_fornecedor) references tb_fornecedor(id));

create table tb_compras(
id int primary key auto_increment not null,
valor_total int not null,
valor_parcela int,
id_produto int not null,
constraint fk_produto foreign key(id_produto) references tb_produtos(id));

create table tb_vendas(
id int primary key auto_increment not null,
total_a_receber int not null,
parcelas_a_receber int,
produto_id int not null,
cliente_id int not null,
constraint produto_fk foreign key(produto_id) references tb_produtos(id),
constraint fk_cliente foreign key(cliente_id) references tb_cliente(id));

insert into tb_compras(valor_total, valor_parcela, id_produto)
values(100, 25, 1);

insert into tb_fornecedor(empresa)
values('Microsoft');

insert into tb_produtos(nome, categoria, valor_unitario, id_fornecedor, quantidade)
values('Micro-ondas', 'Eletrodoméstico', 200, 1, 5);

insert into tb_vendas(total_a_receber, parcelas_a_receber, produto_id, cliente_id)
values(100, 4, 2, 1);

select total_a_receber, parcelas_a_receber, nome, cliente
from tb_vendas, tb_produtos, tb_cliente
where tb_vendas.cliente_id = tb_cliente.id
and tb_vendas.produto_id = tb_produtos.id;

create table tb_forma_de_pagamento(
id int primary key auto_increment not null,
forma_de_pagamento varchar(45) not null);

create table tb_a_pagar(
id int primary key auto_increment not null,
valor_total int not null,
Valor_parcela int not null,
id_forma_de_pagamento int not null,
constraint fk_pgto foreign key(id_forma_de_pagamento) references tb_forma_de_pagamento(id));

alter table tb_compras change valor_parcela valor_parcela_compra int not null;

insert into tb_compras(valor_compra, valor_parcela, id_produto)
values(120, 40, 1);

insert into tb_a_pagar(valor_total, valor_parcela, parcelas_a_pagar, id_forma_de_pagamento, id_compras)
values(120, 40, 3, 2, 4);

select valor_total, valor_Parcela_compra, parcelas_a_pagar, forma_de_pagamento, valor_compra, valor_parcela_compra
from tb_a_pagar, tb_forma_de_pagamento, tb_compras
where tb_a_pagar.id_compras = tb_compras.id
and tb_a_pagar.id_forma_de_pagamento = tb_forma_de_pagamento.id;

select * from tb_forma_de_pagamento;

create table tb_a_receber(
id int primary key auto_increment not null,
valor_a_receber int not null,
parcelas_a_receber int not null,
valor_parcela int not null,
forma_de_pagamento_id int not null,
constraint fk_pagamento foreign key(forma_de_pagamento_id) references tb_forma_de_pagamento(id));

insert into tb_forma_de_pagamento(forma_de_pagamento)
values('Pix');

create table tb_venda_produtos(
compras_id int not null,
produtos_id int not null,
constraint fk_produtos foreign key(produtos_id) references tb_produtos(id));

alter table tb_venda_produtos add constraint fk_compras foreign key(compras_id) references tb_compras(id);