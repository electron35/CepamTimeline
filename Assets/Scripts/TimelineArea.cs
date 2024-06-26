using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class TimelineArea : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool MouseOver = false;
    private float lowerX;
    private float upperX;
    private float areaWidth;

    private void Start()
    {
        upperX = gameObject.GetComponent<RectTransform>().rect.xMax;
        lowerX = gameObject.GetComponent<RectTransform>().rect.xMin;
    }

    public void SortChildByPosition()
    {
        int size = gameObject.transform.childCount;
        if (size != 0)
        {
            SortedList<float,Transform> elements = new SortedList<float, Transform>();

            for (int i = 0; i < size; i++)
            {
                elements.Add(getItemRelativePosition(i), transform.GetChild(i));   
            }

            int j = 0;
            foreach (KeyValuePair<float,Transform> pair in elements)
            {
                pair.Value.gameObject.GetComponent<DateItemData>().CurrentPos = j;
                j++;
            }
        }
    }

    private void Update()
    {
        //Debug.Log("Upper value of x is " + upperX);
        //Debug.Log("lower value of x is " + lowerX);
        /*if (gameObject.transform.childCount != 0)
        {
            //gameObject.transform.GetChild(0).localPosition.x
            Debug.Log("Position y absolue de l'objet: " + gameObject.transform.GetChild(0).position.y);
            Debug.Log("Position y relative de l'objet: " + gameObject.transform.GetChild(0).localPosition.y);
            Debug.Log("Position normalisé x Relative à la timeline: " + NormaliseThousand(getItemRelativePosition(0), lowerX, upperX));
            Debug.Log("Position normalisé x Absolue: " + NormaliseThousand(gameObject.transform.GetChild(0).localPosition.x, lowerX, upperX));
            Debug.Log("Position x Absolue: " + GetChosenChildXPosition(0));
        }*/
        
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        MouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        MouseOver = false;
    }
    public float GetChosenChildXPosition(int index)
    {
        if (transform.GetChild(index) != null)
        {
            //return gameObject.transform.GetChild(index).localPosition.x;
            return transform.GetChild(index).localPosition.x - lowerX;
        }
        else
        {
            return 0;
        }
        
    }

    public int NormaliseThousand(float value, float min, float max)
    {
        return Mathf.RoundToInt(((value - min) / (max - min))*1000);
    }

    private float getItemRelativePosition(int index, float timelineAngle = 27.46f)
    //Recupère la position de l'item en prenant en compte la diagonale de la timeline (Ce base sur le haut de la timeline)
    {
        Vector2 itemPos = gameObject.transform.GetChild(index).localPosition;
        Vector2 tlTopPos = new Vector2(itemPos.x, gameObject.GetComponent<RectTransform>().rect.yMin);


        if (gameObject.transform.GetChild(index) != null)
        {
            return tlTopPos.x + Mathf.Tan(timelineAngle) * (itemPos.y);
        }
        else
        {
            return 0;
        }
    }

    public int GetChosenItemNormalisePos(int index)
    //Fonction à appeler depuis l'extérieur pour récuperer la position normalisé d'un élément choisi
    {
        return NormaliseThousand(getItemRelativePosition(index), lowerX, upperX);
    }

    public void MoveItemToCorrectPosition(int index)
    {
        Transform item = transform.GetChild(index);
        int normalisedX = transform.GetChild(index).GetComponent<DateItemData>().ItemPosition;

        float absoluteX = ((normalisedX * (upperX - lowerX)) / 1000)+lowerX;
        item.localPosition = new Vector2(absoluteX,item.localPosition.y);
    }
}
