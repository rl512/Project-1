using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController2 : MonoBehaviour
{
    private Rigidbody rb2;
    public float speed;
    private int count;
    public Text score2;
    public Text Winning2;
    public Vector3 jump;
    public float jumpForce = 2.0f;

    public void Start()
    {
        rb2 = GetComponent<Rigidbody>();
        count = 0;
        Setscoretext();
        Winning2.text = "";
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    public void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal Player 2");
        float moveVertical = Input.GetAxis("Vertical Player 2");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); // 0.0f bc we do not want to move up 

        if (Input.GetKeyDown(KeyCode.A))
        {
            rb2.AddForce(movement * speed);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            rb2.AddForce(movement * speed);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            rb2.AddForce(movement * speed);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            rb2.AddForce(movement * speed);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            rb2.AddForce(jump * jumpForce, ForceMode.Impulse);

        }
    }

    void OnTriggerEnter(Collider Player2)
    {

        if (Player2.gameObject.CompareTag("Cube"))
        {
            Player2.gameObject.SetActive(false);
            count = count + 1;
            Setscoretext();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "West Wall")
        {

            count = count - 1;
            Subtractscore();
        }

        if (collision.transform.name == "East Wall")
        {

            count = count - 1;
            Subtractscore();
        }

        if (collision.transform.name == "North Wall")
        {

            count = count - 1;
            Subtractscore();
        }

        if (collision.transform.name == "South Wall")
        {

            count = count - 1;
            Subtractscore();
        }

        if (collision.transform.name == "Player")
        {

            count = count - 1;
            Subtractscore();
        }
    }

    void Setscoretext()
    {
        score2.text = "Player2 Score:" + count.ToString();

        if (count >= 11)
        {
            Winning2.text = "Player2 Wins";
            Time.timeScale = 0;
        }
    }

    void Subtractscore()
    {

        if (count < 0)
        {

            count = 0;
        }

        score2.text = "Player2 Score: " + count.ToString();
    }
}
