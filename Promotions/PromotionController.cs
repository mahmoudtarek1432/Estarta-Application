using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Promotions
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController
    {
        [HttpGet]
        public IActionResult get()
        {
            throw new NotImplementedException();
        }
    }
}
