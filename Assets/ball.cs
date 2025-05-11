using System.Collections;
using NUnit.Framework;
using TMPro;
using UnityEngine;

public class ball : MonoBehaviour
{
    public float startingSpeed = 1f;
    public float minPos = -5;
    public float maxVelocity;
    Rigidbody2D rb;

    public int score = 0;
    public int health = 3;

    public GameObject[] healthObj;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        StartCoroutine("IStart");
    }

    private IEnumerator IStart()
    {
        yield return new WaitForSeconds(3);
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.down * 10f;
    }

    void Update()
    {
        if (this.transform.position.y < minPos)
        {
            health--;
            healthObj[health].SetActive(false);
            if (health > 0)
            {
                this.transform.position = new Vector3(0, -2.5f, 0);
                rb.linearVelocity = Vector2.zero;
                StartCoroutine("IStart");
            }
            else
            {
                Time.timeScale = 0f;
            }
            
        }
        if (rb.linearVelocity.magnitude > maxVelocity)
        {
            rb.linearVelocity = Vector3.ClampMagnitude(rb.linearVelocity, maxVelocity);
        }

        scoreText.text = score.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Brick")
        {
            score++;
            Destroy(collision.gameObject);
        }
    }
}
