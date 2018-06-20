using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour {


	[SerializeField] Text gameOverText;

	public static SpawnManager sm;
	public Block block; 
	[SerializeField] CamFollow cam;
	[SerializeField] GameObject[] towerBlocks;
	[SerializeField] GameObject currentBlock;
    [SerializeField] GameManager gm;
	[SerializeField] bool changeGravity, spawnable, spwanvalue;
    [SerializeField] AudioSource audioDrop;

    // Use this for initialization
    void Start () {
		Time.timeScale = 1f;
		Time.fixedDeltaTime = 0.02f;
		sm = this;
		spawnable = true;
        StartCoroutine(SpawnBlocks());

		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && gm.gameStart) {
            audioDrop.Play();
            gm.UpdateScore();
			currentBlock.GetComponent<Rigidbody> ().useGravity = true;
			changeGravity = changeGravity ? !changeGravity : !changeGravity;
			spwanvalue = spwanvalue ? !spwanvalue : !spwanvalue;
            if (!spawnable && GameManager.gm.gameStart)
            {
                StartCoroutine(MakeSpawnable());
            }
			

		}

		if (spwanvalue) {
			block = Block.a;
		} else {
			block = Block.b;
		}
		cam.UpdateCamPosition ();
	}


	IEnumerator SpawnBlocks(){
		
		yield return new WaitForSeconds (1f);
        transform.position = transform.position + Vector3.up * 4.5f;

        if (spawnable) {
			switch (block) {
			case Block.a:
				currentBlock =(GameObject) Instantiate (towerBlocks [0], transform.position, Quaternion.identity);
				currentBlock.transform.localScale = new Vector3 (transform.localScale.x - 0.1f, transform.localScale.y - 0.1f, transform.localScale.z - 0.1f);
				break;
			case Block.b:
				currentBlock =(GameObject) Instantiate (towerBlocks [1], transform.position, Quaternion.identity);
				currentBlock.transform.localScale = new Vector3 (transform.localScale.x - 0.1f, transform.localScale.y - 0.1f, transform.localScale.z - 0.1f);
				break;


			default:
				break;
			}
				//currentBlock =(GameObject) Instantiate (towerBlocks [Random.Range (0, towerBlocks.Length)], transform.position, Quaternion.identity);
				spawnable = false;
		}

	}

	IEnumerator MakeSpawnable(){
		yield return new WaitForSeconds (0.2f);
		spawnable = true;

		StartCoroutine (SpawnBlocks ());
        



    }



	public IEnumerator GameOver(){
        gm.gameOver = true;
		gameOverText.text = "Game Over";
		yield return new WaitForSeconds (1f);
		//Application.LoadLevel (Application.loadedLevel);

	}
}
