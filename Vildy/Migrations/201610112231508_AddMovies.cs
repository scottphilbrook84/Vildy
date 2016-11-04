namespace Vildy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovies : DbMigration
    {
        public override void Up()
        {
			Sql("INSERT INTO Movies (Name, MovieGenreTypeID, ReleaseDate, InStock, DateAdded) VALUES ( 'Die Hard', 1, 01/02/2014, 5, 04/20/2015)");
			Sql("INSERT INTO Movies (Name, MovieGenreTypeID, ReleaseDate, InStock, DateAdded) VALUES ( 'Shrek', 2, 01/02/2014, 7, 03/20/2015)");
        }
        
        public override void Down()
        {
        }
    }
}
