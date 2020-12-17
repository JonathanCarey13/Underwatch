namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeduserstuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FavoritesList", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Game", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.News", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "OwnerId");
            DropColumn("dbo.Game", "OwnerId");
            DropColumn("dbo.FavoritesList", "OwnerId");
        }
    }
}
