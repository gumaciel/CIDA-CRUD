using System;
using System.Collections;
using System.IO;
using System.Linq;

namespace ConsoleApplication1
{
    class Menu
    {
        public ArrayList elementos = new ArrayList();
        public string add; // variavel pra usar readline na ArrayList elementos; 
        public string path; // variavel para por o endereço que quer armazenar o arquivo;
        public string file; // variavel para por o nome do arquivo;
        public string pathFile; // variavel para juntar path + file;
        public int arquivox; // variavel para mostrar o numero do elemento da arraylist no programa;
        public Menu()
        {
            Console.Write("Digite o nome do Diretorio = ");
            path = Console.ReadLine();
            Console.Write("Nomeie o arquivo com extensão '.txt' = ");
            file = Console.ReadLine();
            pathFile = path + file;
            Console.WriteLine(pathFile);

            if (File.Exists(pathFile))
            {
                Console.WriteLine("O arquivo existe, fazendo ajustes...");
                foreach (string line in File.ReadAllLines(@pathFile))
                {
                    elementos.Add(line);
                }
            }
            menu();
        }
        public void menu()
        {
            Console.Clear();
            Console.WriteLine("****");
            Console.WriteLine("1 - Abrir o arquivo");
            Console.WriteLine("2 - Salvar");
            Console.WriteLine("3 - Deletar");
            Console.WriteLine("****");

            Console.Write("Digite: "); ConsoleKeyInfo x = Console.ReadKey();

            switch (x.KeyChar)
            {
                case ('1'):
                    submenu();
                    break;
                case ('2'):
                    Salvaraqr();
                    break;
                case ('3'):
                    Deletararq();
                    break;
                default:
                    menu();
                    break;
            }
        }

        public void submenu()
        {
            Console.Clear();
            Console.WriteLine("1.1 - Consultar");
            Console.WriteLine("1.2 - Inserir");
            Console.WriteLine("1.3 - Deletar");
            Console.WriteLine("1.4 - Alterar");
            Console.WriteLine("1.5 - Voltar pra o menu principal");

            Console.Write("Digite: "); ConsoleKeyInfo x = Console.ReadKey();

            switch (x.KeyChar)
            {
                case ('1'):
                    Consultar();
                    break;
                case ('2'):
                    Inserir();
                    break;
                case ('3'):
                    Deletar();
                    break;
                case ('4'):
                    Alterar();
                    break;
                case ('5'):
                    menu();
                    break;
                default:
                    submenu();
                    break;
            }
        }
        public void Salvaraqr()
        {
            Console.Clear();
            File.WriteAllLines(@pathFile, elementos.Cast<string>());
            Console.WriteLine("Arquivo atualizo com sucesso");
            Console.Write("Pressione qualquer tecla para voltar pro menu principal...");
            Console.ReadKey();
            menu();
        }
        public void Deletararq()
        {
            Console.Clear();
            Console.WriteLine("Tem certeza que quer deletar o arquivo?");
            Console.Write("S = Sim, N = Não: ");
            ConsoleKeyInfo x = Console.ReadKey();
            switch (x.KeyChar)
            {
                case ('S'):
                    File.Delete(pathFile);
                    break;
                case ('s'):
                    File.Delete(pathFile);
                    break;
                case ('N'):
                    Console.Write("Pressione qualquer tecla para voltar pro menu principal...");
                    Console.ReadKey();
                    menu();
                    break;
                case ('n'):
                    Console.Write("Pressione qualquer tecla para voltar pro menu principal...");
                    Console.ReadKey();
                    menu();
                    break;
                default:
                    Deletararq();
                    break;
            }
        }
        public void Consultar()
        {
            Console.Clear();
            int count = elementos.Count;
            Console.WriteLine("Consulta dos elementos:\n");
            Console.WriteLine("Elementos da array do programa: ");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(i + " - " + elementos[i]);
            }
            Console.WriteLine("\nElementos do arquivo: ");

            if (File.Exists(pathFile))
            {
                foreach (string line in File.ReadAllLines(@pathFile))
                {
                    Console.WriteLine(arquivox + " - " + line);
                    arquivox++;
                }
                arquivox = 0;
            }
            Console.Write("\nPressione qualquer tecla para voltar para o menu principal...");
            Console.ReadKey();

            submenu();
        }
        public void Inserir()
        {
            Console.Clear();
            Console.Write("Digite o que você quer inserir: ");
            elementos.Add(add = Console.ReadLine());

            Console.Write("Pressione qualquer tecla para voltar para o menu principal...");
            Console.ReadKey();

            submenu();
        }
        public void Deletar()
        {
            Console.Clear();

            int count = elementos.Count;
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(i + " - " + elementos[i]);
            }

            Console.Write("Digite o numero do elemento que deseja remover: ");
            gotoremoverarray:
            int x = Convert.ToInt32(Console.ReadLine());

            if (x <= (count - 1) && x >= 0)
            {
                elementos.RemoveAt(x);
                Console.WriteLine("Elemento " + x + " removido com sucesso.");
            }
            else { Console.Write("Digite um número valido de 0 à " + (count - 1) + ": "); goto gotoremoverarray; }

            Console.Write("\nDeseja continuar removendo elementos? \n1 - Sim / 2 - Não: ");
            gotoremoverkey:
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.KeyChar)
            {
                case ('1'):
                    Deletar();
                    break;
                case ('2'):
                    Console.Write("\nPressione qualquer tecla para voltar para o menu...");
                    Console.ReadKey();
                    submenu();
                    break;
                default:
                    goto gotoremoverkey;
            }
        }

        public void Alterar()
        {
            Console.Clear();
            int count = elementos.Count;
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(i + " - " + elementos[i]);
            }

            Console.Write("Digite o numero do elemento que deseja alterar: ");
            gotoalterararray:
            int x = Convert.ToInt32(Console.ReadLine());
            if (x <= (count - 1) && x >= 0)
            {
                Console.Write("Digite oque você quer alterar: ");
                elementos[x] = Console.ReadLine();

                Console.WriteLine("Elemento " + x + " alterado com sucesso.");
            }
            else { Console.Write("Digite um número valido de 0 à " + (count - 1) + ": "); goto gotoalterararray; }

            Console.Write("\nDeseja continuar alterando elementos? \n1 - Sim / 2 - Não: ");
            gotoalterarkey:
            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.KeyChar)
            {
                case ('1'):
                    Alterar();
                    break;
                case ('2'):
                    Console.Write("\nPressione qualquer tecla para voltar para o menu...");
                    Console.ReadKey();
                    submenu();
                    break;
                default:
                    goto gotoalterarkey;
            }
        }
    }
}