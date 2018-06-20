using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour {



	public static AIMovement bm;
	public float speed;
	[SerializeField] bool move = true, tower, obs;



	void Start(){
		bm = this;
	}


	// Update is called once per frame
	void Update () {
		transform.Translate (-speed * Time.deltaTime, 0f, 0f);


		if (Input.GetMouseButtonDown(0)) {
			move = false;
		}


		if (transform.position.x >= 12 || transform.position.x <= -12) {
			speed *= -1;
		}
	}


}
