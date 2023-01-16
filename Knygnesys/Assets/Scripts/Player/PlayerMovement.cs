using System.Security.Cryptography;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
     
   private Rigidbody2D body;
   [SerializeField]private float speed;
   [SerializeField]private float jump;
   private Vector3 localScale;

   private bool isJumping;

   private float fallMultiplier = 3f;
   private float lowJumpMultiplier = 2f;

   //sound start
   [SerializeField] private AudioSource jumpStartSoundEffect;
   [SerializeField] private AudioSource jumpEndSoundEffect;
   [SerializeField] private AudioSource highscoreSoundEffect;
   private bool playedOnce = false;
   //sound end
   
   //animacija start
   public Animator animator;
   private bool m_FacingLeft = true;
   //animacija end

   private float dirX;

    //score system
    public Text scoreText;

    private float topScore = 0.0f;

    public Text scoreEnd;
    public Text highScore;
    public Text highScoreEnd;
    public int number;

    //jump
    private float jumpTimer;

   private void Awake()
   {
        body = GetComponent<Rigidbody2D>(); //pasiima veikeja
        localScale = transform.localScale;
        dirX = 1F; //nustato judejimo krypi pradzioje
        // jumpTimer = 0f;
   }

   private void OnTriggerEnter2D(Collider2D collision)
   {
        dirX *=-1f; //kai paliecia siena keicia krypti
   }
   
   void FixedUpdate()
   {
        body.velocity = new Vector2(dirX*speed, body.velocity.y); //nustato greiti ir sokimo auksti

        if (body.velocity.y < 0) //jump'o feel pagerinimas (+- i mario games puse)
        {
            body.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (body.velocity.y > 0)
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

        if(Input.GetKey(KeyCode.Space) && !isJumping) //jei paspaudzia space
        {
            body.velocity = new Vector2(body.velocity.x, jump); //veikejas kyla i virsu
            isJumping = true; //pakeicia busena kad veikejas yra ore (tam kad negaletu spammint space)
            animator.SetBool("IsJumping", true); //animacijai

            //sound start
            
            jumpStartSoundEffect.Play();
            //sound end
        }

        if(Input.GetKey(KeyCode.Mouse0) && !isJumping) //jei paspaudzia space
        {
            body.velocity = new Vector2(body.velocity.x, jump); //veikejas kyla i virsu
            isJumping = true; //pakeicia busena kad veikejas yra ore (tam kad negaletu spammint space)
            animator.SetBool("IsJumping", true); //animacijai

            //sound start

            jumpStartSoundEffect.Play();
            //sound end

            //jumpTimer=0f;
        }

        //score
        if(body.velocity.y>0 && transform.position.y>topScore)
        {
            topScore = transform.position.y;
        }
        scoreText.text = Mathf.Round(topScore/5).ToString();
        scoreEnd.text = Mathf.Round(topScore / 5).ToString();

        number = (int)Mathf.Round(topScore / 5); //sukastinimas

        CheckHighScore();

        // jumpTimer+=Time.deltaTime;
        // if(jumpTimer>=1f && !isJumping)
        // {
        //     jumpTimer=0;
        //     isJumping=false;
        //     animator.SetBool("IsJumping", false);
        // }

    }

    void CheckHighScore()
    {
        UpdateHighScoreText();
        if (number > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", number);
            UpdateHighScoreText();

            //sound start
            if(playedOnce == false)
            {
                highscoreSoundEffect.Play();
                playedOnce = true;
            }
            //sound end
        }
    }

    void UpdateHighScoreText()
    {
        int rekordas = PlayerPrefs.GetInt("HighScore", 0);
        highScore.text = $"Highscore\n{rekordas}";
        highScoreEnd.text = $"{rekordas}";
    }

   void OnCollisionEnter2D(Collision2D other)
   {
        if(other.gameObject.CompareTag("Ground")) //jei paliecia zeme      && jumpTimer>=1f
        {
            isJumping = false; // pakeicia busena kai veikejas nusileidzia ant zemes (tam kad negaletu spammint space)
            animator.SetBool("IsJumping", false); //animacijai
            jumpTimer=0f;

            //sound start
            jumpEndSoundEffect.Play();
            //sound end
        }
   }
//animacijai
   private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingLeft = !m_FacingLeft;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
//animacijai end
}
