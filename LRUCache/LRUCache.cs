using System;
using System.Collections.Generic;
using System.Linq;

namespace LRUCache.Implementation
{
    public class LRUCache<K, V>
    {
        private readonly int _maxCapacity = 0;
        private readonly Dictionary<K, Node<V, K>> _LRUCache;
        private Node<V, K> _head = null;
        private Node<V, K> _tail = null;
        private Action<K, V> _OnRemoveLast;

        public LRUCache(int argMaxCapacity, Action<K, V> onRemoveLastAction)
        {
            _maxCapacity = argMaxCapacity;
            _LRUCache = new Dictionary<K, Node<V, K>>();
            _OnRemoveLast = onRemoveLastAction;
        }
        public void Add(K key, V value)
        {
            if (_LRUCache.ContainsKey(key))
            {
                _LRUCache[key].Data = value;
                MakeMostRecentlyUsed(_LRUCache[key]);
                return;
            }

            if (_LRUCache.Count >= _maxCapacity)
            {
                RemoveLeastRecentlyUsed();
            }

            Node<V, K> insertedNode = new Node<V, K>(value, key);

            if (_head == null)
            {
                _head = insertedNode;
                _tail = _head;
            }
            else
            {
                MakeMostRecentlyUsed(insertedNode);
            }

            _LRUCache.Add(key, insertedNode);
        }
        public Node<V, K> Get(K key)
        {
            if (!_LRUCache.ContainsKey(key)) return null;

            MakeMostRecentlyUsed(_LRUCache[key]);

            return _LRUCache[key];
        }
        public int Size()
        {
            return _LRUCache.Count();
        }
        public string CacheFeed()
        {
            var headReference = _head; 
            
            List<string> items = new List<string>();

            while (headReference != null)
            {
                items.Add(String.Format("[K: {0} V: {1}]", headReference.Key,headReference.Data));
                headReference = headReference.Next;
            }

            return String.Join(",", items);
        }
        private void RemoveLeastRecentlyUsed()
        {
            _LRUCache.Remove(_tail.Key);
            var tmpNode = _tail;
            _tail.Previous.Next = null;
            _tail = _tail.Previous;

            if (null != _OnRemoveLast)
            {
                _OnRemoveLast(tmpNode.Key,tmpNode.Data);
            }
        }
        private void MakeMostRecentlyUsed(Node<V, K> foundItem)
        {
            // Newly inserted item bring to the top
            if (foundItem.Next == null && foundItem.Previous == null)
            {
                foundItem.Next = _head;
                _head.Previous = foundItem;
                if (_head.Next == null) _tail = _head;
                _head = foundItem;
            }
            // If it is the tail than bring it to the top
            else if (foundItem.Next == null && foundItem.Previous != null)
            {
                foundItem.Previous.Next = null;
                _tail = foundItem.Previous;
                foundItem.Next = _head;
                _head.Previous = foundItem;
                _head = foundItem;
            }
            // If it is an element in between than bring it to the top
            else if (foundItem.Next != null && foundItem.Previous != null)
            {
                foundItem.Previous.Next = foundItem.Next;
                foundItem.Next.Previous = foundItem.Previous;
                foundItem.Next = _head;
                _head.Previous = foundItem;
                _head = foundItem;
            }
            // Last case would be to check if it is a head but if it is than there is no need to bring it to the top
        }
    }
}
