using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using Unity.VisualScripting;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D player;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    float horizontal;

    public float runSpeed = 5f;
    private bool m_Grounded;

    public UnityEvent OnLandEvent;
    bool doubleJump;
    public GameManager manager;
    float prevY;
    float prevprevY;
    int counter;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { counter = 0;
        doubleJump = false;
        player = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        if (OnLandEvent == null) {
		    OnLandEvent = new UnityEvent();
        }
        OnLandEvent.AddListener(Landed);
        prevprevY = player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
        horizontal = Input.GetAxisRaw("Horizontal");
    
        if (horizontal < 0) {
            spriteRenderer.flipX = true;
        } else if (horizontal > 0) {
            spriteRenderer.flipX = false;
        }
        animator.SetFloat("horizontal", horizontal);
        if (Input.GetKeyDown("space") && (!animator.GetBool("jump") || (doubleJump && manager.carrots > 0 )))
        {
            if (!doubleJump) {
                Debug.Log("Can double jump!");
                doubleJump = true;
            }
            else if (manager.carrots > 0) {
                Debug.Log("Eating carrot");
                manager.DecrementCarrot();
                doubleJump = false;
            }
            player.AddForce(Vector2.up * 2250);
            animator.SetBool("jump",true);
        }
    }

    void FixedUpdate()
    {
        player.linearVelocity = new Vector2(horizontal * runSpeed, player.linearVelocity.y);


		bool wasGrounded = m_Grounded;
;
        m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.6f);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
                m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
        counter = (counter+1)%5;
        if (counter == 0){
            Debug.Log("1");
        if (!prevY.IsUnityNull()) {
            Debug.Log("2");
            prevprevY = prevY;
        }
        Debug.Log("3");
        prevY = player.transform.position.y;}
        if (animator.GetBool("jump") && !prevY.IsUnityNull() && prevY == player.transform.position.y && prevY == prevprevY) {
            Debug.Log("Stuck jumping!");
            Landed();
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
    }

    public void Landed() {
        animator.SetBool("jump", false);
        doubleJump = false;
    }


}
