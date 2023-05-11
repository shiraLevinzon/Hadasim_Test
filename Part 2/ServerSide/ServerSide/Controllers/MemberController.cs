using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerSide.Data;
using ServerSide.Models;

namespace ServerSide.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly DataAccess _dataAccess;

        public MemberController()
        {
            _dataAccess = new DataAccess("Data Source=DESKTOP-G3GOK72;Initial Catalog=Hadasim;Integrated Security=True");
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Member>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            try
            {
                var mems = _dataAccess.GetMembers();
                if (mems.Count == 0) { return Ok("there is no members"); }
                return Ok(mems);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }



        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Member), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            try
            {
                var mem = _dataAccess.GetMemberById(id);
                if (mem == null) { return Ok("the member not found"); }
                return Ok(mem);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpGet("getVaccinesById/{id}")]
        [ProducesResponseType(typeof(IEnumerable<Vaccine>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetVaccinesById(int id)
        {
            try
            {
                var vacs = _dataAccess.GetVaccines(id);
                if (vacs.Count == 0) { return Ok("there is no vacs to this member"); }
                return Ok(vacs);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Create(Member member)
        {
            try
            {
                _dataAccess.AddMember(member);
                return CreatedAtAction(nameof(Create), new { id = member.Id }, member);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("AddVaccine")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AddVaccine(Vaccine vaccine)
        {
            try
            {
                _dataAccess.AddVaccine(vaccine);
                return CreatedAtAction(nameof(AddVaccine), new { id = vaccine.Id }, vaccine);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
