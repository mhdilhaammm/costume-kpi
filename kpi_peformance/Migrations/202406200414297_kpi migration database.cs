namespace kpi_peformance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kpimigrationdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "LOGISTIC_KPI.TB_KPI",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ship_date = c.DateTime(nullable: false),
                        Input_Date = c.DateTime(nullable: false),
                        Num_BL = c.Int(nullable: false),
                        Num_Dec = c.Int(nullable: false),
                        DE = c.Int(nullable: false),
                        HS_CodeErr = c.Int(nullable: false),
                        CO_Err = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Val_Err = c.Int(nullable: false),
                        Sum_Err = c.Single(nullable: false),
                        SUM = c.Int(nullable: false),
                        CF = c.Single(nullable: false),
                        TF = c.Single(nullable: false),
                        OP = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "LOGISTIC_KPI.TB_LIMITPERITEM",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Create_DatePerItem = c.DateTime(nullable: false),
                        Name = c.String(),
                        Limit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "LOGISTIC_KPI.TB_LIMITOVERALL",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Create_DateOvr = c.DateTime(nullable: false),
                        Name = c.String(),
                        Limit_Ovr = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("LOGISTIC_KPI.TB_LIMITOVERALL");
            DropTable("LOGISTIC_KPI.TB_LIMITPERITEM");
            DropTable("LOGISTIC_KPI.TB_KPI");
        }
    }
}
