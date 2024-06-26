using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private RectTransform itemArea;
    [SerializeField] public GameObject ItemPrefab;
    [SerializeField] private Canvas canvas;
    public void AddNewItem()
    {
        var prefab = Instantiate(ItemPrefab);
        prefab.GetComponent<DateItemData>().ItemName = "test";
        prefab.GetComponent<DateItemData>().ItemDescription = "c'est un test";
        prefab.GetComponent<DateItemData>().ItemEra = 1;
        prefab.GetComponent<DateItemData>().ItemPosition = Random.Range(10,990);
        prefab.GetComponent<DateItemData>().ItemDate = 00;
        prefab.GetComponent<DragNDrop>().CanvasUpdate = canvas;


        itemArea.GetComponent<SortItem>().ReceiveItem(prefab);
    }

    public void Refill()
    {
        while (!itemArea.GetComponent<SortItem>().ChildFull())
        {
            AddNewItem();
        }
    }

    private void Awake()
    {
        Refill();
    }
}
