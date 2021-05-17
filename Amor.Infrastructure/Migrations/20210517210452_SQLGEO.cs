using Microsoft.EntityFrameworkCore.Migrations;

namespace Amor.Infrastructure.Migrations
{
    public partial class SQLGEO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"USE [amorapp]
GO

/****** Object:  StoredProcedure [dbo].[GETSTIntersectsAddress]    Script Date: 17/05/2021 18:04:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





ALTER PROCEDURE [dbo].[GETSTIntersectsAddress]
    @POLYGON NVARCHAR(max)  
AS

declare @tableTemp table (point geometry, id int);
declare @tableEventIntersect table (eventId int, homelessId int, ongId int);

DECLARE @g geometry;  
SET @g = geometry::STGeomFromText(@POLYGON, 4326);  


--EVENTS

INSERT INTO @tableTemp
SELECT	geometry::Point(a.Longitude, a.Latitude,  4326) as POINT,		
		a.eventid	
FROM	Address a
where	(a.EventId is not null)

INSERT INTO @tableEventIntersect(eventId)
SELECT	id
FROM	@tableTemp e
WHERE	@g.STIntersects(e.point) = 1

-- FIM EVENTS

DELETE @tableTemp

--HOMELESS

INSERT INTO @tableTemp
SELECT		geometry::Point(a.Longitude, a.Latitude,  4326) as POINT,
			H.Id
FROM		Homeless H
INNER JOIN	Address A ON A.PersonId = H.PersonId


INSERT INTO @tableEventIntersect(homelessId)
SELECT	id
FROM	@tableTemp e
WHERE	@g.STIntersects(e.point) = 1

-- FIM HOMELESS

DELETE @tableTemp

--ONG

INSERT INTO @tableTemp
SELECT	geometry::Point(a.Longitude, a.Latitude,  4326) as POINT,
			O.Id
FROM		Ongs O
INNER JOIN	Address A ON A.PersonId = O.PersonId

INSERT INTO @tableEventIntersect(ongId)
SELECT	id
FROM	@tableTemp e
WHERE	@g.STIntersects(e.point) = 1

--FIM ONG

DELETE @tableTemp


SELECT * FROM @tableEventIntersect
GO


";

            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
