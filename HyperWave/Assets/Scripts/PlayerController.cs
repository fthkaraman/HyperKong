using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    public float maxSpeed;

    private int desiredLine = 1;
    public float laneDistance = 4;

    private float fuel = 100f;
    public static float currentFuel;
    private float fuelBurnRate = 5f;

    public Slider fuelSlider;
    void Start()
    {
        controller = GetComponent<CharacterController>();

        currentFuel = fuel;
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = forwardSpeed;

        if (forwardSpeed < maxSpeed)
        {
            forwardSpeed += 0.1f * Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLine++;
            if (desiredLine == 3)
                desiredLine = 2;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLine--;
            if (desiredLine == -1)
                desiredLine = 0;
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        
        targetPosition.x = 4.4f;

        controller.center = controller.center;

        if(desiredLine == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLine == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        transform.position = targetPosition;

        //fuel
        fuelSlider.value = currentFuel / fuel;

    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);

        //fuel burn
        currentFuel -= fuelBurnRate * Time.deltaTime;


        if (fuelSlider.value == 0)
        {
            PlayerManager.gameOver = true;
        }

        if (LifeController.lifeValue == 0)
        {
            PlayerManager.gameOver = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            LifeController.lifeValue -= 1;           
            Debug.Log("hit");
        }

        if (other.tag == "Portal")
        {
            LifeController.lifeValue = 0;
            PlayerManager.gameOver = true;
            Object.Destroy(gameObject);
            Debug.Log("hit");
        }
    }
}
