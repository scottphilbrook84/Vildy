namespace Vildy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "MovieGenreType_Id", "dbo.MovieGenreTypes");
            DropIndex("dbo.Movies", new[] { "MovieGenreType_Id" });
            DropColumn("dbo.Movies", "MovieGenreTypeID");
            RenameColumn(table: "dbo.Movies", name: "MovieGenreType_Id", newName: "MovieGenreTypeID");
            AlterColumn("dbo.Movies", "MovieGenreTypeID", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "MovieGenreTypeID", c => c.Byte(nullable: false));
            CreateIndex("dbo.Movies", "MovieGenreTypeID");
            AddForeignKey("dbo.Movies", "MovieGenreTypeID", "dbo.MovieGenreTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "MovieGenreTypeID", "dbo.MovieGenreTypes");
            DropIndex("dbo.Movies", new[] { "MovieGenreTypeID" });
            AlterColumn("dbo.Movies", "MovieGenreTypeID", c => c.Byte());
            AlterColumn("dbo.Movies", "MovieGenreTypeID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Movies", name: "MovieGenreTypeID", newName: "MovieGenreType_Id");
            AddColumn("dbo.Movies", "MovieGenreTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "MovieGenreType_Id");
            AddForeignKey("dbo.Movies", "MovieGenreType_Id", "dbo.MovieGenreTypes", "Id");
        }
    }
}
