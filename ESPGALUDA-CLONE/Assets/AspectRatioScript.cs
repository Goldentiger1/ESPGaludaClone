using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectRatioScript : MonoBehaviour {

    public float fixedAspectRatio = 3.0f / 4.0f;

    void UpdateFixedAspectRatio() {
        float targetAspect = fixedAspectRatio;

        float windowAspect = (float)Screen.width / (float)Screen.height;

        float scaleheight = windowAspect / targetAspect;

        Camera camera = GetComponent<Camera>();

        if (scaleheight < 1.0f) {

            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;

            camera.rect = rect;
        } else {
            float scaleWidth = 1.0f / scaleheight;

            Rect rect = camera.rect;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }

    }

    void Awake() {
        UpdateFixedAspectRatio();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.K)) {
            UpdateFixedAspectRatio();
        }

    }
}
