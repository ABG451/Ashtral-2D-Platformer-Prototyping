using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    [SerializeField] bool follow; // follow1, follow2;

    //[SerializeField] List<GameObject> players;

    [SerializeField] GameObject Player;

    [SerializeField] GameObject follower, sensor;

    [SerializeField] Vector3 SettingY;

    Vector3 allOffset1, allOffset2;
	Vector2 reset;

    float offsetX1, offsetY1, offsetZ1, offsetX2, offsetY2, offsetZ2, setX1, setX2, initialX, initialY;

	// Use this for initialization
	void Start () {
        sensor.GetComponent<Renderer>().material.color = Color.green;
        initialX = follower.GetComponent<Transform>().position.x;
        initialY = follower.GetComponent<Transform>().position.y;
		reset = new Vector2 (initialX,initialY);
    }
	
	// Update is called once per frame
	void Update () {

        Vector3 fPosition = Player.GetComponent<Transform>().position + allOffset1;

        //Vector3 fPosition1 = players[0].GetComponent<Transform>().position + allOffset1;

        //Vector3 fPosition2 = players[1].GetComponent<Transform>().position + allOffset2;

        if (follow)
        {
            follower.transform.position = fPosition;

            //follower.transform.position = fPosition1;
        }

        /*if (follow2)
        {
            Debug.Log("Works");
            follower.transform.position = fPosition2;
        }*/
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (col.gameObject == Player)
            {
                setX1 = follower.transform.position.x - Player.GetComponent<Transform>().position.x;
                //SettingY = new Vector3(setX1, 0, 0);
                follower.transform.position = Player.GetComponent<Transform>().position + SettingY;
                offsetX1 = follower.transform.position.x - Player.GetComponent<Transform>().position.x;
                offsetY1 = follower.transform.position.y - Player.GetComponent<Transform>().position.y;
                offsetZ1 = follower.transform.position.z;
                allOffset1 = new Vector3(offsetX1, offsetY1, offsetZ1);
                sensor.GetComponent<Renderer>().material.color = Color.red;
                follow = true;
            }

            /*if (col.gameObject == players[1])
            {
                setX2 = follower.transform.position.x - players[1].GetComponent<Transform>().position.x;
                SettingY = new Vector3(setX2, 0, 0);
                follower.transform.position = players[1].GetComponent<Transform>().position + SettingY;
                offsetX2 = follower.transform.position.x - players[1].GetComponent<Transform>().position.x;
                offsetY2 = follower.transform.position.y - players[1].GetComponent<Transform>().position.y;
                offsetZ2 = follower.transform.position.z;
                allOffset2 = new Vector3(offsetX2, offsetY2, offsetZ2);
                sensor.GetComponent<Renderer>().material.color = Color.red;
                follow2 = true;
            }*/
        }
    }

	/*public void SetPlayers (List<GameObject> iPlayers) {
		players = new List<GameObject> ();
		players = iPlayers;
	}*/

	public void KillPlayer(){
		follower.transform.position = reset;
	}
}