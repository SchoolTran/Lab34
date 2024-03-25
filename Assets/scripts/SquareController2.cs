using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SquareController2 : MonoBehaviour
{
    public float timeRemaining = 60;
    public Text countdownText;
    public bool loser = false;
    public GameObject win;

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
        SceneManager.LoadScene(currentSceneIndex + 1);
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
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("Circle"))
        {
            Vector2 firstPosition = new Vector2(-6, -4);
            transform.position = firstPosition;
        }

        if (col.gameObject.tag.Equals("Pinwheel"))
        {
            Vector2 firstPosition = new Vector2(-6, -4);
            transform.position = firstPosition;
        }

        if (col.gameObject.name.Equals("Box"))
        {
            Instantiate(win, transform.position, Quaternion.identity);
            Debug.Log("Win");
            LoadNextScene();
        }
    }
}
