namespace DataStructures.SinglyLinkedList;

public class Node
{
    public int Value { get; set; }
    public Node Next { get; set; }

    public Node(int value) => Value = value;

    public override string ToString()
    {
        unsafe
        {
            var o = new object();
            TypedReference tr = __makeref(o);
            IntPtr ptr = **(IntPtr**)(&tr);

            return $"[Node: {ptr}, Value:{Value} - Next: {Next.Value}]";
        }
    }
}