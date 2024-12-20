# Sentiment Analysis API

This project is an API built using ASP.NET Core and ML.NET to perform sentiment analysis on text input. The API uses a pre-trained machine learning model to classify text as either "Positive" or "Negative."

 Features

- Text Sentiment Analysis: Classify text as positive or negative sentiment using a trained machine learning model.
- ML.NET Integration: Uses the ML.NET framework for model training and prediction.
- RESTful API: The API exposes a POST endpoint to analyze sentiment based on user input.

 Technologies Used

- ASP.NET Core: For building the web API.
- ML.NET: For training and using the machine learning model.
- C#: Programming language used for the application.
- CSV Data: A sample dataset for training the sentiment analysis model.

 Project Structure

- Controllers/SentimentController.cs: The controller that handles requests to the API.
- Services/SentimentAnalysisService.cs: The service that loads the pre-trained sentiment analysis model and performs predictions.
- Services/SentimentModelBuilder.cs: The service responsible for training the sentiment analysis model using a CSV dataset.
- Models/SentimentData.cs: The model representing the input and output data for the sentiment analysis.
- Data/sentimentdata.csv: The training data used for building the sentiment model.
- Data/sentiment_model.zip: The pre-trained sentiment analysis model.

 Setup Instructions

# Prerequisites

Before you begin, make sure you have the following installed on your machine:

- .NET SDK (6.0 or above)
- Visual Studio or any other IDE that supports C# development
- ML.NET NuGet package for machine learning functionality

# Steps to Run the Project

1. Clone the repository:

   bash
   git clone https://github.com/daveemix/MLNet-SentimentAnalysis.git
   cd MLNet-SentimentAnalysis
   

2. Install the required dependencies:

   In the project directory, run:

   bash
   dotnet restore
   

3. Train the model (optional):
   
   If you need to train the model, run the `SentimentModelBuilder` class:

   bash
   dotnet run --project SentimentAnalysisAPI
   

   This will load the training data (`sentimentdata.csv`), train the model, and save it as `sentiment_model.zip` in the `Data` folder.

4. Run the API:

   Once the model is ready, run the API:

   bash
   dotnet run
   

   The API will start running on `http://localhost:5000`.

# Using the API

To use the sentiment analysis endpoint, send a POST request to:

http
POST http://localhost:5000/api/sentiment/analyze


Request Body:

json
{
    "text": "I love this product!"
}


Response:

json
{
    "Text": "I love this product!",
    "Prediction": "Positive",
    "Probability": 0.98,
    "Score": 1.0
}


- Prediction: The sentiment classification ("Positive" or "Negative").
- Probability: The probability score of the prediction.
- Score: The raw score of the prediction.

 Model Evaluation

After training, the model is evaluated using the test data, and the following metrics are displayed:

- Accuracy: The proportion of correct predictions.
- AUC: Area under the ROC curve.
- F1 Score: A balance between precision and recall.

 Contributing

Contributions to this project are welcome. If you'd like to improve or extend the functionality, feel free to fork the repository and create a pull request.

 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
