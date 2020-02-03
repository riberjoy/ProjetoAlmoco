IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[InsCliente]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[InsCliente] 
GO 

CREATE PROCEDURE [dbo].[InsCliente](
	@Nom_Cliente	varchar(150),
	@Nom_Usuario	varchar(10),
	@Num_Senha		varchar(20)
	)

	AS

	/*
		Documentação
		Arquivo Fonte.....: Cliente.sql
		Objetivo..........: Cadastra um novo cliente no sistema
		Autor.............: Joyce Ribeiro
 		Data..............: 03/02/2020
		Comentários.......: Parâmetro Status :
							0 - Processado OK
							1 - Erro ao inserir
	*/

	BEGIN 
		
		INSERT  INTO Cliente (Nom_Cliente, Nom_Usuario, Num_Senha)
			VALUES (@Nom_Cliente, @Nom_Usuario, @Num_Senha)

		RETURN 0
			
	END 
GO



IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[AltCliente]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[AltCliente] 
GO 

CREATE PROCEDURE [dbo].[AltCliente](
	@Num_IDCliente	int,
	@Nom_Cliente	varchar(150),
	@Nom_Usuario	varchar(10),
	@Num_Senha		varchar(20)
	)

	AS
	/*
		Documentação
		Arquivo Fonte.....: Cliente.sql
		Objetivo..........: Altera um cliente existente
		Autor.............: Joyce Ribeiro
 		Data..............: 24/01/2020
		Comentários.......: Parâmetro Status :
							0 - Processado OK
							1 - Erro ao alterar
		Ex................: EXEC [dbo].[GKSSP_SelSolicAbonos] 30004644, 2018, 10, '0'
	*/

	BEGIN
		UPDATE  Cliente 
			SET Cliente.Nom_Cliente = @Nom_Cliente,
				Cliente.Nom_Usuario = @Nom_Usuario, 
				Cliente.Num_Senha =  @Num_Senha
			WHERE Cliente.Num_IDCliente = @Num_IDCliente
	END 
GO


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[DelCliente]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[DelCliente] 
GO 

CREATE PROCEDURE [dbo].[DelCliente](
	@Num_Id	varchar(11))

	AS
	/*
		Documentação
		Arquivo Fonte.....: Cliente.sql
		Objetivo..........: Remove um determinado cliente
		Autor.............: Joyce Ribeiro
 		Data..............: 24/01/2020
		Comentários.......: Parâmetro Status :
							0 - Processado OK
							1 - Erro ao excluir
		Ex................: EXEC [dbo].[GKSSP_SelSolicAbonos] 30004644, 2018, 10, '0'
	*/

	BEGIN
		DELETE FROM Cliente 
			WHERE Cliente.Num_IDCliente = @Num_Id
		RETURN 0
	END
GO




IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SelCliente]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SelCliente] 
GO 

CREATE PROCEDURE [dbo].[SelCliente](
	@Num_Usuario	varchar(11) )

	AS
	/*
		Documentação
		Arquivo Fonte.....: Cliente.sql
		Objetivo..........: Seleciona todos os clientes
		Autor.............: Joyce Ribeiro
 		Data..............: 24/01/2020
		Comentários.......: Parâmetro Status :
							0 - Processado OK
							1 - Erro ao selecionar
		Ex................: EXEC [dbo].[GKSSP_SelSolicAbonos] 30004644, 2018, 10, '0'
	*/

	BEGIN
		IF @Num_Usuario = '0'
			BEGIN
				SELECT Num_IDCliente,
					Nom_Cliente,
					Nom_Usuario,
					Num_Senha

				FROM Cliente WITH(NOLOCK)
			END
		ELSE
			BEGIN
				SELECT Num_IDCliente,
					Nom_Cliente,
					Nom_Usuario,
					Num_Senha
				FROM Cliente cl WITH(NOLOCK)
				WHERE cl.Nom_Usuario = @Num_Usuario
			END

		RETURN 0
	END
GO