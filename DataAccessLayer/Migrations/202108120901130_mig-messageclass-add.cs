namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migmessageclassadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        MessageSender = c.String(maxLength: 500),
                        MessageReceiver = c.String(maxLength: 500),
                        MessageSubject = c.String(maxLength: 50),
                        MessageBody = c.String(),
                        MessageDate = c.String(),
                    })
                .PrimaryKey(t => t.MessageId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Messages");
        }
    }
}
