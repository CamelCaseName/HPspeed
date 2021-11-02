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
        private const int Tops = 9;
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
        private GameManager gamer;
        private bool ShownPause = false;
        private bool ShownUnPause = false;
        private int TimesPaused = 0;


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
                if (Amy != null)
                {
                    /*for (int i = 0; i < 7; i++)
                    {
                        data.AmyClothes |= Amy.Clothes.IsWearing((ClothingTypes)i, 0) ? (1 << i) : 0;
                        data.AmyClothes &= Amy.Clothes.IsWearing((ClothingTypes)i, 0) ? ~0 : ~(1 << i);
                    }*/
                }
                else
                {
                    Amy = Object.FindObjectOfType<AmyCharacter>();
                }

                if (Ashley != null)
                {
                    /*for (int i = 0; i < 7; i++)
                    {
                        data.AshleyClothes |= Ashley.Clothes.IsWearing((ClothingTypes)i, 0) ? (1 << i) : 0;
                        data.AshleyClothes &= Ashley.Clothes.IsWearing((ClothingTypes)i, 0) ? ~0 : ~(1 << i);
                    }*/
                }
                else
                {
                    Ashley = Object.FindObjectOfType<AshleyCharacter>();
                }

                if (Brittney != null)
                {
                    /*for (int i = 0; i < 7; i++)
                    {
                        data.BrittneyClothes |= Brittney.Clothes.IsWearing((ClothingTypes)i, 0) ? (1 << i) : 0;
                        data.BrittneyClothes &= Brittney.Clothes.IsWearing((ClothingTypes)i, 0) ? ~0 : ~(1 << i);
                    }*/
                }
                else
                {
                    Brittney = Object.FindObjectOfType<BrittneyCharacter>();
                }

                if (Derek != null)
                {
                    /*for (int i = 0; i < 7; i++)
                    {
                        data.DerekClothes |= Derek.Clothes.IsWearing((ClothingTypes)i, 0) ? (1 << i) : 0;
                        data.DerekClothes &= Derek.Clothes.IsWearing((ClothingTypes)i, 0) ? ~0 : ~(1 << i);
                    }*/
                }
                else
                {
                    Derek = Object.FindObjectOfType<DerekCharacter>();
                }

                if (Frank != null)
                {
                    /*for (int i = 0; i < 7; i++)
                    {
                        data.FrankClothes |= Frank.Clothes.IsWearing((ClothingTypes)i, 0) ? (1 << i) : 0;
                        data.FrankClothes &= Frank.Clothes.IsWearing((ClothingTypes)i, 0) ? ~0 : ~(1 << i);
                    }*/
                }
                else
                {
                    Frank = Object.FindObjectOfType<FrankCharacter>();
                }

                if (Katherine != null)
                {
                    /*for (int i = 0; i < 7; i++)
                    {
                        data.KatherineClothes |= Katherine.Clothes.IsWearing((ClothingTypes)i, 0) ? (1 << i) : 0;
                        data.KatherineClothes &= Katherine.Clothes.IsWearing((ClothingTypes)i, 0) ? ~0 : ~(1 << i);
                    }*/
                }
                else
                {
                    Katherine = Object.FindObjectOfType<KatherineCharacter>();
                }

                if (Leah != null)
                {
                    /*for (int i = 0; i < 7; i++)
                    {
                        data.LeahClothes |= Leah.Clothes.IsWearing((ClothingTypes)i, 0) ? (1 << i) : 0;
                        data.LeahClothes &= Leah.Clothes.IsWearing((ClothingTypes)i, 0) ? ~0 : ~(1 << i);
                    }*/
                }
                else
                {
                    Leah = Object.FindObjectOfType<LeahCharacter>();
                }

                if (Lety != null)
                {
                    /*for (int i = 0; i < 7; i++)
                    {
                        data.LetyClothes |= Lety.Clothes.IsWearing((ClothingTypes)i, 0) ? (1 << i) : 0;
                        data.LetyClothes &= Lety.Clothes.IsWearing((ClothingTypes)i, 0) ? ~0 : ~(1 << i);
                    }*/
                }
                else
                {
                    Lety = Object.FindObjectOfType<LetyCharacter>();
                }

                if (Madison != null)
                {
                    /*for (int i = 0; i < 7; i++)
                    {
                        data.MadisonClothes |= Madison.Clothes.IsWearing((ClothingTypes)i, 0) ? (1 << i) : 0;
                        data.MadisonClothes &= Madison.Clothes.IsWearing((ClothingTypes)i, 0) ? ~0 : ~(1 << i);
                    }*/
                }
                else
                {
                    Madison = Object.FindObjectOfType<MadisonCharacter>();
                }

                if (Patrick != null)
                {
                    /*for (int i = 0; i < 7; i++)
                    {
                        data.PatrickClothes |= Patrick.Clothes.IsWearing((ClothingTypes)i, 0) ? (1 << i) : 0;
                        data.PatrickClothes &= Patrick.Clothes.IsWearing((ClothingTypes)i, 0) ? ~0 : ~(1 << i);
                    }*/
                }
                else
                {
                    Patrick = Object.FindObjectOfType<PatrickCharacter>();
                }

                if (Rachael != null)
                {
                    /*for (int i = 0; i < 7; i++)
                    {
                        data.RachaelClothes |= Rachael.Clothes.IsWearing((ClothingTypes)i, 0) ? (1 << i) : 0;
                        data.RachaelClothes &= Rachael.Clothes.IsWearing((ClothingTypes)i, 0) ? ~0 : ~(1 << i);
                    }*/
                }
                else
                {
                    Rachael = Object.FindObjectOfType<RachaelCharacter>();
                }

                if (Stephanie != null)
                {
                    /*for (int i = 0; i < 7; i++)
                    {
                        data.StephanieClothes |= Stephanie.Clothes.IsWearing((ClothingTypes)i, 0) ? (1 << i) : 0;
                        data.StephanieClothes &= Stephanie.Clothes.IsWearing((ClothingTypes)i, 0) ? ~0 : ~(1 << i);
                    }*/
                }
                else
                {
                    Stephanie = Object.FindObjectOfType<StephanieCharacter>();
                }

                if (Vickie != null)
                {
                    /*for (int i = 0; i < 7; i++)
                    {
                        data.VickieClothes |= Vickie.Clothes.IsWearing((ClothingTypes)i, 0) ? (1 << i) : 0;
                        data.VickieClothes &= Vickie.Clothes.IsWearing((ClothingTypes)i, 0) ? ~0 : ~(1 << i);
                    }*/
                }
                else
                {
                    Vickie = Object.FindObjectOfType<VickieCharacter>();
                }

                if (Player == null)
                {
                    Player = Object.FindObjectOfType<PlayerCharacter>();
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

                if (Player != null)
                {
                    if (Player.GetSpeed != 0f && !data.PlayerMoved && TimesPaused == 1)
                    {
                        data.PlayerMoved = true;
                        data.Time = 0;

                        MelonLogger.Msg("Run started");
                    }
                }

                data.TotalTime += Time.deltaTime;

                if (!data.InMenu && data.PlayerMoved)
                {
                    data.Time += Time.deltaTime;
                }
            }


            if(gamer != null) data.InMenu = gamer.IsPaused;

            if (data.InMenu && !ShownPause)
            {
                MelonLogger.Msg("Game Paused!");
                ShownPause = true;
                ShownUnPause = false;
                TimesPaused++;
                MelonLogger.Msg(data.AmyTopless.ToString());
            }
            else if (!data.InMenu && !ShownUnPause)
            {
                MelonLogger.Msg("Game Unpaused!");
                ShownUnPause = true;
                ShownPause = false;
            }

            return data;
        }
    }
}
