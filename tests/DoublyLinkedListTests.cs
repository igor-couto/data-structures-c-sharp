namespace Tests;

using DataStructures.DoublyLinkedList;
using Bogus;

public class DoublyLinkedListTests
{
    private DoublyLinkedList _doublyLinkedList;
    private Faker _faker;

    [SetUp]
    public void Setup()
    {
        _faker = new();
        _doublyLinkedList = new();
    }

    private void SeedRandom()
    {
        var amount = _faker.Random.Number(min: 3, max: 100);

        for (var key = 0; key < amount; key++)
            _doublyLinkedList.InsertFirst(_faker.Random.Number());
    }

    private void SeedRandomAmount(int count)
    {
        for (var index = 0; index < count; index++)
            _doublyLinkedList.InsertFirst(_faker.Random.Number());
    }

    private void SeedAmount(int count)
    {
        for (var index = 0; index < count; index++)
            _doublyLinkedList.InsertLast(index);
    }

    [Test]
    public void CreateEmptyDoublyLinkedList()
        => Assert.That(_doublyLinkedList.Count, Is.EqualTo(0));

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(10)]
    public void InsertFirstValueAndAccessValue(int amount)
    {
        var nodes = new Node[amount];

        for (var key = 0; key < amount; key++)
            nodes[key] = _doublyLinkedList.InsertFirst(_faker.Random.Number());

        for (var key = 0; key < amount; key++)
        {
            var actualValue = _doublyLinkedList.Access(nodes[key].Value);
            Assert.That(actualValue.Value, Is.EqualTo(nodes[key].Value));
        }

        Assert.That(_doublyLinkedList.Count, Is.EqualTo(amount));
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(10)]
    public void InserFirstNodeAndAccessValue(int amount)
    {
        var nodes = new Node[amount];

        for (var key = 0; key < amount; key++)
        {
            var node = new Node(_faker.Random.Number());
            _doublyLinkedList.InsertFirst(node);
            nodes[key] = node;
        }

        for (var key = 0; key < amount; key++)
        {
            var actualValue = _doublyLinkedList.Access(nodes[key].Value);
            Assert.That(actualValue.Value, Is.EqualTo(nodes[key].Value));
        }

        Assert.That(_doublyLinkedList.Count, Is.EqualTo(amount));
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(10)]
    [Test]
    public void InsertLastValueAndAccessValue(int amount)
    {
        var nodes = new Node[amount];

        for (var key = 0; key < amount; key++)
            nodes[key] = _doublyLinkedList.InsertLast(_faker.Random.Number());

        for (var key = 0; key < amount; key++)
        {
            var actualValue = _doublyLinkedList.Access(nodes[key].Value);
            Assert.That(actualValue.Value, Is.EqualTo(nodes[key].Value));
        }

        Assert.That(_doublyLinkedList.Count, Is.EqualTo(amount));
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(10)]
    public void InsertLastNodeAndAccessValue(int amount)
    {
        var nodes = new Node[amount];

        for (var key = 0; key < amount; key++)
        {
            var node = new Node(_faker.Random.Number());
            _doublyLinkedList.InsertLast(node);
            nodes[key] = node;
        }

        for (var key = 0; key < amount; key++)
        {
            var actualValue = _doublyLinkedList.Access(nodes[key].Value);
            Assert.That(actualValue.Value, Is.EqualTo(nodes[key].Value));
        }

        Assert.That(_doublyLinkedList.Count, Is.EqualTo(amount));
    }

    [Test]
    public void InsertValueAfter()
    {
        _doublyLinkedList.InsertLast(0);
        var node = _doublyLinkedList.InsertLast(1);
        var lastNode = _doublyLinkedList.InsertLast(2);

        _doublyLinkedList.InsertAfter(node, 99);

        var actualNode = _doublyLinkedList.Access(99);

        Assert.That(node.Next, Is.EqualTo(actualNode));
        Assert.That(actualNode.Next, Is.EqualTo(lastNode));
    }

    [Test]
    public void InsertNodeAfter()
    {
        _doublyLinkedList.InsertLast(0);
        var node = _doublyLinkedList.InsertLast(1);
        var lastNode = _doublyLinkedList.InsertLast(2);

        var actualNode = new Node(99);
        _doublyLinkedList.InsertAfter(node, actualNode);

        Assert.That(node.Next, Is.EqualTo(actualNode));
        Assert.That(actualNode.Next, Is.EqualTo(lastNode));
    }

    [Test]
    public void InsertValueBefore()
    {
        _doublyLinkedList.InsertLast(0);
        var node = _doublyLinkedList.InsertLast(1);
        var lastNode = _doublyLinkedList.InsertLast(2);

        _doublyLinkedList.InsertBefore(lastNode, 99);

        var actualNode = _doublyLinkedList.Access(99);

        Assert.That(node.Next, Is.EqualTo(actualNode));
        Assert.That(actualNode.Next, Is.EqualTo(lastNode));
    }

    [Test]
    public void InsertNodeBefore()
    {
        _doublyLinkedList.InsertLast(0);
        var node = _doublyLinkedList.InsertLast(1);
        var lastNode = _doublyLinkedList.InsertLast(2);

        var actualNode = new Node(99);
        _doublyLinkedList.InsertBefore(lastNode, actualNode);

        Assert.That(node.Next, Is.EqualTo(actualNode));
        Assert.That(actualNode.Next, Is.EqualTo(lastNode));
    }

    [Test]
    public void InsertNodeBeforeFirst()
    {
        var firstNode = _doublyLinkedList.InsertLast(0);
        var node = _doublyLinkedList.InsertLast(1);
        _doublyLinkedList.InsertLast(2);

        var actualNode = new Node(99);
        _doublyLinkedList.InsertBefore(firstNode, actualNode);

        Assert.That(actualNode.Next, Is.EqualTo(firstNode));
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(10)]
    public void IncreaseCount(int count)
    {
        SeedRandomAmount(count);
        Assert.That(_doublyLinkedList.Count, Is.EqualTo(count));
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(10)]
    public void DeleteFirstValue(int count)
    {
        SeedAmount(count);

        _doublyLinkedList.DeleteFirst();

        var actualValue = _doublyLinkedList.Access(0);
        Assert.That(actualValue, Is.EqualTo(null));
        Assert.That(_doublyLinkedList.Count, Is.EqualTo(count - 1));
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(10)]
    public void DeleteLastValue(int count)
    {
        SeedAmount(count);

        _doublyLinkedList.DeleteLast();

        var actualValue = _doublyLinkedList.Access(count - 1);
        Assert.That(actualValue, Is.EqualTo(null));
        Assert.That(_doublyLinkedList.Count, Is.EqualTo(count - 1));
    }

    [Test]
    public void DeleteNode()
    {
        _doublyLinkedList.InsertLast(0);
        var node = _doublyLinkedList.InsertLast(1);
        _doublyLinkedList.InsertLast(2);

        _doublyLinkedList.Delete(node);

        var actualValue = _doublyLinkedList.Access(node.Value);
        Assert.That(actualValue, Is.EqualTo(null));
    }

    [Test]
    public void DeleteShouldDoNothingWhenNodeIsNotFound()
    {
        _doublyLinkedList.InsertLast(0);
        _doublyLinkedList.InsertLast(1);
        _doublyLinkedList.InsertLast(2);

        _doublyLinkedList.Delete(3);

        Assert.That(_doublyLinkedList.Count, Is.EqualTo(3));
    }

    [Test]
    public void ContainsValue()
    {
        SeedAmount(10);

        var value = 6;

        var containsValue = _doublyLinkedList.Contains(value);
        Assert.That(containsValue, Is.EqualTo(true));
    }

    [Test]
    public void ContainsValueAtTheEnd()
    {
        SeedRandom();

        var value = 6;
        _doublyLinkedList.InsertLast(value);

        var containsValue = _doublyLinkedList.Contains(value);
        Assert.That(containsValue, Is.EqualTo(true));
    }

    [Test]
    public void ContainsValueAtTheBeginning()
    {
        SeedRandom();

        var value = 6;
        _doublyLinkedList.InsertFirst(value);

        var containsValue = _doublyLinkedList.Contains(value);
        Assert.That(containsValue, Is.EqualTo(true));
    }

    [Test]
    public void NotContainsValue()
    {
        var value = 6;
        _doublyLinkedList.InsertLast(value);

        var containsValue = _doublyLinkedList.Contains(3);
        Assert.That(containsValue, Is.EqualTo(false));
    }

    [Test]
    public void Search()
    {
        var node = new Node(6);
        _doublyLinkedList.InsertLast(node);

        var actualValue = _doublyLinkedList.Search(6);
        Assert.That(actualValue, Is.EqualTo(node));
    }

    [Test]
    public void SearchNotFound()
    {
        var value = 6;
        _doublyLinkedList.InsertLast(value);

        var actualValue = _doublyLinkedList.Search(3);
        Assert.That(actualValue, Is.EqualTo(null));
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(10)]
    public void Clear(int count)
    {
        SeedRandomAmount(count);

        _doublyLinkedList.Clear();

        Assert.That(_doublyLinkedList.Count, Is.EqualTo(0));
    }

}