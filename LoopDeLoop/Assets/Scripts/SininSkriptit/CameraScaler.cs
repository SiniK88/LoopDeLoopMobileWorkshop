using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScaler : MonoBehaviour
{
    public float screenHeight = 1920f;
    public float screenWidth = 1080f;
    public float targetAspect = 9f / 16f;
    public float orthographicSize;
    private Camera camera;

    void Start() {


        // obtain camera component so we can modify its viewport
        Camera camera = GetComponent<Camera>();
    }
     private float DesignOrthographicSize;
    private float DesignAspect;
    private float DesignWidth;

    public float DesignAspectHeight;
    public float DesignAspectWidth;

    public void Awake() {
        this.DesignOrthographicSize = this.camera.orthographicSize;
        this.DesignAspect = this.DesignAspectHeight / this.DesignAspectWidth;
        this.DesignWidth = this.DesignOrthographicSize * this.DesignAspect;

        this.Resize();
    }

    public void Resize() {
        float wantedSize = this.DesignWidth / this.camera.aspect;
        this.camera.orthographicSize = Mathf.Max(wantedSize,
            this.DesignOrthographicSize);
    }

}
