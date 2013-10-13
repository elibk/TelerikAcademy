namespace H01TreeNodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class TreeControler
    {
        public static TreeNode<int>[] ParseToTree(string[] input)
        {
            int numberOfNodes = int.Parse(input[0]);
            TreeNode<int>[] nodes = new TreeNode<int>[numberOfNodes];

            for (int i = 0; i < numberOfNodes; i++)
            {
                nodes[i] = new TreeNode<int>(i);
            }

            for (int i = 1; i < numberOfNodes; i++)
            {
                string conectionsLine = input[i];
                var connections = conectionsLine.Split(' ');
                var parentNode = int.Parse(connections[0]);
                var childNode = int.Parse(connections[1]);

                nodes[parentNode].ChildreanNodes.Add(nodes[childNode]);

                nodes[childNode].Parent = nodes[parentNode];
            }

            return nodes;
        }

        public static TreeNode<int> GetRoot(IEnumerable<TreeNode<int>> nodes)
        {
            foreach (var node in nodes)
            {
                if (node.Parent == null)
                {
                    return node;
                }
            }

            throw new ArgumentException("nodes", "The three does not contain root.");
        }

        public static IEnumerable<TreeNode<int>> GetLeaves(IEnumerable<TreeNode<int>> nodes)
        {
            List<TreeNode<int>> leaves = new List<TreeNode<int>>();

            foreach (var node in nodes)
            {
                if (node.ChildreanNodes.Count == 0)
                {
                    leaves.Add(node);
                }
            }

            return leaves;
        }

        public static IEnumerable<TreeNode<int>> GetMiddleNodes(IEnumerable<TreeNode<int>> nodes)
        {
            var middleNodes = nodes.Where(node => node.ChildreanNodes.Count > 0 && node.Parent != null);
            return middleNodes;
        }

        public static int GetLongestPathLenght(TreeNode<int> root)
        {
            if (root.ChildreanNodes.Count == 0)
            {
                return 0;
            }

            int maxPath = 0;
            for (int i = 0; i < root.ChildreanNodes.Count; i++)
            {
                maxPath = Math.Max(maxPath, GetLongestPathLenght(root.ChildreanNodes[i]));
            }

            return maxPath + 1;
        }

        public static IEnumerable<IEnumerable<TreeNode<int>>> GetPathsTreversingFromTheRoots(TreeNode<int>[] nodes, int sum)
        {
            List<List<TreeNode<int>>> paths = new List<List<TreeNode<int>>>();
            foreach (var node in nodes)
            {
                GetPathsWithThatSum(node, sum, paths);
            }

            return paths;
        }

        private static void GetPathsWithThatSum(TreeNode<int> root, int sum, List<List<TreeNode<int>>> paths)
        {
            Stack<TreeNode<int>> stack = new Stack<TreeNode<int>>();
            List<TreeNode<int>> currentPath = new List<TreeNode<int>>();
            stack.Push(root);
            int currentSum = 0;

            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();

                if (object.ReferenceEquals(currentNode.Parent, root))
                {
                    currentSum = root.Value;
                    currentPath = new List<TreeNode<int>> { root };
                }

                currentSum += currentNode.Value;
                currentPath.Add(currentNode);
                if (currentSum <= sum)
                {
                    if (currentSum == sum)
                    {
                        var matchedPath = new List<TreeNode<int>>();
                        matchedPath.AddRange(currentPath);
                        paths.Add(matchedPath);
                    }

                    if (currentPath.Count > 0)
                    {
                        if (currentNode.ChildreanNodes.Count == 0)
                        {
                            currentSum -= currentPath[currentPath.Count - 1].Value;
                            currentPath.RemoveAt(currentPath.Count - 1);
                        }
                    }

                    foreach (var node in currentNode.ChildreanNodes)
                    {
                        stack.Push(node);
                    }
                }
                else
                {
                    if (currentPath.Count > 0)
                    {
                        currentSum -= currentPath[currentPath.Count - 1].Value;
                        currentPath.RemoveAt(currentPath.Count - 1);
                    }
                }
            }
        }

        public static string GetPathsTreversingFromTheLeaves(IEnumerable<TreeNode<int>> leaves, int sum)
        {
            StringBuilder paths = new StringBuilder();
            foreach (var leaf in leaves)
            {
                if (CanReachSum(leaf, sum, paths))
                {
                    paths.Append("|");
                }
            }

            return paths.ToString();
        }

        private static bool CanReachSum(TreeNode<int> leaf, int sum, StringBuilder paths)
        {
            StringBuilder currentPath = new StringBuilder();

            var currentSum = 0;
            var currnetNode = leaf;
            var isSumReached = false;

            while (currnetNode != null)
            {
                currentSum += currnetNode.Value;

                if (currentSum > sum)
                {
                    break;
                }
                else if (currentSum == sum)
                {
                    isSumReached = true;
                }

                currentPath.Append(currnetNode.Value + " ");
                currnetNode = currnetNode.Parent;
            }

            if (isSumReached)
            {
                paths.Append(currentPath);
            }

            return isSumReached;
        }

        public static IEnumerable<TreeNode<int>> GetSubtreesWithSum(TreeNode<int>[] nodes, int sum)
        {
            var result = new List<TreeNode<int>>();
            int?[] visitedNodesSums = new int?[nodes.Length];

            for (int i = 0; i < nodes.Length; i++)
            {
                if (CanSubTreeMakeSum(nodes[i], sum, visitedNodesSums))
                {
                    result.Add(nodes[i]);
                }
            }

            return result;
        }

        private static bool CanSubTreeMakeSum(TreeNode<int> root, int sum, int?[] visitedNodesSums)
        {
            if (TravesrseSubTree(root, sum, visitedNodesSums) == sum)
            {
                return true;
            }

            return false;
        }

        private static int TravesrseSubTree(TreeNode<int> root, int sum, int?[] visitedNodesSums)
        {
            if (visitedNodesSums[root.Value] != null)
            {
                return (int)visitedNodesSums[root.Value];
            }
            
            int currentSum = root.Value;
            for (int i = 0; i < root.ChildreanNodes.Count; i++)
            {
                currentSum += TravesrseSubTree(root.ChildreanNodes[i], sum, visitedNodesSums);
            }

            visitedNodesSums[root.Value] = currentSum;
            return currentSum;
        }
    }
}
