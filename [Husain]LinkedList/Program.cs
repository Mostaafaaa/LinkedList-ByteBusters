using System.Collections.Generic;
using System.Xml;

namespace LinkedList;
public class Node
{
    public int Data { get; set; }
    public Node Next { get; set; }

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}
public class LinkedList
{

    public Node Head { get; set; }
    public Node Tail { get; set; }
    public int count  { get; set; }
    public void AddToLinkedList(int data)
    {
        if (count == null)
        {
            count = 0;
        }
        //  counting nodes

        count++;

        //  adding nodes if head doesnt exist we add it to the Head

        var NewNode = new Node(data);
        if (Head == null)
        {
            Head = NewNode;
            Tail = NewNode;
            return;
        }

        Node CurrentNode = Head;

        //  this loop is to search through the LinkedList for the last node or the trail
        //  when this loop breaks, the current node is the last node with value
        //  and we give the node that is after it the NewNode value

        while (CurrentNode.Next is not null)
        {
            CurrentNode = CurrentNode.Next;
        }
        CurrentNode.Next = NewNode;
        Tail = CurrentNode.Next;  
    }

    //  show all the node that are in the linked node
    public void DisplayElements()
    {
        Node CurrentNode = Head;
        Console.WriteLine("Linked List Elements:");
        while (CurrentNode.Next is not null)
        {
            Console.Write($"{CurrentNode.Data} -> ");
            CurrentNode = CurrentNode.Next;
        }
        Console.WriteLine(CurrentNode.Data);


    }

    //  Search an Element
    //  we ask nodes one by one "are you the Element" unit we find it
    //  by using first giving the head value to current node then
    //  use while (current node is not null) to search for the node

    public void SearchAnElement(int data,out int PositionElement)
    {
        Node CurrentNode = Head;

        PositionElement = 0;

        while (CurrentNode is not null)
        {
            if (data == CurrentNode.Data)
                return;
            CurrentNode = CurrentNode.Next;
            PositionElement++;
            
        }
        PositionElement = -1;
    }


    //  to insert at Beginning is by first we store the old head into var called 
    //  temperary head 2nd we make a new node and its next node will be the old head
    public void InsertAtBeginning(int data)
    {
        if (count == null)
        {
            count = 0;
        }
        //  counting nodes

        count++;
        //  temperary head
        var TemperaryHead = Head;
        
        //  new node for the new head
        Node NewNode = new Node(data);
        Head = NewNode;

        //  attach the next of head to the old head
        Head.Next = TemperaryHead;
        if (Tail is null)
        {
            Tail = TemperaryHead;
        }
    }



    //  we can insert an element anywhere at Header or at tailer or in between but not out of this range
    public void InsertAtPosition(int data, int position)
    {
        if (count == null)
        {
            count = 0;
        }
        //  counting nodes

        count++;

        //  new node
        var NewNode = new Node(data);


        //  if out of range break
        if (position > count - 1)
        {
            Console.WriteLine($"out of range indexes are between 0 and {count - 1}");
            return;
        }

        //  otherwise 1. we find the position on the list by counting node by node  
        //  2. chenge the next of previous node but no before saving the value to a var called shifted node
        //  to my new node and make its next (for NewNode) to the node that shifted right


        
        var CurrentNode = Head;
        int NodeIndex = 0;
        while (CurrentNode is not null)
        {
            if (position-1 == NodeIndex)        //  -1 position is to get previous node
            {
                var ShiftedNode = CurrentNode.Next;
                CurrentNode.Next = NewNode;
                NewNode.Next = ShiftedNode;

                return;
            }
            CurrentNode = CurrentNode.Next;
            NodeIndex++;
        }


    }

    //  we can use the head to find the first element of the List then make the next of it the new head then
    //  delete the prev head

    //  to delete the first node we do the following
    public void DeleteFirstNode()
    {
        //  counting nodes

        count--;


        var THead = Head.Next;      //  store the new Head to a Temperary Head
        Head.Next = null;       //  removing head by making Head.next and Head null
        Head = null;
        Head = THead;       //  returning the value of the new Head

    }




    //  ValueByIndex
    
    public void ValueByIndex(int index , out Node node)
    {
        node = null;
        var CurrentNode = Head;
        int Counting = 0;
        if ((index > 0) && (index <= count - 1))
        {
            while (CurrentNode.Next is not null)
            {
                CurrentNode = CurrentNode.Next;
                Counting++;
                if (Counting == index)
                {
                    node = CurrentNode;
                    return;
                }

            }
        }else if (index == 0)
        {
            node = Head;
            return;
        }else if (index == count - 1)
        {
            node = Tail;
            return;
        }

        Console.WriteLine("Something wronge with the index the index you enter is out of range");
    }




    //  Delete Last Node 
    //  it is the same as First but we deal with tail not head

    //  fist we use search by value to get postion if it is for tail or head 
    //  we use DeleteLastNode or DeleteFirstNode and if not any of these positions
    //  we delete then reconect linked list
    public void DeleteLastNode()
    {
        //  counting nodes

        count--;

        /*var TTail = Tail.Next;*/      //  store the new Tail to a Temperary Tail
        //  but finding prev of Tail is imposble bc we are using singly
        //  so we use the search by value instead

        ValueByIndex(count -1 , out Node node);
        var TTail = node;   
        Tail = null;
        Tail = TTail;
        Tail.Next = null;
    }

