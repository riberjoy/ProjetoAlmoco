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
	@Num_IDPedido	int)

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
		Ex................: EXEC [dbo].[GKSSP_SelSolicAbonos] 30004644, 2018, 10, '0'
	*/

	BEGIN
		DELETE FROM Pedido 
			WHERE Pedido.Num_IDPedido = @Num_IDPedido
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
 		Data..............: 24/01/2020
		Comentários.......: Parâmetro Status :
							0 - Processado OK
							1 - Erro ao alterar
		Ex................: EXEC [dbo].[GKSSP_SelSolicAbonos] 30004644, 2018, 10, '0'
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
		Ex................: EXEC [dbo].[GKSSP_SelSolicAbonos] 30004644, 2018, 10, '0'
	*/

	BEGIN
		IF @Num_id = '0'
			BEGIN
				SELECT Num_IDPedido,
					Dat_DataPedido,
					Num_IDCliente, 
					Num_IDAlimento
				FROM Pedido WITH(NOLOCK)
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
