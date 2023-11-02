using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private Vector2 ParallaxEffect;
    [SerializeField] private bool infiniteHor;
    [SerializeField] private bool infiniteVert;
    private Transform cameraTranform;
    private Vector3 lastCameraPosition;
    private float textureUnitSizeX;
    private float textureUnitSizeY;
    // Start is called before the first frame update
    void Start()
    {
        cameraTranform = Camera.main.transform;
        lastCameraPosition = cameraTranform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
        textureUnitSizeY = texture.height / sprite.pixelsPerUnit;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTranform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * ParallaxEffect.x, deltaMovement.y * ParallaxEffect.y);
        lastCameraPosition = cameraTranform.position;

        if (infiniteHor)
        {
            if (Mathf.Abs(cameraTranform.position.x - transform.position.x) >= textureUnitSizeX)
            {
                float offsetPositionX = (cameraTranform.position.x - transform.position.x) % textureUnitSizeX;
                transform.position = new Vector3(cameraTranform.position.x + offsetPositionX, transform.position.y);
            }
        }

        if (infiniteVert)
        {
            if (Mathf.Abs(cameraTranform.position.y - transform.position.y) >= textureUnitSizeY)
            {
                float offsetPositionY = (cameraTranform.position.y - transform.position.y) % textureUnitSizeY;
                transform.position = new Vector3(transform.position.x, cameraTranform.position.y + offsetPositionY);
            }
        }
    }
}
