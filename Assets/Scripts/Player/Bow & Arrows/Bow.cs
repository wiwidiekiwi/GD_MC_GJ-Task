using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Bow : MonoBehaviour
{
    
    
    public GameObject arrow;
    public GameObject tpArrow;
    private float launchForce;
    public Transform shotPoint;

    /*public GameObject point;
    private GameObject[] points;
    public int numberOfPoints;
    public float spaceBetweenPoints;*/
    private Vector2 direction;

    private float holdDownStartTime;
    public const float maxForce = 20;
    private Vector2 shootForce;

    private void Start()
    {
        /*points = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            points[i] = Instantiate(point, shotPoint.position, Quaternion.identity);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 bowPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePosition - bowPosition;
        transform.right = direction;

        if (Input.GetMouseButtonDown(0))
        {
            holdDownStartTime = Time.time;
            Debug.Log("Hold start");
        }
        if (Input.GetMouseButtonUp(0))
        {
            float holdDownTime = Time.time - holdDownStartTime;
            Shoot(holdDownTime);
            Debug.Log("hold end");
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            
        }
        /* for (int i = 0; i < numberOfPoints; i++)
        {
            points[i].transform.position = PointPosition(i * spaceBetweenPoints);
        }*/
    }

    void Shoot(float holdTime)
    {
        GameObject newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        shootForce = transform.right * CalculateHoldDownForce(holdTime) * launchForce;
        newArrow.GetComponent<Rigidbody2D>().linearVelocity = shootForce;
    }

    /*Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2)shotPoint.position + (direction.normalized * shootForce * t) +
                           0.5f * Physics2D.gravity * (t * t);
        return position;
    }*/
    
   

    private float CalculateHoldDownForce(float holdTime)
    {
        float maxForceHoldDownTime = 5f;
        float holdTimeNormalized = Mathf.Clamp01(holdTime / maxForceHoldDownTime);
        launchForce = holdTimeNormalized * maxForce;
        return launchForce;
    }

}
