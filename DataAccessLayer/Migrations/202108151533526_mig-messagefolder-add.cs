namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migmessagefolderadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "MessageFolder", c => c.String(maxLength: 8));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "MessageFolder");
        }
    }
}
