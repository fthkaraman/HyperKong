using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = forwardSpeed;

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        transform.Rotate(0, 200 * Time.deltaTime, 0);
    }

    private void FixedUpdate()
    {
        controller.Move(-direction * Time.fixedDeltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Object.Destroy(gameObject);
            FinalScore.finalScore -= 10;
        }

        if (other.tag == "Destroyer")
        {
            Object.Destroy(gameObject);
        }
    }
}
