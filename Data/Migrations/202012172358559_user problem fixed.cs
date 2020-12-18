namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userproblemfixed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Game", "GameWebsite", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Game", "GameWebsite");
        }
    }
}
