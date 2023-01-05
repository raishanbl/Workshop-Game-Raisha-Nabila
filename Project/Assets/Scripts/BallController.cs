using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] Camera cam;

    public float speed;
    public float jumpForce;

    private bool isGrounded;

    public GameManager gm;

    public SceneScript scene;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (gm.isGameOver)
        {
            rb.velocity = Vector3.zero;
            return;
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(cam.transform.forward * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(cam.transform.forward * -speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(cam.transform.right * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(cam.transform.right * -speed);
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0));
            isGrounded = false;
        }
        if (Input.GetKey(KeyCode.R))
        {
            scene.Restart();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stars"))
        {
            Destroy(other.gameObject);
            gm.collectedStars++;
            gm.DisplayStars();
        }
        if (other.CompareTag("Bottom"))
        {
            scene.Restart();
        }
    }
}
