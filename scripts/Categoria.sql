IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[InsCategoria]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[InsCategoria] 
GO 

CREATE PROCEDURE [dbo].[InsCategoria](
	@Nom_Categoria	varchar(20)
	)

	AS

	/*
		Documentação
		Arquivo Fonte.....: Categoria.sql
		Objetivo..........: Cadastra um novo Categoria no sistema
		Autor.............: Joyce Ribeiro
 		Data..............: 03/02/2020
		Comentários.......: Parâmetro Status :
							0 - Processado OK
							1 - Erro ao inserir
	    Ex................: EXEC InsCategoria 'Arroz'
	*/

	BEGIN 
		
		INSERT  INTO Categoria (Nom_Categoria)
			VALUES (@Nom_Categoria)

		RETURN 0
			
	END 
GO



IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[DelCategoria]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[DelCategoria] 
GO 

CREATE PROCEDURE [dbo].[DelCategoria](
	@Num_Cat	varchar(11))

	AS
	/*
		Documentação
		Arquivo Fonte.....: Categoria.sql
		Objetivo..........: Remove uma determinada categoria
		Autor.............: Joyce Ribeiro
 		Data..............: 03/02/2020
		Comentários.......: Parâmetro Status :
							0 - Processado OK
							1 - Erro ao excluir
		Ex................: EXEC DelCategoria '1'
	*/

	BEGIN
		DELETE FROM Categoria 
			WHERE Categoria.Num_IDCategoria = @Num_Cat
		RETURN 0
	END
GO




IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[SelCategoria]') AND objectproperty(id, N'IsPROCEDURE')=1)
	DROP PROCEDURE [dbo].[SelCategoria] 
GO 

CREATE PROCEDURE [dbo].[SelCategoria](
	@Num_id	varchar(11) )

	AS
	/*
		Documentação
		Arquivo Fonte.....: Categoria.sql
		Objetivo..........: Seleciona uma ou todas as Categorias
		Autor.............: Joyce Ribeiro
 		Data..............: 03/02/2020
		Comentários.......: Parâmetro Status :
							0 - Processado OK
							1 - Erro ao selecionar
		Ex................: EXEC SelCategoria '0' 
	*/

	BEGIN
		
		IF @Num_id = '0'
			BEGIN
				SELECT Num_IDCategoria,
					Nom_Categoria
				FROM Categoria ct WITH(NOLOCK)
				RETURN 0
			END
		ELSE
			BEGIN
				SELECT Num_IDCategoria,
					Nom_Categoria
				FROM Categoria ct WITH(NOLOCK)
				WHERE ct.Num_IDCategoria = @Num_id
				RETURN 0
			END
	END
GO