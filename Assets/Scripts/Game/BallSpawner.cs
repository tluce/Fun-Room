using UnityEngine;

/// <summary>
/// Spawn tennis balls
/// </summary>
public class BallSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Vector3 spawnPosition;

    public void Spawn()
    {
        Instantiate(ballPrefab, spawnPosition, ballPrefab.transform.rotation);
    }
}
