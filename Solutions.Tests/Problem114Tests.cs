using System.Collections.Generic;
using NUnit.Framework;

namespace Solutions.Tests
{
    [TestFixture]
    public class Problem114Tests
    {
        [Test]
        public void Flatten_TreeFromLeetCode_OutputMatchesLeetCode()
        {
            var root = new Problem114.TreeNode(1, 
                new Problem114.TreeNode(2, 
                    new Problem114.TreeNode(3), 
                    new Problem114.TreeNode(4)),
                new Problem114.TreeNode(5,
                    right: new Problem114.TreeNode(6)));
            
            Problem114.Flatten(root);

            var result = new List<int>();
            var node = root;
            while (node is not null)
            {
                result.Add(node.val);
                Assert.That(node.left, Is.Null);
                node = node.right;
            }

            Assert.That(result, Is.EqualTo(new[] {1, 2, 3, 4, 5, 6}));
        }
    }
}