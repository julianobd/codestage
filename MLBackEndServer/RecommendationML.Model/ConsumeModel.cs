// This file was auto-generated by ML.NET Model Builder. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.ML;
using RecommendationML.Model;

namespace RecommendationML.Model
{
    public class ConsumeModel
    {
        private static Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictionEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(CreatePredictionEngine);

        public static string MLNetModelPath = Path.GetFullPath("MLModel.zip");

        // For more info on consuming ML.NET models, visit https://aka.ms/mlnet-consume
        // Method for consuming model in your app
        public static ModelOutput Predict(ModelInput input)
        {
            ModelOutput result = PredictionEngine.Value.Predict(input);
            return result;
        }

        public static List<Tuple<ModelInput, ModelOutput>> Predict(List<ModelInput> lstInput)
        {
            var lstOutput = new List<Tuple<ModelInput, ModelOutput>>();
            foreach (var input in lstInput)
            {
                ModelOutput result = PredictionEngine.Value.Predict(input);
                lstOutput.Add(Tuple.Create(input, result));
            }
            return lstOutput;

        }

        public static PredictionEngine<ModelInput, ModelOutput> CreatePredictionEngine()
        {
            // Create new MLContext
            MLContext mlContext = new MLContext();

            // Load model & create prediction engine
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var modelInputSchema);
            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);

            return predEngine;
        }
    }
}