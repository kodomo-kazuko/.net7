

using game.Models;

namespace game.Services.CharacterService;
    public class CharacterService : ICharacterService
{
    private static List<Character> Characters = new List<Character> 
        {
            new Character(),
            new Character {id = 1, name = "red" }   
        };
    public async Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter)
    {
        var serviceResponse = new ServiceResponse<List<Character>>();
        Characters.Add(newCharacter);
        serviceResponse.Data = Characters;
            return serviceResponse;
    }

    public async Task<ServiceResponse<List<Character>>> GetAllCharacters()
    {
        var serviceResponse = new ServiceResponse<List<Character>>();
        serviceResponse.Data = Characters;
        return serviceResponse;
    }

    public async Task<ServiceResponse<Character>> GetCharacterById(int id)
    {
        var serviceResponse = new ServiceResponse<Character>();
        var character = Characters.FirstOrDefault(c => c.id == id);
        serviceResponse.Data = Characters;
        return serviceResponse;
    }
}
