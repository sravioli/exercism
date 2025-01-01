using System;
using System.Collections.Generic;

public class CircularBuffer<T>(int capacity)
{
    private readonly Queue<T> _queue = new(capacity);

    public T Read()
    {
        if (!_queue.TryPeek(out T item))
        {
            throw new InvalidOperationException("Queue is empty");
        }
        _queue.Dequeue();
        return item;
    }

    public void Write(T value)
    {
        if (_queue.Count == capacity)
        {
            throw new InvalidOperationException("Queue is full");
        }
        _queue.Enqueue(value);
    }

    public void Overwrite(T value)
    {
        if (_queue.Count == capacity)
        {
            _queue.Dequeue();
        }
        _queue.Enqueue(value);
    }

    public void Clear() => _queue.Clear();
}
