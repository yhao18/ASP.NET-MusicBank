namespace W2022A6YH.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Media_items1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MediaItems", "StringId", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MediaItems", "StringId", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
