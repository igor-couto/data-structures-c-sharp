namespace tests;

using DataStructures.SinglyLinkedList;
using Bogus;

public class SinglyLinkedListTests
{
    private SinglyLinkedList _singlyLinkedList;
    private Faker _faker;

    private void SeedRandom()
    {
        var amount = _faker.Random.Number(min: 3, max: 100);

        for (var key = 0; key < amount; key++)
            _singlyLinkedList.InsertFirst(_faker.Random.Number());
    }

    private void SeedRandomAmount(int count)
    {
        for (var index = 0; index < count; index++)
            _singlyLinkedList.InsertFirst(_faker.Random.Number());
    }

    private void SeedAmount(int count)
    {
        for (var index = 0; index < count; index++)
            _singlyLinkedList.InsertLast(index);
    }

    [SetUp]
    public void Setup()
    {
        _faker = new();
        _singlyLinkedList = new();
    }

    [Test]
    public void CreateEmptySinglyLinkedList()
        => Assert.That(_singlyLinkedList.Count, Is.EqualTo(0));

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(10)]
    public void InsertFirstValueAndAccessValue(int amount)
    {
        var nodes = new Node[amount];

        for (var key = 0; key < amount; key++)
            nodes[key] = _singlyLinkedList.InsertFirst(_faker.Random.Number());

        for (var key = 0; key < amount; key++)
        {
            var actualValue = _singlyLinkedList.Access(nodes[key].Value);
            Assert.That(actualValue.Value, Is.EqualTo(nodes[key].Value));
        }

        Assert.That(_singlyLinkedList.Count, Is.EqualTo(amount));
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
            _singlyLinkedList.InsertFirst(node);
            nodes[key] = node;
        }

        for (var key = 0; key < amount; key++)
        {
            var actualValue = _singlyLinkedList.Access(nodes[key].Value);
            Assert.That(actualValue.Value, Is.EqualTo(nodes[key].Value));
        }

        Assert.That(_singlyLinkedList.Count, Is.EqualTo(amount));
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(10)]
    [Test]
    public void InsertLastValueAndAccessValue(int amount)
    {
        var nodes = new Node[amount];

        for (var key = 0; key < amount; key++)
            nodes[key] = _singlyLinkedList.InsertLast(_faker.Random.Number());

        for (var key = 0; key < amount; key++)
        {
            var actualValue = _singlyLinkedList.Access(nodes[key].Value);
            Assert.That(actualValue.Value, Is.EqualTo(nodes[key].Value));
        }

        Assert.That(_singlyLinkedList.Count, Is.EqualTo(amount));
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
            _singlyLinkedList.InsertLast(node);
            nodes[key] = node;
        }

        for (var key = 0; key < amount; key++)
        {
            var actualValue = _singlyLinkedList.Access(nodes[key].Value);
            Assert.That(actualValue.Value, Is.EqualTo(nodes[key].Value));
        }

        Assert.That(_singlyLinkedList.Count, Is.EqualTo(amount));
    }

    [Test]
    public void InsertValueAfter()
    {
        _singlyLinkedList.InsertLast(0);
        var node = _singlyLinkedList.InsertLast(1);
        var lastNode = _singlyLinkedList.InsertLast(2);

        _singlyLinkedList.InsertAfter(node, 99);

        var actualNode = _singlyLinkedList.Access(99);

        Assert.That(node.Next, Is.EqualTo(actualNode));
        Assert.That(actualNode.Next, Is.EqualTo(lastNode));
    }

    [Test]
    public void InsertNodeAfter()
    {
        _singlyLinkedList.InsertLast(0);
        var node = _singlyLinkedList.InsertLast(1);
        var lastNode = _singlyLinkedList.InsertLast(2);

        var actualNode = new Node(99);
        _singlyLinkedList.InsertAfter(node, actualNode);

        Assert.That(node.Next, Is.EqualTo(actualNode));
        Assert.That(actualNode.Next, Is.EqualTo(lastNode));
    }

    [Test]
    public void InsertNodeAfterLast()
    {
        _singlyLinkedList.InsertLast(0);
        _singlyLinkedList.InsertLast(1);
        var node = _singlyLinkedList.InsertLast(2);

        var actualNode = new Node(99);
        _singlyLinkedList.InsertAfter(node, actualNode);

        Assert.That(node.Next, Is.EqualTo(actualNode));
        Assert.That(actualNode.Next, Is.EqualTo(null));
    }

    [Test]
    public void InsertValueBefore()
    {
        _singlyLinkedList.InsertLast(0);
        var node = _singlyLinkedList.InsertLast(1);
        var lastNode = _singlyLinkedList.InsertLast(2);

        _singlyLinkedList.InsertBefore(lastNode, 99);

        var actualNode = _singlyLinkedList.Access(99);

        Assert.That(node.Next, Is.EqualTo(actualNode));
        Assert.That(actualNode.Next, Is.EqualTo(lastNode));
    }

    [Test]
    public void InsertNodeBefore()
    {
        _singlyLinkedList.InsertLast(0);
        var node = _singlyLinkedList.InsertLast(1);
        var lastNode = _singlyLinkedList.InsertLast(2);

        var actualNode = new Node(99);
        _singlyLinkedList.InsertBefore(lastNode, actualNode);

        Assert.That(node.Next, Is.EqualTo(actualNode));
        Assert.That(actualNode.Next, Is.EqualTo(lastNode));
    }

    [Test]
    public void InsertNodeBeforeFirst()
    {
        var firstNode = _singlyLinkedList.InsertLast(0);
        var node = _singlyLinkedList.InsertLast(1);
        _singlyLinkedList.InsertLast(2);

        var actualNode = new Node(99);
        _singlyLinkedList.InsertBefore(firstNode, actualNode);

        Assert.That(actualNode.Next, Is.EqualTo(firstNode));
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(10)]
    public void IncreaseCount(int count)
    {
        SeedRandomAmount(count);
        Assert.That(_singlyLinkedList.Count, Is.EqualTo(count));
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(10)]
    public void DeleteFirstValue(int count)
    {
        SeedAmount(count);

        _singlyLinkedList.DeleteFirst();

        var actualValue = _singlyLinkedList.Access(0);
        Assert.That(actualValue, Is.EqualTo(null));
        Assert.That(_singlyLinkedList.Count, Is.EqualTo(count - 1));
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(10)]
    public void DeleteLastValue(int count)
    {
        SeedAmount(count);

        _singlyLinkedList.DeleteLast();

        var actualValue = _singlyLinkedList.Access(count - 1);
        Assert.That(actualValue, Is.EqualTo(null));
        Assert.That(_singlyLinkedList.Count, Is.EqualTo(count - 1));
    }

    [Test]
    public void DeleteNode()
    {
        _singlyLinkedList.InsertLast(0);
        var node = _singlyLinkedList.InsertLast(1);
        _singlyLinkedList.InsertLast(2);

        _singlyLinkedList.Delete(node);

        var actualValue = _singlyLinkedList.Access(node.Value);
        Assert.That(actualValue, Is.EqualTo(null));
    }

    [Test]
    public void DeleteShouldDoNothingWhenNodeIsNotFound()
    {
        _singlyLinkedList.InsertLast(0);
        _singlyLinkedList.InsertLast(1);
        _singlyLinkedList.InsertLast(2);

        _singlyLinkedList.Delete(3);

        Assert.That(_singlyLinkedList.Count, Is.EqualTo(3));
    }

    [Test]
    public void ContainsValue()
    {
        SeedAmount(10);

        var value = 6;

        var containsValue = _singlyLinkedList.Contains(value);
        Assert.That(containsValue, Is.EqualTo(true));
    }

    [Test]
    public void ContainsValueAtTheEnd()
    {
        SeedRandom();

        var value = 6;
        _singlyLinkedList.InsertLast(value);

        var containsValue = _singlyLinkedList.Contains(value);
        Assert.That(containsValue, Is.EqualTo(true));
    }

    [Test]
    public void ContainsValueAtTheBeginning()
    {
        SeedRandom();

        var value = 6;
        _singlyLinkedList.InsertFirst(value);

        var containsValue = _singlyLinkedList.Contains(value);
        Assert.That(containsValue, Is.EqualTo(true));
    }

    [Test]
    public void NotContainsValue()
    {
        var value = 6;
        _singlyLinkedList.InsertLast(value);

        var containsValue = _singlyLinkedList.Contains(3);
        Assert.That(containsValue, Is.EqualTo(false));
    }

    [Test]
    public void Search()
    {
        var node = new Node(6);
        _singlyLinkedList.InsertLast(node);

        var actualValue = _singlyLinkedList.Search(6);
        Assert.That(actualValue, Is.EqualTo(node));
    }

    [Test]
    public void SearchNotFound()
    {
        var value = 6;
        _singlyLinkedList.InsertLast(value);

        var actualValue = _singlyLinkedList.Search(3);
        Assert.That(actualValue, Is.EqualTo(null));
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(10)]
    public void Clear(int count)
    {
        SeedRandomAmount(count);

        _singlyLinkedList.Clear();

        Assert.That(_singlyLinkedList.Count, Is.EqualTo(0));
    }
}