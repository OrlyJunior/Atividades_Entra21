create user operador@localhost identified by 'abc';

drop user operador@localhost;

grant select, insert, alter
on cursocsharp.tb_produtos
to operador@localhost;

revoke insert, alter
on cursocsharp.tb_produtos
from operador@localhost;