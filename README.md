# LRUCache.NET [![Build Status][2]][1]

  [1]: https://ci.appveyor.com/project/AvetisG/lrucache-net
  [2]: https://ci.appveyor.com/api/projects/status/x8kr2fcyk8cv30av?svg=true

Simple LRUCache implementation in C#. Demo project included for easy and convenient testing.

Below is a snippet for a simple usage case:


```C#
LRUCache<int, int> lruCache = new LRUCache<int, int>(5);

Console.WriteLine(lruCache.Size());

lruCache.Insert(0, 10);
lruCache.Insert(1, 20);
lruCache.Insert(2, 30);
lruCache.Insert(3, 40);
lruCache.Insert(4, 50);

Console.WriteLine(lruCache.Size());
Console.WriteLine(lruCache.CacheFeed());

lruCache.GetItem(0);
lruCache.GetItem(1);
lruCache.GetItem(2);

Console.WriteLine(lruCache.Size());
Console.WriteLine(lruCache.CacheFeed());

lruCache.Insert(5, 60);
lruCache.Insert(6, 70);
lruCache.Insert(7, 80);
lruCache.Insert(8, 90);
lruCache.Insert(9, 100);

Console.WriteLine(lruCache.Size());
Console.WriteLine(lruCache.CacheFeed());
