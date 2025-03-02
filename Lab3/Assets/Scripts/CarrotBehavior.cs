using Unity.VisualScripting;
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
        if (collision.rigidbody.CompareTag("Player")) {
            effect.Play();
            manager.GetCarrot();
            if (timer.IsUnityNull()) {
                timer = GameObject.FindWithTag("Timer").GetComponent<CustomTimer>();
            }
            timer.Tick(goalTime, self);
            self.SetActive(false);

        }
    }

    public void UpdateTimer(CustomTimer newTimer) {
        timer = newTimer;
    }

}
