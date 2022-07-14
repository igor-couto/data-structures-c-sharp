namespace DataStructures;

public interface Operations<K, V>
{
    public V Access(K key);
    public K Search(V value);
    public void Insertion(K key, V value);
    public void Deletion(K key);
}