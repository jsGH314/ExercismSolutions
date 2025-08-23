/*
Introduction

You work for a music streaming company.

You've been tasked with creating a playlist feature for your music player application.
Instructions

Write a prototype of the music player application.

For the prototype, each song will simply be represented by a number. Given a range of numbers (the song IDs), create a singly linked list.

Given a singly linked list, you should be able to reverse the list to play the songs in the opposite order.

This exercise requires you to create a linked list data structure which can be iterated.

    Implement the Count property - it should not be possible to change its value from the outside
    Implement the Push(T value) method that adds a value to the list at its head.
    Implement the Pop() method which removes and returns a value from the head.
    Add a constructor to allow initialisation with a single value, or with an interable
    Implement the IEnumerable<T> interface. For more information, see this page.
    Ensure Reverse() method is available.
*/

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

