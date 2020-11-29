namespace Makeup2.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Start_Project1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gamas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tipo = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Maquillajes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Marca = c.String(),
                        GamaId = c.Int(nullable: false),
                        Paletas_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gamas", t => t.GamaId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Paletas_Id)
                .Index(t => t.GamaId)
                .Index(t => t.Paletas_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Maquillajes", "Paletas_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Maquillajes", "GamaId", "dbo.Gamas");
            DropIndex("dbo.Maquillajes", new[] { "Paletas_Id" });
            DropIndex("dbo.Maquillajes", new[] { "GamaId" });
            DropTable("dbo.Maquillajes");
            DropTable("dbo.Gamas");
        }
    }
}
