using System;
using System.Transactions;
using System.Data.SQLite;
using System.Text;
using System.Data;
using NUnit.Framework;

namespace Squire.Framework
{

    [TestFixture]
    public abstract class BaseDataKihon : BaseKihon, IDisposable
    {
        protected SQLiteConnection dbConn;
        protected TransactionScope trans;

        protected abstract void CreateTestData(SQLiteConnection dbConn);

        protected override void BeforeEachTest()
        {
            trans = new TransactionScope();
            dbConn = new SQLiteConnection("Data Source=kihon.db3");
            dbConn.Open();

            CreateTestData(dbConn);

            base.BeforeEachTest();
        }

        protected override void AfterEachTest()
        {
            base.AfterEachTest();

            trans.Dispose();
            trans = null;

            (dbConn as IDisposable).Dispose();
            dbConn = null;
        }

        public void Dispose()
        {
            if (trans != null) trans.Dispose();
            if (dbConn != null) dbConn.Dispose();
        }
    }
}
