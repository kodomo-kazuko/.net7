using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace game.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase
    {
        private static List<Character> Characters = new List<Character> 
        {
            new Character(),
            new Character {id = 1, name = "red" }   
        };

        [HttpGet("GetAll")]
        public ActionResult<List<Character>> Get() 
        {
            return Ok(Characters);
        }

        [HttpGet("{id}")]
        public ActionResult<Character> GetSingle(int id) 
        {
            return Ok(Characters.FirstOrDefault(c => c.id == id));
        }
    }
}