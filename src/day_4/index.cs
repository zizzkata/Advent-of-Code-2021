using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;

class Program
{
    static bool checkForBingo(string[,] table)
    {
        for (int i = 0; i < 5; i++) {
            bool rowsMatch = true;
            bool colsMatch = true;
            for (int iterator = 0; iterator < 5; iterator++) { 
                if (table[i, iterator] != "X")
                    rowsMatch = false;
                if (table[iterator, i] != "X")
                    colsMatch = false;

                if (!rowsMatch && !colsMatch)
                    break;
            }
            if (rowsMatch || colsMatch)
                return true;
        }
        return false;
    }

    static void crossSymbol(string[,] table, string number)
    {
        for (int row = 0; row < table.GetLength(0); row++) {
            for (int col = 0; col < table.GetLength(1); col++) {
                if (table[row, col] == number) {
                    table[row, col] = "X";
                    return;
                }
            }
        }
    }
    // used in debugging
    static void printTable(string[,] table)
    {
        for (int row = 0; row < table.GetLength(0); row++) {
            for (int col = 0; col < table.GetLength(1); col++) {
                if (col == table.GetLength(1) - 1) {
                    Console.WriteLine(" " + table[row, col]);
                } else {
                    Console.Write(" " + table[row, col]);
                }
            }
        }
    }
    static int sumOfUnmarked(string[,] table)
    {
        int sum = 0;
        for (int row = 0; row < table.GetLength(0); row++) {
            for (int col = 0; col < table.GetLength(1); col++) {
                if (table[row, col] != "X") {
                    sum += int.Parse(table[row, col]);
                }
            }
        }
        return sum;
    }
    static void Main(string[] args)
    {
        // Read file
        string fileText = File.ReadAllText(@"./input");
        string[] tables = fileText.Split(new string[] { "\n\n" }, StringSplitOptions.None);
        string[] bingoNumbers = tables[0].Split(','); // bingo numbers

        List<string[,]> listTables = new List<string[,]>();

        // Set up bingo tables
        for (int i = 1; i < tables.Length; i++) {
            string[,] table = new string[5, 5];
            string[] rows = tables[i].Split('\n');

            for (int row = 0; row < table.GetLength(0); row++) {
                for (int col = 0; col < table.GetLength(1); col++) {
                    table[row, col] = rows[row].Substring(col * 3, 2);
                    if (table[row, col][0] == ' ')
                        table[row, col] = table[row, col].Substring(1, 1);
                }
            }
            listTables.Add(table);
        }

        // Start the bingo
        for (int bingoIndex = 0; bingoIndex < bingoNumbers.Length; bingoIndex++) {
            string number = bingoNumbers[bingoIndex];
            List<string[,]> winningTables = new List<string[,]>();
            foreach (string[,] table in listTables) {
                crossSymbol(table, number);
                if (checkForBingo(table)) {
                    int sum = sumOfUnmarked(table);
                    Console.WriteLine(sum * int.Parse(number)); // get score
                    winningTables.Add(table);
                }
            }
            // remove winning tables
            foreach (string[,] table in winningTables) {
                listTables.Remove(table);
            }
        }
    }
}
