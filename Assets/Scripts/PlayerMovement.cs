using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    Rigidbody PlayerRigidbody;

    public Text ScoreText;
    public int score;

    void Start()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
                PlayerRigidbody.AddForce(movement * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
           
        }
    
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            
        }
     
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, -90, 0);
          
        }
     
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 90, 0);
          
        }
      
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Hazard")
        {
            SceneManager.LoadScene("GameLose");
        }

        if (other.gameObject.tag == "Collectibles")
        {
            score++;
            ScoreText.text = "Score: " + score.ToString();
            Destroy(other.gameObject);
            if (score == 4)
            {
                //SceneManager.LoadScene("MazeGameLevel2");
                SceneManager.LoadScene("GameWin");
            }
        }

    }


}
