using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unisantos.TI.Infrastructure.Migrations
{
    public partial class AddHaversineFunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE FUNCTION haversine(latitude1 float, longitude1 float, latitude2 float, longitude2 float)
                    RETURNS float AS
                $$
                BEGIN

                    RETURN (6371 * acos(cos(radians(latitude2))
                                            * cos(radians(latitude1))
                                            * cos(radians(longitude1)
                            - radians(longitude2))
                        + sin(radians(latitude2))
                                            * sin(radians(latitude1))));

                END
                $$
                    LANGUAGE plpgsql
                    IMMUTABLE
                    PARALLEL SAFE
                    RETURNS NULL ON NULL INPUT
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FUNCTION haversine");
        }
    }
}
