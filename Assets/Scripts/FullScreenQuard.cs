using UnityEngine;
using System.Collections;

public class FullScreenQuard : MonoBehaviour
{
    public Camera TargetCamera;

    private float aspectRatio;
    private float distance = 10;
    private Vector3 localScal;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.UpdateCameraParam();
        this.PutToCenter();
        this.CalculateScale();
        this.transform.localScale = this.localScal;
        
	}

    private void CalculateScale()
    {
        float _yScale = this.distance * Mathf.Tan(Mathf.Deg2Rad*this.TargetCamera.fieldOfView / 2.0f)*2.0f;
        float _xScale = _yScale * this.aspectRatio;
        this.localScal = new Vector3(_xScale, _yScale, 1);
    }

    private void PutToCenter()
    {
        this.distance = Vector3.Distance(this.TargetCamera.transform.position, this.transform.position);
        this.transform.position = this.TargetCamera.transform.position + this.distance*this.TargetCamera.transform.forward;
        this.transform.rotation = this.TargetCamera.transform.rotation;
    }

    private void UpdateCameraParam()
    {
        this.aspectRatio = this.TargetCamera.aspect;
    }
}
