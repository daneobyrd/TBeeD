using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TBeeD
{
    public class DrawingCamera : MonoBehaviour
    {
        public Camera drawingCamera;
        public RawImage overlayImage;
        GameObject beeTrail;

        void Start()
        {
            drawingCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
            overlayImage.texture = drawingCamera.targetTexture;
        }

        void Update()
        {

        }
    }
}