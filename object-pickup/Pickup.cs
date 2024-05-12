using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    // Used for controller input
    PlayerControls controls;

    // Range of the raycast in Unity units (metres)
    public float range;

    // Layers that the raycast can hit
    public LayerMask pickableMask;

    // The item that the player can pick up
    GameObject item = null;

    // Awake() is called before Start()
    void Awake()
    {
        controls = new PlayerControls();

        // When the key is pressed, the Grab() function is called
        controls.Gameplay.Pickup.performed += ctx => Grab();

        // When the key is released, the Drop() function is called
        controls.Gameplay.Pickup.canceled += ctx => Drop();
    }

    // To grab an item
    void Grab()
    {
        // The player's camera is the parent of this gameObject (the Hand)
        Transform playerCam = transform.parent;

        RaycastHit hit;

        // If the object that the raycast hit cannot be picked up, return.
        // The ray is cast forwards from the camera's position.
		if (!Physics.Raycast(playerCam.position, playerCam.forward, out hit, range, pickableMask))
		{
            return;
        }

        // Set the item in our hand to the item that was hit
        item = hit.transform.gameObject;

        // Set the item's parent to be the Hand
        item.transform.SetParent(transform);

        // Reset the local position of the item so that it is located exactly where the Hand is
        item.transform.localPosition = Vector3.zero;

        // Slightly rotate the object in your hand when picking it up, just used for style
        Vector3 randomRotation = new Vector3(Random.Range(-25f, 25f), Random.Range(-25f, 25f), Random.Range(-25f, 25f));
        item.transform.localRotation = Quaternion.Euler(randomRotation);

        // Make the object kinematic which means that gravity will not affect it anymore
        item.GetComponent<Rigidbody>().isKinematic = true;
    }

    // To drop a grabbed item
    void Drop()
    {
        // If we didn't grab an item, return
        if (item == null) return;

        // Set the parent of the item to null
        item.transform.SetParent(null);

        // Make the item no longer kinematic
        item.GetComponent<Rigidbody>().isKinematic = false;

        // We now no longer have an item in our hands
        item = null;
    }

    // Enable controller input system
    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    // Disable controller input system
    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
