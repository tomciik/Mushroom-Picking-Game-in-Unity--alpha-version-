using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject viewfinder;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleInventory();
        }

    }

    void ToggleInventory()
    {
        inventory.SetActive(!inventory.activeInHierarchy);
        if (inventory.activeSelf == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            viewfinder.GetComponent<Image>().enabled = false;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            viewfinder.GetComponent<Image>().enabled = true;
        }

        DisablePlayer(!inventory.activeInHierarchy);
    }

    void DisablePlayer(bool flag)
    {
        player.GetComponent<CharacterController>().enabled = flag;
        player.GetComponent<FirstPersonController>().enabled = flag;
    }
}
