using Unity.VisualScripting;
using UnityEngine;

public class MainCamera : MonoBehaviour
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

    public static MainCamera Instance { get; private set; }

    public void ToPlaySpace() {
        Instance.GetComponent<AudioSource>().clip = secondClip;
    }

}
