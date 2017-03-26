using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDirection : MonoBehaviour
{
    private GameObject player;
    private GameObject camera;
    private float px;
    private float py;
    private float pz;
    private float cx;
    private float cy;
    private float cz;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        var playerRotation = GameObject.FindWithTag("Player").transform.rotation;
      
        camera.transform.rotation = playerRotation;
        
    }

    private Vector3 GetCamerPositionRelativToPlayer()
    {

        return new Vector3();
    }
}
