using UnityEngine;

/// <summary>
/// Play success and failure sound effects
/// </summary>
public class SoundEffects : MonoBehaviour
{
    [SerializeField] private AudioClip m_SuccessClip;
    [SerializeField] private AudioClip m_FailureClip;

    public void PlaySuccess()
    {
        GetComponent<AudioSource>().PlayOneShot(m_SuccessClip);
    }

    public void PlayFailure()
    {
        GetComponent<AudioSource>().PlayOneShot(m_FailureClip);
    }
}
