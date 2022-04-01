using System;
using System.Collections.Generic;
namespace CreateBillID
{

    class Program
    {
        private static void PrintList(List<string> l)
        {
            for (int i = 0; i < l.Count; i++)
            {
                Console.Write(l[i]);
                Console.WriteLine();
            }

        }
        private static string CreateBill()
        {
            string[] a = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "O", "T", "R", "P", "Q", "L", "M", "N", "Y", "W", "X", "Z","S","V","U" };
            int[] b = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Random rand = new Random();
            string result = "";
            result += "A";
            int checkNumber = 0;
            int indexCharacter = rand.Next(a.Length);
            int indexNumber = rand.Next(b.Length);
            checkNumber = checkNumber + indexNumber;
            result += (a[indexCharacter]);
            result += (b[indexNumber] + "");
            indexNumber = rand.Next(b.Length);
            result += (b[indexNumber] + "");
            checkNumber = checkNumber + indexNumber;
            indexCharacter = rand.Next(a.Length);
            result += (a[indexCharacter]);
            result += (checkNumber % 10 + "");
            return result;
        }
        private static bool CheckDuplicate(string l1, string l2)
        {
            for (int i = 0; i < l1.Length; i++)
            {
                if (l1[i] != l2[i])
                {
                    return false;
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            List<string> result = new List<string>();
            string billID = "";
            long count = 0;
            billID = CreateBill();
            result.Add(billID);
            for (int i = 0; i < 20000; i++)
            {
                billID = CreateBill();
                for (int j = 0; j < result.Count; j++)
                {
                    if (CheckDuplicate(result[j], billID) == true)
                    {
                        billID = CreateBill();
                        count += 1;
                        j = 0;
                    }
                    else
                    {
                        continue;
                    }
                }
                result.Add(billID);
            }
            PrintList(result);
            Console.WriteLine(count);
        }
    }
}