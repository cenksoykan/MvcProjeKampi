namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class migpersonaadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Personas",
                c => new
                {
                    PersonaId = c.Int(nullable: false, identity: true),
                    PersomaName = c.String(maxLength: 50),
                    PersomaSurname = c.String(maxLength: 50),
                    PersonaTitle = c.String(maxLength: 50),
                    PersonaEmailAddress = c.String(maxLength: 500),
                    PersonaProfilePicture = c.String(maxLength: 500),
                })
                .PrimaryKey(t => t.PersonaId);

            CreateTable(
                "dbo.PersonaSkills",
                c => new
                {
                    PersonaSkillId = c.Int(nullable: false, identity: true),
                    PersonaSkillName = c.String(maxLength: 50),
                    PersonaSkillLevel = c.Int(nullable: false),
                    PersonaSkillIndex = c.Int(nullable: false),
                    PersonaId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.PersonaSkillId)
                .ForeignKey("dbo.Personas", t => t.PersonaId, cascadeDelete: true)
                .Index(t => t.PersonaId);
        }

        public override void Down()
        {
            DropTable("dbo.PersonaSkills");
            DropTable("dbo.Personas");
        }
    }
}
