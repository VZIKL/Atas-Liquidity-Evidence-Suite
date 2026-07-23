namespace ATAS.CustomIndicators;

/// <summary>
/// Fixed-size ring buffer for tick data. O(1) add, O(1) window queries.
/// Thread-safe for single-producer scenarios (ATAS tick callbacks are serialized per instrument).
/// </summary>
public class RingBuffer<T>
{
    private readonly T[] _buffer;
    private int _head;
    private int _count;

    public RingBuffer(int capacity)
    {
        if (capacity <= 0)
            throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be positive.");
        _buffer = new T[capacity];
    }

    public int Count => _count;
    public int Capacity => _buffer.Length;

    public void Add(T item)
    {
        _buffer[_head] = item;
        _head = (_head + 1) % Capacity;
        if (_count < Capacity) _count++;
    }

    public IEnumerable<T> GetRecent(int n)
    {
        n = Math.Min(n, _count);
        for (int i = 0; i < n; i++)
        {
            int idx = (_head - n + i + Capacity) % Capacity;
            yield return _buffer[idx];
        }
    }

    public T? MostRecent => _count > 0 ? _buffer[(_head - 1 + Capacity) % Capacity] : default;

    public decimal Sum(Func<T, decimal> selector)
    {
        decimal sum = 0;
        for (int i = 0; i < _count; i++)
            sum += selector(_buffer[i]);
        return sum;
    }

    public decimal Average(Func<T, decimal> selector) =>
        _count > 0 ? Sum(selector) / _count : 0;

    public void Clear() { _head = 0; _count = 0; }
}
