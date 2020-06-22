using UnityEngine;


public class BaseControll : MonoBehaviour
{
    public int speed = 5;
    public int speedForward;
    public int speedSide;
    public float playerHealth;
    public float countDownTimer;


    protected float startValue;
    protected float angle = 12f;
    protected int rotationSpeed = 5;

    private void Awake()
    {
        startValue = countDownTimer;
    }

    public void MoveForward()
    {
        transform.Translate(Vector3.up * speedForward * Time.deltaTime);
    }

    public void MoveLeft()
    {
        transform.Translate(-Vector3.left * speedSide * Time.deltaTime);
    }

    public void MoveRight()
    {
        transform.Translate(Vector3.left * speedSide * Time.deltaTime);
    }

    public void RotateLeft()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(-90, 180, -angle), rotationSpeed * Time.deltaTime);
    }

    public void RotateRight()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(-90, 180, angle), rotationSpeed * Time.deltaTime);
    }
    public void OffRotate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(-90, 180, 0f), rotationSpeed * Time.deltaTime);
    }

    public void TimerConunt(float timer)
    {
        UIManager.Instance.Timer(Mathf.Round(timer * 10.0f) * 0.1f);
        countDownTimer -= Time.deltaTime / 2;
    }


}
