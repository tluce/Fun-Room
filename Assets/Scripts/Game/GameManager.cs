using UnityEngine;
using TMPro;
using System.Collections.Generic;

/// <summary>
/// Handle throws and update the score
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject m_InstructionsBackground;
    [SerializeField] private GameObject m_ScoreBackground;
    [SerializeField] private TextMeshProUGUI m_ScoreText;
    [SerializeField] private SoundEffects m_SoundEffects;

    // Distance in meters
    private const float ThrowDistanceEasy = 1;
    private const float ThrowDistanceMedium = 2;
    private const float ThrowDistanceHard = 3;

    // Number of points per throw distance
    private Dictionary<float, int> m_ThrowPoints;

    private int m_ScoreValue = 0;
    private int m_BestScoreValue = 0;

    private void Awake()
    {
        InitPointValues();
        InitBestScore();
    }

    /// <summary>
    /// Checks if the ball throw is valid and update the score
    /// </summary>
    /// <param name="throwDistance">Distance between the throw position and the basket</param>
    public void HandleBallThrow(float throwDistance)
    {

        if (throwDistance < ThrowDistanceEasy)
        {
            m_SoundEffects.PlayFailure();
        }
        else
        {
            int points;
            if (throwDistance >= ThrowDistanceHard)
            {
                points = m_ThrowPoints[ThrowDistanceHard];
            }
            else if (throwDistance >= ThrowDistanceMedium)
            {
                points = m_ThrowPoints[ThrowDistanceMedium];
            }
            else
            {
                points = m_ThrowPoints[ThrowDistanceEasy];
            }

            UpdateScore(points);

            m_SoundEffects.PlaySuccess();
        }

    }

    /// <summary>
    /// Updates the score
    /// </summary>
    /// <param name="points">Points to add to the current score</param>
    private void UpdateScore(int points)
    {
        m_InstructionsBackground.SetActive(false);

        m_ScoreValue+= points;
        if (m_ScoreValue > m_BestScoreValue)
        {
            m_BestScoreValue = m_ScoreValue;
            ScoreManager.SaveBestScore(m_BestScoreValue);
        }
        m_ScoreText.text = GetScoreText();
        m_ScoreBackground.SetActive(true);
    }

    /// <summary>
    /// Initializes the m_ThrowPoints dictionary
    /// </summary>
    private void InitPointValues()
    {
        m_ThrowPoints = new Dictionary<float, int>();
        m_ThrowPoints.Add(ThrowDistanceEasy, 1);
        m_ThrowPoints.Add(ThrowDistanceMedium, 2);
        m_ThrowPoints.Add(ThrowDistanceHard, 5);
    }

    /// <summary>
    /// Initializes the best score value and text
    /// </summary>
    private void InitBestScore()
    {
        m_BestScoreValue = ScoreManager.GetBestScore();
        if (m_BestScoreValue > 0)
        {
            m_InstructionsBackground.SetActive(false);
            m_ScoreText.text = GetScoreText();
            m_ScoreBackground.SetActive(true);
        }
    }

    private string GetScoreText()
    {
        return $"Best Score: {m_BestScoreValue}\nScore: {m_ScoreValue}";
    }
}
