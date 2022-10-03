using FootballApi.Managers;
using MandatoryAssignmnt1;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FootballApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FootballPlayersController : ControllerBase
    {
        private readonly FootballPlayersManager _manager = new FootballPlayersManager();
        // GET: api/<FootballPlayersController>
        [HttpGet]
        public IEnumerable<FootballPlayer> Get()
        {
            return _manager.GetAll();
        }

        // GET api/<FootballPlayersController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<FootballPlayer> Get(int id)
        {
            FootballPlayer player = _manager.GetById(id);
            if (player == null) return NotFound("No player with the id: " + id);
            return Ok(player);
        }

        // POST api/<FootballPlayersController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [HttpPost]
        public ActionResult<FootballPlayer> Post([FromBody] FootballPlayer value)
        {
            if (_manager.GetAll().Select(v => v.ShirtNumber).Equals(value.ShirtNumber))
                return Conflict("Aplayer with that shirt number already exists");
            _manager.Add(value);
            return Created($"api/FootballPlayer/{value.Id}", value);

        }

        // PUT api/<FootballPlayersController>/5
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<FootballPlayer> Put(int id, [FromBody] FootballPlayer value)
        {
            if (_manager.GetAll().Select(v => v.Id).Contains(id))
            {
                if (!_manager.GetAll().Select(v => v.ShirtNumber).Contains(value.ShirtNumber))
                {
                    _manager.Update(id, value);
                    return Accepted("Object updated");
                }
                return BadRequest("A player with that shirt number already exists");
            }
            else
                return NotFound();
        }

        // DELETE api/<FootballPlayersController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<FootballPlayer> Delete(int id)
        {
            if (_manager.Delete(id) == null) return NotFound("No such player");
            return Ok("player deleted");
        }
    }
}
