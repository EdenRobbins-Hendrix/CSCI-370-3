using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI collectionCount;
    public TextMeshProUGUI carrotCount;
    int collected;
    public int carrots;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnAwake() {
        
    }
    void Start()
    {
        collected = 0;
        carrots = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
