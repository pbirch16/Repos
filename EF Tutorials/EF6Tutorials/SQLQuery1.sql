CREATE PROCEDURE [dbo].[Student_Insert]
    @StudentName [nvarchar](max),
    @DoB [datetime]
AS
BEGIN
    INSERT [dbo].[Students]([StudentName], [DoB])
    VALUES (@StudentName, @DoB)
    
    DECLARE @StudentId int
    SELECT @StudentId = [StudentId]
    FROM [dbo].[Students]
    WHERE @@ROWCOUNT > 0 AND [StudentId] = scope_identity()
    
    SELECT t0.[StudentId]
    FROM [dbo].[Students] AS t0
    WHERE @@ROWCOUNT > 0 AND t0.[StudentId] = @StudentId
END

GO

CREATE PROCEDURE [dbo].[Student_Update]
    @StudentId [int],
    @StudentName [nvarchar](max),
    @DoB [datetime]
AS
BEGIN
    UPDATE [dbo].[Students]
    SET [StudentName] = @StudentName, [DoB] = @DoB
    WHERE ([StudentId] = @StudentId)
END

GO

CREATE PROCEDURE [dbo].[Student_Delete]
    @StudentId [int]
AS
BEGIN
    DELETE [dbo].[Students]
    WHERE ([StudentId] = @StudentId)
END