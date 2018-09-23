using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Web;
using ISession = Cassandra.ISession;

namespace HotelsBook
{
    public class CassandraConnect
    {
        public ISession Connect()
        {
            Cluster cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
          ISession session = cluster.Connect("hoteldatabase");
            return session;
        }
    }
}