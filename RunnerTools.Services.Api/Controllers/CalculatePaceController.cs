using RunnerTools.Converters;
using RunnerTools.Core;
using System.Web.Http;

namespace RunnerTools.Services.Api.Controllers
{
    public struct PaceModel
    {
        public int Minutes { get; set; }
        public int Seconds { get; set; }
    }

    [RoutePrefix("api/pace/convert")]
    public class CalculatePaceController : ApiController
    {
        [HttpGet]
        [Route("from/km/{pace:datetime:regex(\\d{2}:\\d{2})}")]
        public IHttpActionResult FromKmToMiles(PaceModel paceModel)
        {
            if (paceModel.Minutes <= 0 || paceModel.Seconds <= 0)
            {
                return BadRequest("Minutes and/or seconds values have to be greater than 0");
            }

            var pace = RunningPace.MinPerKmToMinPerMile(new Pace(paceModel.Minutes, paceModel.Seconds));
            return Ok(pace.ToString());
        }

        [HttpGet]
        [Route("from/miles")]
        public IHttpActionResult FromMilesToKm(int min, int sec)
        {
            if (min <= 0 || sec <= 0)
            {
                return BadRequest("Minutes and/or seconds values have to be greater than 0");
            }

            var pace = RunningPace.MinPerMileToMinPerKm(new Pace(min, sec));
            return Ok(pace.ToString());
        }
    }
}
