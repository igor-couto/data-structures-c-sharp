namespace DataStructures.Queue;

public class Queue
{
    private int[] _queue;
    private int _startIndex;
    public int Capacity { get; private set; }
    public int Count { get; private set; }

    public Queue(int capacity)
    {
        _startIndex = 0;

        Capacity = capacity;
        _queue = new int[capacity];

        for (var index = 0; index < capacity; index++)
            _queue[index] = -1;
    }

    // Θ(1)
    public void Enqueue(int value)
    {
        if (Count == Capacity)
            return;

        _queue[(_startIndex + Count) % Capacity] = value;
        Count++;
    }

    // Θ(1)
    public int Dequeue()
    {
        if (Count == 0)
            return -1;

        var value = _queue[_startIndex];
        _queue[_startIndex] = -1;
        Count--;

        if ((_startIndex + 1) % Capacity != -1)
            _startIndex = (_startIndex + 1) % Capacity;

        return value;
    }

    // Θ(1)
    public int Peek()
    {
        if (Count == 0)
            return -1;

        return _queue[_startIndex];
    }

    // Θ(1)
    public bool IsFull()
    {
        return Count == Capacity;
    }

    // Θ(n)
    public void Clear()
    {
        for (var index = 0; index < Count; index++)
            _queue[index] = -1;

        Count = 0;
        _startIndex = 0;
    }

    // Θ(n)
    public bool Contains(int value)
    {
        for (var index = 0; index < Count; index++)
        {
            if (_queue[index] == value)
                return true;
        }
        return false;
    }
}