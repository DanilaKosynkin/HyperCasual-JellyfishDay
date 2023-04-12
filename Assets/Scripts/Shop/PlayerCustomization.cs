using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCustomization : MonoBehaviour
{
    [SerializeField] private List<Sprite> _skinsSprite; 

    private void Start()
    {
        int currentForma = PlayerPrefs.GetInt("CurrentPlayerSkin");
        if (currentForma == 0)
            return;
        GetComponent<SpriteRenderer>().sprite = _skinsSprite[currentForma];
    }
}
