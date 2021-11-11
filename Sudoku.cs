using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Sudoku
    {
        static void Main(string[] args)
        {
            var objsudoku = new char[,]
            {
                {'.','.','.','.','7','.','.','3','5'},
                { '.','.','.','5','9','1','.','.','6'},
                { '.','6','.','.','.','.','8','9','.'},
                { '3','.','.','.','6','.','.','.','8'},
                { '1','.','.','3','.','8','.','.','4'},
                { '6','.','.','.','2','.','.','.','7'},
                { '.','8','2','.','.','.','.','6','.'},
                { '5','.','.','9','1','4','.','.','.'},
                { '9','7','.','.','8','.','.','.','.'},
            };
            ValidateSudoku(objsudoku);
        }
        public static void ValidateSudoku(char[,] objboard)
        {
            if (objboard == null || objboard.Length == 0) 
            {
                return;
            }
            Validate(objboard);

        }
        public static bool Validate(char[,] objboard)
        {
            for (int i = 0; i < objboard.GetLength(0); i++)
            {
                for (int j = 0; j < objboard.GetLength(1); j++)
                {
                    if (objboard[i,j]=='.')
                    {
                        for (char c = '1'; c <='9'; c++)
                        {
                            objboard[i, j] = c;
                            if (IsTrue(objboard,i,j,c))
                            {
                                objboard[i, j] = c;
                                if (Validate(objboard))
                                {
                                    return true;
                                }
                                else
                                {
                                    objboard[i, j] = '.';
                                }
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }
        private static  bool IsTrue(char[,] objboard,int row,int col,char c)
        {
            for (int i = 0; i < 9; i++)
            {
                if (objboard[i,col]!='.'&&objboard[i,col]==c)
                {
                    return false;
                }
                if (objboard[row,i]!='.'&& objboard[row,i]==c)
                {
                    return false;
                }
                if (objboard[3*(row/3)+i/3,3*(col/3)+i%3]!='.'&&objboard[3*(row/3)+i/3,3*(col/3)+i%3]==c)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

//Output:--
//219876435
//843591276
//765243891
//324167958
//197258624
//658429317
//482735169
//356914782
//971682543