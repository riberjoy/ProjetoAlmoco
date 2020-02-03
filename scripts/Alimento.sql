IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[InsAlimento]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[InsAlimento] 
GO 

CREATE PROCEDURE [dbo].[InsAlimento](
	@Nom_Alimento		varchar(150),
	@Num_IDCategoria	int,
	@Ind_Ativo			char(1)
	)

	AS

	/*
		Documentação
		Arquivo Fonte.....: Alimento.sql
		Objetivo..........: Cadastra um novo Alimento no sistema
		Autor.............: Joyce Ribeiro
 		Data..............: 03/02/2020
		Comentários.......: Parâmetro Status :
							0 - Processado OK
							1 - Erro ao inserir
	*/

	BEGIN 
		
		INSERT  INTO Alimento (Nom_Alimento, Num_IDCategoria, Ind_Ativo)
			VALUES (@Nom_Alimento, @Num_IDCategoria, @Ind_Ativo)

		RETURN 0
			
	END 
GO


IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[DelAlimento]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[DelAlimento] 
GO 

CREATE PROCEDURE [dbo].[DelAlimento](
	@Nom_id	varchar(11))

	AS
	/*
		Documentação
		Arquivo Fonte.....: Alimento.sql
		Objetivo..........: Remove um determinado Alimento
		Autor.............: Joyce Ribeiro
 		Data..............: 03/02/2020
		Comentários.......: Parâmetro Status :
							0 - Processado OK
							1 - Erro ao excluir
		Ex................: EXEC [dbo].[GKSSP_SelSolicAbonos] 30004644, 2018, 10, '0'
	*/

	BEGIN
		DELETE FROM Alimento 
			WHERE Alimento.Num_IDAlimento = @Nom_id
		RETURN 0
	END
GO




IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SelAlimento]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SelAlimento] 
GO 

CREATE PROCEDURE [dbo].[SelAlimento](
	@Num_id	varchar(11) )

	AS
	/*
		Documentação
		Arquivo Fonte.....: Alimento.sql
		Objetivo..........: Seleciona um ou todos os Alimentos
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
				SELECT Num_IDAlimento,
					Nom_Alimento,
					Num_IDCategoria,
					Ind_Ativo
				FROM Alimento WITH(NOLOCK)
			END
		ELSE
			BEGIN
				SELECT Num_IDAlimento,
					Nom_Alimento,
					Num_IDCategoria,
					Ind_Ativo
				FROM Alimento al WITH(NOLOCK)
				WHERE al.Ind_Ativo = '0'
			END

		RETURN 0
	END
GO