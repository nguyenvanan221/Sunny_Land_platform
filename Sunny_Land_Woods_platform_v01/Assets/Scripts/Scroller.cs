using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] private RawImage img;
    [SerializeField] private float x;

    void Update()
    {
        img.uvRect = new Rect(img.uvRect.position.x + x * Time.deltaTime, img.uvRect.position.y, img.uvRect.width, img.uvRect.height);    
    }
}
