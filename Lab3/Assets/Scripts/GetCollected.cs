using Unity.VisualScripting;
using UnityEngine;

public class GetCollected : MonoBehaviour
{
    public GameObject self;
    public GameManager manager;
    public AudioSource effect;
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
            Collider2D[] colliders = self.GetComponents<Collider2D>();
            foreach (Collider2D collider in colliders) {
                Destroy(collider);
            }
            effect.Play();
            self.GetComponent<ParticleSystem>().Play();
            Debug.Log("Daddy!");
        }
    }
    
}
