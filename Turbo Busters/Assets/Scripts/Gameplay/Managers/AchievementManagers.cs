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
            PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_first_unlock, 100f, success => { });
#endif
        }

        public void UnlockSecondAchievement()
        {
#if !PLATFORM_IOS
            PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_follow_the_unlocks, 100f, success => { });
#endif
        }

        public void UnlockThirdAchievement()
        {
#if !PLATFORM_IOS
                PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_finishing_up, 100f, success => { });
#endif
        }
    }
}