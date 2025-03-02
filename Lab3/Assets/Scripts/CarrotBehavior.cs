using UnityEngine;

public class CarrotBehavior : MonoBehaviour
{
    public GameObject self;
    public GameManager manager;
    public AudioSource effect;
    float goalTime = 10;
     CustomTimer timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = GameObject.FindWithTag("Timer").GetComponent<CustomTimer>();
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
            manager.GetCarrot();
            timer.Tick(goalTime, self);
            self.SetActive(false);

        }
    }
}
