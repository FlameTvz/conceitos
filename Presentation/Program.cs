using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Data.Common;
using conceitos.DTOs;
using conceitos.Infra.Repositories;
using conceitos.Presentation;
using System.Runtime.InteropServices;
namespace conceitos.Presetation;


class Program
{
    static void Main()
    {
        LanguageRepository repository = new();
        Registration register = new();
        Menu menu = new();

        while (true)
        {
            menu.MostrarMenu();

            switch (menu.option[0])
            {
                case '1':

                    int id = repository.GetLastId() + 1;
                    repository.Criar(register.Add(id));
                    break;

                case '2':
                    register.ListAll(repository.Lista());

                    break;
                case '3':

                    var objEdit = register.Edit();

                    repository.Atualizar(objEdit.Item1, objEdit.Item2);
                    break;
                case '4':

                    id = register.Delete();
                    repository.Deletar(repository.FindbyId(id));
                    break;
                case '5':
                    break;
            }
        }

    }
}
