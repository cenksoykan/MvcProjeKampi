namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migmessagestatusreadadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ContactStatusRead", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "MessageStatusRead", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "MessageStatusRead");
            DropColumn("dbo.Contacts", "ContactStatusRead");
        }
    }
}
