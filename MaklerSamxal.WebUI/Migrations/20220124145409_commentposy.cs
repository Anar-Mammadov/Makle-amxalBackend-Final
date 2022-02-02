using Microsoft.EntityFrameworkCore.Migrations;

namespace MaklerSamxal.WebUI.Migrations
{
    public partial class commentposy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Testimionalss_CreateByUserId",
                table: "Testimionalss",
                column: "CreateByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Testimionalss_DeleteByUserId",
                table: "Testimionalss",
                column: "DeleteByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscrices_CreateByUserId",
                table: "Subscrices",
                column: "CreateByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscrices_DeleteByUserId",
                table: "Subscrices",
                column: "DeleteByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreateByUserId",
                table: "Products",
                column: "CreateByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DeleteByUserId",
                table: "Products",
                column: "DeleteByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CreateByUserId",
                table: "Contacts",
                column: "CreateByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_DeleteByUserId",
                table: "Contacts",
                column: "DeleteByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CreateByUserId",
                table: "Blogs",
                column: "CreateByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_DeleteByUserId",
                table: "Blogs",
                column: "DeleteByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_CreateByUserId",
                table: "Agents",
                column: "CreateByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Agents_DeleteByUserId",
                table: "Agents",
                column: "DeleteByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Users_CreateByUserId",
                table: "Agents",
                column: "CreateByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Users_DeleteByUserId",
                table: "Agents",
                column: "DeleteByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Users_CreateByUserId",
                table: "Blogs",
                column: "CreateByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_Users_DeleteByUserId",
                table: "Blogs",
                column: "DeleteByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Users_CreateByUserId",
                table: "Contacts",
                column: "CreateByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Users_DeleteByUserId",
                table: "Contacts",
                column: "DeleteByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_CreateByUserId",
                table: "Products",
                column: "CreateByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_DeleteByUserId",
                table: "Products",
                column: "DeleteByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscrices_Users_CreateByUserId",
                table: "Subscrices",
                column: "CreateByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscrices_Users_DeleteByUserId",
                table: "Subscrices",
                column: "DeleteByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Testimionalss_Users_CreateByUserId",
                table: "Testimionalss",
                column: "CreateByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Testimionalss_Users_DeleteByUserId",
                table: "Testimionalss",
                column: "DeleteByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Users_CreateByUserId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Users_DeleteByUserId",
                table: "Agents");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Users_CreateByUserId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_Users_DeleteByUserId",
                table: "Blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Users_CreateByUserId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Users_DeleteByUserId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_CreateByUserId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_DeleteByUserId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscrices_Users_CreateByUserId",
                table: "Subscrices");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscrices_Users_DeleteByUserId",
                table: "Subscrices");

            migrationBuilder.DropForeignKey(
                name: "FK_Testimionalss_Users_CreateByUserId",
                table: "Testimionalss");

            migrationBuilder.DropForeignKey(
                name: "FK_Testimionalss_Users_DeleteByUserId",
                table: "Testimionalss");

            migrationBuilder.DropIndex(
                name: "IX_Testimionalss_CreateByUserId",
                table: "Testimionalss");

            migrationBuilder.DropIndex(
                name: "IX_Testimionalss_DeleteByUserId",
                table: "Testimionalss");

            migrationBuilder.DropIndex(
                name: "IX_Subscrices_CreateByUserId",
                table: "Subscrices");

            migrationBuilder.DropIndex(
                name: "IX_Subscrices_DeleteByUserId",
                table: "Subscrices");

            migrationBuilder.DropIndex(
                name: "IX_Products_CreateByUserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_DeleteByUserId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_CreateByUserId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_DeleteByUserId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_CreateByUserId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_DeleteByUserId",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Agents_CreateByUserId",
                table: "Agents");

            migrationBuilder.DropIndex(
                name: "IX_Agents_DeleteByUserId",
                table: "Agents");
        }
    }
}
