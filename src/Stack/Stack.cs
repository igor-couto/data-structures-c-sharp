namespace DataStructures.Stack;

public class Stack
{
    private int[] _stack;
    public int Capacity { get; private set; }
    public int Count { get; private set; }

    public Stack(int capacity)
    {
        Capacity = capacity;
        _stack = new int[capacity];

        for (var index = 0; index < capacity; index++)
            _stack[index] = -1;
    }

    // Θ(1)
    public void Push(int value)
    {
        if (Count == Capacity)
            return;

        _stack[Count] = value;
        Count++;
    }

    // Θ(1)
    public int Pop()
    {
        if (Count == 0)
            return -1;

        var value = _stack[Count - 1];
        _stack[Count - 1] = -1;

        Count--;
        return value;
    }

    // Θ(1)
    public int Peek()
    {
        if (Count == 0)
            return -1;

        return _stack[Count - 1];
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
            _stack[index] = -1;

        Count = 0;
    }

    // Θ(n)
    public bool Contains(int value)
    {
        for (var index = 0; index < Count; index++)
        {
            if (_stack[index] == value)
                return true;
        }

        return false;
    }
}
