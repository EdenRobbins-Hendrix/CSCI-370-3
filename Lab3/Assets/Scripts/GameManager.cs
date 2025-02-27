using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI collectionCount;
    public TextMeshProUGUI carrotCount;
    int collected;
    public int carrots;
    public MusicPlayer jb;
    bool winstate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnAwake() {

    }
    void Start()
    {
        jb = GameObject.FindWithTag("Respawn").GetComponent<MusicPlayer>();
        collected = 0;
        carrots = 0;
        winstate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (collected == 1 && !winstate) {
            winstate = true;
            Win();
        }
        
    }

    public void Collect() {
        collected++;
        collectionCount.text = "Babies: " + collected + "/20";
    }

    public void GetCarrot() {
        carrots++;
        carrotCount.text = "Carrot: " + carrots;
    }

    public void DecrementCarrot() {
        carrots--;
        carrotCount.text = "Carrot: " + carrots;
    }

    void Win() {
        Initiate.Fade("Congratulations", Color.black, 1.5f);
        jb.GetComponent<AudioSource>().Stop();
    }
}
