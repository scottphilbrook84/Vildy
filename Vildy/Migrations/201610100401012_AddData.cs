namespace Vildy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddData : DbMigration
    {
        public override void Up()
        {

			Sql("INSERT Into MovieGenreTypes (Id, Name) VALUES (1, 'Comedy' )");
			Sql("INSERT Into MovieGenreTypes (Id, Name) VALUES (2, 'Action' )");
			Sql("INSERT Into MovieGenreTypes (Id, Name) VALUES (3, 'Sci-fi' )");
			Sql("INSERT Into MovieGenreTypes (Id, Name) VALUES (4, 'Romance')");
        }
        
        public override void Down()
        {
        }
    }
}
