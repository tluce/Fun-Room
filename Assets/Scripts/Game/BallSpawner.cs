using UnityEngine;

/// <summary>
/// Spawn tennis balls
/// </summary>
public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject m_BallPrefab;

    private const float BallYBound = 0.17f;
    private const float CheckBallDelay = 5;
    private float elapsedTime = 0;

    public void Spawn()
    {
        Instantiate(m_BallPrefab, transform.position, m_BallPrefab.transform.rotation);
    }

    private void Update()
    {
        if (elapsedTime < CheckBallDelay)
        {
            elapsedTime += Time.deltaTime;
        }
        else
        {
            elapsedTime = 0;

            Ball ball = FindObjectOfType<Ball>();

            // Spaw a ball if there's none or it's no longer inside the room
            if (ball == null || ball.gameObject.transform.position.y < BallYBound)
            {                
                if (ball != null)
                {
                    Destroy(ball.gameObject);
                }

                Spawn();
            }
        }
    }
}
