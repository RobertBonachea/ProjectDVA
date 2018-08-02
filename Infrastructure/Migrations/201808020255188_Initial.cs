namespace Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false),
                        Address1 = c.String(nullable: false, maxLength: 120),
                        Address2 = c.String(maxLength: 120),
                        City = c.String(nullable: false, maxLength: 50),
                        Zipcode = c.String(nullable: false, maxLength: 10),
                        State = c.String(nullable: false, maxLength: 2),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.People", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 50),
                        HomePhone = c.String(nullable: false, maxLength: 15),
                        MobilePhone = c.String(nullable: false, maxLength: 15),
                        Email = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "AddressId", "dbo.People");
            DropIndex("dbo.Addresses", new[] { "AddressId" });
            DropTable("dbo.People");
            DropTable("dbo.Addresses");
        }
    }
}
