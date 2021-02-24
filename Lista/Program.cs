using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace Lista {

    class Program {
        static void Main(string[] args) {
            int opcao;
            string nome;
            int idade;

            Pessoa pessoa;
            List<Pessoa> pessoas = new List<Pessoa>();

            do {
                Console.WriteLine("\n1 - Inserir\n2 - Remover Contato\n3 - localizar um contato\n4 - imprimir os contatos\n" +
                    "5 - Imprimir 1 por 1\n6 - Quantidade de Contatos\n0 - Sair");

                Console.Write("Digite a opção desejada: ");
                opcao = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (opcao) {
                    case 1:
                        pessoa = InserirPessoa();
                        pessoas.Add(pessoa);
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
                        Console.WriteLine();
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

            string Path = @"D:\C#\Contatos.txt";
            using (StreamWriter arq = new StreamWriter(Path)) {
                foreach (Pessoa p in pessoas)
                    arq.WriteLine(p);
            }
            Console.ReadKey();
        }

        static Pessoa InserirPessoa() {

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

            return pessoa;
        }
        static void RemoverPessoa(List<Pessoa> pessoas) {
            string nome;
            bool encontrou = false;

            Console.Write("Nome que deseja remover: ");
            nome = Console.ReadLine();

            for (var i = 0; i < pessoas.Count; i++) {
                if (pessoas[i].Nome == nome) {
                    pessoas.Remove(pessoas[i]);
                    encontrou = true;
                }
            }
            if (!encontrou) Console.WriteLine("Ninguém foi removido, nome não encontrado!\n");
        } 
        static void AcharPessoa(List<Pessoa> pessoas) {
            string nome;
            bool encontrou = false;

            Console.Write("Nome que deseja encontrar: ");
            nome = Console.ReadLine();

            for (var i = 0; i < pessoas.Count; i++) {
                if (pessoas[i].Nome == nome) {
                    Console.WriteLine($"{nome} encontrado na posição {i+1}");
                    encontrou = true;
                }
            }
            if (!encontrou) Console.WriteLine("Nome não encontrado!\n");
        }
        static void Imprimir1(List<Pessoa> pessoas) {
            string resp;
            for (int i = 0; i < pessoas.Count; i++) {
                Console.WriteLine(pessoas[i]);

                if (i<pessoas.Count - 1) {
                    Console.Write("Deseja imprimir o próximo contato?[s/n]: ");
                    resp = Console.ReadLine().ToUpper();
                    if (resp == "N") return;
                }
            }
        }
    }
}
