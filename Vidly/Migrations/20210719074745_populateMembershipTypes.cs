using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Migrations
{
    public partial class populateMembershipTypes : Migration
    {
        string[] columns = { "Id", "SignUpFee", "DurationInMonth", "DiscountRate" };
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
           table: "MembershipType",
           columns: new string[]{ "Id", "SignUpFee", "DurationInMonth", "DiscountRate" },
           values: new object[,]
           {
                { 1,0,0,0 },
                { 2,30,1,10 },
                { 3,90,3,15 },
                { 4,300,12,20 }
       });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
