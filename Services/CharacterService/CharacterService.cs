using AutoMapper;
using game.Dto.Character;
using game.Models.Character;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace game.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> Characters = new List<Character>
        {
            new Character(),
            new Character {id = 1, name = "red" }
        };
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var character = _mapper.Map<Character>(newCharacter);
            character.id = Characters.Max(c => c.id) + 1;
            Characters.Add(character);
            Characters.Add(_mapper.Map<Character>(newCharacter));
            serviceResponse.Data = Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse; 
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.Data = Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var character = Characters.FirstOrDefault(c => c.id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var character = Characters.FirstOrDefault(c => c.id == updatedCharacter.id); 

            character.name = updatedCharacter.name;
            character.brains = updatedCharacter.defence;
            character.defence = updatedCharacter.defence;
            character.hitPoint = updatedCharacter.hitPoint;
            character.strength = updatedCharacter.strength;
            character.Class = updatedCharacter.Class;

            serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);

            return serviceResponse;
        }
    }
}
