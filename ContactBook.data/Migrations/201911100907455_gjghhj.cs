namespace ContactBook.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gjghhj : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ContactEmail", newName: "ContactEmails");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ContactEmails", newName: "ContactEmail");
        }
    }
}
