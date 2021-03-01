using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRoom : MonoBehaviour
{
    public float mouseSensitivity;
    public float moveSpeed;
    public float upperBounds;
    public float lowerBounds;
    public float closeToFriendThreshold;
    public float farFromFriendThreshold;
    public bool inverseMouse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float sideMove = Input.GetAxis("Mouse X") * mouseSensitivity;
        float upMove = Input.GetAxis("Mouse Y") * mouseSensitivity;
        float forwardMove = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3();

        if (Input.GetMouseButton(1))
        {
            if (inverseMouse) upMove *= -1;

            //Make sure the camera stay clamped between 2 heights, to prevent from going upside down.
            if (upMove > 0 && transform.position.y >= upperBounds)
                upMove = 0;
            if (upMove < 0 && transform.position.y <= lowerBounds)
                upMove = 0;

            movement = Vector3.up * upMove + transform.right * sideMove;
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            inverseMouse = !inverseMouse;
        }
        

        //Prevent the camera from getting too close or far from the friend.
        if (forwardMove < 0 && Vector3.Distance(transform.position, Vector3.up) >= farFromFriendThreshold)
            forwardMove = 0;
        if (forwardMove > 0 && Vector3.Distance(transform.position, Vector3.up) <= closeToFriendThreshold)
            forwardMove = 0;

        movement += transform.forward * forwardMove * moveSpeed * Time.deltaTime;

        transform.position += movement;

        transform.LookAt(Vector3.up);
    }
}
