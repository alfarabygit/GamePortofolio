using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject Paddle1;
    public GameObject Paddle2;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        Paddle1 = GameObject.Find("Paddle1");
        Paddle2 = GameObject.Find("Paddle2");
        StartCoroutine(Pause());
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(this.transform.position.x) >= 22f)
        {
            CountScore.canAddScore = true;
            this.transform.position = new Vector3(0f, 0f, 0f);
            StartCoroutine(Pause());
        }
    }
    IEnumerator Pause()
    {
        int DirectionX = Random.Range(-1, 3);
        int DirectionY = Random.Range(-1, 3);
        if (DirectionX == 0)
        {
            DirectionX = 1;
        }
        rb.velocity = new Vector2(0f, 0f);
        yield return new WaitForSeconds(1);
        rb.velocity = new Vector2(12f * DirectionX, 10f * DirectionY);
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.name == "Paddle1")
        {
            if (Paddle1.GetComponent<Rigidbody2D>().velocity.y > 0.5f)
            {
                rb.velocity = new Vector2(10f, 10f);

            }
            else if (Paddle1.GetComponent<Rigidbody2D>().velocity.y < -0.5f)
            {
                rb.velocity = new Vector2(10f, -10f);

            }
            else
            {
                rb.velocity = new Vector2(12f, 0f);
            }
        }
        if (hit.gameObject.name == "Paddle2")
        {
            if (Paddle1.GetComponent<Rigidbody2D>().velocity.y > 0.5f)
            {
                rb.velocity = new Vector2(-10f, 10f);

            }
            else if (Paddle1.GetComponent<Rigidbody2D>().velocity.y < -0.5f)
            {
                rb.velocity = new Vector2(-10f, -10f);

            }
            else
            {
                rb.velocity = new Vector2(-12f, 0f);
            }
        }
    }
}
