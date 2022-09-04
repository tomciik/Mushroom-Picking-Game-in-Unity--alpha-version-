using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightObject : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material selectedMaterial;

    private Material defaultMaterial;
    private Transform _selection;

    void Update()
    {

        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            defaultMaterial = null;
            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray,out hit, 2f))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer.material != selectedMaterial && defaultMaterial == null)
                {
                    defaultMaterial = selectionRenderer.material;
                }
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = selectedMaterial;
                }

                _selection = selection;
            }
        }
    }
}
