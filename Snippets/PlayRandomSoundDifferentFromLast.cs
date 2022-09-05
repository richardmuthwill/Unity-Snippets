using UnityEngine;

public class PlayRandomSoundDifferentFromLast : MonoBehaviour
{
    [SerializeField] AudioClip[] soundClips;
    [SerializeField] AudioSource audioSource;

    int listIndex = 0;

    // Play a sound clip that is different from the last
    public void PlayRandomClip ()
    {
        listIndex = (listIndex + Random.Range(1, soundClips.Count-1)) % soundClips.Count;

        audioSource.clip = soundClips[listIndex];
        audioSource.Play();
    }
}
