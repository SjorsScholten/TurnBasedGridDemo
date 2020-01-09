namespace HinosPackage.Runtime.Util.Timers {
    public interface ITimerCallbacks {
        void OnTimerStart();
        void OnTimerEnd();
        void OnTimerTick();
    }
}