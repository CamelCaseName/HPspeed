using System.Runtime.InteropServices;

namespace HPdata
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Data
    {
#pragma warning disable IDE0044 // Add readonly modifier
        public float DeltaTime;
        public float TotalTime;
        public int LoadingScreen;
        public int GameMain;
        public int MainMenu;
        public int PlayerMoved;
        public int InMenu;
        public int AmyClothes;
        public int AshleyClothes;
        public int BrittneyClothes;
        public int DerekClothes;
        public int FrankClothes;
        public int KatherineClothes;
        public int LeahClothes;
        public int LetyClothes;
        public int MadisonClothes;
        public int PatrickClothes;
        public int RachaelClothes;
        public int StephanieClothes;
        public int VickieClothes;
        public int AmyTopless;
        public int AshleyTopless;
        public int BrittneyTopless;
        public int KatherineTopless;
        public int LeahTopless;
        public int LetyTopless;
        public int MadisonTopless;
        public int RachaelTopless;
        public int StephanieTopless;
        public int VickieTopless;
        //unsafe public fixed char GameVersion[30];
#pragma warning restore IDE0044 // Add readonly modifier

        public override string ToString()
        {
            return $"DT: {DeltaTime} TT: {TotalTime} LS: {LoadingScreen} GM: {GameMain} MM: {MainMenu} IM: {InMenu} PM: {PlayerMoved}";
        }
    }
}
