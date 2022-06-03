using System;
using UnityEngine;
using Views;

namespace Debug
{
    public class DebugCubeMovement:MonoBehaviour
    {
        [SerializeField] private CubeView cube;
        [SerializeField] private GameObject controller;

        private void Update()
        {
            // if(cube==null)
            //     return;
            // var cubePosition = cube.transform.position;
            // var controller = Camera.main.ScreenToViewportPoint(
            //     Camera.main.WorldToScreenPoint(this.controller.transform.position));
            // UnityEngine.Debug.Log(controller);
            // cube.transform.position = new Vector3(controller.x, cubePosition.y, cubePosition.z);
            
            
        }
        
        
 
       
    }
}