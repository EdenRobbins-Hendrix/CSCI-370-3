using UnityEngine;

public class TitleTransition : MonoBehaviour
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
        Initiate.Fade("Title", Color.black, 1);
    }

}
