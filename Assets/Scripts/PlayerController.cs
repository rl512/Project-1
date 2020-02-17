using UnityEngine;
using UnityEngine.UI; 
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    public float speed;
    private int count;
    public Text score;
    public Text Winning;
    public Vector3 jump;
    public float jumpForce = 2.0f;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        Setscoretext();
        Winning.text = "";
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    public void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal Player 1");
        float moveVertical = Input.GetAxis("Vertical Player 1");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); // 0.0f bc we do not want to move up 

        rb.AddForce(movement * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);

        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

    }

    void OnTriggerEnter(Collider Player)
    {

        if (Player.gameObject.CompareTag("Cube"))
        {
            Player.gameObject.SetActive(false);
            count = count + 1;
            Setscoretext();  
        }
    }

    void OnCollisionEnter(Collision collision)
    {
       if (collision.transform.name=="West Wall") {

           count=count-1;
           Subtractscore ();
        }

       if (collision.transform.name=="East Wall") {

            count=count-1;
            Subtractscore ();
       }

       if (collision.transform.name=="North Wall") {

            count=count-1;
            Subtractscore ();
       }

       if (collision.transform.name=="South Wall") {

           count=count-1;
           Subtractscore ();
       }

       if (collision.transform.name=="Player2") {

           count=count-1;
           Subtractscore ();
       }
    }

    void Setscoretext ()
    {
        score.text = "Player1 Score:" + count.ToString();

        if (count>=11)
        {
            Winning.text = "Player1 Wins";
            Time.timeScale = 0;
        }
    }

    void Subtractscore () {

        if (count<0 ) {

          count=0; 
        }

         score.text = "Player1 Score: " + count.ToString();
    }


}

