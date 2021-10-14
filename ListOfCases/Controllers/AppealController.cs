using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application;
using Database;

namespace ListOfCases.Controllers
{
    [Route("[controller]")]
    public class AppealController : Controller
    {
        private readonly ApplicationDbContext _ctx;

        public AppealController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet("")]
        public IActionResult GetAppeals() => Ok(new GetAppeals(_ctx).Do());

        [HttpPost("")]
        public async Task<IActionResult> CreateAppeal([FromBody] CreateAppeal.Request request) =>
            Ok(await new CreateAppeal(_ctx).Do(request));

        [HttpGet("{id}")]
        public IActionResult GetAppeal(int id) => Ok(new GetAppeal(_ctx).Do(id));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppeal(int id) => Ok(await new DeleteAppeal(_ctx).Do(id));

        [HttpPut("")]
        public async Task<IActionResult> UpdateAppeal([FromBody] UpdateAppeal.Request request) =>
            Ok(await new UpdateAppeal(_ctx).Do(request));
    }
}
