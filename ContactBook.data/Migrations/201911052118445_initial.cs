namespace ContactBook.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactAdresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactId = c.Int(nullable: false),
                        Adress = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Company = c.String(),
                        Notes = c.String(),
                        DateOfBirth = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactEmails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactId = c.Int(nullable: false),
                        Email = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.ContactPhones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactId = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactPhones", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.ContactEmails", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.ContactAdresses", "ContactId", "dbo.Contacts");
            DropIndex("dbo.ContactPhones", new[] { "ContactId" });
            DropIndex("dbo.ContactEmails", new[] { "ContactId" });
            DropIndex("dbo.ContactAdresses", new[] { "ContactId" });
            DropTable("dbo.ContactPhones");
            DropTable("dbo.ContactEmails");
            DropTable("dbo.Contacts");
            DropTable("dbo.ContactAdresses");
        }
    }
}
