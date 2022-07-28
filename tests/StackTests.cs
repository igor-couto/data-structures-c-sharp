namespace tests;

using DataStructures.Stack;
using Bogus;

public class StackTests
{
    private Stack _stack;
    private Faker _faker;

    private void Seed(int count)
    {
        for (var index = 1; index <= count; index++)
            _stack.Push(index);
    }

    private void SeedToCapacity()
    {
        for (var index = 1; index <= _stack.Capacity; index++)
            _stack.Push(index);
    }

    [SetUp]
    public void Setup()
    {
        _faker = new();
        _stack = new(5);
    }

    [Test]
    public void CreateAsExpected()
    {
        Assert.That(_stack.Capacity, Is.EqualTo(5));
        Assert.That(_stack.Count, Is.EqualTo(0));
        Assert.That(_stack.Pop, Is.EqualTo(-1));
        Assert.That(_stack.Peek, Is.EqualTo(-1));
        Assert.That(_stack.IsFull, Is.EqualTo(false));
    }

    [Test]
    public void Push()
    {
        _stack.Push(_faker.Random.Number());
        Assert.That(_stack.Count, Is.EqualTo(1));
    }

    [Test]
    public void PushUntilCapacity()
    {
        SeedToCapacity();

        Assert.That(_stack.Count, Is.EqualTo(5));
        Assert.That(_stack.IsFull, Is.EqualTo(true));
    }

    [Test]
    public void IsFullShouldBeFalse()
    {
        _stack.Push(1);

        Assert.That(_stack.Count, Is.EqualTo(1));
        Assert.That(_stack.IsFull, Is.EqualTo(false));
    }

    [Test]
    public void PushBeyondCapacityShouldSetCountAsExpected()
    {
        SeedToCapacity();
        _stack.Push(6);

        Assert.That(_stack.Count, Is.EqualTo(5));
    }

    [Test]
    public void PushBeyondCapacityShouldReturnCorrectValue()
    {
        SeedToCapacity();
        _stack.Push(6);

        var lastValue = _stack.Pop();

        Assert.That(lastValue, Is.EqualTo(5));
        Assert.That(_stack.Count, Is.EqualTo(4));
    }

    [Test]
    public void PushAndPopAsExpected()
    {
        var value = _faker.Random.Number();
        _stack.Push(value);

        var expectedValue = _stack.Pop();

        Assert.That(value, Is.EqualTo(expectedValue));
        Assert.That(_stack.Count, Is.EqualTo(0));
    }

    [Test]
    public void PushAndPopAllValues()
    {
        SeedToCapacity();

        var value5 = _stack.Pop();
        var value4 = _stack.Pop();
        var value3 = _stack.Pop();
        var value2 = _stack.Pop();
        var value1 = _stack.Pop();

        Assert.That(value1, Is.EqualTo(1));
        Assert.That(value2, Is.EqualTo(2));
        Assert.That(value3, Is.EqualTo(3));
        Assert.That(value4, Is.EqualTo(4));
        Assert.That(value5, Is.EqualTo(5));

        Assert.That(_stack.Count, Is.EqualTo(0));
    }

    [Test]
    public void ClearAsExpected()
    {
        SeedToCapacity();

        _stack.Clear();

        Assert.That(_stack.Count, Is.EqualTo(0));
        Assert.That(_stack.Pop, Is.EqualTo(-1));
    }

    [TestCase(1)]
    [TestCase(3)]
    [TestCase(5)]
    public void Peek(int count)
    {
        Seed(count);

        var value = _stack.Peek();

        Assert.That(value, Is.EqualTo(count));
        Assert.That(_stack.Count, Is.EqualTo(count));
    }
}