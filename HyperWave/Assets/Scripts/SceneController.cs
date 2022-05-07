using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float maxSpeed;

    public GameObject road;

    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        direction.z = forwardSpeed;

        if (forwardSpeed < maxSpeed)
        {
            forwardSpeed += 0.1f * Time.deltaTime;
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        road.transform.localScale = new Vector3(1.4f, 1, 1);

        controller.center = controller.center;
    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);

    }
}
