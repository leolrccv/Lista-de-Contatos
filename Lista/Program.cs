using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace Lista {

    class Program {
        static void Main(string[] args) {
            int opcao;

            List<Pessoa> pessoas = new List<Pessoa>();

            do {
                Console.WriteLine("\n1 - Inserir\n2 - Remover Contato\n3 - localizar um contato\n4 - imprimir os contatos\n" +
                    "5 - Imprimir 1 por 1\n6 - Quantidade de Contatos\n0 - Sair e Arquivar\n");

                Console.Write("Digite a opção desejada: ");
                opcao = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (opcao) {
                    case 1:
                        InserirPessoa(pessoas);
                        pessoas = pessoas.OrderBy(i => i.Nome).ToList();
                        break;

                    case 2:
                        RemoverPessoa(pessoas);
                        break;

                    case 3:
                        AcharPessoa(pessoas);
                        break;

                    case 4:
                        pessoas.ForEach(i => Console.WriteLine(i));
                        break;

                    case 5:
                        Imprimir1(pessoas);
                        break;

                    case 6:
                        Console.WriteLine("Quantidade de contatos: " + pessoas.Count);
                        break;

                    case 0:
                        Console.WriteLine("Saindo...");
                        break;

                    default:
                        Console.WriteLine("Digite uma opção válida!");
                        break;
                }
            } while (opcao != 0);


            string Path = @"..\..\..\Contatos.txt";
            using (var streamWriter = new StreamWriter(Path, true)) {
                foreach (Pessoa p in pessoas)
                    streamWriter.WriteLine(p);
            }

            Console.ReadKey();
        }

        static void InserirPessoa(List<Pessoa> pessoas) {

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Celular DDD: ");
            int ddd1 = int.Parse(Console.ReadLine());

            Console.Write("Celular número: ");
            int numero1 = int.Parse(Console.ReadLine());

            Console.Write("Fixo DDD: ");
            int ddd2 = int.Parse(Console.ReadLine());

            Console.Write("Fixo número: ");
            int numero2 = int.Parse(Console.ReadLine());

            Telefone telefone1 = new Telefone { DDD = ddd1, Numero = numero1, Tipo = "Celular" };
            Telefone telefone2 = new Telefone { DDD = ddd2, Numero = numero2, Tipo = "Fixo" };

            Pessoa pessoa = new Pessoa { Nome = nome, telefone = new Telefone[] { telefone1, telefone2 } };

            pessoas.Add(pessoa);
        }
        static void RemoverPessoa(List<Pessoa> pessoas) {
            Console.Write("\nNome do contato que deseja remover: ");
            string nome = Console.ReadLine();

            int x = pessoas.RemoveAll(p => p.Nome == nome);
            if (x == 0) Console.WriteLine("Contato Inexistente!");
        }
        static void AcharPessoa(List<Pessoa> pessoas) {
            string nome;
            bool encontrou = false;

            Console.Write("Nome que deseja encontrar: ");
            nome = Console.ReadLine();

            for (var i = 0; i < pessoas.Count; i++) {
                if (pessoas[i].Nome == nome) {
                    Console.WriteLine($"{nome} encontrado na posição {i + 1}");
                    encontrou = true;
                }
            }
            if (!encontrou) Console.WriteLine("Nome não encontrado!\n");
        }
        static void Imprimir1(List<Pessoa> pessoas) {
            string resp;
            Console.WriteLine();

            for (int i = 0; i < pessoas.Count; i++) {
                Console.WriteLine(pessoas[i]);
                if (i < pessoas.Count - 1) {
                    Console.Write("Deseja imprimir o próximo contato?[s/n]: ");
                    resp = Console.ReadLine().ToUpper();
                    if (resp == "N") return;
                }
            }
        }
    }
}
