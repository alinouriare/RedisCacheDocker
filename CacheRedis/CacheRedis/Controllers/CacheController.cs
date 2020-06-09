using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CacheRedis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacheController : ControllerBase
    {
        private readonly IDatabase _database;

        public CacheController(IDatabase database)
        {
            _database = database;
        }
        [HttpGet]
        //https://localhost:5001/api/cache?key=mykey
        public string Get([FromQuery]string key)
        {
            return _database.StringGet(key);
        }

        [HttpPost]
        public void Post([FromBody] KeyValuePair<string,string> keyValue)
        {
            _database.StringSet(keyValue.Key,keyValue.Value);
        }

       
    }
}
