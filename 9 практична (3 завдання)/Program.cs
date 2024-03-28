using System;

public class ArrayQueue
{

    private string[] queueArray;
    private int front; // Індекс першого елемента в черзі
    private int rear; // Індекс останнього елемента в черзі
    private int capacity; // Максимальний розмір черги

    public ArrayQueue(int initialCapacity)
    {
        capacity = initialCapacity;
        queueArray = new string[capacity];
        front = 0;
        rear = -1;
    }

    public void Put(string item)
    {
        if (rear == capacity - 1)
        {
            // Якщо масив переповнений, збільшити його розмір
            ResizeQueue();
        }
        queueArray[++rear] = item;
    }

    public string Get()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty");
        }
        return queueArray[front++];
    }

    public int Size()
    {
        return rear - front + 1;
    }

    public string Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty");
        }
        string item = queueArray[front];
        front++;
        return item;
    }

    public bool IsEmpty()
    {
        return front > rear;
    }

    private void ResizeQueue()
    {
        int newCapacity = capacity * 2;
        string[] newQueue = new string[newCapacity];
        Array.Copy(queueArray, front, newQueue, 0, Size());
        queueArray = newQueue;
        capacity = newCapacity;
        rear = Size() - 1;
        front = 0;
    }
}

class Program
{
    static void Main(string[] args)
        
    {
       
        ArrayQueue queue = new ArrayQueue(5);
        queue.Put("One");
        queue.Put("Two");
        queue.Put("Three");
        queue.Put("Four");
        queue.Put("Five");

        Console.WriteLine("Загальний розмiр: " + queue.Size());
        while (!queue.IsEmpty())
        {
            Console.WriteLine("Вилучений елемент: " + queue.Dequeue());
        }

        Console.WriteLine("Розмiр черги пiсля вилучення з черги:: " + queue.Size());
    }
}
