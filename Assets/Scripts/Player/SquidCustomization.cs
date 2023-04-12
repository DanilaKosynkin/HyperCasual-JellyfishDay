using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidCustomization : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _hatSprite;
    [SerializeField] private SpriteRenderer _decoratingSprite;



    public void EquipHat(Item hat)
    {
        _hatSprite.sprite = hat.GetSprite();
       
    }
    public void EquipDecorating(Item decorating)
    {
      
        _decoratingSprite.sprite = decorating.GetSprite();
    }
 }
