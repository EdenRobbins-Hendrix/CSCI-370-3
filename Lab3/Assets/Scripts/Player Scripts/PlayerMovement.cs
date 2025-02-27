using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doubleJump = false;
        player = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        if (OnLandEvent == null) {
		    OnLandEvent = new UnityEvent();
        }
        OnLandEvent.AddListener(Landed);
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
                doubleJump = true;
            }
            else if (manager.carrots > 0) {
                Debug.Log("Eating carrot");
                manager.DecrementCarrot();
                doubleJump = false;
            }
            player.AddForce(Vector2.up * 2250);
            animator.SetBool("jump",true);
            Debug.Log("space key was pressed");
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
		Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.4f);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
			{
                m_Grounded = true;
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
    }

    public void Landed() {
        animator.SetBool("jump", false);
        doubleJump = false;
        Debug.Log("Landed");
    }


}
