﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mango.NodisClient.Test
{
    [TestClass]
    public class UnitTest
    {
        private string zkAddr;
        private int zkSessionTimeout;
        private string zkProxyDir;
        private ZooKeeperHelper zkhelper;
        public UnitTest()
        {
            zkAddr = "localhost:20000";
            zkSessionTimeout = 5000;
            zkProxyDir = "mango";
        }

        [TestMethod]
        public void TestMethod1()
        {
            zkhelper = new ZooKeeperHelper(zkAddr, zkProxyDir, zkSessionTimeout,
               (nodes) =>
               {
                   foreach (var item in nodes)
                   {
                       Console.WriteLine($"新增节点：{item.Addr}");
                   }
               },
               (nodes) =>
               {
                   foreach (var item in nodes)
                   {
                       Console.WriteLine($"删除节点：{item.Addr}");
                   }
               });

            var pools = zkhelper.pools;

        }
    }
}
