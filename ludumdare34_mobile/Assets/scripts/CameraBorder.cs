using UnityEngine;
using System.Collections;

namespace StandardAssets{

	/// <summary>
	/// Adds a border to the top or the side.
	/// Add this one to the child camera!
	/// </summary>
	[ExecuteInEditMode]
	public class CameraBorder : MonoBehaviour {
		/// <summary>
		/// The border Texture (a 1x1 black dot is enough)
		/// </summary>
		public Texture border;

		void OnGUI() {

			//Ensure were on the top
			GUI.depth = 10;
			//Not needed, but to be sure
			GUI.color = Color.black;

			if (!CameraSize.letterbox) {
				GUI.DrawTexture(new Rect(0, 0, Camera.main.pixelRect.x, GetComponent<Camera>().pixelRect.height), border);
				GUI.DrawTexture(new Rect(Camera.main.pixelRect.width + Camera.main.pixelRect.x, 0, GetComponent<Camera>().pixelRect.width - Camera.main.pixelRect.width, GetComponent<Camera>().pixelRect.height), border);
			} else {
				GUI.DrawTexture(new Rect(0, 0, Camera.main.pixelRect.width,Camera.main.pixelRect.y), border);
				GUI.DrawTexture(new Rect(0,Camera.main.pixelRect.y, Camera.main.pixelRect.width, Camera.main.pixelRect.y), border);
			}


		}
	}
}