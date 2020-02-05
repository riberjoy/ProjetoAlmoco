-- CLIENTES

--insere
EXEC InsCliente 'Joyce Ribeiro', 'Cyjoe', '121212'
EXEC InsCliente 'Cliente 01', 'Teste01', '131313'
EXEC InsCliente 'Clinete 02', 'Teste02', '101010'
EXEC InsCliente 'Clinete 03', 'Teste03', '141414'

--seleciona Cliente por usuario
EXEC SelCliente 'Cyjoe'

--seleciona todos clientes
EXEC SelCliente '0'

--remove
EXEC DelCliente '1'

--seleciona todos clientes
EXEC SelCliente '0'

--insere
EXEC InsCliente 'Joyce Ribeiro', 'Cyjoe', '121212'

--seleciona Cliente por usuario
EXEC SelCliente 'Cyjoe'

--altera 
EXEC AltCliente '1','Cliente 01', 'Teste01', '151515'

--seleciona Cliente por usuario
EXEC SelCliente 'Cliente 01'




-- Categoria
--insere
EXEC InsCategoria 'Arroz'
EXEC InsCategoria 'Carne'
EXEC InsCategoria 'Feijão'
EXEC InsCategoria 'Vegetal'

--seleciona todos Categorias
EXEC SelCategoria '0'

--seleciona Categoria por usuario
EXEC SelCategoria '3'

--remove
EXEC DelCategoria '3'

--seleciona todos Categorias
EXEC SelCategoria '0'



-- Alimento
--insere
EXEC InsAlimento 'Arroz branco', 1, '0'
EXEC InsAlimento 'Carne de panela bovina', 2, '0'
EXEC InsAlimento 'Feijão de caldo', 3, '0'
EXEC InsAlimento 'Tropeiro', 3, '1'
EXEC InsAlimento 'Tutu', 3, '1'
EXEC InsAlimento 'Feijão preto', 3, '0'
EXEC InsAlimento 'Abobrinha verde', 4, '0'

--seleciona todos Alimentos
EXEC SelAlimento '0'

--seleciona Alimento disponiveis
EXEC SelAlimento '3'

--remove
EXEC DelAlimento '1'

--seleciona todos Alimentos
EXEC SelAlimento '0'



--Pedido

EXEC SelCliente '0'
EXEC SelAlimento '1'

EXEC InsPedido '03-02-2020', 5, 1
EXEC InsPedido '03-02-2020', 5, 2
EXEC InsPedido '03-02-2020', 5, 18
EXEC InsPedido '02-02-2020', 5, 1
EXEC InsPedido '02-02-2020', 5, 2
EXEC InsPedido '02-02-2020', 5, 18

EXEC SelPedido '2'

EXEC DelPedido '4'

EXEC AltPedido 5,'02-02-2020', 2, 1