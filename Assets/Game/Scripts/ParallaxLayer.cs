using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using TMPro;

public class ParallaxLayer : MonoBehaviour
{

    #region FIELDS

        [Header("NOTES")] [TextArea(4, 10)]
        public string notes;

        [Space(20)] [Header("VARIABLES")]
            
            [Header("Basic Variables")]
            public float parallaxFactor = 0.5f; // Lower = slower, Higher = closer to camera
            private Vector3 lastCameraPosition;
            private Transform cameraTransform;
            private float initialYValue;

    #endregion

    #region LIFE CYCLE METHODS

        /// <summary>
        /// Called when the script instance is being loaded.
        /// Useful for initialization before the game starts.
        /// </summary>
        void Awake()
        {
            // Initialize variables or cache references here.
            // Example: Setting up components or data before start is called.
            
            // Example of adding a component.
            // MyGame.Utils.AddComponent<SpriteRenderer>(out spriteRenderer, gameObject, this.GetType().Name);   
        }

        /// <summary>
        /// Called before the first frame update.
        /// Useful for initialization once the game starts.
        /// </summary>
        void Start()
        {
            cameraTransform = Camera.main.transform;
            lastCameraPosition = cameraTransform.position;
            initialYValue = transform.position.y;
        }

        /// <summary>
        /// Called once per frame.
        /// Use for logic that needs to run every frame, such as user input or animations.
        /// </summary>
        void Update()
        {
            // Add your per-frame logic here.
            // Example: Move objects, check user input, update animations, etc.
        }

        /// <summary>
        /// Called at fixed intervals, ideal for physics updates.
        /// Use this for physics-related updates like applying forces or handling Rigidbody physics.
        /// </summary>
        void FixedUpdate()
        {
            // Add physics-related logic here.
            // Example: Rigidbody movement, applying forces, or collision detection.
        }

        void LateUpdate()
        {
            Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;

            // Only apply X parallax movement
            float parallaxX = deltaMovement.x * parallaxFactor;

            // Apply new position, locking Y
            Vector3 newPosition = transform.position + new Vector3(parallaxX, 0f, 0f);
            newPosition.y = initialYValue;
            transform.position = newPosition;

            lastCameraPosition = cameraTransform.position;
        }

    #endregion

    #region CUSTOM METHODS

        /// <summary>
        /// An example custom method.
        /// Replace with your own custom logic.
        /// </summary>
        void ExampleMethod()
        {
            // Implement custom functionality here.
            // Example: Execute game-specific behavior or helper logic.
        }

        /// <summary>
        /// An example coroutine that waits for 2 seconds.
        /// </summary>
        IEnumerator ExampleCoroutine()
        {
            // Wait for 2 seconds before executing further code.
            yield return new WaitForSeconds(2f);

            Debug.Log("Action after 2 seconds.");
        }

    #endregion

}