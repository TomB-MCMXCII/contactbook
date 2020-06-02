namespace ContactBook.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hgh : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ContactEmails", newName: "ContactEmail");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ContactEmail", newName: "ContactEmails");
        }
    }
}
