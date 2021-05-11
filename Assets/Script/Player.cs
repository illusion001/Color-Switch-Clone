using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public float jumpForce = 10f;

    public Rigidbody2D rb;
    public SpriteRenderer sr;
    
    public string currentColor;

    public Color colorCyan;
    public Color colorYellow;
    public Color colorPink;
    public Color colorPurple;

    bool gameStarted;

    void Start()
    {
        SetRandomColor();
    }


    void Update()
    {
        if (!gameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                rb.gravityScale = 3;
                gameStarted = true;
                GameManager.instance.GameStart();
            }
        }
        
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "ColorChanger")
        {
            GameManager.instance.scoreUp();
            SetRandomColor();
            Destroy(col.gameObject);
            return;
        }
        if(col.tag != currentColor)
        {
            GameManager.instance.Restart();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "fallCheck")
        {
            GameManager.instance.Restart();
        }
    }

    void SetRandomColor()
    {
        int index = Random.Range(0, 4);
        switch (index)
        {
            case 0:
                currentColor = "Cyan";
                sr.color = colorCyan;
                break;
            case 1:
                currentColor = "Purple";
                sr.color = colorPurple;
                break;
            case 2:
                currentColor = "Yellow";
                sr.color = colorYellow;
                break;
            case 3:
                currentColor = "Pink";
                sr.color = colorPink;
                break;
        }
    }

}
