namespace Vildy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectMovies : DbMigration
    {
        public override void Up()
        {

			Sql("Update Movies Set ReleaseDate = '1/1/2015', DateAdded = '2/2/2016' WHERE ID = 1");
			Sql("Update Movies Set ReleaseDate = '1/1/2014', DateAdded = '2/2/2015' WHERE ID = 2");

		}
        
        public override void Down()
        {
        }
    }
}
