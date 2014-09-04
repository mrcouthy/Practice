using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfPractice
{
    public class DataGenerator
    {
        public static  IEnumerable<RBM_DBCatalogs> GetDbCatalogMetaData(string user)
        {

            List<RBM_DBCatalogs> RBM_DBCatalogsList = new List<RBM_DBCatalogs>();
            List<RBM_Tables> RBM_TablesList = new List<RBM_Tables>();

            List<RBM_Columns> rbColumnList = new List<RBM_Columns>();

            rbColumnList.Add(new RBM_Columns { ColumnName = "Col1", ColumnDesc = "Desc1" });
            rbColumnList.Add(new RBM_Columns { ColumnName = "Col2", ColumnDesc = "Desc1" });
            rbColumnList.Add(new RBM_Columns { ColumnName = "Col3", ColumnDesc = "Desc1" });
            rbColumnList.Add(new RBM_Columns { ColumnName = "Col4", ColumnDesc = "Desc1" });
            rbColumnList.Add(new RBM_Columns { ColumnName = "Col5", ColumnDesc = "Desc1" });
            rbColumnList.Add(new RBM_Columns { ColumnName = "Col6", ColumnDesc = "Desc1" });
            rbColumnList.Add(new RBM_Columns { ColumnName = "Col7", ColumnDesc = "Desc1" });
            rbColumnList.Add(new RBM_Columns { ColumnName = "Col8", ColumnDesc = "Desc1" });
            rbColumnList.Add(new RBM_Columns { ColumnName = "Col9", ColumnDesc = "Desc1" });
            rbColumnList.Add(new RBM_Columns { ColumnName = "Col10", ColumnDesc = "Desc1" });
            rbColumnList.Add(new RBM_Columns { ColumnName = "Col11", ColumnDesc = "Desc1" });
            rbColumnList.Add(new RBM_Columns { ColumnName = "Col12", ColumnDesc = "Desc1" });
            rbColumnList.Add(new RBM_Columns { ColumnName = "Col13", ColumnDesc = "Desc1" });
            rbColumnList.Add(new RBM_Columns { ColumnName = "Col14", ColumnDesc = "Desc1" });
            rbColumnList.Add(new RBM_Columns { ColumnName = "Col15", ColumnDesc = "Desc1" });
            rbColumnList.Add(new RBM_Columns { ColumnName = "Col16", ColumnDesc = "Desc1" });
            rbColumnList.Add(new RBM_Columns { ColumnName = "Col17", ColumnDesc = "Desc1" });
            rbColumnList.Add(new RBM_Columns { ColumnName = "Col18", ColumnDesc = "Desc1" });
            rbColumnList.Add(new RBM_Columns { ColumnName = "Col19", ColumnDesc = "Desc1" });
            rbColumnList.Add(new RBM_Columns { ColumnName = "Col20", ColumnDesc = "Desc1" });
            rbColumnList.Add(new RBM_Columns { ColumnName = "Col21", ColumnDesc = "Desc1" });
            rbColumnList.Add(new RBM_Columns { ColumnName = "Col22", ColumnDesc = "Desc1" });
            rbColumnList.Add(new RBM_Columns { ColumnName = "Col23", ColumnDesc = "Desc1" });
            rbColumnList.Add(new RBM_Columns { ColumnName = "Col24", ColumnDesc = "Desc1" });


            RBM_TablesList.Add(new RBM_Tables { RBM_Columns = rbColumnList, TableName = "T1" });
            //RBM_TablesList.Add(new RBM_Tables { RBM_Columns = rbColumnList, TableName = "T2" }); Adding this gives multiplicity error as its adding same object
            


            RBM_DBCatalogsList.Add(new RBM_DBCatalogs { RBM_Tables = RBM_TablesList, DBCatalogName = "Db1", DBCatalogServer = "jdedev" });
            RBM_DBCatalogsList.Add(new RBM_DBCatalogs { RBM_Tables = RBM_TablesList, DBCatalogName = "Db2", DBCatalogServer = "jdedev" });
            RBM_DBCatalogsList.Add(new RBM_DBCatalogs { RBM_Tables = RBM_TablesList, DBCatalogName = "Db3", DBCatalogServer = "jdedev" });
            RBM_DBCatalogsList.Add(new RBM_DBCatalogs { RBM_Tables = RBM_TablesList, DBCatalogName = "Db4", DBCatalogServer = "jdedev" });
            RBM_DBCatalogsList.Add(new RBM_DBCatalogs { RBM_Tables = RBM_TablesList, DBCatalogName = "Db5", DBCatalogServer = "jdedev" });
            RBM_DBCatalogsList.Add(new RBM_DBCatalogs { RBM_Tables = RBM_TablesList, DBCatalogName = "Db6", DBCatalogServer = "jdedev" });
            RBM_DBCatalogsList.Add(new RBM_DBCatalogs { RBM_Tables = RBM_TablesList, DBCatalogName = "Db7", DBCatalogServer = "jdedev" });
            RBM_DBCatalogsList.Add(new RBM_DBCatalogs { RBM_Tables = RBM_TablesList, DBCatalogName = "Db8", DBCatalogServer = "jdedev" });
            RBM_DBCatalogsList.Add(new RBM_DBCatalogs { RBM_Tables = RBM_TablesList, DBCatalogName = "Db9", DBCatalogServer = "jdedev" });
            RBM_DBCatalogsList.Add(new RBM_DBCatalogs { RBM_Tables = RBM_TablesList, DBCatalogName = "Db10", DBCatalogServer = "jdedev" });
            return RBM_DBCatalogsList;
        }

    }
}
