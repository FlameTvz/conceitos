using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;


public class Linguagens
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Nivel { get; set; }
}

class Program
{
    static void Main()
    {
        string nome;
        string nivel;
        List<Linguagens> linguagens = [];
        int count = 0;
        while (true)
        {
            count++;
            Console.Write("Nome: ");

            nome = Console.ReadLine();
            Console.WriteLine(nome);

            Console.Write("Nivel: ");

            nivel = Console.ReadLine();
            Console.WriteLine(nivel);

            linguagens.Add(new Linguagens { Id = count, Nome = nome, Nivel = nivel });
            linguagens.ForEach(x =>
            {
                Console.WriteLine(x.Id);
                Console.WriteLine(x.Nome);
                Console.WriteLine(x.Nivel);
            });
        }
    }

}
