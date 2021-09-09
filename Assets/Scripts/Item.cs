using UnityEngine;


[CreateAssetMenu(fileName="Item",menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    public int id;
    public string nameItem;
    public string Description;
    public Sprite image;
    public int hpAdd;
    public int Price;
    public int jumpAdd;
    public float speedDuration;
}
