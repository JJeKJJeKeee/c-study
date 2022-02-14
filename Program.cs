using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpDownConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int rannum = 1000;
            int numberOfGame = 10000;
            int gameCount = 0;
            int[] countList = new int[numberOfGame];
            double limitScale = 0.6;


            while (gameCount < numberOfGame)
            {
                gameCount++;
                int answer = rnd.Next(1, rannum + 1);
                //Console.WriteLine(answer);
                int count = 0;
                int ranInputUpperLimit = rannum;
                int ranInputLowerLimit = 0;
                

                while (true)
                {
                    count++;
                    int scaledgap = (int)((1.0 - limitScale) * (ranInputUpperLimit - ranInputLowerLimit) * 0.5);

                    // int ranInput = rnd.Next(ranInputLowerLimit + 1, ranInputUpperLimit);
                    int ranInput = rnd.Next((ranInputLowerLimit + 1 + scaledgap),(ranInputUpperLimit - scaledgap + 1));


                    // Console.WriteLine("count:{0}/{1}/{2}/{3}", ranInput, count, answer,scaledgap);

                    if (ranInput == answer)
                    {
                        break;
                    }
                    else if (ranInput > answer)
                    {
                        ranInputUpperLimit = ranInput + scaledgap + 1;
                    }
                    else if (answer > ranInput)
                    {
                        ranInputLowerLimit = ranInput - scaledgap - 1;
                    }

                    /*
                    if (ranInput == answer)
                    {
                        break;
                    }
                    else if (ranInput > answer)
                    {
                        ranInputUpperLimit = ranInput;
                    }
                    else if (answer > ranInput)
                    {
                        ranInputLowerLimit = ranInput;
                    }
                    */
                }
                countList[gameCount - 1] = count;                
                // Console.WriteLine("gamecount:{0} / count:{1}",gameCount,count);
            
                if((double)gameCount / numberOfGame == 0.2)
                {
                    Console.WriteLine("20%");
                }
                else if ((double)gameCount / numberOfGame == 0.4)
                {
                    Console.WriteLine("40%");
                }
                else if((double)gameCount / numberOfGame == 0.6)
                {
                    Console.WriteLine("60%");
                }
                else if ((double)gameCount / numberOfGame == 0.8)
                {
                    Console.WriteLine("80%");
                }
            }

            
            
            Console.WriteLine("limitscale : {0} / rannum : {1} / numberofgame : {2} / avg : {3} / min : {4}", limitScale,rannum, numberOfGame, countList.Average(), countList.Min());
        }
    }
}
