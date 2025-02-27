using UnityEngine;

public class CustomTimer : MonoBehaviour
{
    bool ticking;
    GameObject waiter;
    float goalTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    ticking = false;    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ticking) {
            goalTime -= Time.deltaTime;
            if (goalTime <= 0) {
                ticking = false;
                Invoke("EndTimer",0.1f);
            }
        }
    }

    public void Tick(float goalTime, GameObject waiter) {
        this.goalTime = goalTime;
        this.waiter = waiter;
        ticking = true;
    }

    void EndTimer() {
        waiter.SetActive(true);
    }
}
