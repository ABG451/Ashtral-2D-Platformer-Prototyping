using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour {

    [SerializeField] float bForce, direction;

	[SerializeField] bool bLeft, bRight, bUp, bDown, inverse;

    ///List<GameObject> players;

    [SerializeField] GameObject bumper;

    private Rigidbody2D playerRB;

    /*public void SetPlayers (List<GameObject> iPlayers) {
		players = new List<GameObject> ();
		players = iPlayers;
		player1RB = players[0].GetComponent<Rigidbody2D>();
		if (players.Count == 2){
    	    player2RB = players[1].GetComponent<Rigidbody2D>();
		}
	}*/

    void OnCollisionEnter2D(Collision2D pCol){

        if (inverse)
        {
            if (pCol.gameObject.tag == "Player")
            {

                Debug.Log("Works Bitch");

                direction = bumper.GetComponent<Transform>().rotation.eulerAngles.z;

                playerRB = pCol.gameObject.GetComponent<Rigidbody2D>();

                playerRB.velocity = Vector3.zero;
                //start with no force
                Vector3 addedForce = Vector3.zero;
            
                //Add force based on direction
                if (bLeft) addedForce.x += -1;
                if (bRight) addedForce.x += 1;
                if (bDown) addedForce.y += -1;
                if (bUp) addedForce.y += 1;

                //Keep the same exact force in the correct direction
                playerRB.AddForce(addedForce.normalized * bForce, ForceMode2D.Impulse);
            }

            /*if (pCol.gameObject != players[1])
            {
                //start with no force
                Vector3 addedForce = Vector3.zero;

                //Add force based on direction
                if (bLeft) addedForce.x += -1;
                if (bRight) addedForce.x += 1;
                if (bDown) addedForce.y += -1;
                if (bUp) addedForce.y += 1;

                //Keep the same exact force in the correct direction
                player2RB.AddForce(addedForce.normalized * bForce, ForceMode2D.Impulse);
            }*/
        }

        if (!inverse)
        {
            if (pCol.gameObject.tag == "Player")
            {
                Debug.Log("Works Bitch");

                playerRB = pCol.gameObject.GetComponent<Rigidbody2D>();
                playerRB.velocity = Vector3.zero;
                //start with no force
                Vector3 addedForce = Vector3.zero;
                if (direction >= 90.0f && direction <= 179.9f)
                {
                    bLeft = true;
                    bRight = false;
                    bDown = false;
                    bUp = false;
                    if (bLeft) addedForce.x += -1;
                }

                else if (direction >= 180.0f && direction <= 269.9f)
                {
                    bLeft = false;
                    bRight = false;
                    bDown = true;
                    bUp = false;
                    if (bDown) addedForce.y += -1;
                }

                else if (direction >= 270.0f && direction <= 360.0f)
                {
                    bLeft = false;
                    bRight = true;
                    bDown = false;
                    bUp = false;
                    if (bRight) addedForce.x += 1;
                }

                else if (direction >= 0.0f && direction <= 89.9f)
                {
                    bLeft = false;
                    bRight = false;
                    bDown = false;
                    bUp = true;
                    if (bUp) addedForce.y += 1;
                }

                playerRB.AddForce(addedForce.normalized * bForce, ForceMode2D.Impulse);
            }

            /*if (pCol.gameObject == players[0])
            {
                //start with no force
                Vector3 addedForce = Vector3.zero;
                if (direction >= 90.0f && direction <= 179.9f)
                {
                    bLeft = true;
                    bRight = false;
                    bDown = false;
                    bUp = false;
                    if (bLeft) addedForce.x += -1;
                }

                else if (direction >= 180.0f && direction <= 269.9f)
                {
                    bLeft = false;
                    bRight = false;
                    bDown = true;
                    bUp = false;
                    if (bDown) addedForce.y += -1;
                }

                else if (direction >= 270.0f && direction <= 360.0f)
                {
                    bLeft = false;
                    bRight = true;
                    bDown = false;
                    bUp = false;
                    if (bRight) addedForce.x += 1;
                }

                else if (direction >= 0.0f && direction <= 89.9f)
                {
                    bLeft = false;
                    bRight = false;
                    bDown = false;
                    bUp = true;
                    if (bUp) addedForce.y += 1;
                }

                //Keep the same exact force in the correct direction
                player1RB.AddForce(addedForce.normalized * bForce, ForceMode2D.Impulse);
            }*/
        }       
    }
}