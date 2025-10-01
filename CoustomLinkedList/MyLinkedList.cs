namespace CoustomLinkedList
{
    public class MyLinkedList<T>
    {
        // properties
        public Node<T> First { get; private set; }
        public Node<T> Last { get; private set; }
        public int Count { get; private set; }
        public MyLinkedList()
        {
            First = null;
            Last = null;
        }

        public void AddFirst(Node<T> newNode)
        {
            if (First == null)
            {
                First = newNode;
                Last = newNode;
            }
            else
            {
                newNode.Next = First;
                First = newNode;
            }
            Count++;
        }
        public void AddLast(Node<T> newNode)
        {
            if (First == null)
            {
                First = newNode;
                Last = newNode;
            }
            else
            {
                Last.Next = newNode;
                Last = newNode;
            }
            Count++;
        }

        public void AddAfter(Node<T> newNode, Node<T> existingNode)
        {
            if (Last == existingNode)
            {
                Last = newNode;
            }
            newNode.Next = existingNode.Next;
            existingNode.Next = newNode;
            Count++;
        }

        public int Find(T target)
        {
            Node<T> currentNode = First;
            int position = 1;
            while (currentNode != null && !currentNode.Data.Equals(target))
            {
                currentNode = currentNode.Next;
                position++;
            }
            if (currentNode == null)
                return -1;

            return position;
        }

        public void RemoveFirst()
        {
            if (First == null || Count == 0)
            {
                return;
            }
            First = First.Next;
            Count--;
        }
      
        public void Remove(Node<T> doomedNode)
        {
            if (First == null || Count == 0)
            {
                return;
            }

            if (First == doomedNode)
            {
                RemoveFirst();
                return;
            }

            Node<T> previous = First;
            Node<T> current = previous.Next;

            while (current != null && current != doomedNode)
            {
                previous = current;
                current = previous.Next;
            }

            if (current != null)
            {
                previous.Next = current.Next;
                if(current == Last)
                {
                    Last = previous;
                }
                Count--;
            }
        }
        public void Reverse()
        {
            if (First == null || Count <= 1)
                return; 

            Node<T> previous = null;
            Node<T> current = First;
            Node<T> next = null;

            Last = First; 

            while (current != null)
            {
                next = current.Next;  
                current.Next = previous; 
                previous = current;      
                current = next;          
            }

            First = previous; 
        }
        public Node<T> FindMiddle()
        {
            if (First == null)
                return null;

            int middlePosition = (Count / 2) + 1; 
            Node<T> current = First;
            int position = 1;

            while (position < middlePosition)
            {
                current = current.Next;
                position++;
            }

            return current; 
        }



        public void Print()
        {
            Console.WriteLine($"First Node {First.Data}");
            Console.WriteLine($"Last Node {Last.Data}");

            Node<T> node = First;

            while (node.Next != null)
            {
                Console.WriteLine(node.Data);
                node = node.Next;
            }
            Console.WriteLine(node.Data);
        }

    }
}