using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using conceitos.DTOs;
using conceitos.Services;
namespace conceitos.Presentation;

//Estado = Propiedades
//Comportamento = Metodos

public class Registration
{
    // int tentativas = 0;
    LanguageService service { get; set; }

    public bool status { get; set; }
    public int erros { get; set; }
    public string nome { get; set; }
    public string nivel { get; set; }
    public int id { get; set; }
    public Registration()
    {
        service = new();
        status = true;
        erros = 0;
        nome = "";
        nivel = "";
        id = 0;
    }

    public void Tentativas(int tentativas)
    {

        if (tentativas >= 3)
        {
            status = false;
            Console.WriteLine("Você excedeu o número de tentativas");

        }

    }

    public LanguageDto Add(int count)
    {
        Reset();
        while (status)
        {
            Console.Write("Nome: ");
            nome = Console.ReadLine();
            if (nome.Length == 0)
            {
                if (service.ValidationName(nome) == false)
                {
                    erros++;
                    Tentativas(erros);
                    if (status == false)
                        break;
                    Console.WriteLine("Necessario informar o Nome ");
                    continue;
                }
            }
            Console.Write("Nivel: ");
            nivel = Console.ReadLine();
            if (service.ValidationNivel(nivel) == false)
            {
                erros++;
                Tentativas(erros);
                if (status == false)
                    break;
                Console.WriteLine("Necessario informar o Nivel");
                continue;
            }
            break;
        }

        return new LanguageDto { Id = count, Nome = nome, Nivel = nivel };

    }

    public void Reset()
    {
        erros = 0;
        nome = "";
        nivel = "";
        id = 0;
    }

    public Tuple<int, LanguageDto> Edit()
    {
        Reset();
        while (true)
        {
            if (id < 1)
            {
                Console.Write("Informe um Id: ");
                try
                {
                    id = service.CheckId(Console.ReadLine());
                }
                catch (InvalidCastException ex)
                {
                    Console.WriteLine($"Cast error: {ex.Message}");
                }
            }
            if (nome.Length == 0)
            {
                Console.Write("Nome: ");
                nome = Console.ReadLine();
                if (service.ValidationName(nome) == false)
                {
                    erros++;
                    Tentativas(erros);
                    if (status == false)
                        break;
                    Console.WriteLine("Necessario informar o Nome ");
                    continue;
                }
            }
            Console.Write("Nivel: ");
            nivel = Console.ReadLine();
            if (service.ValidationNivel(nivel) == false)
            {
                erros++;
                Tentativas(erros);
                if (status == false)
                    break;
                Console.WriteLine("Necessario informar o Nivel");
                continue;
            }
            break;
        }

        return new Tuple<int, LanguageDto>(id, new LanguageDto { Id = id, Nome = nome, Nivel = nivel });
    }

    public void ListAll(List<LanguageDto> languages)
    {
        languages.ForEach(x =>
                    {
                        Console.WriteLine("=====================================");
                        Console.WriteLine($"{x.Id} - {x.Nome} - {x.Nivel}");


                    });
    }

    public int Delete()
    {
        string notification = "Informe um Id: ";
        while (true)
        {
            Console.Write(notification);

            try
            {
                id = service.CheckId(Console.ReadLine());
                break;
            }
            catch (InvalidCastException ex)
            {
                notification = $"Cast error: {ex.Message}";
            }

        }
        return id;
    }

}
