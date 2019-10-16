using System;
using System.Collections.Generic;
using System.Text;

namespace DoublyLinkedList_class
{
    public class DoublyLinkedList
    {
        public class ListNode
        {
            public ListNode(int value)
            {
                this.Value = value;
            }

            public ListNode NextNode { get; set; }
            public ListNode PreviousNode { get; set; }

            public int Value { get; set; }
        }

        public ListNode head;
        public ListNode tail;

        public int Count { get; private set; }

        public void AddFirst(int element)
        {
            var newHead = new ListNode(element);

            if (Count == 0)
            {
                this.head = this.tail = newHead;
            }
            else
            {
                newHead.NextNode = this.head;
                this.head.PreviousNode = newHead;
                this.head = newHead;
            }

            this.Count++;
        }

        public void AddLast(int element)
        {
            var newTile = new ListNode(element);

            if (Count == 0)
            {
                this.head = this.tail = newTile;
            }

            newTile.PreviousNode = this.tail;
            this.tail.NextNode = newTile;
            this.tail = newTile;

            this.Count++;

        }

        public void RemoveFirst()
        {
            CheckForInvalidOperation();

            var newHead = this.head.NextNode;
            newHead.PreviousNode = null;
            this.head = newHead;

            this.Count--;
        }

        public void RemoveLast()
        {
            CheckForInvalidOperation();

            var newTail = this.tail.PreviousNode;
            this.tail.NextNode = null;
            this.tail = newTail;

            this.Count--;
        }

        public void ForEach(Action<int> action, bool startingFromHead = true)
        {
            if (!startingFromHead)
            {
                var currentNode = this.tail;

                while (currentNode != null)
                {
                    action(currentNode.Value);
                    currentNode = currentNode.PreviousNode;
                }
            }
            else
            {
                var currentNode = this.head;

                while (currentNode.Value != 0)
                {
                    action(currentNode.Value);
                    currentNode = currentNode.NextNode;
                }
            }
        }

        public int[] ToArray()
        {
            var linkedListToArray = new int[this.Count];

            var currentNode = this.head;

            for (int i = 0; i < Count; i++)
            {
                linkedListToArray[i] = currentNode.Value;
                currentNode = currentNode.NextNode;
            }

            return linkedListToArray;
        }

        public void Clear()
        {
            this.head = this.tail = null;

            this.Count = 0;
        }

        private void CheckForInvalidOperation()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("DoublyLinkedList is empty!");
            }
        }
    }
}
