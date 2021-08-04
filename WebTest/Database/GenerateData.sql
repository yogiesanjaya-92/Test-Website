DECLARE @tempString NVARCHAR(MAX), 
		@rowSize SMALLINT,
		@stringSize SMALLINT,
		@rowCounter SMALLINT,
		@stringCounter SMALLINT,
		@stringCharacter VARCHAR(100),
		@takeChar SMALLINT

SET @rowCounter = 1
SET @stringCounter = 1

SET @stringCharacter = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890 '
SET @rowSize = 100;
SET @stringSize = 1250;

WHILE @rowCounter < @rowSize + 1
BEGIN
	SET @tempString = ''
		WHILE @stringCounter < @stringSize + 1
		BEGIN
			SET @takeChar = CAST((62) *RAND() + 1 as Integer)
			SET @tempString = @tempString + SUBSTRING(@stringCharacter, @takeChar, 1)
			IF @stringCounter % 10 = 0 
				BEGIN
					SET @tempString = STUFF(@tempString, @stringCounter, 1, ' ')
				END
			SET @stringCounter = @stringCounter + 1
		END
	Insert into ImportedData ([String Content]) Values (@tempString)
	SET @stringCounter = 1
	SET @rowCounter = @rowCounter + 1
END