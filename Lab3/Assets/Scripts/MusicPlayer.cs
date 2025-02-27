using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
       public AudioClip secondClip;
    void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

    public static MusicPlayer Instance { get; private set; }

    public void ToPlaySpace() {
        Instance.GetComponent<AudioSource>().clip = secondClip;
        Instance.GetComponent<AudioSource>().Play();
        Instance.GetComponent<AudioSource>().volume = 0.55f;
    }
}
