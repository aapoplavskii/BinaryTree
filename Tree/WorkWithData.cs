using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;
using Microsoft.VisualBasic.FileIO;

namespace Tree
{
    public class WorkWithData
    {

        public Node EnterDataMethod()
        {
            string _name = string.Empty;
            int _zp = 0;
            

            Node root = null;


            while (true)
            {
                Console.Write("Введите имя сотрудника: ");
                _name = Console.ReadLine();
                
                if (_name == "")
                {
                    break;
                }

                Console.WriteLine();

                while (true)
                {
                    Console.Write("Введите зарплату сотрудника: ");
                    var str = Console.ReadLine();

                    if (!int.TryParse(str, out _zp))
                    {
                        Console.WriteLine($"Зарплату необходимо вводить цифрами! Повторите ввод зарплаты для {_name}");
                        Console.WriteLine();
                    }
                    else
                    {
                        break;
                    }

                } 

                
                
                
                Console.WriteLine();

                if (root == null)
                {

                    root = new Node
                    {
                        Name = _name,
                        ZP = _zp
                    };

                }
                else
                {
                    Add(root, new Node
                    {
                        Name = _name,
                        ZP = _zp
                    });

                }

            }
        
            return root;

        }

        public Node Seach(Node current, int zp)
        {
            if (zp < current.ZP)
            {

                if (current.LeftNode != null)
                {

                    return Seach(current.LeftNode, zp);

                }
                else
                {
                    return null;
                }

            }
            else if (zp > current.ZP)
            {
                if (current.RightNode != null)
                {

                    return Seach(current.RightNode, zp);

                }
                else
                {
                    return null;
                }
            }
            else
            {
                return current;
            }



        }

        public void Add(Node currentNode, Node addedNode)
        {

            if (addedNode.ZP < currentNode.ZP)
            {
                if (currentNode.LeftNode != null)
                {
                    Add(currentNode.LeftNode, addedNode);
                }
                else
                {
                    currentNode.LeftNode = addedNode;
                }
            }
            else
            {
                if (currentNode.RightNode != null)
                {
                    Add(currentNode.RightNode, addedNode);
                }
                else
                {
                    currentNode.RightNode = addedNode;
                }
            }

        }

        public void Traverse(Node node)
        {
            
            if (node.LeftNode != null)
            {
                Traverse(node.LeftNode);
            }

            Console.WriteLine(node);

            if (node.RightNode != null)
            {

                Traverse(node.RightNode);
            }


        }

        public void FindZP(Node currentNode)
        {
            int zp = 0;
            

            while(true)
            {
            
                Console.WriteLine();
                Console.Write("Введите размер зарплаты для поиска в базе: ");
                var strzp = Console.ReadLine();

                if (!int.TryParse(strzp, out zp))
                {
                    Console.WriteLine("Для поиска зарплаты значение необходимо вводить цифрами. Повторите ввода снова!");
                    Console.WriteLine();
                }
                else
                {
                    break;
                }

            }

            var Findznach = Seach(currentNode, zp);
            if (Findznach != null)
            {

                Console.WriteLine($"Имя сотрудника с указанной зарплатой - {Findznach.Name}");
                Console.WriteLine();

            }
            else
            {

                Console.WriteLine("Такой сотрудник не найден");
                Console.WriteLine();

            }



        }

    }
}
