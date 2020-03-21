using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;

    public float distance; // 9.2
    public float height; // 2.78

    public float hightD; // 3.25
    public float rotationD; // -3.5

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    //Runs after Update();
    private void LateUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        float wantedRotationAngles = target.eulerAngles.y;
        float wantedHight = target.position.y + height;

        float currentRotationAngles = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        currentRotationAngles = Mathf.LerpAngle(currentRotationAngles, wantedRotationAngles, rotationD * Time.deltaTime);

        currentHeight = Mathf.Lerp(currentHeight, wantedHight, hightD * Time.deltaTime);

        Quaternion currentRotation = Quaternion.Euler(0f, currentRotationAngles, 0f);

        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
    }
}
