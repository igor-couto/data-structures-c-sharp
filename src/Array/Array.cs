namespace DataStructures.Array;

public class Array
{
    private int[] _array;
    private int _size;

    // It`s fixed size, so we need to create the internal array object in the contructor
    // Considering that -1 represent an absence of value
    public Array(int size)
    {
        _array = new int[size];
        _size = size;

        for (var index = 0; index < size; index++)
            _array[index] = -1;
    }

    // O(1)
    public void Insert(int index, int value)
    {
        if (index < _size) _array[index] = value;
    }

    // O(n)
    public int Insert(int value)
    {
        for (var index = 0; index < _size; index++)
        {
            if (_array[index] == -1)
            {
                _array[index] = value;
                return index;
            }
        }
        return -1;
    }

    // O(1)
    public int Access(int index) => _array[index];

    // O(n)
    public int Search(int value)
    {
        for (var index = 0; index < _size; index++)
        {
            if (_array[index] == value)
                return index;
        }
        return -1;
    }

    // O(1)
    public void Delete(int index)
    {
        if (index < _size) _array[index] = -1;
    }

    public void Print()
    {
        for (var index = 0; index < _size; index++)
        {
            Console.WriteLine($"Index: {index}, Value: {_array[index]}");
        }
    }
}