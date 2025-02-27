using UnityEngine;

public class TimerCustom : MonoBehaviour
{
    bool ticking = false;
    float goalTime;
    GameObject waiter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (ticking) {
            goalTime -= Time.deltaTime;
            if (goalTime <= 0) {
                ticking = false;
                Invoke("EndTick", 0.1f);
            }
        }
    }
    public void Tick(float goalTime, GameObject waiter) {
        this.goalTime = goalTime;
        this.waiter = waiter;
        ticking = true;

    }

    void EndTick() {
        Debug.Log("Ding!");
        waiter.SetActive(true);
    }
}
