using System;

namespace DataStructures;

public class Array : Operations<int, int>
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

    // In all scenarios it will be Θ(1)
    public int Access(int index) => _array[index];

    // In all scenarios it will be Θ(1)
    public void Deletion(int index)
    {
        if (index < _size)
            _array[index] = -1;
    }

    // In all scenarios it will be Θ(1)
    public void Insertion(int index, int value)
    {
        if (index < _size)
            _array[index] = value;
    }

    // Θ(n)
    public int Insertion(int value)
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

    // Θ(n)
    public int Search(int value)
    {
        for (var index = 0; index < _size; index++)
        {
            if (_array[index] == value)
                return index;
        }
        return -1;
    }
}