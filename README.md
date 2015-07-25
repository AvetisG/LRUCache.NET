# LRUCache.NET

This is my implementation of LRUCache in C# along with a demo project so that you can download it and start playing around with it right away. 

I will be adding more and more things to it as the times goes by and you should too so don't be a stranger :)

Below is a snippet for a simple usage case:

`
LRUCache<int, int> lruCache = new LRUCache<int, int>(5);

lruCache.Insert(0, 10);
lruCache.Insert(1, 20);
lruCache.Insert(2, 30);
lruCache.Insert(3, 40);
lruCache.Insert(4, 50);

var item = lruCache.GetItem(0).Value;
`
