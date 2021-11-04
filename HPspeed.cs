using EekCharacterEngine;
using HouseParty;
using HouseParty.Interface;
using HPdata;
using MelonLoader;
using System.IO.MemoryMappedFiles;
using System.Linq.Expressions;
using System.Reflection;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HPspeed
{
    public class HPspeed : MelonMod
    {
        private const int Tops = 9;
        private Scene scene;
        public Data SharedData;
        private readonly MemoryMappedFile MemoryFile = MemoryMappedFile.CreateOrOpen("HousePartyMemoryFile", 2048);
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
        //private GameMenu menu;
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
            Accessor.Read(0, out SharedData);

            SharedData = SetData(SharedData);

            Accessor.Write(0, ref SharedData);
        }

        private Data InitData(Data data)
        {
            MelonLogger.Msg($"Writing from scene {scene.name}");
            data.IsGameMain = (byte)(scene.name == "GameMain" ? 1 : 0);
            data.IsMainMenu = (byte)(scene.name == "MainMenu" ? 1 : 0);
            data.IsLoadingScreen = (byte)(scene.name == "LoadingScreen" ? 1 : 0);
            data.HasPlayerMoved = 0;

            if (data.IsGameMain == 1)
            {
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
                //menu = Object.FindObjectOfType<GameMenu>();
            }

            if (data.IsGameMain == 1 && data.IsMainMenu == 1)
            {
                //menu = Object.FindObjectOfType<GameMenu>();
                GameMenu.add_OnStartOverPressed((GameMenu.OnMenuButtonPressedDelegate)Il2CppSystem.Delegate.CreateDelegate(Il2CppType.Of<GameMenu.OnMenuButtonPressedDelegate>(), ((GameMenu.OnMenuButtonPressedDelegate)OnGameRestart).Method));
            }

            return data;
        }

        public void OnGameRestart()
        {
            MelonLogger.Msg("It do fucking work wtf");
        }


        private Data SetData(Data data)
        {
            if (data.IsRestart == 1)
            {
                data.HasPlayerMoved = 0;
                TimesPaused = 1;
                data.IsRestart = 0;
                data.DeltaTime = 0;
                data.TotalTime = 0;
            }
            else
            {
                data.IsGameMain = (byte)(scene.name == "GameMain" ? 1 : 0);
                data.IsMainMenu = (byte)(scene.name == "MainMenu" ? 1 : 0);
                data.IsLoadingScreen = (byte)(scene.name == "LoadingScreen" ? 1 : 0);

                if (data.IsGameMain == 1) // in game
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


                    if (Amy != null) data.IsAmyTopless = (byte)(Amy.EvaluateIsTopless ? 1 : 0);
                    if (Ashley != null) data.IsAshleyTopless = (byte)(Ashley.EvaluateIsTopless ? 1 : 0);
                    if (Brittney != null) data.IsBrittneyTopless = (byte)(Brittney.EvaluateIsTopless ? 1 : 0);
                    if (Katherine != null) data.IsKatherineTopless = (byte)(Katherine.EvaluateIsTopless ? 1 : 0);
                    if (Leah != null) data.IsLeahTopless = (byte)(Leah.EvaluateIsTopless ? 1 : 0);
                    if (Lety != null) data.IsLetyTopless = (byte)(Lety.EvaluateIsTopless ? 1 : 0);
                    if (Madison != null) data.IsMadisonTopless = (byte)(Madison.EvaluateIsTopless ? 1 : 0);
                    if (Rachael != null) data.IsRachaelTopless = (byte)(Rachael.EvaluateIsTopless ? 1 : 0);
                    if (Stephanie != null) data.IsStephanieTopless = (byte)(Stephanie.EvaluateIsTopless ? 1 : 0);
                    if (Vickie != null) data.IsVickieTopless = (byte)(Vickie.EvaluateIsTopless ? 1 : 0);

                    if (Player != null)
                    {
                        if (Player.GetSpeed != 0f && data.HasPlayerMoved == 0 && TimesPaused == 1)
                        {
                            data.HasPlayerMoved = 1;
                            data.DeltaTime = 0;
                            data.TotalTime = 0;

                            MelonLogger.Msg("Run started");
                        }
                    }
                }

                data.TotalTime += Time.deltaTime;
                data.DeltaTime = Time.deltaTime;
            }

            //paused state
            if (gamer != null) data.IsInMenu = (byte)(gamer.IsPaused ? 1 : 0);

            //pause state output
            if (data.IsInMenu == 1 && !ShownPause)
            {
                MelonLogger.Msg("Game Paused!");
                ShownPause = true;
                ShownUnPause = false;
                TimesPaused++;
                //MelonLogger.Msg(data.AmyTopless.ToString());
            }
            else if (data.IsInMenu == 0 && !ShownUnPause)
            {
                MelonLogger.Msg("Game Unpaused!");
                ShownUnPause = true;
                ShownPause = false;
            }

            return data;
        }
    }
}