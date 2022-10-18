using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   private Rigidbody2D body;
   [SerializeField]private float speed;
   [SerializeField]private float jump;
   private Vector3 localScale;
   private bool isJumping;

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
   }

   private void Update()
   {
        body.velocity = new Vector2(0, body.velocity.y);

        if(Input.GetKey(KeyCode.Space) && !isJumping)
        {
            body.velocity = new Vector2(body.velocity.x, jump);
            isJumping = true;
        }
   }

   void OnCollisionEnter2D(Collision2D other)
   {
        if(other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
   }
}
