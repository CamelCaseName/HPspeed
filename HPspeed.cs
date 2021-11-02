using EekCharacterEngine;
using EekCharacterEngine.Interaction;
using EekEvents;
using HouseParty;
using HPdata;
using MelonLoader;
using System.IO.MemoryMappedFiles;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HPspeed
{
    public class HPspeed : MelonMod
    {
        private Scene scene;
        public Data SharedData;
        private readonly MemoryMappedFile MemoryFile = MemoryMappedFile.CreateOrOpen("HousePartyMemoryFile", 1024);
        private MemoryMappedViewAccessor Accessor;
        private AmyCharacter Amy;
        private AshleyCharacter Ashley;
        private BrittneyCharacter Brittney;
        private DerekCharacter Derek;
        private FrankCharacter Frank;
        private KatherineCharacter Katherine;
        private LeahCharacter Leah;
        private LetyCharacter Lety;
        private MadisonCharacter Madison;
        private PatrickCharacter Patrick;
        private RachaelCharacter Rachael;
        private StephanieCharacter Stephanie;
        private VickieCharacter Vickie;
        private PlayerCharacter Player;
        private Vector3 LastPos = new Vector3();
        private GameManager gamer;
        private bool ShownPause = false;
        private bool ShownUnPause = false;


        public override void OnApplicationStart()
        {
            Accessor = MemoryFile.CreateViewAccessor();
            if (Accessor.CanWrite) MelonLogger.Msg("Can Write to MMF");
        }
        public override void OnApplicationQuit()
        {
            Accessor.Dispose();
            MemoryFile.Dispose();
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            scene = SceneManager.GetActiveScene();
            SharedData = InitData(SharedData);
        }

        public override void OnUpdate()
        {
            SharedData = SetData(SharedData);


            Accessor.Write(0, ref SharedData);
        }

        private Data InitData(Data data)
        {
            MelonLogger.Msg($"Writing from scene {scene.name}");
            data.GameMain = scene.name == "GameMain";
            data.MainMenu = scene.name == "MainMenu";
            data.LoadingScreen = scene.name == "LoadingScreen";
            data.PlayerMoved = false;

            if (data.GameMain)
            {
                unsafe
                {
                    for (int i = 0; i < ApplicationManager.Version.Length; i++)
                    {
                        *(data.GameVersion + sizeof(char) * i) = ApplicationManager.Version.ToCharArray()[i];
                    }
                }
                Amy = Object.FindObjectOfType<AmyCharacter>();
                Ashley = Object.FindObjectOfType<AshleyCharacter>();
                Brittney = Object.FindObjectOfType<BrittneyCharacter>();
                Derek = Object.FindObjectOfType<DerekCharacter>();
                Frank = Object.FindObjectOfType<FrankCharacter>();
                Katherine = Object.FindObjectOfType<KatherineCharacter>();
                Leah = Object.FindObjectOfType<LeahCharacter>();
                Lety = Object.FindObjectOfType<LetyCharacter>();
                Madison = Object.FindObjectOfType<MadisonCharacter>();
                Patrick = Object.FindObjectOfType<PatrickCharacter>();
                Rachael = Object.FindObjectOfType<RachaelCharacter>();
                Stephanie = Object.FindObjectOfType<StephanieCharacter>();
                Vickie = Object.FindObjectOfType<VickieCharacter>();
                Player = Object.FindObjectOfType<PlayerCharacter>();
                gamer = Object.FindObjectOfType<GameManager>();
                LastPos = Player.PlayerRootTransform.position;
            }

            return data;
        }

        private Data SetData(Data data)
        {
            data.GameMain = scene.name == "GameMain";
            data.MainMenu = scene.name == "MainMenu";
            data.LoadingScreen = scene.name == "LoadingScreen";

            if (data.GameMain) // in game
            {
                for (int i = 0; i < 7; i++)
                {
                    if (Amy != null)
                    {
                        data.AmyClothes |= Amy.Clothes.IsWearing((ClothingTypes)i, 0) ? (1 << i) : 0;
                        data.AmyClothes &= Amy.Clothes.IsWearing((ClothingTypes)i, 0) ? ~0 : ~(1 << i);
                    }
                    if (Ashley != null)
                    {
                        data.AshleyClothes |= Ashley.Clothes.IsWearing((ClothingTypes)i, 0) ? (1 << i) : 0;
                        data.AshleyClothes &= Ashley.Clothes.IsWearing((ClothingTypes)i, 0) ? ~0 : ~(1 << i);
                    }
                    if (Brittney != null)
                    {
                        data.BrittneyClothes |= Brittney.Clothes.IsWearing((ClothingTypes)i, 0) ? (1 << i) : 0;
                        data.BrittneyClothes &= Brittney.Clothes.IsWearing((ClothingTypes)i, 0) ? ~0 : ~(1 << i);
                    }
                    if (Derek != null)
                    {
                        data.DerekClothes |= Derek.Clothes.IsWearing((ClothingTypes)i, 0) ? (1 << i) : 0;
                        data.DerekClothes &= Derek.Clothes.IsWearing((ClothingTypes)i, 0) ? ~0 : ~(1 << i);
                    }

                    if (Frank != null)
                    {
                        data.FrankClothes |= Frank.Clothes.IsWearing((ClothingTypes)i, 0) ? (1 << i) : 0;
                        data.FrankClothes &= Frank.Clothes.IsWearing((ClothingTypes)i, 0) ? ~0 : ~(1 << i);
                    }
                    if (Katherine != null)
                    {
                        data.KatherineClothes |= Katherine.Clothes.IsWearing((ClothingTypes)i, 0) ? (1 << i) : 0;
                        data.KatherineClothes &= Katherine.Clothes.IsWearing((ClothingTypes)i, 0) ? ~0 : ~(1 << i);
                    }
                    if (Leah != null)
                    {
                        data.LeahClothes |= Leah.Clothes.IsWearing((ClothingTypes)i, 0) ? (1 << i) : 0;
                        data.LeahClothes &= Leah.Clothes.IsWearing((ClothingTypes)i, 0) ? ~0 : ~(1 << i);
                    }
                    if (Lety != null)
                    {
                        data.LetyClothes |= Lety.Clothes.IsWearing((ClothingTypes)i, 0) ? (1 << i) : 0;
                        data.LetyClothes &= Lety.Clothes.IsWearing((ClothingTypes)i, 0) ? ~0 : ~(1 << i);
                    }
                    if (Madison != null)
                    {
                        data.MadisonClothes |= Madison.Clothes.IsWearing((ClothingTypes)i, 0) ? (1 << i) : 0;
                        data.MadisonClothes &= Madison.Clothes.IsWearing((ClothingTypes)i, 0) ? ~0 : ~(1 << i);
                    }
                    if (Patrick != null)
                    {
                        data.PatrickClothes |= Patrick.Clothes.IsWearing((ClothingTypes)i, 0) ? (1 << i) : 0;
                        data.PatrickClothes &= Patrick.Clothes.IsWearing((ClothingTypes)i, 0) ? ~0 : ~(1 << i);
                    }
                    if (Rachael != null)
                    {
                        data.RachaelClothes |= Rachael.Clothes.IsWearing((ClothingTypes)i, 0) ? (1 << i) : 0;
                        data.RachaelClothes &= Rachael.Clothes.IsWearing((ClothingTypes)i, 0) ? ~0 : ~(1 << i);
                    }
                    if (Stephanie != null)
                    {
                        data.StephanieClothes |= Stephanie.Clothes.IsWearing((ClothingTypes)i, 0) ? (1 << i) : 0;
                        data.StephanieClothes &= Stephanie.Clothes.IsWearing((ClothingTypes)i, 0) ? ~0 : ~(1 << i);
                    }
                    if (Vickie != null)
                    {
                        data.VickieClothes |= Vickie.Clothes.IsWearing((ClothingTypes)i, 0) ? (1 << i) : 0;
                        data.VickieClothes &= Vickie.Clothes.IsWearing((ClothingTypes)i, 0) ? ~0 : ~(1 << i);
                    }
                }

                if (Amy != null) data.AmyTopless = Amy.EvaluateIsTopless;
                if (Ashley != null) data.AshleyTopless = Ashley.EvaluateIsTopless;
                if (Brittney != null) data.BrittneyTopless = Brittney.EvaluateIsTopless;
                if (Katherine != null) data.KatherineTopless = Katherine.EvaluateIsTopless;
                if (Leah != null) data.LeahTopless = Leah.EvaluateIsTopless;
                if (Lety != null) data.LetyTopless = Lety.EvaluateIsTopless;
                if (Madison != null) data.MadisonTopless = Madison.EvaluateIsTopless;
                if (Rachael != null) data.RachaelTopless = Rachael.EvaluateIsTopless;
                if (Stephanie != null) data.StephanieTopless = Stephanie.EvaluateIsTopless;
                if (Vickie != null) data.VickieTopless = Vickie.EvaluateIsTopless;

                data.InMenu = gamer.IsPaused;

                if (data.InMenu && !ShownPause)
                {
                    MelonLogger.Msg("Game Paused!");
                    ShownPause = true;
                    ShownUnPause = false;
                }
                else if (!data.InMenu && !ShownUnPause)
                {
                    MelonLogger.Msg("Game Unpaused!");
                    ShownUnPause = true;
                    ShownPause = false;
                }

                //Amy.Intimacy.Came;

                if (Player.PlayerRootTransform.position != LastPos)
                {
                    data.PlayerMoved = true;
                }

                data.TotalTime += Time.deltaTime;

                if (!data.InMenu && data.PlayerMoved)
                {
                    data.Time += Time.deltaTime;
                }

            }

            /*else if (data.MainMenu || data.LoadingScreen || data.InMenu) //loading/pausing
            {

            }
            */
            return data;
        }
    }
}
