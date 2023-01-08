namespace Solutions
{
    /// <summary>
    /// First approach is to compare heads of all lists at the iteration, it's quite simple,
    /// but has the disadvantage, because at each iteration we have to recompare all lists.Count heads.
    /// So the time complexity is O(lists.Count * elements_count). If the toltal elements count is N,
    /// in the worst case it can be O(N^2).
    /// </summary>
    public static partial class Problem23
    {
        public static ListNode? MergeListsLinear(ListNode?[] lists)
        {
            ListNode? resultRoot = null;
            var resultTail = resultRoot;

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

            while (true)
            {
                var minValue = int.MaxValue;
                var indexWithMinValue = -1;
                for (var i = 0; i < lists.Length; ++i)
                {
                    var candidateNode = lists[i];
                    if (candidateNode != null && candidateNode.val < minValue)
                    {
                        minValue = candidateNode.val;
                        indexWithMinValue = i;
                    }
                }

                if (indexWithMinValue < 0)
                {
                    break;
                }

                var selectedNode = lists[indexWithMinValue];
                
                MakeNext(selectedNode!);
                lists[indexWithMinValue] = selectedNode!.next;
            }

            if (resultTail != null)
            {
                resultTail.next = null;
            }

            return resultRoot;
        }
    }
}