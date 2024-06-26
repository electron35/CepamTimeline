using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CanvasDrop : MonoBehaviour, IDropHandler
{
    [SerializeField] private GameObject anchorObject;
    [SerializeField] private TimelineArea timeline;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.gameObject.GetComponent<DragNDrop>())
            {
                if (timeline.MouseOver == true)
                {
                    eventData.pointerDrag.GetComponent<RectTransform>().transform.SetParent(timeline.transform);
                    
                }
                else
                {
                    // anchorObject.GetComponent<RectTransform>().anchoredPosition;
                    //anchorObject.GetComponent<SortItem>().ReceiveItem(eventData.pointerDrag.gameObject);
                    if (!anchorObject.GetComponent<SortItem>().ChildFull())
                    {
                        eventData.pointerDrag.GetComponent<RectTransform>().transform.SetParent(anchorObject.GetComponent<SortItem>().GetFreeItemSlot(),false);
                        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
                    }
                    else
                    {
                        eventData.pointerDrag.GetComponent<RectTransform>().transform.SetParent(timeline.transform);
                        eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
                    }
                    
                }
            }
            
            
        }
    }
}
