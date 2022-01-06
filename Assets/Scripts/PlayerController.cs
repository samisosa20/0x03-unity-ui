using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public int health = 5;
    public float speed = 2000f;
    private int score = 0;
    public Text scoreText;
    public Text healthText;
    public Text winLoseText;
    public Image winLoseBG;

    private Rigidbody rb_player;

    void Start()
    {
            rb_player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(0, 0, -speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(0, 0, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            score++;
            SetScoreText();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Trap"))
        {
            health--;
            SetHealthText();
        }

        if (other.gameObject.CompareTag("Goal"))
        {
            winLoseText.color = Color.black;
            winLoseText.text = "You Win!";
            winLoseBG.color = Color.green;
            winLoseBG.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3f));
        }
    }

    void Update()
    {
        if (health == 0)
        {
            winLoseText.color = Color.white;
            winLoseText.text = "Game Over!";
            winLoseBG.color = Color.red;
            winLoseBG.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3f));
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score;
    }
    void SetHealthText()
    {
        healthText.text = "Health: " + health;
    }
    // Wait to reload
    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
