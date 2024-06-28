/**
 * Copyright(c) Live2D Inc. All rights reserved.
 *
 * Use of this source code is governed by the Live2D Open Software license
 * that can be found at https://www.live2d.com/eula/live2d-open-software-license-agreement_en.html.
 */

using UnityEngine;

namespace Live2D.Cubism.Samples.LookAt
{
    /// <summary>
    /// Forces a <see cref="GameObject"/> to face the mouse position.
    /// </summary>
    public class Billboarder : MonoBehaviour
    {
        /// <summary>
        /// Camera to use for calculating mouse position.
        /// </summary>
        [SerializeField] public Camera CameraToFace;

        #region Unity Event Handling

        /// <summary>
        /// Called by Unity. Updates facing.
        /// </summary>
        private void Update()
        {
            // Get mouse position in screen space
            Vector3 mouseScreenPosition = Input.mousePosition;

            // Convert screen space mouse position to world space
            Vector3 mouseWorldPosition = CameraToFace.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, CameraToFace.nearClipPlane));

            // Calculate direction to look at
            Vector3 direction = mouseWorldPosition - transform.position;
            direction.z = 0; // Optional: Ignore the z-axis to keep the object facing in 2D space

            // Rotate the object to face the mouse position
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
            }
        }

        #endregion
    }
}
