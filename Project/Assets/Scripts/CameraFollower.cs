using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;
    private Quaternion curRotation;

    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        curRotation = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gm.isGameOver) return;
        transform.position = Vector3.Lerp(transform.position, target.position, 100.0f * Time.fixedDeltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, curRotation, 0.500f);

        if (Input.GetKey(KeyCode.LeftArrow)) 
        {
            curRotation *= Quaternion.Euler(0, -4, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            curRotation *= Quaternion.Euler(0, 4, 0);
        }
    }
}
