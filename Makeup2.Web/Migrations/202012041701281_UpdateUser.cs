namespace Makeup2.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUser : DbMigration
    { 
        public override void Up()
        {
            RenameColumn(table: "dbo.Maquillajes", name: "Paletas_Id", newName: "ApplicationUser");
            RenameIndex(table: "dbo.Maquillajes", name: "IX_Paletas_Id", newName: "IX_ApplicationUser");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Maquillajes", name: "IX_ApplicationUser", newName: "IX_Paletas_Id");
            RenameColumn(table: "dbo.Maquillajes", name: "ApplicationUser", newName: "Paletas_Id");
        }
    }
}
