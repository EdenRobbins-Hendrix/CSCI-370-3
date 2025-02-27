using Unity.VisualScripting;
using UnityEngine;

public class GetCollected : MonoBehaviour
{
    public GameObject self;
    public GameManager manager;
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
            manager.Collect();
            Destroy(self.GetComponent<SpriteRenderer>());
            Destroy(self.GetComponent<Collider2D>());
            Debug.Log("Daddy!");
        }
    }
    
}
