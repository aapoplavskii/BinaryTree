using System;
using System.Threading.Channels;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {

                WorkWithData WorkData = new WorkWithData();
                var currentNode = WorkData.EnterDataMethod();

                Console.WriteLine("Итоговое дерево зарплат:");
                WorkData.Traverse(currentNode);

                WorkData.FindZP(currentNode);



                while (true)
                {
                Console.WriteLine();
                    Console.WriteLine("Для ввода новых данных по сотрудникам нажмите 0.");
                    Console.WriteLine("Для нового поиска зарплаты нажмите 1.");
                    Console.WriteLine("Для выхода из программы нажмите 2.");

                    var otvet = Console.ReadKey();
                    Console.WriteLine();

                    switch (otvet.KeyChar)
                    {
                        case '1':
                            WorkData.FindZP(currentNode);
                            break;
                        case '0':
                            Console.Clear();
                            currentNode = WorkData.EnterDataMethod();
                            Console.WriteLine("Итоговое дерево зарплат:");
                            WorkData.Traverse(currentNode);
                            WorkData.FindZP(currentNode);
                        break;
                        case '2':
                            break;
                        default:
                            Console.WriteLine("Необходимо ввести указанные цифры!");
                            break;

                    }

                    if (otvet.KeyChar == '2')
                    {
                        break;
                    }

                }

            

           


        }

        
    }
}
