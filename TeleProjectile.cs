using UnityEngine;

public class TeleProjectile : MonoBehaviour {

    GameObject player, teleProj;
	WeaponsManager wm;

	public void OnCreate(GameObject iplayer){
		player = iplayer;
		teleProj = this.gameObject;
		wm = GameManager.GM.GetComponent<WeaponsManager> ();
	}

    private void FixedUpdate(){
        if (Input.GetKeyDown(KeyCode.X) && PlayerAttacks.weaponType == "teleportation"){
			player.transform.position = teleProj.transform.position;
			wm.KillAttack (this.gameObject);
		}
		if (Input.GetKeyDown(KeyCode.C)){
		wm.KillAttack (this.gameObject);    
	    }
    }
}