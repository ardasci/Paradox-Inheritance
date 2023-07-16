using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loopBackground : MonoBehaviour
{
    public float bgSpeed;
    public Renderer bgRenderer;
    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(bgSpeed*Time.deltaTime,0);
    }
}
