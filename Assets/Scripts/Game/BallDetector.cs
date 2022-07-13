using UnityEngine;

/// <summary>
/// Detect when a ball collides with the game object
/// </summary>
public class BallDetector : MonoBehaviour
{
    [SerializeField] private string m_BallTagName;

    private BallSpawner m_BallSpawner;

    private GameManager m_GameManager;

    // Position on the (X, Z) plane
    private Vector3 m_positionXZ;
    
    void Awake()
    {
        m_BallSpawner = FindObjectOfType<BallSpawner>();
        m_GameManager = FindObjectOfType<GameManager>();
        m_positionXZ = GetPositionXZ(transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(m_BallTagName))
        {
            Destroy(other.gameObject);
            m_BallSpawner.Spawn();

            Vector3 throwPosition = other.gameObject.GetComponent<Ball>().ThrowPosition;
            m_GameManager.HandleBallThrow(GetDistanceFromThrowYZ(throwPosition));
        }
    }

    /// <summary>
    /// Gets the distance from the throw position on the (X, Z) plane
    /// </summary>
    /// <param name="throwPosition">Position from where the distance is needed</param>
    /// <returns>Computed distance</returns>
    private float GetDistanceFromThrowYZ(Vector3 throwPosition)
    {
        Vector3 throwPositionXZ = GetPositionXZ(throwPosition);
        return (throwPositionXZ - m_positionXZ).magnitude;
    }

    /// <summary>
    /// Gets a position projected on the (X, Z) plane
    /// </summary>
    /// <param name="position">Position to project</param>
    /// <returns>Projected position</returns>
    private Vector3 GetPositionXZ(Vector3 position)
    {
        return new Vector3(position.x, 0, position.z);
    }
}
