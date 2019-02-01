using System;
using System.Collections.Generic;

namespace ConsoleArvoreBinaria
{
    class Program
    {
        static List<Node> arvore;
        static int tamanho = 10;

        static void Main(string[] args)
        {
            int node = -1;
            arvore = new List<Node>();

            Console.WriteLine("####### Arvore #######");
            Console.WriteLine("Inserida um número: ");
            node = Convert.ToInt32(Console.ReadLine());

            while (node != 0)
            {
                Inserir(node);

                Imprimir();

                Console.WriteLine("Inserida outro número: ");
                node = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("###### Fim ######");
            Console.Read();
        }

        private static void Imprimir()
        {
            Console.WriteLine(" ");
            foreach (var item in arvore)
            {
                Console.WriteLine("-----" + item.current);
                Console.WriteLine(item.left + "----------" + item.right);
            }
            Console.WriteLine(" ");
        }

        private static void Inserir(int node)
        {
            if (arvore.Count == 0)
                arvore.Add(new Node() { current = node });
            else
            {
                if (arvore[0].current > node)
                    FindRight(0, arvore[0].right, node);
                else
                    FindLeft(0, arvore[0].left, node);
            }
        }

        private static void FindLeft(int i,int left, int node)
        {
            if (arvore[i].left == 0)
            {
                arvore[i].left = node;
            }
            else
            {
                var ramo = arvore.Find(x => x.current == left);

                if (ramo == null)
                    arvore.Add(new Node() { current = left });
                else
                {
                    int index = arvore.FindIndex(x => x.current == left);
                    if (ramo.current > node)
                        FindRight(index, ramo.right, node);
                    else
                        FindLeft(index, ramo.left, node);
                }
            }
        }

        private static void FindRight(int i, int right, int node)
        {
            if (arvore[i].right == 0)
            {
                arvore[i].right = node;
            }
            else
            {
                var ramo = arvore.Find(x => x.current == right);

                if (ramo == null)
                    arvore.Add(new Node() { current = right });
                else
                {
                    int index = arvore.FindIndex(x => x.current == right);
                    if (ramo.current > node)
                        FindRight(index, ramo.right, node);
                    else
                        FindLeft(index, ramo.left, node);
                }
            }
        }
    }

    public class Node
    {
        public int current { get; set; }
        public int left { get; set; }
        public int right { get; set; }
    }
}
