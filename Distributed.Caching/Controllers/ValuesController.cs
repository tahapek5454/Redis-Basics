using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace Distributed.Caching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IDistributedCache _distributedCache;

        public ValuesController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }


        [HttpPost("{name}")]
        public async Task<IActionResult> Post([FromRoute] string name) 
        {
            // absolute ve slide configurasyonlarini da 3. parametere olarak verelim
            await _distributedCache.SetStringAsync("name", name, new DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = DateTime.UtcNow.AddSeconds(30),
                SlidingExpiration = TimeSpan.FromSeconds(5)

            });

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var value = await _distributedCache.GetStringAsync("name");

            return Ok(value);
        }
    }
}
