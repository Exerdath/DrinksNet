using System;
using MongoDB.Driver;
using System.Security.Authentication;

namespace DrinksNet.DAL
{
    public class DataAccessLayer
    {
        private string userName = "barmapp-cosmos";
        private string host = "barmapp-cosmos.documents.azure.com";
        private string password = "AS57Bj4QtVd5HxsTO2CtJEyHlM2Z79N0TVQxgeM5nxao6Onm1MlUGxvgchYVw6eMIBPGjROGmr63YapdQGkHWg==";

        private string dbName = "barmapp-db";
        private bool _disposed = false;
        protected IMongoDatabase _database;

        public DataAccessLayer()
        {
            MongoClientSettings settings = new MongoClientSettings();
            settings.Server = new MongoServerAddress(host, 10255);
            settings.UseTls = true;
            settings.SslSettings = new SslSettings();
            settings.SslSettings.EnabledSslProtocols = SslProtocols.Tls12;
            settings.RetryWrites = false;

            MongoIdentity identity = new MongoInternalIdentity(dbName, userName);
            MongoIdentityEvidence evidence = new PasswordEvidence(password);

            settings.Credential = new MongoCredential("SCRAM-SHA-1", identity, evidence);

            //MongoClient client = new MongoClient("mongodb://barmapp-cosmos:AS57Bj4QtVd5HxsTO2CtJEyHlM2Z79N0TVQxgeM5nxao6Onm1MlUGxvgchYVw6eMIBPGjROGmr63YapdQGkHWg==@barmapp-cosmos.documents.azure.com:10255/?ssl=true&retrywrites=false&replicaSet=globaldb");
            MongoClient client = new MongoClient(settings);
            var database = client.GetDatabase(dbName);
            _database = database;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                }
            }
            this._disposed = true;
        }
    }
}
