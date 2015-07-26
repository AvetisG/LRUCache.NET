namespace LRUCache.Implementation
{
    public class Node<D>
    {
        public D Data { get; private set; }
        public Node<D> Previous { get; set; }
        public Node<D> Next { get; set; }

        public Node(D data)
        {
            Data = data;
        }
    }
}
