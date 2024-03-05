using Azure.AI.TextAnalytics;
using Azure.AI.TextAnalytics.Models;
using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticKernelDemo
{
    public class MyAnalyzer
    {

        public void Init() 
        {
            //Uri endpoint, TokenCredential credential
            var uri = new Uri("Your Endpoint");
            var credentials = new TokenCredential(); //new ApiKeyServiceClientCredentials("Your Subscription Key");
            var client = new TextAnalyticsClient(uri, credentials);

            var input = new MultiLanguageBatchInput(
                new List<MultiLanguageInput>()
                {
                    new MultiLanguageInput("en", "1", "The hotel was dark and uninviting.")
                });

            var result = client.AnalyzeSentimentAsync(false, input).Result;

            foreach (var document in result.Documents)
            {
                Console.WriteLine($"Document ID: {document.Id} , Sentiment Score: {document.Score:0.00}");
            }
        }
    }
}
