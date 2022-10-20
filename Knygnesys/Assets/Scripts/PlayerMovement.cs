using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
     
   private Rigidbody2D body;
   [SerializeField]private float speed;
   [SerializeField]private float jump;
   private Vector3 localScale;

   private bool isJumping;

   private float fallMultiplier = 3f;
   private float lowJumpMultiplier = 2f;
   
   //animacija start
   public Animator animator;
   private bool m_FacingLeft = true;
   //animacija end

   private float dirX;

   private void Awake()
   {
        body = GetComponent<Rigidbody2D>();
        localScale = transform.localScale;
        dirX = 1F;
   }

   private void OnTriggerEnter2D(Collider2D collision)
   {
        if(collision.GetComponent<Wall>())
        {
            dirX *=-1f;
        }
        if(collision.GetComponent<Wall2>())
        {
            dirX *=-1f;
        }
   }
   
   void FixedUpdate()
   {
        body.velocity = new Vector2(dirX*speed, body.velocity.y);

        if (body.velocity.y < 0) //jump'o feel pagerinimas (+- i mario games puse): 14-15, 47-54
        {
            body.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (body.velocity.y > 0 && !Input.GetButton ("Jump"))
        {
            body.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
   }

   private void Update()
   {
        body.velocity = new Vector2(0, body.velocity.y);

     //animacijai
        // If the input is moving the player right and the player is facing left...
			if (dirX*speed > 0 && m_FacingLeft)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (dirX*speed < 0 && !m_FacingLeft)
			{
				// ... flip the player.
				Flip();
			}
     //animaicijai end

        if(Input.GetKey(KeyCode.Space) && !isJumping)
        {
            body.velocity = new Vector2(body.velocity.x, jump);
            isJumping = true;
            animator.SetBool("IsJumping", true); //animacijai
        }

   }

   void OnCollisionEnter2D(Collision2D other)
   {
        if(other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            animator.SetBool("IsJumping", false); //animacijai
        }
   }

   private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingLeft = !m_FacingLeft;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
