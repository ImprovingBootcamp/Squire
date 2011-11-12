using System;

using System.Data.SQLite;
using System.Text;
using System.Data;

using NUnit.Framework;

namespace Squire.Framework
{
    //[TestFixture]
    public abstract class SqlKihonBase : BaseDataKihon
    {
        private int ExecuteScalarInt(string cmdText)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(cmdText, dbConn))
            {
                object result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }

        private int ExecuteNonQuery(string cmdText)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(cmdText, dbConn))
            {
                return cmd.ExecuteNonQuery();
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
            ExecuteNonQuery(CreatePersonTable());
            ExecuteNonQuery(CreateAddressTable());
            ExecuteNonQuery(SamplePersons());
            ExecuteNonQuery(SampleAddress());
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

        //[Test]
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

        //[Test]
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

        //[Test]
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

        //[Test]
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

        //[Test]
        public void Actual_Insert_PersonId_4_Named_Mike_Johnson_Age_5_To_Person()
        {
            // Arrange
            int count = 0;

            // Act
            string cmdText = Insert_PersonId_4_Named_Mike_Johnson_Age_5_To_Person();
            var rowCount = ExecuteNonQuery(cmdText);

            // Assert
            Assert.AreEqual(1, rowCount);
            Execute("SELECT * FROM PERSON WHERE FIRSTNAME='Mike' AND LASTNAME='Johnson' AND AGE=5",
                r =>
                {
                    while (r.Read())
                    {
                        count += 1;
                    }
                });
            Assert.AreEqual(1, count);
        }

        //[Test]
        public void Actual_Update_All_LastNames_Rayburn_To_Johnson_In_Person()
        {
            // Arrange
            // int count = 0;

            // Act
            string cmdText = Update_All_LastNames_Rayburn_To_Johnson_In_Person();
            var rowCount = ExecuteNonQuery(cmdText);

            // Assert
            Assert.AreEqual(2, rowCount);
            Assert.AreEqual(2, ExecuteScalarInt("SELECT COUNT(*) FROM PERSON WHERE LASTNAME='Johnson'"));
            Assert.AreEqual(0, ExecuteScalarInt("SELECT COUNT(*) FROM PERSON WHERE LASTNAME='Rayburn'"));
        }
        
        protected abstract string Select_All_Fields_And_Rows_From_Person();
        protected abstract string Select_All_Fields_From_Person_Joined_To_Address();
        protected abstract string Select_FirstName_From_Person_Where_LastName_Equals_Rayburn();
        protected abstract string Select_All_Fields_From_Person_Left_Outer_Joined_To_Address();
        protected abstract string Insert_PersonId_4_Named_Mike_Johnson_Age_5_To_Person();
        protected abstract string Update_All_LastNames_Rayburn_To_Johnson_In_Person();
    }
}
