namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddropdown : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.News", "UpdateTitle", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.News", "UpdateTitle", c => c.Boolean(nullable: false));
        }
    }
}
