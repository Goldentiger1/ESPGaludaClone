using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GroundAdjuster : MonoBehaviour {

    float x;
    float y;
    float xpos;
    float ypos;

    GameObject ground;
    Vector2 gridTiling;
    Vector2 gridOffset;
    Renderer rend;

    public void Start() {
        ground = GameObject.Find("Plane");
        rend = ground.GetComponent<Renderer>();
    }

    public void Update() {
        
        x = ground.transform.localScale.x;
        y = ground.transform.localScale.z;

        xpos = ground.transform.position.x;
        ypos = ground.transform.position.z;

        //To keep the size of the grid's tiles as 1, change the grid's tiling to match the values of ground's Scale x and z
        //Have to make a new Vector2 because ground's scale is a Vector3 (get x and z that become x and y)
        gridTiling = new Vector2(x, y);

        //offset

        float tempX = -0.1f * xpos - 0.5f * x + 0.025f;
        float tempY = -0.1f * ypos - 0.5f * y + 0.025f;

        //offset = -0.5 * scale + 0.05
        //offset = -0.1 * pos + 0.05

        Vector2 tempVector = new Vector2(tempX, tempY);
        gridOffset = tempVector;

        var tempMaterial = new Material(rend.sharedMaterial)
        {
            mainTextureScale = gridTiling,
            mainTextureOffset = gridOffset
        };
        rend.sharedMaterial = tempMaterial;
    }

}