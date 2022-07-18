namespace tests;

using DataStructures.SinglyLinkedList;
using Bogus;

public class SinglyLinkedListTestsTests
{
    private SinglyLinkedList _singlyLinkedList;
    private Faker _faker;

    [SetUp]
    public void Setup()
    {
        _faker = new Faker();
        _singlyLinkedList = new SinglyLinkedList();
    }

    [Test]
    public void InsertAndAccessFirstValue()
    {
        var value = 3;
        var key = 3;

        _singlyLinkedList.Insert(key, value);

        var actualValue = _singlyLinkedList.Access(key);
        Assert.That(actualValue, Is.EqualTo(value));
    }

    [Test]
    public void InsertAndAccessValue()
    {
        Seed();

        var key = 2;
        var value = 9;
        _singlyLinkedList.Insert(key, value);

        var actualValue = _singlyLinkedList.Access(key);
        Assert.That(actualValue, Is.EqualTo(value));
    }

    [Test]
    public void DeleteValue()
    {
        Seed();

        var value = 6;
        var key = 1;
        _singlyLinkedList.Insert(key, value);

        _singlyLinkedList.Delete(key);

        var actualValue = _singlyLinkedList.Access(key);
        Assert.That(actualValue, Is.EqualTo(null));
    }

    [Test]
    public void SearchValue()
    {
        Seed();

        var value = 6;
        var key = 4;
        _singlyLinkedList.Insert(key, value);

        var actualKey = _singlyLinkedList.Search(value);
        Assert.That(actualKey, Is.EqualTo(key));
    }

    private void Seed()
    {
        var amount = _faker.Random.Number(max: 10);

        for (var key = 0; key < amount; key++)

            _singlyLinkedList.Insert(key, _faker.Random.Number());
    }
}