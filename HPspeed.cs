using MelonLoader;
using System.IO.MemoryMappedFiles;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HPspeed
{
    public class HPspeed : MelonMod
    {
        private Scene scene = SceneManager.GetActiveScene();
        public Data SharedData;
        private MemoryMappedFile MemoryFile = MemoryMappedFile.CreateOrOpen("HousePartyMemoryFile",1024);
        private MemoryMappedViewAccessor Accessor;


        public override void OnApplicationStart()
        {
            Accessor = MemoryFile.CreateViewAccessor();
        }
        public override void OnApplicationQuit()
        {
            Accessor.Dispose();
            MemoryFile.Dispose();
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {

        }

        public override void OnUpdate()
        {
            SharedData.DeltaTime = Time.deltaTime;
            SharedData.GameMain = scene.name == "GameMain";
            SharedData.MainMenu = scene.name == "MainMenu";
            SharedData.LoadingScreen = scene.name == "LoadingScreen";

            Accessor.Write(0, ref SharedData);
        }
    }
}
