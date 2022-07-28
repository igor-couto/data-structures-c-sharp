namespace DataStructures.Tests;

using DataStructures.Queue;
using Bogus;

public class QueueTests
{
    private Queue _queue;
    private Faker _faker;

    private void Seed(int count)
    {
        for (var index = 1; index <= count; index++)
            _queue.Enqueue(index);
    }

    private void SeedToCapacity()
    {
        for (var index = 1; index <= _queue.Capacity; index++)
            _queue.Enqueue(index);
    }

    [SetUp]
    public void SetUp()
    {
        _queue = new(5);
        _faker = new();
    }

    [Test]
    public void CreateAsExpected()
    {
        Assert.That(_queue.Capacity, Is.EqualTo(5));
        Assert.That(_queue.Count, Is.EqualTo(0));
        Assert.That(_queue.Dequeue, Is.EqualTo(-1));
        Assert.That(_queue.Peek, Is.EqualTo(-1));
        Assert.That(_queue.IsFull, Is.EqualTo(false));
    }

    [Test]
    public void Enqueue()
    {
        _queue.Enqueue(_faker.Random.Number());
        Assert.That(_queue.Count, Is.EqualTo(1));
    }

    [Test]
    public void EnqueueUntilCapacity()
    {
        SeedToCapacity();

        Assert.That(_queue.Count, Is.EqualTo(5));
        Assert.That(_queue.IsFull, Is.EqualTo(true));
    }

    [Test]
    public void IsFullShouldBeFalse()
    {
        _queue.Enqueue(1);

        Assert.That(_queue.Count, Is.EqualTo(1));
        Assert.That(_queue.IsFull, Is.EqualTo(false));
    }

    [Test]
    public void EnqueueBeyondCapacityShouldSetCountAsExpected()
    {
        SeedToCapacity();
        _queue.Enqueue(6);

        Assert.That(_queue.Count, Is.EqualTo(5));
    }

    [Test]
    public void EnqueuehBeyondCapacityShouldReturnCorrectValue()
    {
        SeedToCapacity();
        _queue.Enqueue(6);

        var lastValue = _queue.Dequeue();

        Assert.That(lastValue, Is.EqualTo(1));
        Assert.That(_queue.Count, Is.EqualTo(4));
    }

    [Test]
    public void EnqueueAndDequeue()
    {
        _queue.Enqueue(1);
        _queue.Enqueue(2);
        _queue.Enqueue(3);

        var value1 = _queue.Dequeue();
        var value2 = _queue.Dequeue();

        _queue.Enqueue(4);
        _queue.Enqueue(5);

        var value3 = _queue.Dequeue();

        _queue.Enqueue(6);

        var value4 = _queue.Dequeue();
        var value5 = _queue.Dequeue();
        var value6 = _queue.Dequeue();

        _queue.Enqueue(7);

        Assert.That(value1, Is.EqualTo(1));
        Assert.That(value2, Is.EqualTo(2));
        Assert.That(value3, Is.EqualTo(3));
        Assert.That(value4, Is.EqualTo(4));
        Assert.That(value5, Is.EqualTo(5));

        Assert.That(_queue.Count, Is.EqualTo(1));
    }


    [Test]
    public void EnqueueAndDequeueAsExpected()
    {
        var value = _faker.Random.Number();
        _queue.Enqueue(value);

        var expectedValue = _queue.Dequeue();

        Assert.That(value, Is.EqualTo(expectedValue));
        Assert.That(_queue.Count, Is.EqualTo(0));
    }

    [Test]
    public void ClearAsExpected()
    {
        SeedToCapacity();

        _queue.Clear();

        Assert.That(_queue.Count, Is.EqualTo(0));
        Assert.That(_queue.Dequeue, Is.EqualTo(-1));
    }

    [TestCase(1)]
    [TestCase(3)]
    [TestCase(5)]
    public void Peek(int count)
    {
        Seed(count);

        var value = _queue.Peek();

        Assert.That(value, Is.EqualTo(1));
        Assert.That(_queue.Count, Is.EqualTo(count));
    }
}