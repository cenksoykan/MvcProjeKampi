namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class miggalleryimagestatusadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GalleryImages", "GalleryImageStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GalleryImages", "GalleryImageStatus");
        }
    }
}
