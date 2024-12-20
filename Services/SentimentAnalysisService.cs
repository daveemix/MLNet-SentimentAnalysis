using System.IO;
using Microsoft.ML;
using SentimentAnalysisAPI.Models;

namespace SentimentAnalysisAPI.Services
{
    public class SentimentAnalysisService
    {
        private readonly MLContext _context;
        private readonly ITransformer _model;

        public SentimentAnalysisService()
        {
            _context = new MLContext();
            _model = _context.Model.Load(Path.Combine(Directory.GetCurrentDirectory(), "Data", "sentiment_model.zip"), out _);
        }

        public SentimentPrediction Predict(string text)
        {
            var predictionEngine = _context.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(_model);
            var input = new SentimentData { Text = text };
            return predictionEngine.Predict(input);
        }
    }
}
