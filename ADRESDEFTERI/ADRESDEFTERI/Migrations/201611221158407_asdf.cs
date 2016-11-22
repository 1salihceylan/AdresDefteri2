namespace ADRESDEFTERI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdf : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.AdresDefteris");
            AlterColumn("dbo.AdresDefteris", "TcNo", c => c.Double(nullable: false));
            AddPrimaryKey("dbo.AdresDefteris", "TcNo");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.AdresDefteris");
            AlterColumn("dbo.AdresDefteris", "TcNo", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.AdresDefteris", "TcNo");
        }
    }
}
