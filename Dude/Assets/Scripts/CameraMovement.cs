using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 velocity;

    public float smoothX;
    public float smoothY;

    public bool bounds;
    public Vector3 lowerbound;
    public Vector3 upperbound;


    public GameObject boy;
    void Start()
    {
        boy = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float posx = Mathf.SmoothDamp(transform.position.x, boy.transform.position.x, ref velocity.x, smoothX);
        float posy = Mathf.SmoothDamp(transform.position.y, boy.transform.position.y, ref velocity.y, smoothY);
        transform.position = new Vector3(posx, posy, transform.position.z);

        if (bounds) {

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, lowerbound.x, upperbound.x), Mathf.Clamp(transform.position.y, lowerbound.y, upperbound.y),
                Mathf.Clamp(transform.position.z, lowerbound.z, upperbound.z));

        }
    }
}
