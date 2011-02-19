using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SQLite;
using System.Text;
using System.Data;

namespace Squire.Framework
{
    [TestClass]
    public abstract class SqlKihonStructure : BaseDataKihon
    {
        private static void ExecuteNonQuery(SQLiteConnection dbConn, string cmdText)
        {
            using (SQLiteCommand sQLiteCommand1 = new SQLiteCommand(cmdText, dbConn))
            {
                sQLiteCommand1.ExecuteNonQuery();
            }
        }

        private void Execute(string cmdText, Action<IDataReader> rdrAction)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(cmdText, dbConn))
            using (SQLiteDataReader dataReader = cmd.ExecuteReader())
            {
                rdrAction.Invoke(dataReader);
            }
        }

        protected override void CreateTestData(SQLiteConnection dbConn)
        {
            ExecuteNonQuery(dbConn, CreatePersonTable());
            ExecuteNonQuery(dbConn, CreateAddressTable());
            ExecuteNonQuery(dbConn, SamplePersons());
            ExecuteNonQuery(dbConn, SampleAddress());
        }

        private string SamplePersons()
        {
            var sb = new StringBuilder();

            sb.AppendLine("INSERT INTO PERSON VALUES (1,'Tim','Rayburn',37);");
            sb.AppendLine("INSERT INTO PERSON VALUES (2,'Kate','Rayburn',33);");
            sb.AppendLine("INSERT INTO PERSON VALUES (3,'Chris','Jackson',38);");

            return sb.ToString();
        }

        private string SampleAddress()
        {
            var sb = new StringBuilder();

            sb.AppendLine("INSERT INTO ADDRESS VALUES (1,1,'1102 Angel Fire Lane',null,'Arlington','TX','76001');");
            sb.AppendLine("INSERT INTO ADDRESS VALUES (2,4,'1102 Angel Fire Lane',null,'Arlington','TX','76001');");

            return sb.ToString();
        }

        private string CreateAddressTable()
        {
            var sb = new StringBuilder();

            sb.AppendLine("CREATE TABLE Address");
            sb.AppendLine("(");
            sb.AppendLine("AddressId int not null PRIMARY KEY, ");
            sb.AppendLine("PersonId int,");
            sb.AppendLine("Line1 varchar(50),");
            sb.AppendLine("Line2 varchar(50),");
            sb.AppendLine("City varchar(50),");
            sb.AppendLine("State varchar(50),");
            sb.AppendLine("Zip varchar(9)");
            sb.AppendLine(")");

            return sb.ToString();
        }

        private string CreatePersonTable()
        {
            var sb = new StringBuilder();

            sb.AppendLine("CREATE TABLE Person");
            sb.AppendLine("(");
            sb.AppendLine("PersonId int not null PRIMARY KEY, ");
            sb.AppendLine("FirstName varchar(50),");
            sb.AppendLine("LastName varchar(50),");
            sb.AppendLine("Age int");
            sb.AppendLine(")");

            return sb.ToString();
        }

        [TestMethod]
        public void Actual_Select_All_Fields_And_Rows_From_Person()
        {
            // Arrange
            int count = 0;

            // Act
            string cmdText = Select_All_Fields_And_Rows_From_Person();
            Execute(cmdText, r =>
            {
                while (r.Read())
                {
                    Assert.AreEqual(4, r.FieldCount);
                    count += 1;
                }
            });

            // Assert
            Assert.AreEqual(3, count);
        }

        [TestMethod]
        public void Actual_Select_All_Fields_From_Person_Joined_To_Address()
        {
            // Arrange
            int count = 0;

            // Act
            string cmdText = Select_All_Fields_From_Person_Joined_To_Address();
            Execute(cmdText, r =>
            {
                while (r.Read())
                {
                    Assert.AreEqual(11, r.FieldCount);
                    count += 1;
                }
            });

            // Assert
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void Actual_Select_FirstName_From_Person_Where_LastName_Equals_Rayburn()
        {
            // Arrange
            int count = 0;

            // Act
            string cmdText = Select_FirstName_From_Person_Where_LastName_Equals_Rayburn();
            Execute(cmdText, r => {
                while (r.Read())
                {
                    Assert.AreEqual(1, r.FieldCount);
                    count += 1;
                }
            });

            // Assert
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void Actual_Select_All_Fields_From_Person_Left_Outer_Joined_To_Address()
        {
            // Arrange
            int count = 0;

            // Act
            string cmdText = Select_All_Fields_From_Person_Left_Outer_Joined_To_Address();
            Execute(cmdText, r => {
                while (r.Read())
                {
                    Assert.AreEqual(11, r.FieldCount);
                    count += 1;
                }
            });

            // Assert
            Assert.AreEqual(3, count);
        }

        protected abstract string Select_All_Fields_And_Rows_From_Person();
        protected abstract string Select_All_Fields_From_Person_Joined_To_Address();
        protected abstract string Select_FirstName_From_Person_Where_LastName_Equals_Rayburn();
        protected abstract string Select_All_Fields_From_Person_Left_Outer_Joined_To_Address();
    }
}
