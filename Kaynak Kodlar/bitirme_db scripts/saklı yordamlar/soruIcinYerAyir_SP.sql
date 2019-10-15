CREATE PROCEDURE soruIcinYerAyir
(
	@projeId int,
	@oncekiId int
)
AS

-- INSERT the new record
INSERT INTO HataTakip.dbo.Soru(PROJEID, ONCEKIID)
VALUES(@projeId, @oncekiId)

-- Now return the ID of the newly inserted record
RETURN SCOPE_IDENTITY()