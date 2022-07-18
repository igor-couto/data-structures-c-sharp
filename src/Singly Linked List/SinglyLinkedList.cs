namespace DataStructures.SinglyLinkedList;

public class SinglyLinkedList
{
    private Node _firstNode;
    private Node _lastNode;

    // Θ(1)
    public void Insert(int key, int value)
    {
        var newNode = new Node(key, value);

        if (_lastNode is null)
        {
            _lastNode = newNode;
            _firstNode = _lastNode;
        }
        else
        {
            _lastNode.Next = newNode;
            _lastNode = newNode;
        }
    }

    // Θ(n)
    public int? Access(int key)
    {
        var currentNode = _firstNode;
        while (currentNode is not null)
        {
            if (currentNode.Key == key) return currentNode.Value;

            currentNode = currentNode.Next;
        }
        return null;
    }

    // Θ(n)
    public int? Search(int value)
    {
        var currentNode = _firstNode;
        while (currentNode is not null)
        {
            if (currentNode.Value == value) return currentNode.Key;

            currentNode = currentNode.Next;
        }
        return null;
    }

    // Θ(n)
    public void Delete(int key)
    {
        var previousNode = _firstNode;
        var currentNode = _firstNode;
        while (currentNode is not null)
        {
            if (currentNode.Key == key)
            {
                previousNode.Next = currentNode.Next;

                if (currentNode == _firstNode)
                    _firstNode = null;

                if (currentNode == _lastNode)
                    _lastNode = null;

                currentNode = null;
                break;
            }
            previousNode = currentNode;
            currentNode = currentNode.Next;
        }
    }

    public void Print()
    {
        var currentNode = _firstNode;
        while (currentNode is not null)
        {
            Console.WriteLine($"[Key: {currentNode.Key}, Value:{currentNode.Value}]");
            currentNode = currentNode.Next;
        }
        Console.WriteLine();
    }
}

public class Node
{
    public int Key { get; set; }
    public int Value { get; set; }
    public Node Next { get; set; }

    public Node(int key, int value)
    {
        Key = key;
        Value = value;
    }
}