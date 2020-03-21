using UnityEngine;

public class BaseController : MonoBehaviour
{
    public Vector3 carSpeed; //Overall Speed;

    public float xSpeed; //For left & right;
    public float zSpeed; //For forward;
    public float acceleration;
    public float deceleration;
    public float playerHealth;

    protected float rotationSpeed = 10f;
    protected float maxAngle = 10f;


    //Sound effect.
    public float lowSound, normalSound, highSound;
    //public AudioClip onSound, offSound;

    private bool _isSlow;
    //private AudioSource _audioManager;

    private void Awake()
    {
        // _audioManager = GetComponent<AudioSource>();
        carSpeed = new Vector3(0f, 0f, zSpeed);
    }


    protected void MoveLeft()
    {
        carSpeed = new Vector3(-xSpeed / 2f, 0f,carSpeed.z);
    }

    protected void MoveRight()
    {
        carSpeed = new Vector3(xSpeed / 2f, 0f, carSpeed.z);
    }

    protected void MoveForward()
    {
        carSpeed = new Vector3(0f, 0f, carSpeed.z);
    }
    
    protected void MoveNormal()
    {
        //if(_isSlow)
        //{
        //    _isSlow = false;
        //    _audioManager.clip = onSound;
        //    _audioManager.volume = 0.3f;
        //    _audioManager.Play();
        //}
        carSpeed = new Vector3(carSpeed.x, 0f, zSpeed);
    }

    protected void MoveSlow()
    {
        //if(!_isSlow)
        //{
        //    _isSlow = true;
        //    _isSlow = false;
        //    _audioManager.clip = offSound;
        //    _audioManager.volume = 0.5f;
        //    _audioManager.Play();
        //}
        carSpeed = new Vector3(carSpeed.x, 0f, deceleration);

    }

    protected void MoveFast()
    {
        carSpeed = new Vector3(carSpeed.x, 0f, acceleration);

    }

    protected void ChangeRotation()
    {
        if (carSpeed.x > 0) //right
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(-90f, 180, maxAngle), rotationSpeed * Time.deltaTime);
            //Rotating from Car position with "sphere lerp" to maxAngle (just around Y axis). 
        }
        else if (carSpeed.x < 0) //Left
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(-90f, 180, -maxAngle), rotationSpeed * Time.deltaTime);
        }

        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(-90f, 180f, 0f), rotationSpeed * Time.deltaTime);
        }
    }
}
