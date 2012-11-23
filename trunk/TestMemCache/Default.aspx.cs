using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Enyim.Caching;
using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached;

namespace TestMemCache
{
    public partial class Default : System.Web.UI.Page
    {
        private static MemcachedClient _instant;
        public static MemcachedClient Client
        {
            get { return _instant ?? (_instant = new MemcachedClient()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Client.Store(StoreMode.Set, "CurrentTime", DateTime.Now);
            var value = Client.Get("CurrentTime");
            var o = (DateTime) value;
            //var mcc = new MemcachedClientConfiguration();
            //mcc.AddServer("127.0.0.1",11211);
            //mcc.Protocol = MemcachedProtocol.Text;
            //mcc.SocketPool.ReceiveTimeout = new TimeSpan(0, 0, 10);
            //mcc.SocketPool.ConnectionTimeout = new TimeSpan(0, 0, 10);
            //mcc.SocketPool.DeadTimeout = new TimeSpan(0, 0, 20);
            //var mc = new MemcachedClient(mcc);
            //mc.Store(StoreMode.Add, "enyimtest", "test value");
            //Console.WriteLine(mc.Get<string>("enyimtest"));
        }
    }
}