namespace DataStructures.SinglyLinkedList;

public class SinglyLinkedList
{
    private Node _firstNode;
    private Node _lastNode;

    public int Count { get; private set; }

    // O(1)
    public Node InsertFirst(int value)
    {
        var newNode = new Node(value);

        InsertFirst(newNode);

        return newNode;
    }

    // O(1)
    public void InsertFirst(Node newNode)
    {
        newNode.Next = _firstNode;

        _firstNode = newNode;

        if (_lastNode is null)
            _lastNode = newNode;

        Count++;
    }

    // O(1)
    public Node InsertLast(int value)
    {
        var newNode = new Node(value);

        InsertLast(newNode);

        return newNode;
    }

    // O(1)
    public void InsertLast(Node newNode)
    {
        if (_lastNode is null)
            _firstNode = newNode;
        else
            _lastNode.Next = newNode;

        _lastNode = newNode;

        Count++;
    }

    // O(1)
    public void InsertAfter(Node node, int value)
    {
        var newNode = new Node(value);
        InsertAfter(node, newNode);
    }

    // O(1)
    public void InsertAfter(Node node, Node newNode)
    {
        newNode.Next = node.Next;
        node.Next = newNode;

        Count++;
    }

    // O(n)
    public void InsertBefore(Node node, int value)
    {
        var newNode = new Node(value);
        InsertBefore(node, newNode);
    }

    // O(n)
    public void InsertBefore(Node node, Node newNode)
    {
        var currentNode = _firstNode;
        while (currentNode is not null)
        {
            if (currentNode.Next == node)
                currentNode.Next = newNode;

            currentNode = currentNode.Next;
        }

        newNode.Next = node;
        Count++;
    }

    // O(n)
    public Node Access(int value)
    {
        var currentNode = _firstNode;
        while (currentNode is not null)
        {
            if (currentNode.Value == value)
                return currentNode;

            currentNode = currentNode.Next;
        }
        return null;
    }

    // O(n)
    public Node AccessLast(int value)
    {
        Node lastNode = null;

        var currentNode = _firstNode;
        while (currentNode is not null)
        {
            if (currentNode.Value == value)
                lastNode = currentNode;

            currentNode = currentNode.Next;
        }
        return lastNode;
    }

    // O(n)
    public bool Contains(int value)
    {
        var currentNode = _firstNode;
        while (currentNode is not null)
        {
            if (currentNode.Value == value)
                return true;

            currentNode = currentNode.Next;
        }
        return false;
    }

    // O(n)
    public Node Search(int value)
    {
        var currentNode = _firstNode;
        while (currentNode is not null)
        {
            if (currentNode.Value == value) return currentNode;

            currentNode = currentNode.Next;
        }
        return null;
    }

    // O(n)
    public void Delete(Node node)
    {
        var previousNode = _firstNode;
        var currentNode = _firstNode;
        while (currentNode is not null)
        {
            if (currentNode == node)
            {
                previousNode.Next = currentNode.Next;

                if (currentNode == _firstNode)
                    _firstNode = null;

                if (currentNode == _lastNode)
                    _lastNode = null;

                currentNode = null;
                Count--;
                break;
            }
            currentNode = currentNode.Next;
        }
    }

    // O(n)
    public void Delete(int value)
    {
        var node = new Node(value);
        Delete(node);
    }

    // O(n)
    public void DeleteFirst()
        => Delete(_firstNode);

    // O(n)
    public void DeleteLast()
        => Delete(_lastNode);

    // O(n)
    public void Clear()
    {
        var currentNode = _firstNode;
        while (currentNode is not null)
        {
            var next = currentNode.Next;
            currentNode.Next = null;
            currentNode = next;
        }

        _firstNode = null;
        _lastNode = null;
        Count = 0;
    }

    public void Print()
    {
        var currentNode = _firstNode;
        while (currentNode is not null)
        {
            Console.WriteLine(currentNode);
            currentNode = currentNode.Next;
        }
    }
}