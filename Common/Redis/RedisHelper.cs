using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Redis
{
    public class RedisHelper
    {
        private static IDatabase Instance;
        static RedisHelper()
        {
            var conn = "192.168.190.200:6379";
            Instance = ConnectionMultiplexer.Connect(conn).GetDatabase();
        }

        public static void StringSet(string k, string v)
        {
            Instance.StringSet(k, v);
        }

        public static string StringGet(string k)
        {
            return Instance.StringGet(k);
        }
    }
}
