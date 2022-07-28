namespace tests;

using DataStructures.DynamicStack;
using Bogus;

public class DynamicStackTests
{
    private DynamicStack _stack;
    private Faker _faker;

    private void Seed(int count)
    {
        for (var index = 1; index <= count; index++)
            _stack.Push(index);
    }

    [SetUp]
    public void Setup()
    {
        _faker = new();
        _stack = new();
    }

    [Test]
    public void CreateAsExpected()
    {
        Assert.That(_stack.Count, Is.EqualTo(0));
        Assert.That(_stack.Pop, Is.EqualTo(null));
        Assert.That(_stack.Peek, Is.EqualTo(null));
    }

    [Test]
    public void PushOneValue()
    {
        _stack.Push(_faker.Random.Number());
        Assert.That(_stack.Count, Is.EqualTo(1));
    }

    [Test]
    public void PushOneNode()
    {
        _stack.Push(new Node(_faker.Random.Number()));
        Assert.That(_stack.Count, Is.EqualTo(1));
    }

    [Test]
    public void PushAndPopAsExpected()
    {
        var value = _faker.Random.Number();
        _stack.Push(value);

        var expectedNode = _stack.Pop();

        Assert.That(value, Is.EqualTo(expectedNode.Value));
        Assert.That(_stack.Count, Is.EqualTo(0));
    }

    [Test]
    public void PushAndPopValues()
    {
        Seed(5);

        Assert.That(_stack.Count, Is.EqualTo(5));

        var node5 = _stack.Pop();
        var node4 = _stack.Pop();
        var node3 = _stack.Pop();
        var node2 = _stack.Pop();
        var node1 = _stack.Pop();

        Assert.That(node1.Value, Is.EqualTo(1));
        Assert.That(node2.Value, Is.EqualTo(2));
        Assert.That(node3.Value, Is.EqualTo(3));
        Assert.That(node4.Value, Is.EqualTo(4));
        Assert.That(node5.Value, Is.EqualTo(5));

        Assert.That(_stack.Count, Is.EqualTo(0));
    }

    [Test]
    public void ClearAsExpected()
    {
        Seed(5);

        _stack.Clear();

        Assert.That(_stack.Count, Is.EqualTo(0));
        Assert.That(_stack.Pop, Is.EqualTo(null));
    }

    [TestCase(1)]
    [TestCase(3)]
    [TestCase(5)]
    public void Peek(int count)
    {
        Seed(count);

        var node = _stack.Peek();

        Assert.That(node.Value, Is.EqualTo(count));
        Assert.That(_stack.Count, Is.EqualTo(count));
    }
}