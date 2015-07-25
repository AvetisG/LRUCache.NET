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

            Console.WriteLine(lruCache.GetItem(0).Value);
            Console.WriteLine(lruCache.GetItem(1).Value);
            Console.WriteLine(lruCache.GetItem(2).Value);

            lruCache.Insert(5, 60);
        }
    }
}