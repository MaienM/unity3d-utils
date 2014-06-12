
namespace MaienM.PrefabRenderer
{
    public class PrefabRendererFromDirectories : PrefabRenderer
    {
        public List<String> Directories;

        new public void Start()
        {
            LoadPrefabsFromDirectories();
            base.Start();
        }

        /// <summary>
        /// Pulls all prefabs in specified folders, relative to Assets/Resources
        /// </summary>
        private void LoadPrefabsFromDirectories()
        {
            foreach (string dirName in Directories)
            {
                string path = Path.Combine("Assets/Resources/", dirname);
                if (!Directory.Exists(path))
                {
                    Debug.Log_Error(string.Format("The folder {0} doesn't exist. We cannot load prefabs from there.", path));
                    continue;
                }
                DirectoryInfo dir = new DirectoryInfo(path);
                FileInfo[] info = dir.GetFiles("*.prefab");
                foreach (FileInfo f in info)
                {
                    GameObject prefab = Resources.Load<GameObject>(f.Name.Replace(".prefab", ""));
                    if (prefab != null)
                    {
                        prefabs.Add(prefab);
                    }
                }
            }
        }
    }
}
