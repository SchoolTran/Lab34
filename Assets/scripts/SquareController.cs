using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SquareController : MonoBehaviour
{
    public float timeRemaining = 60;
    public Text countdownText;
    public  bool loser = false;
    public GameObject win;

    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    private Vector2 shootDirection;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1);
            timeRemaining--;
            countdownText.text = "Time: " + timeRemaining.ToString();
        }
        countdownText.text = "Time's up!";
        loser = true;
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene (currentSceneIndex + 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (!loser)
        {
            // Lấy giá trị trục ngang (horizontal) và trục dọc (vertical) từ bàn phím 
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            // Tính toán hướng di chuyển 
            Vector3 movement = new Vector3(horizontal, vertical, 0f).normalized;
            transform.Translate(movement * 5f * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            shootDirection = Vector2.left;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            shootDirection = Vector2.right;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            shootDirection = Vector2.up;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            shootDirection = Vector2.down;
        }

        // Bắn đạn khi người chơi nhấn Space 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Circle"))
        {
            Debug.Log("xxxxxx");
            Vector2 firstPosition = new Vector2(-9, 1);
            transform.position = firstPosition;
        }

        if (col.gameObject.name.Equals("Box"))
        {
            Instantiate(win, transform.position, Quaternion.identity);
            Debug.Log("Next level");
            LoadNextScene();
        }

        if (col.gameObject.tag.Equals("Yellow"))
        {
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Map"))
        {
            Debug.Log("XXXXXX");
            Vector2 firstPosition = new Vector2(-9, 1);
            transform.position = firstPosition;
        }
    }

    void Shoot()  // Bắn đạn 
    {
        GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();
        if (bulletRb != null)
        {
            bulletRb.velocity = shootDirection * bulletSpeed; //Bắn theo hướng của GameObject
        }
    }
}
