using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    [Header("Car Settings")]
    public float driftFactor=0.95f;
    public float accelerationFactor = 30.0f;
    public float turnFactor=3.5f;
    public float maxSpeed=20;

    float accelerationInput=0;
    float steeringInput=1;

    float rotationAngle=0;

    float velocityVsUp=0;

    Rigidbody2D carRigidbody2D;

    void Awake()
    {
        carRigidbody2D= GetComponent<Rigidbody2D>();

    }

    // Start is called before the first frame update
    void Start()
    {
        carRigidbody2D= GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       //print(rotationAngle);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ApplyEngineForce();

        killOrthogonalVelocity();

        ApplySteering();
    }

    void ApplyEngineForce()
    {

        velocityVsUp=Vector2.Dot(transform.up, carRigidbody2D.velocity);

        if(velocityVsUp>maxSpeed&&accelerationInput>0)
            return;

        if(velocityVsUp<-maxSpeed*0.5f&&accelerationInput<0)
            return;

        if (carRigidbody2D.velocity.sqrMagnitude>maxSpeed*maxSpeed&&accelerationInput>0)
            return;
        

        if(accelerationInput==0)
            carRigidbody2D.drag = Mathf.Lerp(carRigidbody2D.drag,3.0f,Time.fixedDeltaTime*3);
        else carRigidbody2D.drag=0;


        Vector2 engineForceVector= transform.up*accelerationInput*accelerationFactor;

        carRigidbody2D.AddForce(engineForceVector, ForceMode2D.Force);
    }

    void ApplySteering()
    {
        float minSpeedBeforeAllowTurningFactor=(carRigidbody2D.velocity.magnitude/8);
        minSpeedBeforeAllowTurningFactor=Mathf.Clamp01(minSpeedBeforeAllowTurningFactor);

        rotationAngle-=steeringInput*turnFactor*minSpeedBeforeAllowTurningFactor;

        carRigidbody2D.MoveRotation(rotationAngle);
    }

    public void SetInputVector(Vector2 inputVector)
    {
        steeringInput=inputVector.x;
        accelerationInput=inputVector.y;
    }

    void killOrthogonalVelocity()
    {
        Vector2 forwardVelocity=transform.up*Vector2.Dot(carRigidbody2D.velocity,transform.up);
        Vector2 rightVelocity=transform.right*Vector2.Dot(carRigidbody2D.velocity,transform.right);

        carRigidbody2D.velocity=forwardVelocity+rightVelocity*driftFactor;

    }

    
}
