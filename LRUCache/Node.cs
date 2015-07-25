namespace LRUCache.Implementation
{
    public class Node<V>
    {
        public V Value { get; private set; }
        public Node<V> Previous { get; set; }
        public Node<V> Next { get; set; }

        public Node(V value)
        {
            Value = value;
        }
    }
}
