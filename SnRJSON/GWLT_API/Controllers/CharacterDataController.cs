using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GWLT_API.Models;

namespace GWLT_API.Controllers
{
    public class CharacterDataController : ApiController
    {
        Character[] players = new Character[]
        {
            new Character { id = 1, name = "Geroam", xCoord = 10.4f, yCoord = 17.8f, zCoord = 1.0f},
            new Character { id = 2, name = "Snappey", xCoord = 12.8f, yCoord = 13.9f, zCoord = 1.0f},
        };

        public IEnumerable<Character> GetAllCharacters ()
        {
            return players;
        }

        public IHttpActionResult GetCharacter (int id)
        {
            var character = players.FirstOrDefault((c) => c.id == id);

            if (character == null)
            {
                return NotFound();
            }
            return Ok(character);
        }
        
        public Character
    }
}
