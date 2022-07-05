//Написать программу, которая принимает из командной строки последовательность символов (строку) в качестве аргумента 
//и выводит в консоль максимальное количество неодинаковых последовательных символов в строке.
namespace HW1
{
    class program
    {
        static void Main(string[] args)
        {
            String str = "Putin Huilo rotebal ya vashuVoinu";
            int result = 0;

            do
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str.IndexOf(str[i]) < i)
                    {
                        if (i > result)
                        {
                            result = i;
                        }
                        str = str.Substring(str.IndexOf(str[i]) + 1);
                        break;
                    }
                }
            } while (str.Length > result);

            Console.WriteLine(result);
        }


    }
}