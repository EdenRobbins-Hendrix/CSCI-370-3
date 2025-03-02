using System.Linq.Expressions;
using UnityEngine;

public class CustomTimer : MonoBehaviour
{
    bool ticking;
    public GameObject waiter;
    public float goalTime;
    public GameObject self;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    ticking = false;
    self = gameObject;    
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
        if (!ticking){ 
        this.goalTime = goalTime;
        this.waiter = waiter;
        ticking = true;
        }
        else {
            GameObject next = MakeNewTimer();
            next.GetComponent<CustomTimer>().Tick(goalTime, waiter);
            self.tag = "Untagged"; 
        }
    }

    void EndTimer() {
        waiter.SetActive(true);
        if (self.CompareTag("Untagged")) {
            Destroy(self);
        }
        ticking = false;
    }

    GameObject MakeNewTimer() {
        GameObject go = Instantiate(self);
        return go;
    }
}
