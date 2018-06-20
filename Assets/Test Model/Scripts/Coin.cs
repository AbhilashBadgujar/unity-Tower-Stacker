using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    [SerializeField] GameObject Player;
    AudioSource audio;
    [SerializeField] float rotationSpeed;

    private void Start()
    {
        Player = GameObject.Find("Player");
        audio = Player.GetComponent<AudioSource>();
    }

    void Update () {

        // rotate coin 
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
	}


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Destroy(gameObject);
               
            StartCoroutine(DestroyCoin());
            
        }
    }

    IEnumerator DestroyCoin()
    {
        GetComponent<ParticleSystem>().Play();
        GetComponent<MeshRenderer>().enabled = false;
        
        yield return new WaitForSeconds(0.2f);
        audio.Play();
        //GameManager.gm.UpdateText();
        Destroy(gameObject);
        

    }
}
