namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migmessagesenderrename : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessageSenderStatusRead", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "MessageSenderFolder", c => c.String(maxLength: 8));
            DropColumn("dbo.Messages", "MessageStatusRead");
            DropColumn("dbo.Messages", "MessageFolder");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "MessageFolder", c => c.String(maxLength: 8));
            AddColumn("dbo.Messages", "MessageStatusRead", c => c.Boolean(nullable: false));
            DropColumn("dbo.Messages", "MessageSenderFolder");
            DropColumn("dbo.Messages", "MessageSenderStatusRead");
        }
    }
}
