using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Validation : MonoBehaviour
{

    [SerializeField] private GameObject dropPanel;
    [SerializeField] private GameObject itemArea;

    private void Start()
    {
        GetComponent<Button>().interactable = false;
        GetComponent<CanvasGroup>().alpha = 0.5f;
    }
    private void Update()
    {
        if (itemArea.GetComponent<SortItem>().ChildEmpty())
        {
            GetComponent<Button>().interactable = true;
            GetComponent<CanvasGroup>().alpha = 1;
        }
    }
    public void ValidateCurrentData()
    {
        int size = dropPanel.transform.childCount;
        if (size == 0)
        {
            Debug.Log("No data to check");
        }
        else
        {
            for (int i = 0; i < size; i++)
            {
                var isValid = false;

                var element = dropPanel.transform.GetChild(i);
                int elementPos = dropPanel.GetComponent<TimelineArea>().GetChosenItemNormalisePos(i);
                
                if (element != null)
                { 
                    DateItemData data = element.GetComponent<DateItemData>();
                    Debug.Log(elementPos);
                    if (elementPos > data.ItemPosition - 50 && elementPos < data.ItemPosition + 50)
                    {
                        Debug.Log("Position absolu correct");
                        isValid = true;
                    }
                    data.ChangeColorValidity(isValid);
                    dropPanel.GetComponent<TimelineArea>().MoveItemToCorrectPosition(i);
                }
            }
        }
        FindAnyObjectByType<GameManager>().Refill();
    }
}
