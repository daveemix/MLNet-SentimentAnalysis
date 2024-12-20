using Microsoft.AspNetCore.Mvc;
using SentimentAnalysisAPI.Services;

namespace SentimentAnalysisAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SentimentController : ControllerBase
    {
        private readonly SentimentAnalysisService _sentimentService;

        public SentimentController(SentimentAnalysisService sentimentService)
        {
            _sentimentService = sentimentService;
        }

        [HttpPost("analyze")]
        public IActionResult Analyze([FromBody] string text)
        {
            var prediction = _sentimentService.Predict(text);
            return Ok(new
            {
                Text = text,
                Prediction = prediction.Prediction ? "Positive" : "Negative",
                Probability = prediction.Probability,
                Score = prediction.Score
            });
        }
    }
}
