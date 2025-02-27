using UnityEngine;

public class PlayTransition : MonoBehaviour
{
    public AudioSource effect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReactToClick() {
        effect.Play();
        Initiate.Fade("PlaySpace", Color.black, 1);
    }
}

