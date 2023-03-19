using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemoryCaching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //IMemoryCache interface!inden yararlanacagiz
        private readonly IMemoryCache _memoryCache;
        public ValuesController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        //[HttpPost("{name}")]
        //public void Post([FromRoute] string name)
        //{
        //    _memoryCache.Set("name", name);

        //}

        //[HttpGet]
        //public string Get()
        //{
        //    if(_memoryCache.TryGetValue<string>("name", out string name)) return name;
        //    return "";
        //}

        [HttpPost]
        public void SetDate()
        {
            _memoryCache.Set<DateTime>("date", DateTime.Now, options: new()
            {
                // kesin kalma degeri 30 sn fakat islem yapilirsa 3 sn 3 sn arttir
                AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(30),
                SlidingExpiration = TimeSpan.FromSeconds(3)
            });

        }

        [HttpGet]
        public DateTime GetDate()
        {
            return _memoryCache.Get<DateTime>("date");  

        }


    }
}
