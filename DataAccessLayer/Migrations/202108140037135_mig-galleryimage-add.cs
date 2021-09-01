namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class miggalleryimageadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GalleryImages",
                c => new
                    {
                        GalleryImageId = c.Int(nullable: false, identity: true),
                        GalleryImageName = c.String(maxLength: 100),
                        GalleryImagePath = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.GalleryImageId);
        }
        
        public override void Down()
        {
            DropTable("dbo.GalleryImages");
        }
    }
}
