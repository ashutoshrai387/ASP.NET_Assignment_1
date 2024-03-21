using Microsoft.AspNetCore.Mvc;
using Assignment_1.Models;
using Assignment_1.Data;
using System.Collections.Generic;

namespace Assignment_1.Controllers
{
    
        [ApiController]
        [Route("[controller]")]
        public class KeyValueController : ControllerBase
        {
            private readonly KeyValueDbContext _context;

            public KeyValueController(KeyValueDbContext context)
            {
                _context = context;
            }

            [HttpGet("{key}")]
            public IActionResult Get(string key)
            {
                var keyValueItem = _context.KeyValuePairs.FirstOrDefault(x => x.Key == key);
                if (keyValueItem == null)
                    return NotFound();

                return Ok(keyValueItem);
            }
            [HttpPost]
            [HttpPut]
            public IActionResult PostOrPut([FromBody] KeyValue keyValuePair)
            {
                var existingItem = _context.KeyValuePairs.FirstOrDefault(x => x.Key == keyValuePair.Key);
                if (existingItem != null)
                    return Conflict("Key already exists");

                _context.KeyValuePairs.Add(keyValuePair);
                _context.SaveChanges();

                return CreatedAtAction(nameof(Get), new { key = keyValuePair.Key }, keyValuePair);
            }

            [HttpPatch("{key}")]
            public IActionResult Patch(string key, [FromBody] string value)
            {
                var keyValueItem = _context.KeyValuePairs.FirstOrDefault(x => x.Key == key);
                if (keyValueItem == null)
                    return NotFound();

                keyValueItem.Value = value;
                _context.SaveChanges();

                return NoContent();
            }

            [HttpDelete("{key}")]
            public IActionResult Delete(string key)
            {
                var keyValueItem = _context.KeyValuePairs.FirstOrDefault(x => x.Key == key);
                if (keyValueItem == null)
                    return NotFound();

                _context.KeyValuePairs.Remove(keyValueItem);
                _context.SaveChanges();

                return NoContent();
            }
        }
    
}

