using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolCarController : MonoBehaviour
{
    [SerializeField] float acceleration = 8f;
    //[SerializeField] float rotationAngle = 10f;
    [SerializeField] float turnSpeed = 10f;
    //public float steeringSpeed = 5f;

    Vector3 direction;
    float angle;
    Rigidbody rb;
    JHandler controlsObject;
    Quaternion targetRotation = Quaternion.identity;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        controlsObject = GameObject.Find("JContainer").GetComponent<JHandler>();


    }

    private void Update()
    {
        if (controlsObject.InputDirection.x != 0 || controlsObject.InputDirection.y != 0)
        {
            direction = new Vector3(controlsObject.InputDirection.x, 0f, controlsObject.InputDirection.y);
            float x = controlsObject.InputDirection.x;
            float z = controlsObject.InputDirection.y;
            angle = Mathf.Atan2(x, z) * Mathf.Rad2Deg;
            targetRotation = Quaternion.Euler(0, angle, 0);
        }

        Movement();
    }
    private void FixedUpdate()
    {
        float accelerationInput = acceleration * (Mathf.Max(Mathf.Abs(controlsObject.InputDirection.x), Mathf.Abs(controlsObject.InputDirection.y))) * Time.fixedDeltaTime;
        rb.AddRelativeForce(Vector3.forward * accelerationInput);
    }

    void Movement()
    {
        //transform.rotation = Quaternion.AngleAxis(angle - rotationAngle, new Vector3(0f, 1f, 0f));
        //rb.position = transform.position;

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

    }
}
