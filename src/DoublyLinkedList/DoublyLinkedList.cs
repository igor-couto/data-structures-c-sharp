namespace DataStructures.DoublyLinkedList;

public class DoublyLinkedList
{
    private Node _firstNode;
    private Node _lastNode;

    public int Count { get; private set; }

    // Θ(1)
    public Node InsertFirst(int value)
    {
        var newNode = new Node(value);

        InsertFirst(newNode);

        return newNode;
    }

    // Θ(1)
    public void InsertFirst(Node newNode)
    {
        newNode.Next = _firstNode;

        _firstNode = newNode;

        if (_lastNode is null)
            _lastNode = newNode;

        Count++;
    }

    // Θ(1)
    public Node InsertLast(int value)
    {
        var newNode = new Node(value);

        InsertLast(newNode);

        return newNode;
    }

    // Θ(1)
    public void InsertLast(Node newNode)
    {
        if (_lastNode is null)
        {
            _firstNode = newNode;
        }
        else
        {
            newNode.Previous = _lastNode;
            _lastNode.Next = newNode;
        }

        _lastNode = newNode;

        Count++;
    }

    // Θ(1)
    public void InsertAfter(Node node, int value)
    {
        var newNode = new Node(value);
        InsertAfter(node, newNode);
    }

    // Θ(1)
    public void InsertAfter(Node node, Node newNode)
    {
        newNode.Next = node.Next;
        newNode.Previous = node;

        node.Next = newNode;

        Count++;
    }

    // Θ(1)
    public void InsertBefore(Node node, int value)
    {
        var newNode = new Node(value);
        InsertBefore(node, newNode);
    }

    // Θ(1)
    public void InsertBefore(Node node, Node newNode)
    {

        newNode.Next = node;
        newNode.Previous = node.Previous;

        if (node.Previous is not null)
        {
            node.Previous.Next = newNode;
            node.Previous = newNode;
        }

        Count++;
    }

    // Θ(n)
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

    // Θ(n)
    public Node AccessLast(int value)
    {
        var currentNode = _lastNode;
        while (currentNode is not null)
        {
            if (currentNode.Value == value)
                return currentNode;

            currentNode = currentNode.Previous;
        }
        return null;
    }

    // Θ(n)
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

    // Θ(n)
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

    // Θ(1)
    public void Delete(Node nodeToDelete)
    {
        var node = Access(nodeToDelete.Value);

        if (node is null)
            return;

        var previous = node.Previous;
        var next = node.Next;

        if (node.Previous is not null)
            node.Previous.Next = next;

        if (node.Next is not null)
            node.Next.Previous = previous;

        if (node == _firstNode)
            _firstNode = null;

        if (node == _lastNode)
            _lastNode = null;

        Count--;
    }

    //Θ(1)
    public void Delete(int value)
    {
        var node = new Node(value);
        Delete(node);
    }

    // Θ(1)
    public void DeleteFirst()
        => Delete(_firstNode);

    // Θ(1)
    public void DeleteLast()
        => Delete(_lastNode);

    // Θ(n)
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