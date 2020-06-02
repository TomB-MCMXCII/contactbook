namespace ContactBook.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedlatanlngtoadress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactAdresses", "lat", c => c.Single(nullable: false));
            AddColumn("dbo.ContactAdresses", "lng", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ContactAdresses", "lng");
            DropColumn("dbo.ContactAdresses", "lat");
        }
    }
}
