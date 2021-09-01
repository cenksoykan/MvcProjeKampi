namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migmessagedatedatetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "MessageDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "MessageDate", c => c.String());
        }
    }
}
