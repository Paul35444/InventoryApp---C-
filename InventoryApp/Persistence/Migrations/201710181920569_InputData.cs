namespace InventoryApp.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InputData : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Items", new[] { "User_Id" });
            AlterColumn("dbo.Items", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Items", "User_Id");
            AddForeignKey("dbo.Items", "User_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Items", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "DateTime", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Items", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Items", new[] { "User_Id" });
            AlterColumn("dbo.Items", "User_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Items", "User_Id");
            AddForeignKey("dbo.Items", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
