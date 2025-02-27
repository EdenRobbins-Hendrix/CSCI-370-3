using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI collectionCount;
    int collected;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        collected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Collect() {
        collected++;
        collectionCount.text = "Babies: " + collected + "/20";
    }
}
