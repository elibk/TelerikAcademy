using System;
using System.Numerics;

class WeAllLoveBits
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        uint [] P = new uint [N];
        string [] PS  =new string [N];
           
        for (int i = 0; i < N; i++)
		{
			P[i]= uint.Parse(Console.ReadLine());
            PS[i] = Convert.ToString(P[i], 2); 
		}
                     
        for (int PPosition = 0; PPosition < N; PPosition++ )
        {
            char[] Prevs = new char[PS[PPosition].Length];
            string PInv = "";
            string PRev = "";

            //PINV
            foreach (var item in PS[PPosition])
            {
                if (item == '0')
                {
                    PInv += '1';
                }
                else
                {
                    PInv += '0';
                }
            }

            //PREV
            int counting = PS[PPosition].Length - 1;
            foreach (var item in PS[PPosition])
            {
                Prevs[counting] = item;

                counting--;
            }
            for (int i = 0; i < PS[PPosition].Length; i++)
            {
                PRev += Prevs[i];
            }
            PInv = Convert.ToString(BigInteger.Parse(PInv));
            PRev = Convert.ToString(BigInteger.Parse(PRev));
            /////////
            int PInvInt= 0;
            for (int i = 0; i < PInv.Length-1; i++)
            {
                PInvInt = (PInvInt + (PInv[i] - '0')) * 2;                                // change from bitwise to decimal
            }
            PInvInt += (PInv[PInv.Length - 1] - '0');
            /////////
            int PRevInt = 0;                                                                               
            for (int i = 0; i < PRev.Length - 1; i++)
            {
                PRevInt = (PRevInt + (PRev[i] - '0')) * 2;
            }
            PRevInt += (PRev[PRev.Length - 1] - '0');                                       // change from bitwise to decimal
            ////////
            int newP = ((int)P[PPosition] ^ PInvInt) & PRevInt;
            Console.WriteLine((uint)newP);
        }
    }
}
