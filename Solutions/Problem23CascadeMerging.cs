namespace Solutions
{
    /// <summary>
    /// Cascade merging aproach will have O(N * ln(N)) time compleity if the total elements count is N.
    /// </summary>
    public static partial class Problem23
    {
        public static ListNode? MergeListsCascade(ListNode?[] lists)
        {
            var listsToMerge = lists.Length;
            if (listsToMerge == 0)
            {
                return null;
            }

            while (listsToMerge > 1)
            {
                var floorHalfSize = listsToMerge / 2;
                for (var i = 0; i < floorHalfSize; ++i)
                {
                    lists[i] = MergeTwoLists(lists[i * 2], lists[i * 2 + 1]);
                }

                if (listsToMerge % 2 != 0)
                {
                    lists[floorHalfSize] = lists[listsToMerge - 1];
                    listsToMerge = floorHalfSize + 1;
                }
                else
                {
                    listsToMerge = floorHalfSize;
                }
            }

            return lists[0];
        }

        private static ListNode? MergeTwoLists(ListNode? root1, ListNode? root2)
        {
            ListNode? resultRoot = null;
            var resultTail = resultRoot;
            var head1 = root1;
            var head2 = root2;

            void MakeNext(ListNode listNode)
            {
                if (resultRoot is null)
                {
                    resultRoot = listNode;
                    resultTail = listNode;
                    return;
                }

                resultTail!.next = listNode;
                resultTail = listNode;
            }

            while (head1 != null && head2 != null)
            {
                if (head1.val < head2.val)
                {
                    MakeNext(head1);
                    head1 = head1.next;
                }
                else
                {
                    MakeNext(head2);
                    head2 = head2.next;
                }
            }

            while (head1 != null)
            {
                MakeNext(head1);
                head1 = head1.next;
            }

            while (head2 != null)
            {
                MakeNext(head2);
                head2 = head2.next;
            }

            if (resultTail != null)
            {
                resultTail.next = null;
            }

            return resultRoot;
        }
    }
}