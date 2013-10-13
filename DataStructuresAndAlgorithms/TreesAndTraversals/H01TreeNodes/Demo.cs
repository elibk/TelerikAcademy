////
namespace H01TreeNodes
{
    using System;
    using System.Linq;

   public class Demo
    {
       public static void Main(string[] args)
        {   //// can replace ReadInput with 
            /*
             * string[] lines = 
                {
                    "7",
                    "2 4",
                    "3 2",
                    "5 0",
                    "3 5",
                    "5 6",
                    "5 1"
                };
             * 
             */
            TreeNode<int>[] nodes = TreeControler.ParseToTree(ReadInput());

            var root = TreeControler.GetRoot(nodes);
            Console.WriteLine("The root of the tree is {0}.", root.Value);

            Console.WriteLine("The the leaves of the tree are :");
            var leaves = TreeControler.GetLeaves(nodes);
            foreach (var leaf in leaves)
            {
                Console.WriteLine(leaf.Value);
            }

            Console.WriteLine("The middle nodes of the tree are :");
            var middleNodes = TreeControler.GetMiddleNodes(nodes);
            foreach (var middleNode in middleNodes)
            {
                Console.WriteLine(middleNode.Value);
            }

            Console.WriteLine("Longest path in the tree is {0} steps.", TreeControler.GetLongestPathLenght(root));

            int sum = 6;

            Console.WriteLine("Paths with sum {0} TreversingFromTheLeaves:", sum);
            Console.WriteLine(TreeControler.GetPathsTreversingFromTheLeaves(leaves, sum));
            Console.WriteLine();

            Console.WriteLine("Paths with sum {0} TreversingFromTheRoots:", sum);
            var paths = TreeControler.GetPathsTreversingFromTheRoots(nodes, sum);
            foreach (var path in paths)
            {
                Console.Write('|');
                foreach (var node in path)
                {
                    Console.Write(" " + node.Value);
                }

                Console.WriteLine(" |");
            }

            Console.WriteLine();

            Console.WriteLine("Trees with sum {0} :", sum);

            var subTrees = TreeControler.GetSubtreesWithSum(nodes, sum);
            foreach (var tree in subTrees)
            {
                Console.WriteLine("-> Tree with root {0}.", tree.Value);
            }
        }

        private static string[] ReadInput()
        {
            int numberOfNodes = int.Parse(Console.ReadLine());
            string[] input = new string[numberOfNodes];

            input[0] = numberOfNodes.ToString();

            for (int i = 1; i < numberOfNodes; i++)
            {
                input[i] = Console.ReadLine();
            }

            return input;
        }
    }
}
