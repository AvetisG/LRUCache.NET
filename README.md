# LRUCache.NET [![Build Status][2]][1]

  [1]: https://ci.appveyor.com/project/AvetisG/lrucache-net
  [2]: https://ci.appveyor.com/api/projects/status/x8kr2fcyk8cv30av?svg=true

Simple LRUCache implementation in C#. Demo project included for easy and convenient testing.

**WARNING:** It is not not thread-safe yet, but will be in the future iterations so please be cautious of that.

If you would like to use a data structure similar to LRU cache that is thread-safe for the time being then please look into [MemoryCache Class](https://msdn.microsoft.com/en-us/library/system.runtime.caching.memorycache%28v=vs.110%29.aspx). You can [read here](http://stackoverflow.com/questions/9653696/default-memory-cache-with-lru-policy) about how to make the MemoryCache behave like an LRU cache.

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
