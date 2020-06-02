namespace ContactBook.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedcontactadress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactAdresses", "Street", c => c.String());
            AddColumn("dbo.ContactAdresses", "HouseNumber", c => c.String());
            AddColumn("dbo.ContactAdresses", "City", c => c.String());
            DropColumn("dbo.ContactAdresses", "Adress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactAdresses", "Adress", c => c.String());
            DropColumn("dbo.ContactAdresses", "City");
            DropColumn("dbo.ContactAdresses", "HouseNumber");
            DropColumn("dbo.ContactAdresses", "Street");
        }
    }
}
