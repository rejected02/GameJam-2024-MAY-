using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    PlayerMovement playerMovement;
    public Door door;
    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, playerMovement.mainCameraTransform.forward, out hit, 2))
        {
            Debug.DrawRay(transform.position, playerMovement.mainCameraTransform.forward);
            if (hit.collider.name.Contains("Door"))
            {
                door = hit.collider.GetComponent<Door>();
                door.doorTxt.SetActive(true);
            }
            else
            {
                if (door != null)
                {
                    Debug.Log("Null");
                    door.doorTxt.SetActive(false);
                }
            }
        }
    }

}
