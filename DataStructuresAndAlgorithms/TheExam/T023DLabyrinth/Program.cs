using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T023DLabyrinth
{
   public class Coords
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Depth { get; set; }
        public int Dist { get; set; }


       public Coords(int row = 0, int col = 0, int depth = 0, int dist = 0)
        {
            this.Row = row;
            this.Col = col;
            this.Depth = depth;
            this.Dist = dist;
        }
    };

    class Program
    {
        private const char emptyCell = '.';
        private const char UpperLevelLadder = 'U';
        private const char LowerLevelLadder = 'D';

        private const char ImpassibleCell = '#';

        private static char[,,] labyrinth;

        private static Queue<Coords> queue = new Queue<Coords>();
        private static int Y;
        private static int X;
        private static int Z;
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            int startingRow = int.Parse(data[1]);
            int startingCol = int.Parse(data[2]);
            int startingDepth = int.Parse(data[0]);

            data = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Y = int.Parse(data[1]);
            X = int.Parse(data[2]);
            Z = int.Parse(data[0]);

            labyrinth = new char[Y, X, Z];

            for (int level = 0; level < Z; level++)
            {
                for (int row = 0; row < Y; row++)
                {
                    string line = Console.ReadLine();
                    for (int col = 0; col < X; col++)
                    {
                        labyrinth[row, col, level] = line[col];
                    }
                }
            }

            int result = ReachEndWithGoUP(new Coords(startingRow, startingCol, startingDepth));
            //if (result == -1)
            //{
            //    Console.WriteLine(ReachEndWithGoDown(new Coords(startingRow, startingCol, startingDepth)));
            //}
            //else
            //{
            //    Console.WriteLine(result);
            //}

            Console.WriteLine(result);
        }


        private static int ReachEndWithGoUP(Coords start)
        {

           if (labyrinth[start.Row, start.Col, start.Depth] == UpperLevelLadder)
            {
                if (!IsExitUp(start))
                {
                    var generated = new Coords(start.Row, start.Col, start.Depth + 1, start.Dist + 1);
                    if (IsValidStep(generated))
                    {
                        queue.Enqueue(generated);
                    }
                }
                else
                {
                    return start.Dist + 1;
                }
            }
            else if (labyrinth[start.Row, start.Col, start.Depth] == LowerLevelLadder)
            {
                if (!IsExitDown(start))
                {
                    var generated = new Coords(start.Row, start.Col, start.Depth - 1, start.Dist + 1);
                    if (IsValidStep(generated))
                    {
                        queue.Enqueue(generated);
                    }
                }
                else
                {
                    return start.Dist + 1;
                }
            }
                queue.Enqueue(start);
           
            Coords visited = null;
            while (queue.Count > 0)
            {
                visited = queue.Dequeue();

                List<Coords> nextSteps = GetNextSteps(visited);
                for (int i = 0; i < nextSteps.Count; i++)
                {
                    if (labyrinth[nextSteps[i].Row, nextSteps[i].Col, nextSteps[i].Depth] == UpperLevelLadder)
                    {
                        if (!IsExitUp(nextSteps[i]))
                        {
                            var generated = new Coords(nextSteps[i].Row, nextSteps[i].Col, nextSteps[i].Depth + 1, nextSteps[i].Dist + 1);
                            if (IsValidStep(generated))
                            {
                                labyrinth[nextSteps[i].Row, nextSteps[i].Col, nextSteps[i].Depth + 1] = ImpassibleCell;
                                queue.Enqueue(generated);
                            }
                        }
                        else
                        {
                            return nextSteps[i].Dist + 1;
                        }
                    }
                    else if (labyrinth[nextSteps[i].Row, nextSteps[i].Col, nextSteps[i].Depth] == LowerLevelLadder)
                    {
                        if (!IsExitDown(nextSteps[i]))
                        {
                            var generated = new Coords(nextSteps[i].Row, nextSteps[i].Col, nextSteps[i].Depth - 1, nextSteps[i].Dist + 1);
                            if (IsValidStep(generated))
                            {
                                labyrinth[nextSteps[i].Row, nextSteps[i].Col, nextSteps[i].Depth -1] = ImpassibleCell;
                                queue.Enqueue(generated);
                            }
                        }
                        else
                        {
                            return nextSteps[i].Dist + 1;
                        }
                    }
                    
                        labyrinth[nextSteps[i].Row, nextSteps[i].Col, nextSteps[i].Depth] = ImpassibleCell;
                        queue.Enqueue(nextSteps[i]);
                }
            }

            throw new OverflowException();
        }

        private static int ReachEndWithGoDown(Coords start)
        {

            if (labyrinth[start.Row, start.Col, start.Depth] == UpperLevelLadder)
            {
                if (!IsExitUp(start))
                {
                    labyrinth[start.Row, start.Col, start.Depth + 1] = ImpassibleCell;
                    queue.Enqueue(new Coords(start.Row, start.Col, start.Depth + 1, start.Dist + 1));
                }
                else
                {
                    return start.Dist + 1;
                }
            }
            else if (labyrinth[start.Row, start.Col, start.Depth] == LowerLevelLadder)
            {
                if (!IsExitDown(start))
                {
                    labyrinth[start.Row, start.Col, start.Depth - 1] = ImpassibleCell;
                    queue.Enqueue(new Coords(start.Row, start.Col, start.Depth - 1, start.Dist + 1));
                }
                else
                {
                    return start.Dist + 1;
                }
            }
            else
            {
                queue.Enqueue(start);
            }
            Coords visited = null;
            while (queue.Count > 0)
            {
                visited = queue.Dequeue();
                if (labyrinth[visited.Row, visited.Col, visited.Depth] == UpperLevelLadder)
                {
                    if (!IsExitUp(visited))
                    {
                        labyrinth[visited.Row, visited.Col, visited.Depth + 1] = ImpassibleCell;
                        queue.Enqueue(new Coords(visited.Row, visited.Col, visited.Depth + 1, visited.Dist + 1));
                    }
                    else
                    {
                        return visited.Dist;
                    }
                }
                else if (labyrinth[visited.Row, visited.Col, visited.Depth] == LowerLevelLadder)
                {
                    if (!IsExitDown(visited))
                    {
                        labyrinth[visited.Row, visited.Col, visited.Depth - 1] = ImpassibleCell;
                        queue.Enqueue(new Coords(visited.Row, visited.Col, visited.Depth - 1, visited.Dist + 1));
                    }
                    else
                    {
                        return visited.Dist;
                    }
                }
                List<Coords> nextSteps = GetNextSteps(visited);
                for (int i = 0; i < nextSteps.Count; i++)
                {

                    if (labyrinth[nextSteps[i].Row, nextSteps[i].Col, nextSteps[i].Depth] != UpperLevelLadder && labyrinth[nextSteps[i].Row, nextSteps[i].Col, nextSteps[i].Depth] != LowerLevelLadder)
                    {
                        labyrinth[nextSteps[i].Row, nextSteps[i].Col, nextSteps[i].Depth] = ImpassibleCell;
                        queue.Enqueue(nextSteps[i]);
                    }

                }
            }
            throw new OverflowException();
            return visited.Dist;
        }

        private static List<Coords> GetNextSteps(Coords step)
        {
            List<Coords> nextSteps = new List<Coords>();
            Coords generated;
            
            //right
            generated = new Coords(step.Row, step.Col + 1, step.Depth, step.Dist + 1);
            if (IsValidStep(generated))
            {
                nextSteps.Add(generated);
            }

            //down
            generated = new Coords(step.Row + 1, step.Col, step.Depth, step.Dist + 1);
            if (IsValidStep(generated))
            {
                nextSteps.Add(generated);
            }

            //left
            generated = new Coords(step.Row, step.Col - 1, step.Depth, step.Dist + 1);
            if (IsValidStep(generated))
            {
                nextSteps.Add(generated);
            }

            //up
            generated = new Coords(step.Row -1, step.Col, step.Depth, step.Dist + 1);
            if (IsValidStep(generated))
            {
                nextSteps.Add(generated);
            }

            return nextSteps;
        }

        private static bool IsValidStep(Coords step)
        {
            if (step.Row < 0 || step.Row >= Y)
            {
                return false;
            }

            if (step.Col < 0 || step.Col >= X)
            {
                return false;
            }

            if (labyrinth[step.Row, step.Col, step.Depth] != '#')
            {
                return true;
            }

            return false;
        }

        private static bool IsExitUp(Coords step)
        {
            if (step.Depth + 1 >= Z)
            {
                return true;
            }

            return false;
        }

        private static bool IsExitDown(Coords step)
        {
            if (step.Depth - 1 < 0)
            {
                return true;
            }

            return false;
        }
    }
}
