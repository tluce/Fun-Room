using UnityEngine;
using TMPro;
using System.Collections.Generic;

/// <summary>
/// Updates the score.
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject m_InstructionsBackground;
    [SerializeField] private GameObject m_ScoreBackground;
    [SerializeField] private TextMeshProUGUI m_ScoreText;
    [SerializeField] private SoundEffects m_SoundEffects;

    private const float ThrowDistanceEasy = 1;
    private const float ThrowDistanceMedium = 2;
    private const float ThrowDistanceHard = 3;

    private Dictionary<float, int> throwPoints;

    private int m_ScoreValue = 0;

    private void Awake()
    {
        // Set throw point values
        throwPoints = new Dictionary<float, int>();
        throwPoints.Add(ThrowDistanceEasy, 1);
        throwPoints.Add(ThrowDistanceMedium, 2);
        throwPoints.Add(ThrowDistanceHard, 5);
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
                points = throwPoints[ThrowDistanceHard];
            }
            else if (throwDistance >= ThrowDistanceMedium)
            {
                points = throwPoints[ThrowDistanceMedium];
            }
            else
            {
                points = throwPoints[ThrowDistanceEasy];
            }

            UpdateScore(points);

            m_SoundEffects.PlaySuccess();
        }

    }

    /// <summary>
    /// Updates the score
    /// </summary>
    /// <param name="points">Points to add</param>
    private void UpdateScore(int points)
    {
        m_InstructionsBackground.SetActive(false);
        m_ScoreValue+= points;
        m_ScoreText.text = $"Score: {m_ScoreValue}";
        m_ScoreBackground.SetActive(true);
    }
}
