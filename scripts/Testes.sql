-- CLIENTES

--insere
execute InsCliente 'Joyce Ribeiro', 'Cyjoe', '121212'
execute InsCliente 'Cliente 01', 'Teste01', '131313'
execute InsCliente 'Clinete 02', 'Teste02', '101010'
execute InsCliente 'Clinete 03', 'Teste03', '141414'

--seleciona Cliente por usuario
execute SelCliente 'Cyjoe'

--seleciona todos clientes
execute SelCliente '0'

--remove
execute DelCliente '1'

--seleciona todos clientes
execute SelCliente '0'

--insere
execute InsCliente 'Joyce Ribeiro', 'Cyjoe', '121212'

--seleciona Cliente por usuario
execute SelCliente 'Cyjoe'

--altera 
execute AltCliente '1','Joyce', 'Cyjoe', '151515'

--seleciona Cliente por usuario
execute SelCliente 'Cyjoe'




-- Categoria
--insere
execute InsCategoria 'Arroz'
execute InsCategoria 'Carne'
execute InsCategoria 'Feijão'
execute InsCategoria 'Vegetal'

--seleciona todos Categorias
execute SelCategoria '0'

--seleciona Categoria por usuario
execute SelCategoria '3'

--remove
execute DelCategoria '3'

--seleciona todos Categorias
execute SelCategoria '0'



-- Alimento
--insere
execute InsAlimento 'Arroz branco', 1, '0'
execute InsAlimento 'Carne de panela bovina', 2, '0'
execute InsAlimento 'Feijão de caldo', 3, '0'
execute InsAlimento 'Tropeiro', 3, '1'
execute InsAlimento 'Tutu', 3, '1'
execute InsAlimento 'Feijão preto', 3, '0'
execute InsAlimento 'Abobrinha verde', 4, '0'

--seleciona todos Alimentos
execute SelAlimento '0'

--seleciona Alimento disponiveis
execute SelAlimento '3'

--remove
execute DelAlimento '7'

--seleciona todos Alimentos
execute SelAlimento '0'



--Pedido

