using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    private int attemptsCounter;
    private int hitsCounter;
    public float speed;
    public Text attempts;
    public Text hits;
    public Text win;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        attemptsCounter = 0;
        hitsCounter = 0;
        attempts.text = "Attempts: " + attemptsCounter.ToString();
        hits.text = "Hits: " + hitsCounter.ToString();
        win.text = "";
    }
    private void FixedUpdate()
    {
		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) {
			if (attemptsCounter == 0) {
				attemptsCounter = 1;
			}
			else {
				attemptsCounter = attemptsCounter + 1;
			}
			UpdateUI ();
		}

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical= Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical);

        rb.AddForce(movement*speed);
    }
		
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            hitsCounter = hitsCounter + 1;
			UpdateUI ();
        }
    }
		
    void UpdateUI()
    {
        attempts.text = "Attempts: " + attemptsCounter.ToString();
        hits.text = "Hits: " + hitsCounter.ToString();
        win.text = "";
        if (hitsCounter >= 2)
        {
            attempts.text = "";
            hits.text = "";
            win.text = "YOU WIN!!";
        }
    }
}
