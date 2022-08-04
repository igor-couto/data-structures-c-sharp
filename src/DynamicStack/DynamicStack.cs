namespace DataStructures.DynamicStack;

public class DynamicStack
{
    private Node _topNode;
    public int Count { get; private set; }

    // O(1)
    public void Push(int value)
    {
        var node = new Node(value);
        Push(node);
    }

    // O(1)
    public void Push(Node node)
    {
        node.Previous = _topNode;

        _topNode = node;

        Count++;
    }

    // O(1)
    public Node Pop()
    {
        var node = _topNode;

        if (_topNode is not null)
        {
            _topNode = _topNode.Previous;
            Count--;
        }

        return node;
    }

    // O(1)
    public Node Peek()
    {
        return _topNode;
    }

    // O(n)
    public void Clear()
    {
        while (_topNode is not null)
            Pop();
    }

    // O(n)
    public bool Contains(int value)
    {
        var currentNode = _topNode;
        while (currentNode is not null)
        {
            if (currentNode.Value == value)
                return true;

            currentNode = currentNode.Previous;
        }

        return false;
    }

    // O(1)
    public bool IsEmpty()
    {
        return Count == 0;
    }
}