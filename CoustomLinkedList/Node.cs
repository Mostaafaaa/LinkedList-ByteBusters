using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoustomLinkedList
{
    public class Node <T>
    {
        // data
        public T Data { get; set; }
        // link (refrence)
        public Node<T> Next { get; internal set; }

        // constructor
        public Node (T data)
        {
            Data = data;
        }
    }
}
