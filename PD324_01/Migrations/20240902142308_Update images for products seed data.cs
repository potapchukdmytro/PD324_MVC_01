using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PD324_01.Migrations
{
    /// <inheritdoc />
    public partial class Updateimagesforproductsseeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "910632df-d958-45ee-a84e-1ec107893d66.webp");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "f1e28f88-7de9-4468-9673-4e78201a89fb.webp");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "8db30c71-35a1-4903-b279-dfc1c92bdd8d.webp");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "fd47a589-db2d-4804-b32b-40007955f610.webp");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "8681144b-62b0-4344-a0d9-191d8cc8955b.webp");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "068c9a22-dc0b-4033-8ad4-c55ad2f1a444.webp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Image",
                value: "https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcRC98q4Vog6E0ThvsYJZ9M4zQYc7dC-BPrOut3rXMOpAHCgdRd4wlG7b7Y2Ml30vh9ijbrRhVrhizkWlyfQRB2AzspjWn3WTg4muTZFkWA&usqp=CAE");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Image",
                value: "https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcTR0a-LCLAsE8kD7EyVZtQ4fWuOJFUr7om5GatUqr_LNAkbon0RnDxfWLE-uxZhFHuL_EWYtSRj3M5MTWlQsVymGKfBaDkbjBySMoIwj6qDdHa7xTmQOVD1&usqp=CAE");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Image",
                value: "https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcTTuRvD4ecfGFUT5OPX7Y0DUMVCa91IHyzbeqwO3TY6UNwhpfJoB6Harwwm83LcDEfP1bYo34LvJH-PkaKODY8Xwh-x1c1R6pqW_oRaeWDdkMjMTSWIzN8-gg&usqp=CAE");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Image",
                value: "https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcT_OzFW3PueJdquyAqLvXML8ex14absxwEKb9_ai1zWa3_bzk-GccmBsWblN47cJQXndg_ni1lcz8v1y0xTs3BGiu8NSgRXCYRElUKdTvyKjySYjbPQIQz8&usqp=CAE");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Image",
                value: "https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcSN-HOzsGtF5sr9xFHO2ttuITyboTba__ey5QJXz5_vfQT2t_qdV9-qRnqgHlK4tvbY7DoprOEmbrqAW5VnDOZcdK2WkStUAMW-duANTnk&usqp=CAE");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Image",
                value: "https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcSbElEyWjjPP1cYTHLoyhnkZ3EJDbFsXQD1pNvJe6bSr1F5uCmMFThovMt2hRaP8BASxdTA5P2M6WIGNKnNnIwHb6OKPIy0LoyD6GurgAXU4iEen_Foj5W4&usqp=CAE");
        }
    }
}
