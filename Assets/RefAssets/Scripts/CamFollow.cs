using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {

 
    public Transform follow;

    public float smoothtime = 0.5f;

    public Vector3 offset;
    public void UpdateCamPosition()
    {
        if (GameManager.gm.gameStart)
            transform.position = Vector3.Lerp(transform.position, follow.position + offset, smoothtime);
    }
}
