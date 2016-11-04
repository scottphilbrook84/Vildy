namespace Vildy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieInformation1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "InStock", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "InStock");
            DropColumn("dbo.Movies", "ReleaseDate");
        }
    }
}
