CREATE PROCEDURE spupdatequery      
(      
   @RollNo int ,    
   @Name varchar(20),     
   @Age int,    
   @City varchar(20),    
   @Course varchar(20)    
)      
AS    
BEGIN      
   Update StudentTable       
   SET Name=@Name,
   Age=@Age,
   City=@City,     
   Course=@Course    
   WHERE RollNo=@RollNo      
END
