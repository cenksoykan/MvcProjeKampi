namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migpersonastatusadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personas", "PersonaStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.PersonaSkills", "PersonaSkillStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PersonaSkills", "PersonaSkillStatus");
            DropColumn("dbo.Personas", "PersonaStatus");
        }
    }
}
