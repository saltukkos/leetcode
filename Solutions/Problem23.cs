namespace Solutions
{
    /// <summary>
    /// Merge k Sorted Lists
    /// https://leetcode.com/problems/merge-k-sorted-lists/
    /// </summary>
    public static partial class Problem23
    {
        //Leetcode declaration
        public sealed class ListNode
        {
            // ReSharper disable All
            public int val;
            public ListNode? next;

            public ListNode(int val = 0, ListNode? next = null)
            {
                this.val = val;
                this.next = next;
            }
            // ReSharper restore All

            public static ListNode? From(int[] data)
            {
                if (data.Length == 0)
                {
                    return null;
                }

                var root = new ListNode(data[0]);
                var tail = root;
                for (var i = 1; i < data.Length; ++i)
                {
                    var newNode = new ListNode(data[i]);
                    tail.next = newNode;
                    tail = newNode;
                }

                return root;
            }

        }
    }
}