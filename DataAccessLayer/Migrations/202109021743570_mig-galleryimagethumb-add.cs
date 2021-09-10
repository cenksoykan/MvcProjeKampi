namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class miggalleryimagethumbadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GalleryImages", "GalleryImageThumbPath", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GalleryImages", "GalleryImageThumbPath");
        }
    }
}
