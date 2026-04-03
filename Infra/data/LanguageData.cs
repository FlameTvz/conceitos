using conceitos.DTOs;
namespace conceitos.Infra.data;

//Sempre que eu instanciar ela vai resetar a lista!!!

public class LanguageData
{
    public int IdTemp {get; set;}
    public List<LanguageDto> languages { get; set; }
    public LanguageData()
    {

        languages = [new LanguageDto {Id = 1, Nome = "luis", Nivel = "basico"},
                                    new LanguageDto {Id = 2, Nome = "gustavo", Nivel = "basico"} ];
        IdTemp = languages[^1].Id;
    }

}