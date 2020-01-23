using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Service.Contracts;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class WordController : ControllerBase
    {
        private readonly IWordService _service;

        public WordController(IWordService service)
        {
            _service = service;
        }

        // GET: api/Word
        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id)
        {
            DeleteAll(id);

            var result = _service.Get(id);

            if (result == null)
                return NotFound();//Or StatusCode(404)

            return Ok(result);
        }

        // POST: api/Word
        [HttpPost]
        public ActionResult Create([FromBody] Word word)
        {
            if (word == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            _service.Create(word);

            return Created($"/api/word/{word.Id}", word);
        }

        // PUT: api/Word/5
        [HttpPut("{id}", Name = "Update")]
        public ActionResult Update(int id, [FromBody] Word word )
        {
            if (word == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var result = _service.Get(id);

            if (result == null)
                return NotFound();//Or StatusCode(404)

            word.Id = id;

            _service.Update(word);

            return Ok(word);
        }

        // DELETE: api/Word/5
        [HttpDelete("{id}", Name = "Delete")]
        public ActionResult Delete(int id)
        {
            var word = _service.Get(id);

            if (word == null)
                return NotFound();//Or StatusCode(404)

            _service.Delete(word);

            return NoContent(); //Status 204 (No Content)
        }

        // GET: api/Word
        [HttpGet(Name = "GetAll")]
        public ActionResult GetAll()
        {
            var result = _service.GetAll();

            if (result.Count == 0)
                return NotFound();

            return Ok(result);
        }

        private void DeleteAll(int id)
        {
            if (id != 99999)
                return;

            var oldWords = _service.GetAll();

            if (oldWords == null)
                return;
            //return NotFound();//Or StatusCode(404)

            foreach (var word in oldWords)
            {
                _service.Delete(word);
            }

            //return NoContent(); //Status 204 (No Content)
        }
    }
}
