using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        enum Option
        {
            ENTER = 1,
            INFO = 2,
            REENTER = 3,
            OVER = -1,
        }
        struct Grade
        {
            public int id;
            public int L_score;
            public int R_score;
            public int total;
        }
        static void Main(string[] args)
        {
            bool isOK = false;
            int i = 0;
            Grade[] grades = new Grade[0];
            while (!isOK)
            {
                Console.Write("主選單：1)輸入成績 2)統計資料 3)修改成績 -1)結束:");
                int op = int.Parse(Console.ReadLine());
                if (op == (int)Option.ENTER)
                {
                    Array.Resize(ref grades, grades.Length + 1);
                }
                switch (op)
                {
                    case (int)Option.ENTER:
                        grades[i].id = i + 1;
                        Console.Write("聽力測驗：");
                        grades[i].L_score = int.Parse(Console.ReadLine());
                        if (grades[i].L_score<0 || grades[i].L_score>120)
                        {
                            Console.WriteLine("聽力測驗分數輸入錯誤!");
                            goto case (int)Option.ENTER;
                        }
                        Console.Write("閱讀測驗：");
                        grades[i].R_score = int.Parse(Console.ReadLine());
                        if (grades[i].R_score < 0 || grades[i].R_score > 120)
                        {
                            Console.WriteLine("閱讀測驗分數輸入錯誤!");
                            goto case (int)Option.ENTER;
                        }
                        grades[i].total = grades[i].L_score + grades[i].R_score;
                        Console.WriteLine($"總分:{grades[i].total}");
                        i++;
                        break;
                    case (int)Option.INFO:
                        Console.WriteLine("      聽力測驗   閱讀測驗   總分");
                        Console.WriteLine("---------------------------------");
                        for (int k = 0; k < grades.Length; k++)
                        {
                            Console.WriteLine($"{grades[k].id}     {grades[k].L_score}         {grades[k].R_score}         {grades[k].total}");
                        }
                        break;
                    case (int)Option.REENTER:
                        Console.Write("編號：");
                        int index = int.Parse(Console.ReadLine());
                        if (index > i)
                        {
                            Console.WriteLine("索引超出範圍！");
                            goto case (int)Option.REENTER;
                        }
                        Console.Write("聽力測驗：");
                        grades[index - 1].L_score = int.Parse(Console.ReadLine());
                        Console.Write("閱讀測驗：");
                        grades[index - 1].R_score = int.Parse(Console.ReadLine());
                        grades[index - 1].total = grades[index - 1].L_score + grades[index - 1].R_score;
                        break;
                    case (int)Option.OVER:
                        Console.WriteLine("結束程式");
                        isOK = true;
                        break;
                    default:
                        break;
                }
            }

        }
    }
}
