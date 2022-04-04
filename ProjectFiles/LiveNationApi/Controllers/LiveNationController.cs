using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using RuleResponseGenerator;

namespace LiveNationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LiveNationAPI : ControllerBase
    {
        private readonly IMemoryCache _cache;

        public LiveNationAPI(IMemoryCache memoryCache) {
            this._cache = memoryCache;
        }

        [HttpGet]
        public string Get() {
            return "To use this api add /number,number at the end of the URL e.g. https://localhost:44393/LiveNationAPI/1,20";
        }

        [HttpGet("{id}")]
        public JsonResult GetQuery(string id) {

            Entry existingItem;

            if (id == null) {
                string error = "Your arguments were not defined. To use this api add /number,number at the end of the URL e.g. https://localhost:44393/LiveNationAPI/1,20";
                return new JsonResult(error);
            }

            if (_cache.TryGetValue(id, out existingItem)) {
                return new JsonResult(existingItem.CreateResponse(id));
            } else {
                existingItem = new Entry();
                _cache.Set(id, existingItem);
                return new JsonResult(existingItem.CreateResponse(id));
            }
        }

    }
}
