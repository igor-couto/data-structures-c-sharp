namespace tests;

using Array = DataStructures.Array;

public class Tests
{
    private Array _array;

    [SetUp]
    public void Setup() => _array = new Array(5);

    [Test]
    public void InsertValueByIndex()
    {
        var index = 2;
        var value = 3;

        _array.Insertion(index, value);

        var actualValue = _array.Access(index);
        Assert.That(actualValue, Is.EqualTo(value));
    }

    [Test]
    public void InsertValue()
    {
        var value = 3;

        _array.Insertion(value);

        var actualValue = _array.Access(0);
        Assert.That(actualValue, Is.EqualTo(value));
    }

    [Test]
    public void DeleteValue()
    {
        var value = 6;
        var index = 0;
        _array.Insertion(index, value);

        _array.Deletion(index);
        var actualValue = _array.Access(0);

        Assert.That(actualValue, Is.EqualTo(-1));
    }

    [Test]
    public void SearchValue()
    {
        var value = 6;
        var index = 4;
        _array.Insertion(index, value);

        _array.Search(index);
        var actualIndex = _array.Search(value);

        Assert.That(actualIndex, Is.EqualTo(index));
    }
}