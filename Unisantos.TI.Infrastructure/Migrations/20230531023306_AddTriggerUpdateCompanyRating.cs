using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Unisantos.TI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTriggerUpdateCompanyRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE FUNCTION update_company_rating()
                    RETURNS TRIGGER AS
                    $$
                        DECLARE
                            rating float;
                        BEGIN

                            SELECT (SUM(""Rate"") / COUNT(""Rate"")) INTO rating
                            FROM ""Rates"" WHERE ""CompanyId"" = NEW.""CompanyId"" GROUP BY ""CompanyId"";

                            UPDATE ""Companies"" SET ""Rating"" = rating WHERE ""Id"" = NEW.""CompanyId"";

                            RETURN NULL;

                        END
                    $$
                            LANGUAGE plpgsql;

                CREATE TRIGGER update_company_rating AFTER INSERT ON ""Rates""
                FOR EACH ROW EXECUTE FUNCTION update_company_rating();
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DROP TRIGGER update_company_rating ON ""Rates"";

                DROP FUNCTION update_company_rating;
            ");
        }
    }
}
