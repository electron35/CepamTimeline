using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DisplayToken : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] public string TextToShow = "";
    private bool mouse_over = false;

    private void Update()
    {
        if (mouse_over)
        {
            Tooltip.ShowTooltip_Static(TextToShow);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
        Tooltip.HideTooltip_Static();
    }
}
