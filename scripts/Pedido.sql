IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[InsPedido]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[InsPedido] 
GO 

CREATE PROCEDURE [dbo].[InsPedido](
	@Dat_DataPedido		date,
	@Num_IDCliente		int,
	@Num_IDAlimento		int
	)

	AS

	/*
		Documentação
		Arquivo Fonte.....: Pedido.sql
		Objetivo..........: Cadastra um novo Pedido no sistema
		Autor.............: Joyce Ribeiro
 		Data..............: 03/02/2020
		Comentários.......: Parâmetro Status :
							0 - Processado OK
							1 - Erro ao inserir
		Ex:...............: EXEC InsPedido '03-02-2020', 5, 1
	*/

	BEGIN
		INSERT  INTO Pedido (Dat_DataPedido, Num_IDCliente, Num_IDAlimento)
			VALUES (@Dat_DataPedido, @Num_IDCliente, @Num_IDAlimento)
		RETURN 0
	END 
GO



IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[DelPedido]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[DelPedido] 
GO 

CREATE PROCEDURE [dbo].[DelPedido](
	@Num_IDCliente	int)

	AS
	/*
		Documentação
		Arquivo Fonte.....: Pedido.sql
		Objetivo..........: Remove uma determinada Pedido
		Autor.............: Joyce Ribeiro
 		Data..............: 03/02/2020
		Comentários.......: Parâmetro Status :
							0 - Processado OK
							1 - Erro ao excluir
		Ex................: EXEC DelPedido '1'
	*/

	BEGIN
	IF @Num_IDCliente = '0'
		BEGIN
			DELETE FROM Pedido
		END
	ELSE
		DELETE FROM Pedido 
			WHERE Pedido.Num_IDCliente = @Num_IDCliente
		RETURN 0
	END
GO



IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[AltPedido]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[AltPedido] 
GO 

CREATE PROCEDURE [dbo].[AltPedido](
	@Num_IDPedido		int,
	@Dat_DataPedido		date,
	@Num_IDCliente		int,
	@Num_IDAlimento		int
	)

	AS
	/*
		Documentação
		Arquivo Fonte.....: Pedido.sql
		Objetivo..........: Altera um Pedido existente
		Autor.............: Joyce Ribeiro
 		Data..............: 03/02/2020
		Comentários.......: Parâmetro Status :
							0 - Processado OK
							1 - Erro ao alterar
		Ex................: EXEC AltPedido 5,'02-02-2020', 2, 1
	*/

	BEGIN
		UPDATE  Pedido 
			SET Pedido.Dat_DataPedido= @Dat_DataPedido,
				Pedido.Num_IDCliente = @Num_IDCliente, 
				Pedido.Num_IDAlimento=  @Num_IDAlimento
			WHERE Pedido.Num_IDPedido = @Num_IDPedido
	END 
GO




IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SelPedido]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SelPedido] 
GO 

CREATE PROCEDURE [dbo].[SelPedido](
	@Num_id	varchar(11) )

	AS
	/*
		Documentação
		Arquivo Fonte.....: Pedido.sql
		Objetivo..........: Seleciona uma ou todas as Pedidos
		Autor.............: Joyce Ribeiro
 		Data..............: 03/02/2020
		Comentários.......: Parâmetro Status :
							0 - Processado OK
							1 - Erro ao selecionar
		Ex................: EXEC SelPedido '2'
	*/

	BEGIN
		IF @Num_id = '0'
			BEGIN
				SELECT pd.Num_IDPedido,
					pd.Dat_DataPedido,
					pd.Num_IDCliente, 
					cl.Nom_Cliente,
					pd.Num_IDAlimento,
					al.Nom_Alimento,
					ct.Nom_Categoria
				FROM Pedido pd WITH(NOLOCK) 
				INNER JOIN Cliente cl ON pd.Num_IDCliente = cl.Num_IDCliente
				INNER JOIN Alimento al ON pd.Num_IDAlimento = al.Num_IDAlimento
				INNER JOIN Categoria ct ON al.Num_IDCategoria = ct.Num_IDCategoria
				WHERE Dat_DataPedido = getDate() ORDER BY cl.Nom_Cliente ASC
			END
		ELSE
			BEGIN
				SELECT Num_IDPedido,
					Dat_DataPedido,
					Num_IDCliente, 
					Num_IDAlimento
				FROM Pedido pd WITH(NOLOCK)
				WHERE pd.Num_IDCliente = @Num_id
			END

		RETURN 0
	END
GO
