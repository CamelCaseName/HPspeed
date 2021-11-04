using System.Runtime.InteropServices;

namespace HPdata
{
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public struct Data
    {
#pragma warning disable IDE0044 // Add readonly modifier
        public float DeltaTime;
        public float TotalTime;
        public byte IsLoadingScreen;
        public byte IsGameMain;
        public byte IsMainMenu;
        public byte HasPlayerMoved;
        public byte IsInMenu;
        public byte IsRestart;
        public byte AmyClothes;
        public byte AshleyClothes;
        public byte BrittneyClothes;
        public byte DerekClothes;
        public byte FrankClothes;
        public byte KatherineClothes;
        public byte LeahClothes;
        public byte LetyClothes;
        public byte MadisonClothes;
        public byte PatrickClothes;
        public byte RachaelClothes;
        public byte StephanieClothes;
        public byte VickieClothes;
        public byte IsAmyTopless;
        public byte IsAshleyTopless;
        public byte IsBrittneyTopless;
        public byte IsKatherineTopless;
        public byte IsLeahTopless;
        public byte IsLetyTopless;
        public byte IsMadisonTopless;
        public byte IsRachaelTopless;
        public byte IsStephanieTopless;
        public byte IsVickieTopless;
        //unsafe public fixed char GameVersion[30];
#pragma warning restore IDE0044 // Add readonly modifier

        public override string ToString()
        {
            return $"DT: {DeltaTime} TT: {TotalTime} LS: {IsLoadingScreen} GM: {IsGameMain} MM: {IsMainMenu} IM: {IsInMenu} PM: {HasPlayerMoved}";
        }
    }
}