using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.FindWithTag("Player");
        this.offset = new Vector3(0,0,-10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = this.player.transform.position + this.offset;
    }
}
