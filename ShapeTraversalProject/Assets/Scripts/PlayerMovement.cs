using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float speed2;
    public float speedUpTime;
    private float speedUpTimeLimit;
    private float horizontal;
    private float vertical;
    private bool speedUp = false;

    public SpriteRenderer spriteRenderer;
    public Sprite square;
    public Sprite circle;
    public Sprite triangle;

    private int health;
    public int MAXHEALTH;
    public TMP_Text healthText;

    private ShapeStats stats;
    // Start is called before the first frame update
    void Start()
    {
        stats = this.GetComponent<ShapeStats>();
        SetShape();
        SetColor();
        health = MAXHEALTH;
        healthText.text = "Health: " + health;
        speedUpTimeLimit = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (Time.time > speedUpTimeLimit)
            speedUp = false;
    }

    void FixedUpdate()
    {
        if (speedUp)
            rb.velocity = new Vector2(horizontal * speed2, vertical * speed2);
        else
            rb.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    void SetColor()
    {
        if (stats.color == ShapeStats.Colors.Red)
            spriteRenderer.color = Color.red;

        else if (stats.color == ShapeStats.Colors.Green)
            spriteRenderer.color = Color.green;

        else if (stats.color == ShapeStats.Colors.Blue)
            spriteRenderer.color = Color.blue;
    }

    void SetShape()
    {
        if (stats.shape == ShapeStats.Shapes.Square)
            spriteRenderer.sprite = square;

        else if (stats.shape == ShapeStats.Shapes.Circle)
            spriteRenderer.sprite = circle;

        else if (stats.shape == ShapeStats.Shapes.Triangle)
            spriteRenderer.sprite = triangle;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Obstacle")
        {
            if ((other.GetComponent<ShapeStats>().color != stats.color) && (other.GetComponent<ShapeStats>().shape != stats.shape))
            {
                DecreaseHealth();
                speedUp = false;
            }
                
            else
            {
                if (other.GetComponent<ShapeStats>().color != stats.color)
                {
                    stats.color = other.GetComponent<ShapeStats>().color;
                    SetColor();
                }
                else if (other.GetComponent<ShapeStats>().shape != stats.shape)
                {
                    stats.shape = other.GetComponent<ShapeStats>().shape;
                    SetShape();
                }

                speedUp = true;
                speedUpTimeLimit = Time.time + speedUpTime;
            }

            Destroy(other.gameObject);
        }
    }

    void DecreaseHealth()
    {
        health--;
        healthText.text = "Health: " + health;
        if (health == 0)
            SceneManager.LoadScene("MainMenu");
    }
}
