CREATE PROCEDURE spdeletequery    
(      
   @RollNo int      
)      
AS      
BEGIN      
   DELETE FROM StudentTable WHERE RollNo=@RollNo     
END