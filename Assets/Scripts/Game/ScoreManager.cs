using System;
using System.IO;
using UnityEngine;

/// <summary>
/// Load and save the best score in a file
/// </summary>
public static class ScoreManager
{
    private const string BestScoreFileName = "bestScore.json";

    /// <summary>
    /// Reads the best score from file
    /// </summary>
    /// <returns>The best score</returns>
    public static int GetBestScore()
    {
        string path = GetBestScoreFilePath();
        int bestScoreValue = 0;

        if (File.Exists(path))
        {
            BestScore bestScore = JsonUtility.FromJson<BestScore>(File.ReadAllText(path));
            bestScoreValue = bestScore.Value;
        }

        return bestScoreValue;
    }

    /// <summary>
    /// Saves the best score in a file
    /// </summary>
    /// <param name="bestScoreValue">The new best score value</param>
    public static void SaveBestScore(int bestScoreValue)
    {
        BestScore bestScore = new BestScore(bestScoreValue);
        File.WriteAllText(GetBestScoreFilePath(), JsonUtility.ToJson(bestScore));
    }

    private static string GetBestScoreFilePath()
    {
        return Path.Combine(Application.persistentDataPath, BestScoreFileName);
    }

    [Serializable]
    private struct BestScore
    {
        [SerializeField] private int m_value;

        public BestScore(int value)
        {
            m_value = value;
        }

        public int Value
        {
            get { return m_value; }
        }
    }

}
