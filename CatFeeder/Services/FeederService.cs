using CatFeeder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatFeeder.Services
{
    public class FeederService
    {
        List<FeedResponse> feedResponse = new ();
        public async Task<List<FeedResponse>> GetFeedResponse()
        {
            return feedResponse;
        }
    }
}
