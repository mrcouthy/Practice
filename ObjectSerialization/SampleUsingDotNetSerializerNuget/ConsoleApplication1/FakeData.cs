using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDE.Common.Tests
{

    [Serializable]
    public class ReportModel
    {
        public string abc { get; set; }
         public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public List<UserDataSetModel> MyDataSets { get; set; }
    }

    public class UserTable
    {
        public string Name { get; set; }
        public List<ColumnDefinition> Columns { get; set; }
    }

    public class ColumnDefinition
    {
        public string Name { get; set; }
    }

    public class UserDataSetModel
    {
        public string Name { get; set; }
        public string Server { get; set; }
        public List<UserTable> Tables { get; set; }
    }

    public class DataGenerator
    {
        public static ReportModel GetUserDataSets()
        {
            
            var policy = new UserDataSetModel
            {
                Name = "Policy",
                Tables =
                    new List<UserTable>
                    {
                        new UserTable
                        {
                            Name = "Exposure",
                            Columns =
                                new List<ColumnDefinition>
                                {
                                    new ColumnDefinition { Name = "ExosureId" },
                                    new ColumnDefinition { Name = "ExosureType" },
                                    new ColumnDefinition { Name = "ExosureLevel" },
                                }
                        },
                        new UserTable
                        {
                            Name = "Table 2",
                            Columns =
                                new List<ColumnDefinition>
                                {
                                    new ColumnDefinition { Name = "Exosure2Id" },
                                    new ColumnDefinition { Name = "Exosure2Type" },
                                    new ColumnDefinition { Name = "Exosure2Level" },
                                }
                        }
                    }
            };

            var claims = new UserDataSetModel
            {
                Name = "Claims",
                Tables =
                    new List<UserTable>
                    {
                        new UserTable
                        {
                            Name = "BenefitType",
                            Columns =
                                new List<ColumnDefinition>
                                {
                                    new ColumnDefinition { Name = "BenefitTypeId" },
                                    new ColumnDefinition { Name = "BenefitType" },
                                    new ColumnDefinition { Name = "BenefitTypeLevel" },
                                }
                        },
                        new UserTable
                        {
                            Name = "Benefit Table 2",
                            Columns =
                                new List<ColumnDefinition>
                                {
                                    new ColumnDefinition { Name = "BenefitType2Id" },
                                    new ColumnDefinition { Name = "BenefitType2" },
                                    new ColumnDefinition { Name = "BenefitTypeLevel1" },
                                }
                        }
                    }
            };

            var expenses = new UserDataSetModel
            {
                Name = "Expenses",
                Tables =
                    new List<UserTable>
                    {
                        new UserTable
                        {
                            Name = "ExpenseType",
                            Columns =
                                new List<ColumnDefinition>
                                {
                                    new ColumnDefinition { Name = "ExpenseTypeId" },
                                    new ColumnDefinition { Name = "ExpenseType" },
                                    new ColumnDefinition { Name = "ExpenseTypeLevel" },
                                }
                        },
                        new UserTable
                        {
                            Name = "Expenses Table 2",
                            Columns =
                                new List<ColumnDefinition>
                                {
                                    new ColumnDefinition { Name = "ExpenseType2Id" },
                                    new ColumnDefinition { Name = "ExpenseType2" },
                                    new ColumnDefinition { Name = "ExpenseType3" },
                                }
                        }
                    }
            };

            var datasets = new List<UserDataSetModel> { policy, claims, expenses };
            ReportModel reportModel = new ReportModel();
            reportModel.MyDataSets = datasets;
            reportModel.abc = "ramramr";
           // reportModel.Phone = "a56s4df";
            return reportModel;
        }
    }
}

