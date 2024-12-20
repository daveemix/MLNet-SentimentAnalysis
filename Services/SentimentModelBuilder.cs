using System.IO;
using Microsoft.ML;
using SentimentAnalysisAPI.Models;

namespace SentimentAnalysisAPI.Services
{
    public class SentimentModelBuilder
    {
        private static readonly string TrainingDataPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "sentimentdata.csv");
        private static readonly string ModelPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "sentiment_model.zip");

        public static void TrainModel()
        {
            var context = new MLContext();

            // Load data
            var data = context.Data.LoadFromTextFile<SentimentData>(
                path: TrainingDataPath,
                hasHeader: true,
                separatorChar: ',');

            // Split data
            var split = context.Data.TrainTestSplit(data, testFraction: 0.2);

            // Build pipeline
            var pipeline = context.Transforms.Text.FeaturizeText("Features", nameof(SentimentData.Text))
                .Append(context.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Label", featureColumnName: "Features"));

            // Train the model
            var model = pipeline.Fit(split.TrainSet);

            // Evaluate the model
            var metrics = context.BinaryClassification.Evaluate(model.Transform(split.TestSet), labelColumnName: "Label");
            Console.WriteLine($"Accuracy: {metrics.Accuracy:P2}");
            Console.WriteLine($"AUC: {metrics.AreaUnderRocCurve:P2}");
            Console.WriteLine($"F1 Score: {metrics.F1Score:P2}");

            // Save the model
            context.Model.Save(model, split.TrainSet.Schema, ModelPath);
        }
    }
}
