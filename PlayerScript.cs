using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;
    private int score;
    private int scoreValue = 0;
    private int lives = 3;
    private GameObject other;


    public float speed;
    public Text scoreText;
    public Text winText;
    public Text livesText;
    public Text loseText;


    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
        winText.text = "";
        SetScoreText();
        SetLivesText();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
        if (Input.GetKey("escape"))
            Application.Quit();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Coin")
        {
            Destroy(collision.collider.gameObject);
            scoreValue += 1;
            SetScoreText();
        }

        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetLivesText();
            Destroy(collision.collider.gameObject);
        }

    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        if (score == 4)
        {
            winText.text = "Congratulations! You win! Game created by Aaron Martin";
        }

    }

    void SetLivesText()
    {
        LivesText.text = "Lives: " + lives.ToString();
        if (lives < 1)
        {
            loseText.text = " You Lost. ";
            Destroy(gameObject);
        }
    }
}