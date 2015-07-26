using System;
using System.Collections.Generic;
using System.Linq;

namespace LRUCache.Implementation
{
    public class LRUCache<K, V>
    {
        private readonly int _maxCapacity = 0;
        private readonly Dictionary<K, Node<V>> _LRUCache;
        private Node<V> head = null;
        private Node<V> tail = null; 

        public LRUCache(int argMaxCapacity)
        {
            _maxCapacity = argMaxCapacity;
            _LRUCache = new Dictionary<K, Node<V>>();
        }

        public void Insert(K key, V value)
        {
            if (_LRUCache.ContainsKey(key))
            {
                Node<V> foundItem = _LRUCache.FirstOrDefault(l => l.Key.Equals(key)).Value;
                MakeMostRecentlyUsed(foundItem);
            }

            if (_LRUCache.Count >= _maxCapacity) RemoveLeastRecentlyUsed();

            Node<V> insertedNode = new Node<V>(value);

            if (head == null)
            {
                head = insertedNode;
                tail = head;
            }
            else MakeMostRecentlyUsed(insertedNode);

            _LRUCache.Add(key, insertedNode);
        }

        public Node<V> GetItem(K key)
        {
            if (!_LRUCache.ContainsKey(key)) return null;
            
            Node<V> foundItem = _LRUCache.FirstOrDefault(l => l.Key.Equals(key)).Value;

            MakeMostRecentlyUsed(foundItem);

            return foundItem;
        }

        public int Size()
        {
            return _LRUCache.Count();
        }

        public string CacheFeed()
        {
            var headReference = head; 
            
            List<string> items = new List<string>();

            while (headReference != null)
            {
                items.Add(String.Format("[V: {0}]", headReference.Data));
                headReference = headReference.Next;
            }

            return String.Join(",", items);
        }

        private void RemoveLeastRecentlyUsed()
        {
            var key = _LRUCache.FirstOrDefault(l => l.Value.Equals(tail)).Key;

            _LRUCache.Remove(key);

            tail.Previous.Next = null;
            tail = tail.Previous;
        }

        private void MakeMostRecentlyUsed(Node<V> foundItem)
        {
            // Newly inserted item bring to the top
            if (foundItem.Next == null && foundItem.Previous == null)
            {
                foundItem.Next = head;
                head.Previous = foundItem;
                if (head.Next == null) tail = head;
                head = foundItem;
            }
            // If it is the tail than bring it to the top
            else if (foundItem.Next == null && foundItem.Previous != null)
            {
                foundItem.Previous.Next = null;
                tail = foundItem.Previous;
                foundItem.Next = head;
                head.Previous = foundItem;
                head = foundItem;
            }
            // If it is an element in between than bring it to the top
            else if (foundItem.Next != null && foundItem.Previous != null)
            {
                foundItem.Previous.Next = foundItem.Next;
                foundItem.Next.Previous = foundItem.Previous;
                foundItem.Next = head;
                head.Previous = foundItem;
                head = foundItem;
            }
            // Last case would be to check if it is a head but if it is than there is no need to bring it to the top
        }
    }
}
