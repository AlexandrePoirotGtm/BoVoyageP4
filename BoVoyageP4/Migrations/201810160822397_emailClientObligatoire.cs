namespace BoVoyageP4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emailClientObligatoire : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Clients", new[] { "Email" });
            AlterColumn("dbo.Clients", "Email", c => c.String(nullable: false, maxLength: 150));
            CreateIndex("dbo.Clients", "Email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Clients", new[] { "Email" });
            AlterColumn("dbo.Clients", "Email", c => c.String(maxLength: 150));
            CreateIndex("dbo.Clients", "Email", unique: true);
        }
    }
}
