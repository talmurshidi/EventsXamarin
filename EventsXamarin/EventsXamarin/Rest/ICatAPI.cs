using Refit;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EventsXamarin.Rest
{
    public interface ICatAPI
    {
        [Get("/facts/random?animal_type=cat&amount=40")]
        Task<HttpResponseMessage> CatFactsAsync();
    }
}
