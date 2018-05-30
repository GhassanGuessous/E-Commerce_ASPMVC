namespace E_Commerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        NumArticle = c.Int(nullable: false, identity: true),
                        Designation = c.String(),
                        PrixU = c.Double(nullable: false),
                        Stock = c.Int(nullable: false),
                        Photo = c.String(),
                        RefCat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NumArticle)
                .ForeignKey("dbo.Categories", t => t.RefCat, cascadeDelete: true)
                .Index(t => t.RefCat);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        RefCat = c.Int(nullable: false, identity: true),
                        NomCat = c.String(),
                    })
                .PrimaryKey(t => t.RefCat);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        NumClient = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        MotDePasse = c.String(),
                        Nom = c.String(),
                        Prenom = c.String(),
                        Email = c.String(),
                        Ville = c.String(),
                        Tel = c.String(),
                    })
                .PrimaryKey(t => t.NumClient);
            
            CreateTable(
                "dbo.Commandes",
                c => new
                    {
                        NumCmd = c.Int(nullable: false, identity: true),
                        DateCmd = c.String(),
                        NumClient = c.Int(nullable: false),
                        NumArticle = c.Int(nullable: false),
                        QteArticle = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NumCmd)
                .ForeignKey("dbo.Articles", t => t.NumArticle, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.NumClient, cascadeDelete: true)
                .Index(t => t.NumClient)
                .Index(t => t.NumArticle);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Commandes", "NumClient", "dbo.Clients");
            DropForeignKey("dbo.Commandes", "NumArticle", "dbo.Articles");
            DropForeignKey("dbo.Articles", "RefCat", "dbo.Categories");
            DropIndex("dbo.Commandes", new[] { "NumArticle" });
            DropIndex("dbo.Commandes", new[] { "NumClient" });
            DropIndex("dbo.Articles", new[] { "RefCat" });
            DropTable("dbo.Commandes");
            DropTable("dbo.Clients");
            DropTable("dbo.Categories");
            DropTable("dbo.Articles");
        }
    }
}
