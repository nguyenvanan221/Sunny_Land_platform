using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    public string nameObject;

    public Sprite sprite;

    public int quantity;

    public bool stackable;
}
