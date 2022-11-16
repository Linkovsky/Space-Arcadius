using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMoving : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.RawImage img;
    [SerializeField] private float scrollingY;

    // Update is called once per frame
    void Update()
    {
        img.uvRect = new Rect(img.uvRect.position + new Vector2(img.uvRect.x, scrollingY) * Time.deltaTime, img.uvRect.size);
    }
}
