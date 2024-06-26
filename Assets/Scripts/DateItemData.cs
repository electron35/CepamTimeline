using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UI;

public class DateItemData : MonoBehaviour
{
    [SerializeField] public string ItemName = "DefaultName";
    [SerializeField] public string ItemDescription = "DefaultName";
    [SerializeField] public int ItemDate = 0; //Année approximative de l'objet
    [SerializeField][Range (0,1000)] public int ItemPosition = 0; //Position entre 0 et 1000 sur la timeline, variable appelé pour verifier si le joueur à bien placer l'objet.
    [SerializeField][Range(1, 9)] public int ItemEra = 1; //Ère de l'objet (Moyen age, antiquité, etc...)

    private int currentPosition = 0;

    private bool relativeValidity = false;
    private bool absoluteValidity = false;

    public bool RelativeValidity { get => relativeValidity; }
    public bool AbsoluteValidity { get => absoluteValidity; }

    public int CurrentPos
    {
        get => currentPosition;
        set => currentPosition = value;
    }

    public void ChangeColorValidity(bool isValid)
    {
        if (isValid)
        {
            gameObject.GetComponent<Image>().color = Color.green;
            gameObject.GetComponent<CanvasGroup>().interactable = false;
            gameObject.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        else
        {
            gameObject.GetComponent<Image>().color = Color.red;
        }
    }
}
