using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public float maxHorizontalDistance;
    public float maxVerticalDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCheck();
    }

    private void MoveCheck()
    {
        if (player.transform.position.x > transform.position.x + maxHorizontalDistance)
        {
            transform.position = new Vector3(player.transform.position.x - maxHorizontalDistance, transform.position.y, transform.position.z);
        }

        if (player.transform.position.x < transform.position.x - maxHorizontalDistance)
        {
            transform.position = new Vector3(player.transform.position.x + maxHorizontalDistance, transform.position.y, transform.position.z);
        }

        if (player.transform.position.y > transform.position.y + maxVerticalDistance)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y - maxVerticalDistance, transform.position.z);
        }

        if (player.transform.position.y < transform.position.y - maxVerticalDistance)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y + maxVerticalDistance, transform.position.z);
        }
    }
}
