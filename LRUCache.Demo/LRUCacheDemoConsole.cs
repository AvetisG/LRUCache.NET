using System;
using LRUCache.Implementation;

namespace LRUCache.Demo
{
    class LRUCacheDemoConsole
    {
        static void Main(string[] args)
        {
            LRUCache<int, int> lruCache = new LRUCache<int, int>(5);

            lruCache.Insert(0, 10);
            lruCache.Insert(1, 20);
            lruCache.Insert(2, 30);
            lruCache.Insert(3, 40);
            lruCache.Insert(4, 50);

            Console.WriteLine(lruCache.CacheFeed());

            lruCache.GetItem(0);
            lruCache.GetItem(1);
            lruCache.GetItem(2);

            Console.WriteLine(lruCache.CacheFeed());

            lruCache.Insert(5, 60);
            lruCache.Insert(6, 70);
            lruCache.Insert(7, 80);
            lruCache.Insert(8, 90);
            lruCache.Insert(9, 100);

            Console.WriteLine(lruCache.CacheFeed());
        }
    }
}