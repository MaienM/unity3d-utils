using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Collections;

namespace MaienM.PrefabRenderer
{
    /// <summary>
    /// Renders prefabs and stores the renders into renderedtextures.
    /// </summary>
    public class PrefabRenderer : MonoBehaviour
    {
        /// <summary>
        /// The prefabs to process.
        /// </summary>
        public List<GameObject> prefabs;

        /// <summary>
        /// Dictionary containing the prefab name as key, and rendered texture as value
        /// </summary>
        public static Dictionary<string, RenderTexture> RenderedTextures = new Dictionary<string, RenderTexture>();

        /// <summary>
        /// Whether the rendering process has been completed.
        /// </summary>
        public static bool Done = false;

        /// <summary>
        /// The width of the rendertextures
        /// </summary>
        public int TextureWidth = 0;

        /// <summary>
        /// The height of the rendertextures
        /// </summary>
        public int TextureHeight = 0;

        /// <summary>
        /// The depth of the rendertextures
        /// </summary>
        public int TextureDepth = 0;

        /// <summary>
        /// The position the prefabs should be placed
        /// </summary>
        public Vector3 TargetOffset;

        /// <summary>
        /// The rotation of instantiated objects
        /// </summary>
        public Vector3 TargetRotation;

        /// <summary>
        /// Start the main coroutine.
        /// </summary>
        public void Start()
        {
            StartCoroutine(ProcessPrefabs());
        }

        /// <summary>
        /// A coroutine that processes all the prefabs into rendertextures.
        /// </summary>
        /// <returns></returns>
        private IEnumerator ProcessPrefabs()
        {
            GameObject obj;
            RenderTexture tex;

            foreach (GameObject prefab in prefabs)
            {
                obj = GameObject.Instantiate(prefab, transform.position + TargetOffset, Quaternion.Euler(TargetRotation)) as GameObject;
                tex = new RenderTexture(TextureWidth, TextureHeight, TextureDepth, RenderTextureFormat.Default);
                gameObject.camera.targetTexture = tex;
                yield return new WaitForEndOfFrame();
                RenderedTextures[prefab] = tex;
                gameObject.camera.targetTexture = null;
                Destroy(obj);
            }
            Done = true;
            Destroy(gameObject);
        }
    }
}