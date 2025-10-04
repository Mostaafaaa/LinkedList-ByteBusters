namespace LinkedList;
public class Node
{
    public int Data;
    public Node Next;

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}
public class LinkedList
{

    public Node Head { get; set; }
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
        //  temperary head
        var TemperaryHead = Head;
        
        //  new node for the new head
        Node NewNode = new Node(data);
        Head = NewNode;

        //  attach the next of head to the old head
        Head.Next = TemperaryHead;
    }



    //  we can insert an element anywhere at Header or at tailer or in between but not out of this range
    public void InsertAtPosition(int data, int position)
    {
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

        List<int> numbers2 = new List<int> { 1, 3, 55, 65, 2, 532 };

        //  add nodes
        foreach (int n in nunbers)
        {
            list.InsertAtBeginning(n);

        }

        //  we use the display function again to see the result of InsertAtBeginning

        //  show nodes
        list.DisplayElements();




        // InsertAtPosition
        list.InsertAtPosition(0,2);

        //  show nodes
        list.DisplayElements();


    }
}
