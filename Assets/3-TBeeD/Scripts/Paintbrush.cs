// from Joyce, AKA Minions Art
// https://twitter.com/minionsart
// https://www.patreon.com/posts/rendertexture-15961186

using System.Collections.Generic;
using UnityEngine;

public class PaintBrush : MonoBehaviour
{
    public int resolution = 512;
    Texture2D whiteMap;
    public float brushSize;
    public Texture2D brushTexture;
    Vector2 stored;
    public static Dictionary<Collider, RenderTexture> paintTextures = new Dictionary<Collider, RenderTexture>();
    void Start()
    {
        CreateClearTexture();// clear white texture to draw on
    }

    void Update()
    {

        // Set up a canvas with a raw image, and make a RenderTexture for it

        // Instead of Raycasting, use the mouse position to paint to the RenderTexture. Get the X and Y coordinates by

        // xCoordinate = Mathf.Floor(Input.mousePosition.x - rawImage.rectTransform.position.x);
        // yCoordinate = Mathf.Floor(Input.mousePosition.y - rawImage.rectTransform.position.y);
        // DrawTexture(texture, xCoordinate, yCoordinate);
        // With this you can draw on the RawImage UI component

        // 3D Mesh Painting
        Debug.DrawRay(transform.position, Vector3.down * 20f, Color.magenta);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        //if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) // delete previous and uncomment for mouse painting
        {
            Collider coll = hit.collider;
            if (coll != null)
            {
                if (!paintTextures.ContainsKey(coll)) // if there is already paint on the material, add to that
                {
                    Renderer rend = hit.transform.GetComponent<Renderer>();
                    paintTextures.Add(coll, getWhiteRT());
                    rend.material.SetTexture("_PaintMap", paintTextures[coll]);
                }
                if (stored != hit.lightmapCoord) // stop drawing on the same point
                {
                    stored = hit.lightmapCoord;
                    Vector2 pixelUV = hit.lightmapCoord;
                    pixelUV.y *= resolution;
                    pixelUV.x *= resolution;
                    DrawTexture(paintTextures[coll], pixelUV.x, pixelUV.y);
                }
            }
        }
    }

    void DrawTexture(RenderTexture rt, float posX, float posY)
    {

        RenderTexture.active = rt; // activate rendertexture for drawtexture;
        GL.PushMatrix();                       // save matrixes
        GL.LoadPixelMatrix(0, resolution, resolution, 0);      // setup matrix for correct size

        // draw brushtexture
        Graphics.DrawTexture(new Rect(posX - brushTexture.width / brushSize, (rt.height - posY) - brushTexture.height / brushSize, brushTexture.width / (brushSize * 0.5f), brushTexture.height / (brushSize * 0.5f)), brushTexture);
        GL.PopMatrix();
        RenderTexture.active = null;// turn off rendertexture


    }

    RenderTexture getWhiteRT()
    {
        RenderTexture rt = new RenderTexture(resolution, resolution, 32);
        Graphics.Blit(whiteMap, rt);
        return rt;
    }

    void CreateClearTexture()
    {
        whiteMap = new Texture2D(1, 1);
        whiteMap.SetPixel(0, 0, Color.white);
        whiteMap.Apply();
    }
}