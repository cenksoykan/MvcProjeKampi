namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migmessagereceiverfolderadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessageReceiverStatusRead", c => c.Boolean(nullable: false));
            AddColumn("dbo.Messages", "MessageReceiverFolder", c => c.String(maxLength: 8));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "MessageReceiverFolder");
            DropColumn("dbo.Messages", "MessageReceiverStatusRead");
        }
    }
}
