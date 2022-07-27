namespace Solutions
{
    /// <summary>
    /// Flatten Binary Tree to Linked List
    /// https://leetcode.com/problems/flatten-binary-tree-to-linked-list/
    /// Solve it in-place without any allocations
    /// </summary>
    public static class Problem114
    {
        public static void Flatten(TreeNode? root)
        {
            if (root is null)
            {
                return;
            }

            FlattenRecursive(root, null);
        }

        private static void FlattenRecursive(TreeNode node, TreeNode? sibling)
        {
            if (node.right is { } right)
            {
                FlattenRecursive(right, sibling);
                sibling = right;
            }

            if (node.left is { } left)
            {
                FlattenRecursive(left, sibling);
                sibling = left;
            }

            node.left = null;
            node.right = sibling;
        }

        #region LeetcodeDeclarations
        // ReSharper disable All
        
#nullable disable
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
#nullable restore

        #endregion
    }
}