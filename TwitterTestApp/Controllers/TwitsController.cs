using NLog;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using TwitterTestApp.Models;
using TwitterTestApp.Services;

namespace TwitterTestApp.Controllers
{
    public class TwitsController : Controller
    {
        private readonly ILogger logger = LogManager.GetCurrentClassLogger();

        private readonly TwitterService twitterService;
        private readonly TwitterSearchConfig searchConfig;

        public TwitsController(TwitterService twitterService, TwitterSearchConfig searchConfig)
        {
            this.twitterService = twitterService;
            this.searchConfig = searchConfig;
        }

        public async Task<ActionResult> Last()
        {
            ViewBag.Hashtag = searchConfig.HashTag;

            List<Twit> twits = await twitterService.GetLastTwitsAsync(searchConfig.HashTag, searchConfig.TwitsCount);

            logger.Info("{0} twits sent", twits.Count);

            return View(twits);
        }
    }
}
