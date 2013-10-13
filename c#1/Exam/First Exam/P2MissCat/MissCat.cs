using System;

class MissCat
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int[] votes = new int[N];
        int[] cats = new int[11];
        int mostPopularCat, smallestNum, winner = 0;

        for (int i = 0; i < votes.Length; i++)
        {
            votes[i] = int.Parse(Console.ReadLine());
        }

        smallestNum = votes[0];
        for (int i = 1; i < votes.Length; i++)
        {
            if (smallestNum > votes[i])
            {
                smallestNum = votes[i];
            }
        }
        for (int i = 0; i < votes.Length; i++)
        {
            cats[votes[i]]++;
        }
        mostPopularCat = cats[0];
        for (int i = 1; i < cats.Length; i++)
        {
            if (mostPopularCat < cats[i])
            {
                mostPopularCat = cats[i];
                winner = i;
            }
        }

        if (mostPopularCat > 1)
        {
            Console.WriteLine(winner);
        }
        else
        {
            Console.WriteLine(smallestNum);
        }
    }
}
