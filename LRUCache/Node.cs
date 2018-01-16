namespace LRUCache.Implementation
{
    public class Node<D, K>
    {
        public D Data { get; set; }
        public K Key { get; private set; }
        public Node<D, K> Previous { get; set; }
        public Node<D, K> Next { get; set; }

        public Node(D data, K key)
        {
            Data = data;
            Key = key;
        }
    }
}
