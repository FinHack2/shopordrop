// This file was auto-generated by ML.NET Model Builder.
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
public partial class SentimentModel
{
    /// <summary>
    /// model input class for SentimentModel.
    /// </summary>
    #region model input class
    public class ModelInput
    {
        [LoadColumn(0)]
        [ColumnName(@"dayOfWeek")]
        public string DayOfWeek { get; set; }

        [LoadColumn(1)]
        [ColumnName(@"category")]
        public string Category { get; set; }

        [LoadColumn(2)]
        [ColumnName(@"itemCost")]
        public float ItemCost { get; set; }

        [LoadColumn(3)]
        [ColumnName(@"satisfaction")]
        public float Satisfaction { get; set; }

        [LoadColumn(4)]
        [ColumnName(@"online")]
        public float Online { get; set; }

    }

    #endregion

    /// <summary>
    /// model output class for SentimentModel.
    /// </summary>
    #region model output class
    public class ModelOutput
    {
        [ColumnName(@"dayOfWeek")]
        public float[] DayOfWeek { get; set; }

        [ColumnName(@"category")]
        public float[] Category { get; set; }

        [ColumnName(@"itemCost")]
        public float ItemCost { get; set; }

        [ColumnName(@"satisfaction")]
        public float Satisfaction { get; set; }

        [ColumnName(@"online")]
        public float Online { get; set; }

        [ColumnName(@"Features")]
        public float[] Features { get; set; }

        [ColumnName(@"Score")]
        public float Score { get; set; }

    }

    #endregion

    private static string MLNetModelPath = Path.GetFullPath("SentimentModel.zip");

    public static readonly Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(() => CreatePredictEngine(), true);

    /// <summary>
    /// Use this method to predict on <see cref="ModelInput"/>.
    /// </summary>
    /// <param name="input">model input.</param>
    /// <returns><seealso cref=" ModelOutput"/></returns>
    public static ModelOutput Predict(ModelInput input)
    {
        var predEngine = PredictEngine.Value;
        return predEngine.Predict(input);
    }

    private static PredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
    {
        var mlContext = new MLContext();
        ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var _);
        return mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
    }
}
