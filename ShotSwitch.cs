using UnityEngine;

public class ShotSwitch : MonoBehaviour {

	[SerializeField] string tags;
	[SerializeField] GameObject toBreak;
	[SerializeField] Animator Anim;
	[SerializeField] bool kill;

	void OnTriggerEnter2D(Collider2D ent){
		print (ent.gameObject.name);
		if (ent.gameObject.tag == (tags) && kill) Destroy (toBreak.gameObject);
		if (ent.gameObject.tag == (tags) && !kill) {
			Anim.SetBool ("Shot", true);
		}
	}
}