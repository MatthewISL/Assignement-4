using FootballPlayerProject;
using Microsoft.AspNetCore.Mvc;

namespace Assignement_4
{
    public class FootballPlayersController : ControllerBase
    {
        private readonly FootballPlayersManager _manager;

        public FootballPlayersController(FootballPlayersManager manager)
        {
            _manager = manager;
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<FootballPlayer>> GetAll()
        {
            IEnumerable<FootballPlayer> result = new List<FootballPlayer>();
            result = _manager.GetAll();
            
            if (result.Count().Equals(0))
            {
                return NotFound("No such class, list empty");
            }
            Response.Headers.Add("totalAmount", result.Count().ToString());

            return Ok(result);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<FootballPlayer> GetById(int id)
        {
            FootballPlayer footballPlayer = _manager.GetById(id);
            if(footballPlayer == null)
            {
                return NotFound("No such class, id: " + id);
                
            }
            return Ok(footballPlayer);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpPost]
        public ActionResult<FootballPlayer> Post(FootballPlayer value)
        {
                FootballPlayer player = _manager.Add(value);
                if (value == null) return Conflict("Can't add empty");
                return Created("/api/FootballPlayers/" + value.Id, value);
        }
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status405MethodNotAllowed)]
        [HttpPut("{id}")]
        public ActionResult<FootballPlayer> Put(int id, FootballPlayer value)
        {
            _manager.Update(id, value);
            foreach (var n in _manager.GetAll())
            {
                if (id != n.Id) return NotFound("Id doesn't exist");
            }
            return NoContent();
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<FootballPlayer> Delete(int id)
        {
            FootballPlayer player = _manager.Delete(id);

            if (player == null) return NotFound("Id doesn't exist");

            return Ok();
        }

    }
}
