using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu]
public class Item : ScriptableObject
{
    [SerializeField] private int _cost;
    [SerializeField] private Sprite _sprite;

    public int GetCost()
    {
        return _cost;
    }

    public Sprite GetSprite()
    {
        return _sprite;
    }
}
