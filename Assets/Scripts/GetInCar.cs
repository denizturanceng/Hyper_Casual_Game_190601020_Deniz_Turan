using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GetInCar : MonoBehaviour
{
    public GameObject human = null;
     public bool inCar = false;
     public float vehicleRange = 5f;
     public GameObject car = null;

     public GameObject followCamera = null;
    
     public GameObject enterButton = null;
    public GameObject exitButton = null;
    public GameObject carcamera = null;
    public GameObject playercamera = null;


    public VehicleUnlock vu;



    void Start()
    {

        car.GetComponent<CarMove>().controller.enabled = false;
        car.GetComponent<CarMove>().canRotate = false;
        inCar = !car.activeSelf;
        enterButton.SetActive(false); exitButton.SetActive(false);


    }


    void Update()
    {
        if (vu.carUnlocked)
        {
            float distance = Vector3.Distance(car.transform.position, human.transform.position);


            if (distance < vehicleRange)
            {
                if (inCar)
                {
                    enterButton.SetActive(false);
                    exitButton.SetActive(true);
                }

                else
                {
                    enterButton.SetActive(true);
                }

            }

            else
            {

                enterButton.SetActive(false);

                if (inCar)
                {
                    exitButton.SetActive(true);
                }
                else if (!inCar)
                {
                    exitButton.SetActive(false);

                }

            }
        }


    }



    public void ExitCar()
    {
        inCar = false;

        human.SetActive(true);

        followCamera.GetComponent<CameraScript>().target = playercamera.transform;

        car.GetComponent<CarMove>().controller.enabled = false;
        car.GetComponent<CarMove>().canRotate = false;

        human.transform.position = car.transform.position + 2 * car.transform.TransformDirection(Vector3.left);

    }

    public void EnterCar()
    {
        inCar = true;
        human.SetActive(false);

        followCamera.GetComponent<CameraScript>().target = carcamera.transform;

        car.GetComponent<CarMove>().controller.enabled = true;
        car.GetComponent<CarMove>().canRotate = true;
        enterButton.SetActive(false);
    }
}
