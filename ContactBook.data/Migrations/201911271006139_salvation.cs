namespace ContactBook.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class salvation : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Contacts", "ContactId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "ContactId", c => c.Int(nullable: false));
        }
    }
}
