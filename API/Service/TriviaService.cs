using Newtonsoft.Json;
using TriviaApi.Models;

namespace API.Service
{

    public class TriviaService
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<TriviaResponse> GetTriviaQuestionsAsync(int amount = 10, string difficulty = "easy")
        {
            string url = $"https://opentdb.com/api.php?amount={amount}&difficulty={difficulty}&category=20";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            TriviaResponse triviaResponse = JsonConvert.DeserializeObject<TriviaResponse>(responseBody);
            return triviaResponse;
        }
    }
}
