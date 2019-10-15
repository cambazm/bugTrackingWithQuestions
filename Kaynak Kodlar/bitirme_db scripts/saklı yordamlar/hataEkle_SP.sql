CREATE PROCEDURE [dbo].[hataEkle]
(
	@projeId int,
	@soruId int,
	@aciklama nvarchar(MAX),
	@simdi datetime,
	@yollayanId int,
	@cevap int
)
AS

-- INSERT the new record
INSERT INTO Hata (PROJEID, SONSORUID, ACIKLAMA, ZAMAN, YOLLAYANID, CEVAP) 
VALUES (@projeId, @soruId, @aciklama, @simdi, @yollayanId, @cevap)

-- Now return the ID of the newly inserted record
RETURN SCOPE_IDENTITY()