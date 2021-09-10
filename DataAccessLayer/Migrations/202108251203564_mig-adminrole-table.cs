namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migadminroletable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminRoles",
                c => new
                    {
                        AdminRoleCode = c.String(nullable: false, maxLength: 1),
                    })
                .PrimaryKey(t => t.AdminRoleCode);
            
            AddColumn("dbo.Admins", "AdminRoleCode", c => c.String(maxLength: 1));
            CreateIndex("dbo.Admins", "AdminRoleCode");
            AddForeignKey("dbo.Admins", "AdminRoleCode", "dbo.AdminRoles", "AdminRoleCode");
            DropColumn("dbo.Admins", "AdminRole");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminRole", c => c.String(maxLength: 1));
            DropForeignKey("dbo.Admins", "AdminRoleCode", "dbo.AdminRoles");
            DropIndex("dbo.Admins", new[] { "AdminRoleCode" });
            DropColumn("dbo.Admins", "AdminRoleCode");
            DropTable("dbo.AdminRoles");
        }
    }
}
