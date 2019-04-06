
CREATE PROCEDURE spinsertquery     
(    
    @RollNo int,
    @Name VARCHAR(20),  
	@Age int,
    @City VARCHAR(20),    
    @course VARCHAR(20)   
)    
AS  
BEGIN     
    INSERT INTO StudentTable (Rollno,Name,Age,City,Course)     
    VALUES (@RollNo,@Name,@Age,@City,@Course)     
END  