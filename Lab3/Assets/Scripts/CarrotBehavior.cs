using UnityEngine;

public class CarrotBehavior : MonoBehaviour
{
    public GameObject self;
    public GameManager manager;
    public AudioSource effect;
    float goalTime = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Who's there!");
        if (collision.rigidbody.CompareTag("Player")) {
            effect.Play();
            Debug.Log("Predator!");
            self.SetActive(false);
            manager.GetCarrot();
            StartCoroutine("Tick");
        }
    }

    void Tick() {
        if (goalTime <= 0) {
            EndTick();
        }
        else {
            goalTime -= Time.deltaTime;
        }
    }
    void EndTick () {
        StopCoroutine("Tick");
        goalTime = 10;
        self.SetActive(true);
    }
}
