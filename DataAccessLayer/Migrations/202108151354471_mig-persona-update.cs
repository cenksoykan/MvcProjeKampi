namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migpersonaupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personas", "PersonaName", c => c.String(maxLength: 50));
            AddColumn("dbo.Personas", "PersonaSurname", c => c.String(maxLength: 50));
            DropColumn("dbo.Personas", "PersomaName");
            DropColumn("dbo.Personas", "PersomaSurname");
            DropColumn("dbo.PersonaSkills", "PersonaSkillStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PersonaSkills", "PersonaSkillStatus", c => c.Boolean(nullable: false));
            AddColumn("dbo.Personas", "PersomaSurname", c => c.String(maxLength: 50));
            AddColumn("dbo.Personas", "PersomaName", c => c.String(maxLength: 50));
            DropColumn("dbo.Personas", "PersonaSurname");
            DropColumn("dbo.Personas", "PersonaName");
        }
    }
}
