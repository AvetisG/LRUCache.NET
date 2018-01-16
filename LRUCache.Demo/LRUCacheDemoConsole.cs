using System;
using LRUCache.Implementation;

namespace LRUCache.Demo
{
    class LRUCacheDemoConsole
    {
        static void Main(string[] args)
        {
            LRUCache<int, int> lruCache = new LRUCache<int, int>(5);

            Console.WriteLine(lruCache.Size());

            lruCache.Add(0, 10);
            lruCache.Add(1, 20);
            lruCache.Add(2, 30);
            lruCache.Add(3, 40);
            lruCache.Add(4, 50);

            Console.WriteLine(lruCache.Size());
            Console.WriteLine(lruCache.CacheFeed());

            lruCache.Get(0);
            lruCache.Get(1);
            lruCache.Get(2);

            Console.WriteLine(lruCache.Size());
            Console.WriteLine(lruCache.CacheFeed());

            lruCache.Add(5, 60);
            lruCache.Add(6, 70);
            lruCache.Add(7, 80);
            lruCache.Add(8, 90);
            lruCache.Add(9, 100);
            lruCache.Add(6, 10);

            Console.WriteLine(lruCache.Size());
            Console.WriteLine(lruCache.CacheFeed());
            int a = 0;

        }
    }
}