using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Squire.Framework;

namespace Squire
{
    [TestClass]
    public class SqlKihon : SqlKihonStructure
    {
        /* Given SQL Tables defined as:
         * ----------------------------
         * CREATE TABLE Person
           (
             PersonId int not null PRIMARY KEY, 
             FirstName varchar(50),
             LastName varchar(50),
             Age int
           )
         * 
         * CREATE TABLE Address
           (
             AddressId int not null PRIMARY KEY, 
             PersonId int,
             Line1 varchar(50),
             Line2 varchar(50),
             City varchar(50),
             State varchar(50),
             Zip varchar(9)
           )
         */
        protected override string Select_All_Fields_And_Rows_From_Person()
        {
            return "SELECT * FROM PERSON";
        }

        protected override string Select_All_Fields_From_Person_Joined_To_Address()
        {
            return "SELECT * FROM PERSON JOIN ADDRESS ON PERSON.PERSONID = ADDRESS.PERSONID";
        }

        protected override string Select_FirstName_From_Person_Where_LastName_Equals_Rayburn()
        {
            return "SELECT FIRSTNAME FROM PERSON WHERE LASTNAME='Rayburn'";
        }

        protected override string Select_All_Fields_From_Person_Left_Outer_Joined_To_Address()
        {
            return "SELECT * FROM PERSON LEFT OUTER JOIN ADDRESS ON PERSON.PERSONID = ADDRESS.PERSONID";
        }
    }
}
