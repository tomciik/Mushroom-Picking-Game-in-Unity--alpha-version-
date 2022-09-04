using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Picking : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Sprite RedShroom;
    [SerializeField] private Sprite BrownShroom;
    [SerializeField] private Sprite BlueShroom;
    [SerializeField] private Sprite GreenShroom;
    [SerializeField] private GameObject shrooms;
    [SerializeField] private GameObject[] slots;


    Sprite iconShroom;

    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<MeshRenderer>();
                if(Input.GetMouseButtonDown(0) && selectionRenderer != null)
                {
                    selectionRenderer.enabled = false;
                    addToInventory(selectionRenderer);
                }
            }
            
        }
    }

    void addToInventory(MeshRenderer shrooms)
    {
        switch (shrooms.name)
        {
            case "Shroom_Red":
                Debug.Log(shrooms.name);
                iconShroom = RedShroom;
                break;
            case "Shroom_Brown":
                Debug.Log(shrooms.name);
                iconShroom = BrownShroom;
                break;
            case "Shroom_Blue":
                Debug.Log(shrooms.name);
                iconShroom = BlueShroom;
                break;
            case "Shroom_Green":
                Debug.Log(shrooms.name);
                iconShroom = GreenShroom;
                break;
            default:
                break;
        }

        for(int i= 0; i < slots.Length; i++)
        {
            GameObject icon = slots[i].transform.GetChild(0).gameObject;
            string nameIcon = icon.GetComponent<Image>().sprite.name;
            Image imageIcon = icon.GetComponent<Image>();
            Debug.Log(nameIcon);

            if (nameIcon == "slot")
            {
                imageIcon.color = new Color32(255,255,255,255);
                imageIcon.sprite = iconShroom;
                break;
            }
            else
            {
                continue;
            }
        }
    }
}
