CREATE DATABASE DBRecipes
COLLATE Hebrew_CI_AS
GO

Use DBRecipes
GO

-- Drop Table TBRecipes
CREATE TABLE TBRecipes (
Recipe_Id int identity,
Recipe_Name nvarchar(50),
Recipe_Time nvarchar(50),
Recipe_Type nvarchar(20),
Recipe_Category nvarchar(50)
)
GO

Insert into TBRecipes(Recipe_Name, Recipe_Time, Recipe_Type, Recipe_Category) values('שקשוקה', '30 דק', 'רגיל', 'ארוחות בוקר')
Insert into TBRecipes(Recipe_Name, Recipe_Time, Recipe_Type, Recipe_Category) values('פיצה טבעונית', 'שעה', 'טבעוני', 'פיצות')
Insert into TBRecipes(Recipe_Name, Recipe_Time, Recipe_Type, Recipe_Category) values('המבורגר מושלם', '20 דק', 'בשרי', 'בשרים')
GO

CREATE PROCEDURE TBRecipeInsert
@name nvarchar(50), @time nvarchar(50), @type nvarchar(50), @category nvarchar(50)
AS
BEGIN
	Insert into TBRecipes(Recipe_Name, Recipe_Time, Recipe_Type, Recipe_Category) 
	values(@name, @time, @type, @category)
END
GO

ALTER PROCEDURE TBRecipeUpd
@id nvarchar(50), @name nvarchar(50), @time nvarchar(50), @type nvarchar(50), @category nvarchar(50)
AS
BEGIN
	UPDATE TBRecipes 
	Set Recipe_Name = @name, Recipe_Time = @time, Recipe_Type = @type, Recipe_Category = @category
	WHERE Recipe_Id = @id
END
GO

CREATE PROCEDURE TBRecipeDel
@id int
AS
BEGIN
	DELETE TBRecipes
	WHERE Recipe_Id=@id
END
GO

CREATE PROCEDURE TBRecipeSelSpe
@name nvarchar(50)
AS
BEGIN
	SELECT * From TBRecipes
	Where Recipe_Name = @name
END
GO
