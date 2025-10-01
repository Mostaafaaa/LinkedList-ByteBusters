using CoustomLinkedList;
using MyLinkedList;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        /* 1# Create and Display
        Create a linked list of integers (e.g., 10 → 20 → 30).
        Traverse and print all nodes.
        */
        // creating linked list
        MyLinkedList<int> LinkList = new MyLinkedList<int>();
        Node<int> a = new Node<int>(10);
        Node<int> b = new Node<int>(20);
        Node<int> c = new Node<int>(30);

        LinkList.AddFirst(a);
        LinkList.AddLast(b);
        LinkList.AddLast(c);
        Console.WriteLine("------1------");
        LinkList.Print();

        /* 2# Count Nodes
       Write a function to count how many nodes are in the linked list.
       */
        Console.WriteLine("------2------");
        Console.WriteLine("Number of Nodes in the Linked List : " + LinkList.Count);
        /* 3# Search an Element
         Search for a given value (e.g., 25) inside the linked list and return its position.
        */
        Console.WriteLine("------3------");
        int target = LinkList.Find(20);
        if (target != null)
            Console.WriteLine("Found At Position: " + target);
        else
            Console.WriteLine("TArget Not Found");
        // 4# Insert at Beginning
        Console.WriteLine("------4------");
        Node<int> d = new Node<int>(500);
        LinkList.AddFirst(d);
        LinkList.Print();
        //5# Insert at End
        Console.WriteLine("------5------");
        Node<int> e = new Node<int>(910);
        LinkList.AddLast(e);
        LinkList.Print();
        /*6# Insert at Position
        Insert a new node at a specific position(e.g., 3rd position).
        */
        Console.WriteLine("------6------");
        Node<int> f = new Node<int>(333);
        Console.WriteLine("add after c");
        LinkList.AddAfter(f, c);
        LinkList.Print();
        //7# Delete First Node
        Console.WriteLine("------7------");
        LinkList.RemoveFirst();
        LinkList.Print();
        //8# Delete First Node
        Console.WriteLine("------8------");
        LinkList.Remove(LinkList.Last);
        LinkList.Print();
        //9# Reverse Linked List
        //Reverse the linked list so that head becomes tail.
        Console.WriteLine("------9------");
        LinkList.Reverse();
        LinkList.Print();
        /*10# Find Middle Node
        Find and print the middle element of the linked list.*/
        Console.WriteLine("------10------");
        LinkList.AddFirst(e);
        LinkList.Print();
        Node<int> middle = LinkList.FindMiddle();
        Console.WriteLine("The Middle elemengt is : " + middle.Data);

        //12# Check if Empty
        // already done

        // 13# Sort Numbers
        Console.WriteLine("------13------");
        int[] numbers = { 5, 2, 9, 1, 7 };
        SortAndArray.SelectionSort(numbers);
        Console.WriteLine("Sorted Numbers");
        SortAndArray.PrintArray(numbers);

        // 14# Sort Floating-Point Numbers
        Console.WriteLine("------14------");
        double[] decimals = { 3.2, 1.5, 4.7, 2.8 };
        SortAndArray.SelectionSort(decimals);
        Console.WriteLine("Sorted Decimals");
        SortAndArray.PrintArray(decimals);
        // 15# Sort Characters
        Console.WriteLine("------15------");
        char[] chars = { 'z', 'b', 'a', 'c' };
        SortAndArray.SelectionSort(chars);
        Console.WriteLine("Sorted Characters");
        SortAndArray.PrintArray(chars);

        // 16# Sort Names Alphabetically
        Console.WriteLine("------16------");
        string[] names = { "Ali", "Sara", "Zain", "Maryam" };
        SortAndArray.SelectionSort(names);
        Console.WriteLine("Sorted Names");
        SortAndArray.PrintArray(names);

        // 17# Sort Exam Scores
        Console.WriteLine("------17------");
        int[] scores = { 88, 45, 92, 60, 74 };
        SortAndArray.SelectionSort(scores);
        Console.WriteLine("Sorted Exam Scores");
        SortAndArray.PrintArray(scores);

        // 18# Sort Grocery Prices
        Console.WriteLine("------18------");
        int[] prices = { 12, 4, 19, 3, 7 };
        SortAndArray.SelectionSort(prices);
        Console.WriteLine("Sorted Grocery Prices");
        SortAndArray.PrintArray(prices);

        // 19# Sort Temperatures
        Console.WriteLine("------19------");
        int[] temps = { 32, 29, 35, 28, 30 };
        SortAndArray.SelectionSort(temps);
        Console.WriteLine("Sorted Temperatures");
        SortAndArray.PrintArray(temps);
    }
}
