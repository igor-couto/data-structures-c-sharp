namespace DataStructures.DynamicStack;

public class Node
{
    public int Value { get; set; }
    public Node Previous { get; set; }

    public Node(int value) => Value = value;

    public override string ToString()
    {
        unsafe
        {
            var o = new object();
            TypedReference tr = __makeref(o);
            IntPtr ptr = **(IntPtr**)(&tr);

            return $"[Node: {ptr}, Value:{Value} - Next: {Previous.Value}]";
        }
    }
}