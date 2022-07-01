using GeekBrainsTests;
using System;
using System.Collections.Generic;
using System.Text;


namespace MyList
{
    public class MyLinkedList : ILinkedList
    {

        Node head = null;
        Node tail = null;

        public void AddNode(int value)
        {
            if (head == null)
            {
                head = new Node();
                head.Value = value;
                return;
            }

            if (tail == null)
            {
                tail = new Node();
                tail.Value = value;
                head.NextNode = tail;
                tail.PrevNode = head;
                return;
            }

            var temp = tail;
            Node Newnode = new Node();
            tail.NextNode = Newnode;
            Newnode.Value = value;
            Newnode.PrevNode = temp;
            tail = Newnode;

        }

        public void AddNodeAfter(Node node, int value)
        {
            Node temp = FindNode(value);
            if (temp == null)
            {
                Console.WriteLine("Элемент не найден!");
            }
            var nextTemp = temp.NextNode;
            temp.NextNode = node;
            node.PrevNode = temp;
            node.NextNode = nextTemp;

            if (node.PrevNode == null)
                head = node;
            if (node.NextNode == null)
                tail = node;
        }

        public Node FindNode(int searchValue)
        {
            var Node = head;
            while (Node != null)
            {
                if (searchValue == Node.Value)
                    return Node;
                Node = Node.NextNode;
            }
            return null;
        }

        public int GetCount()
        {
            Node node = head;
            int counter = 0;
            while (node != null)
            {
                node = node.NextNode;
                counter++;
            }
            return counter;
        }

        public void RemoveNode(int index)
        {
            Node node = head;
            int currentIndex = 1;
            while (currentIndex < index)
            {
                node = node.NextNode;
                currentIndex++;
                if (node == null)
                {
                    return;
                }
            }
            RemoveNode(node);
        }

        public void RemoveNode(Node node)
        {
            if (node == null)
                return;

            node.NextNode.PrevNode = node.PrevNode;
            node.PrevNode.NextNode = node.NextNode;
        }
    }
}
