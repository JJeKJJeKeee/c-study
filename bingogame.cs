using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework03
{
    public class Bingo // 빙고판 클래스
    {               
        public int[,] Board { get; } // 2차원 빙고판
        public int Size { get; } // 총 칸수
        public int Line { get; } // 한줄 길이

        public Bingo() // 사이즈5 자동생성
        {
            Board = new int[5, 5];
            Random ran = new Random();
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    Board[i, j] = ran.Next(20) + 1;                   
                }                
            }
            Size = 5 * 5;
            Line = 5;
        }

        public Bingo(int Size) // 임의 사이즈 생성
        {            
            Board = new int[Size, Size];
            Random ran = new Random();
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    Board[i, j] = ran.Next(20) + 1;
                }
            }
            this.Size = Size * Size;
            Line = Size;
        }

        public void Print() // 빙고판 출력
        {           
            for(int i = 0; i < Board.GetLength(0); i++)
            {
                for(int j = 0;j< Board.GetLength(1); j++)
                {                    
                    Console.Write("{0,3}",Board[i,j]);
                }
                Console.WriteLine();
            }
        }
    }

    public class BingoManager // 입력받은 빙고판 매니져
    {
        public Bingo Bingo;
        public BingoManager(Bingo Bingo)
        {
            this.Bingo = Bingo;
        }               
        public int[,] Search(int num) // 대입받은 정수와 같은 빙고판 주소 2차원 배열로 출력
        {
            int[,] temp = new int[Bingo.Size,2];
            int count = 0;
            for (int i = 0; i < Bingo.Line; i++)
            {
                for (int j = 0; j < Bingo.Line; j++)
                {
                    if (num == Bingo.Board[i, j])
                    {
                        temp[count, 0] = i;
                        temp[count, 1] = j;
                        count++;
                    }                    
                }
            }
            int[,] result = new int[count, 2];
            for (int i = 0; i < count; i++)
            {
                result[i, 0] = temp[i, 0];
                result[i, 1] = temp[i, 1];
            }

            return result;
        }
        public void ChangeNum(int find, int result) // 대입받은 정수검색후 리턴받은 주소들의 값을 result 값으로 바꿈
        {
            int[,] list = Search(find);
            for(int i = 0; i < list.GetLength(0); i++)
            {
                Bingo.Board[list[i, 0], list[i, 1]] = result;
            }
        }
        public void ElimiNum() // 사용자에게 입력 요청하여 changenum 실행
        {
            Console.Write("지울 숫자 입력 : ");
            int input = int.Parse(Console.ReadLine());
            ChangeNum(input, 0);                        
        }        
        public int BingoCheck() // 현재 빙고판의 빙고개수 체크
        {
            int bingoCount = 0;
            for (int i = 0, diaCount = 0, rdiaCount = 0; i < Bingo.Line; i++)
            {
                if (Bingo.Board[i, i] == 0)
                {
                    diaCount++;
                }
                if (Bingo.Board[i, Bingo.Line - 1 - i] == 0)
                {
                    rdiaCount++;
                }
                if (rdiaCount == 5)
                {
                    bingoCount++;
                }
                if (diaCount == 5)
                {
                    bingoCount++;
                }
                for (int j = 0, rowCount = 0, colCount = 0; j < Bingo.Line; j++)
                {
                    if (Bingo.Board[i, j] == 0)
                    {
                        rowCount++;
                    }
                    if (Bingo.Board[j, i] == 0)
                    {
                        colCount++;
                    }
                    if (colCount == 5)
                    {
                        bingoCount++;
                    }
                    if (rowCount == 5)
                    {
                        bingoCount++;
                    }
                }
            }
            return bingoCount;

        }
        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // 빙고 게임 만들기

            Bingo bingo = new Bingo();
            BingoManager manager = new BingoManager(bingo);            

            while (true)
            {
                Console.Clear();
                bingo.Print();
                Console.WriteLine("현재 빙고 개수 : {0}", manager.BingoCheck());                
                if (manager.BingoCheck() >= 3)
                {
                    Console.WriteLine("승리!!!");
                    break;
                }
                manager.ElimiNum();
            }            
        }
    }
}
