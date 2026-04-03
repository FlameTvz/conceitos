using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace conceitos.Presentation
{

    public class Menu
    {
        public string option;
        public string MostrarMenu()
        {
            Console.WriteLine("==============MENU==========");
            Console.WriteLine("1 - Criar");
            Console.WriteLine("2 - Lista");
            Console.WriteLine("3 - Atualizar");
            Console.WriteLine("4 - Deletar");
            Console.WriteLine("5 - Sair");

            Console.Write("Escolha: ");
            option = Console.ReadLine();
            return $"{option}";
        }
    }


}