﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public int dis = 10;

    // Update is called once per frame
    void LateUpdate() {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(0, gameObject.transform.position.y , player.gameObject.transform.position.z - dis), Time.deltaTime * 100);
      
    }
}
