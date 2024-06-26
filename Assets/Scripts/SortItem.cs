using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SortItem : MonoBehaviour
{
    public bool ChildFull()
    {
        bool isFull = true;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<ItemSlot>() && (transform.GetChild(i).childCount == 0))
            {
                isFull = false;
                break;
            }
        }
        return isFull;
    }

    public bool ChildEmpty()
    {
        bool isEmpty = true;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<ItemSlot>() && (transform.GetChild(i).childCount != 0))
            {
                isEmpty = false;
                break;
            }
        }
        return isEmpty;
    }
    public void ReceiveItem(GameObject item)
    {
        if (item.GetComponent<DateItemData>() && item.GetComponent<DragNDrop>())
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                if (child.GetComponent<ItemSlot>() && (child.childCount == 0))
                {
                    item.transform.SetParent(child, false);
                    item.transform.localPosition = new Vector2(0, 0);
                }
            }
        }
    }
    public Transform GetFreeItemSlot()
    {
        Transform child = null;

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).childCount == 0)
            {
                child = transform.GetChild(i);
                break;
            }
        }

        return child;
    }
}
