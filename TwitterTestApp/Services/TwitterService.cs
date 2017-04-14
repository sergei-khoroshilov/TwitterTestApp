using LinqToTwitter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterTestApp.Mappers;
using TwitterTestApp.Models;

namespace TwitterTestApp.Services
{
    public class TwitterService
    {
        private readonly TwitterConfig config;
        private readonly ObjectMapper mapper;

        public TwitterService(TwitterConfig config, ObjectMapper mapper)
        {
            this.config = config;
            this.mapper = mapper;
        }

        public async Task<List<Twit>> GetLastTwitsAsync(string query, int maxCount)
        {
            var twits = new List<Twit>();

            var auth = new ApplicationOnlyAuthorizer
            {
                CredentialStore = new InMemoryCredentialStore()
                {
                    ConsumerKey = config.ConsumerKey,
                    ConsumerSecret = config.ConsumerSecret
                }
            };

            await auth.AuthorizeAsync();

            using (var twitterCtx = new TwitterContext(auth))
            {
                Search searchResult = await twitterCtx.Search
                                                      .Where(s => s.Type == SearchType.Search
                                                               && s.Query == query
                                                               && s.Count == maxCount)
                                                      .FirstOrDefaultAsync();

                if (searchResult == null)
                {
                    return twits;
                }

                foreach (var status in searchResult.Statuses)
                {
                    var twit = mapper.Map<Status, Twit>(status);
                    twits.Add(twit);
                }
            }

            return twits;
        }
    }
}
