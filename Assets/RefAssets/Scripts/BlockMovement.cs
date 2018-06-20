using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour {


    [SerializeField] ParticleSystem placeTower;
	public static BlockMovement bm;
	public float speed;
    [SerializeField] bool move = true, tower, obs, toched = false, gameStart, doOnce = true;
    AudioSource audio;

    public float min = 2f;
    public float max = 3f;


    void Start(){
		bm = this;
        audio = GetComponent<AudioSource>();
        min = transform.position.x - 12;
        max = transform.position.x + 12;
        gameStart = GameManager.gm.gameStart;
    }


	// Update is called once per frame
	void Update () {

        if (doOnce)
        {
            if (GameManager.gm.gameStart)
            {
                gameStart = true;
                doOnce = false;
            }
        }

        if (move && gameStart) {
            transform.position = new Vector3(Mathf.PingPong(Time.time * speed, max - min) + min, transform.position.y, transform.position.z);
            move = GameManager.gm.gameStart;

        }
        speed = 7 + GameManager.gm.score * 0.15f;
        if (Input.GetMouseButtonDown(0) && GameManager.gm.gameStart) {
			move = false;
            gameStart = false;
		}
	}

	void OnCollisionEnter(Collision other){
        
        

        if (other.gameObject.tag == "floor" || other.gameObject.tag == "obs" ) {
			if (tower) {
				SpawnManager.sm.StartCoroutine (SpawnManager.sm.GameOver ());
			}
		}
		if (other.gameObject.tag == "base" || other.gameObject.tag == "block" ) {
			if (obs) {
				SpawnManager.sm.StartCoroutine (SpawnManager.sm.GameOver ());
			}
            if (tower)
            {
                if (!toched)
                {
                    audio.Play();
                    placeTower.Play();
                    GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    toched = true;
                }
               
            }
        }
		if (other.gameObject.tag == "floor" ) {
			if (obs) {
				Destroy (gameObject, 1f);
			}
		}

	}



}
