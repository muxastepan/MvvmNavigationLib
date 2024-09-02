namespace MvvmNavigationLib.Utilities;

public class StackQueue<T>
{
    private readonly LinkedList<T> _linkedList = new();

    public void Push(T obj)=>_linkedList.AddFirst(obj);

    public void Enqueue(T obj)=>_linkedList.AddFirst(obj);

    public T Pop()
    {
        if (_linkedList.First == null) throw new InvalidOperationException();
        var obj = _linkedList.First.GetValue();
        _linkedList.RemoveFirst();
        return obj;
    }

    public T Dequeue()
    {
        if (_linkedList.Last == null) throw new InvalidOperationException();
        var obj = _linkedList.Last.GetValue();
        _linkedList.RemoveLast();
        return obj;

    }

    public T PeekStack()=>_linkedList.First.GetValue();

    public T PeekQueue()=>_linkedList.Last.GetValue();

    public int Count => _linkedList.Count;
}

public static class LinkedListNodeExtensions
{
    public static T GetValue<T>(this LinkedListNode<T>? node) =>
        node is not null? node.Value : throw new InvalidOperationException("No such value");
}