    public void DeleteByValue(int ValueToBeDeleted)
    {
        SearchAnElement(ValueToBeDeleted, out int position);
        if (position != 0 && position != count - 1)
        {
            ValueByIndex(position -1, out Node node);
            Node LeftElement = node;
            Node RightElement = node.Next.Next;
            Node RemovedNode = node.Next;
            RemovedNode.Next = null;
            RemovedNode = null;
            LeftElement.Next = RightElement;
        }
        else if (position == 0)
        {
            DeleteFirstNode();
        }
        else if (position == count - 1)
        {
            DeleteLastNode();
        }
    }

    //  we make a list that collect the linked list data then we InsertAtEnd
    public void ReverseLinkedList()
    {
        List<Node> NodesList = new List<Node>();
        var CurrentNode = Head;
        if (CurrentNode == Head)
        {
            NodesList.Add(CurrentNode);
        }
        while(CurrentNode.Next is not null)
        {
            CurrentNode = CurrentNode.Next;
            NodesList.Add(CurrentNode);
        }

        //  both head and tail should set to zero and count as well 
        //  so we can start over new linked list with revese elements linked

        Head = null;
        Tail = null;

        

        //  now we can delete every node link by Node.next = null one by one 
        //  and insert at beginning so it reverse the elements

        count = 0;
        foreach (var Node in NodesList)
        {
            Node.Next = null;
            InsertAtBeginning(Node.Data);
        }
        


    }


    //  to get the middle we use count and half it and then 
    //  if you get float value you just -0.5
    //  and if you get int value you just -1 and say there was no middle but two numbers 
    public Node FindMiddleNode(out bool IsOneMiddleNumber)
    {
        dynamic HalfCount = count / 2;
        if (HalfCount is float)
        {
            IsOneMiddleNumber= true;
            HalfCount -= 0.5;
            ValueByIndex(HalfCount,out Node MiddleNode);
            return MiddleNode;
        }
        else if (HalfCount is int)
        {
            IsOneMiddleNumber = false;
            HalfCount -= 1;
            ValueByIndex(HalfCount, out Node FirstOfTwoMiddleNodes);
            return FirstOfTwoMiddleNodes;
        }
        throw new NotImplementedException("invailed input for Find middle node function");
    }




}
internal class Program
{
    static void Main(string[] args)
    {

        //  making list to test our add and DisplayElements functions 
        LinkedList list = new LinkedList();
        List<int> nunbers = new List<int> { 1, 3, 55, 65, 2, 532 };




        //  add nodes
        foreach (int n in nunbers)
        {
            list.AddToLinkedList(n);

        }

        //  show nodes
        list.DisplayElements();

        //  show node counting 
        Console.WriteLine($"\nNodes Count: {list.count}");

        //  searching for a value in a linked list
        Console.Write("\nWrite the value you want to search: ");
        int InputValue = int.Parse( Console.ReadLine() );
        list.SearchAnElement(InputValue, out int position);
        if (position >= 0)
        {
            Console.WriteLine($"Element position is {position}\n");
        }
        else
        {
            Console.WriteLine($"there is elemet in the linked like with the value '{InputValue}'\n");
        }

        //   Insert at Beginning

        List<int> numbers2 = new List<int> { 42, 34, 255, 5, 12, 32 };

        //  add nodes
        foreach (int n in numbers2)
        {
            list.InsertAtBeginning(n);

        }

        //  we use the display function again to see the result of InsertAtBeginning

        //  show nodes
        list.DisplayElements();


       



        // InsertAtPosition
        Console.WriteLine("Enter the value you want to insert");
        int InsertAtPositionValue = int.Parse(Console.ReadLine());      //  value

        Console.WriteLine("Enter postion where you want to insert the value");
        int Position = int.Parse(Console.ReadLine());       //  position where you want to insert the value
        list.InsertAtPosition(InsertAtPositionValue, Position);

        //  show nodes
        Console.WriteLine("");
        list.DisplayElements();


        //  delete First node
        list.DeleteFirstNode();
        Console.WriteLine("\nDelete first node...");
        list.DisplayElements();

        //  delete last node
        list.DeleteLastNode();
        Console.WriteLine("\nDelete Last node...");
        list.DisplayElements();


        //  delete by value 
        Console.Write("Enter value to be deleted: ");
        int ValueToBeDeleted = int.Parse(Console.ReadLine());
        list.DeleteByValue(ValueToBeDeleted);
        Console.WriteLine("\nDelete unwanted node...");
        list.DisplayElements();


        //  Reverse Linked List
        Console.WriteLine("\n\nReverse Linked List ...");
        list.ReverseLinkedList();
        list.DisplayElements();



        //  Find Middle Node
        Console.WriteLine("\n\n");
        Node Middle = list.FindMiddleNode(out bool IsOneMiddleNumber);
        if (IsOneMiddleNumber)
        {
            Console.WriteLine($"Middle Node is -> {Middle.Data}");
        }
        else
        {
            Console.WriteLine($"Middle Nodes are -> {Middle.Data} and  {Middle.Next.Data}");
        }
            


    }
}
