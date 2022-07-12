using UnityEngine;

/// <summary>
/// Detect when a ball collides with the game object
/// </summary>
public class BallDetector : MonoBehaviour
{
    [SerializeField] private string ballTagName;

    private BallSpawner ballSpawner;

    // Play a sound when a ball collides with the game object
    private AudioSource ballInsideAS;
    
    void Awake()
    {
        ballInsideAS = GetComponent<AudioSource>();
        ballSpawner = FindObjectOfType<BallSpawner>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(ballTagName))
        {
            ballInsideAS.PlayOneShot(ballInsideAS.clip);
            Destroy(other.gameObject);
            ballSpawner.Spawn();
        }
    }
}
