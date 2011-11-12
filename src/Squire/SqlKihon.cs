using System;
using NUnit.Framework;
using Squire.Framework;

namespace Squire
{
    //[TestFixture]
    public class SqlKihon : SqlKihonBase
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
            throw new NotImplementedException();
        }

        protected override string Select_All_Fields_From_Person_Joined_To_Address()
        {
            throw new NotImplementedException();
        }

        protected override string Select_FirstName_From_Person_Where_LastName_Equals_Rayburn()
        {
            throw new NotImplementedException();
        }

        protected override string Select_All_Fields_From_Person_Left_Outer_Joined_To_Address()
        {
            throw new NotImplementedException();
        }

        protected override string Insert_PersonId_4_Named_Mike_Johnson_Age_5_To_Person()
        {
            throw new NotImplementedException();
        }

        protected override string Update_All_LastNames_Rayburn_To_Johnson_In_Person()
        {
            throw new NotImplementedException();
        }
    }
}
