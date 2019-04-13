using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeBoxCollier2D : MonoBehaviour
{
    void Start()
    {
        //コライダーのサイズをオブジェクトに合わせる
        Vector2 objectSize = gameObject.GetComponent<RectTransform>().sizeDelta;
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        collider.size = objectSize;
    }
}