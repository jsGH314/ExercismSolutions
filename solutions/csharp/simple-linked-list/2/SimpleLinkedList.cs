using System;
using System.Collections;
using System.Collections.Generic;

public class SimpleLinkedList<T> : IEnumerable<T>
{    
    //First, we need to create our Node class
    private class Node
    {
        //Next points to next node in list, Data holds our data!
        public Node Next {get; set;}
        public T Data {get; set;}
    }
    //Count cannot be changed from outside
    public int Count {get; private set;}
    //Head is basically the "first" node in the linked list
    private Node head;
    
    public SimpleLinkedList(params T[] values)
    {
        foreach(T value in values)
            Push(value);
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node current = this.head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }
    
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
    //"Add First"
    public void Push(T value)
    {
        Node toAdd = new Node();
        
        toAdd.Data = value;
        toAdd.Next = this.head;

        this.head = toAdd;
        this.Count++;
    }

    public T Pop()
    {
        if (this.head == null ) throw new InvalidOperationException();

        Node tempHead = this.head;
        this.head = tempHead.Next;

        this.Count--;

        return (T)tempHead.Data;
    }
}

