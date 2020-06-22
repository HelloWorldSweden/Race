using UnityEngine;

public class Environment : MonoBehaviour
{
    public Transform otherEnv;
    public float halfLength = 104.5f;


    private Transform player;
    private float endOffSet = 110f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        MoveGround();
    }

    void MoveGround()
    {
        if (transform.position.z + halfLength < player.transform.position.z - endOffSet)
        {
            //Debug.Log(player.transform.position.z - endOffSet);
            transform.position = new Vector3(otherEnv.position.x, otherEnv.position.y, otherEnv.position.z + halfLength * 2);

        }
    }
}


