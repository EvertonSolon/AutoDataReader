using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Service.Contracts;

namespace WebApi.Controllers
{
    [Route("api/word")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private readonly IWordService _services;

        public WordController(IWordService service)
        {
            _services = service;
        }

        // GET: api/Word
        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id)
        {
            var result = _services.Get(id);

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

            _services.Create(word);

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

            var result = _services.Get(id);

            if (result == null)
                return NotFound();//Or StatusCode(404)

            word.Id = id;

            _services.Update(word);

            return Ok(word);
        }

        // DELETE: api/Word/5
        [HttpDelete("{id}", Name = "Delete")]
        public ActionResult Delete(int id)
        {
            var word = _services.Get(id);

            if (word == null)
                return NotFound();//Or StatusCode(404)

            _services.Delete(word);

            return NoContent(); //Status 204 (No Content)
        }

        // GET: api/Word
        [HttpGet(Name = "GetAll")]
        public ActionResult GetAll()
        {
            var result = _services.GetAll();

            if (result.Count == 0)
                return NotFound();

            return Ok(result);
        }
    }
}
