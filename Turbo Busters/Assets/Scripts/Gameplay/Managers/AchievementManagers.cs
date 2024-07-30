using Scripts.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

namespace Scripts.Gameplay
{
    public class AchievementManagers : Singleton<AchievementManagers>
    {
        public void UnlockFirstAchievement()
        {
#if !PLATFORM_IOS
            PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_wave_runner, 100f, success => { });
#endif
        }

        public void UnlockSecondAchievement()
        {
#if !PLATFORM_IOS
            PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_wave_splitter, 100f, success => { });
#endif
        }

        public void UnlockThirdAchievement()
        {
#if !PLATFORM_IOS
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_wave_freerunner, 100f, success => { });
#endif
        }
    }
}