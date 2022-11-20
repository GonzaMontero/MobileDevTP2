using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class AchievementManager : SingletonBase<AchievementManager>
{
   public void FirstUnlockAchievement()
    {
        PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_first_unlock, 100.0f, success => { });
    }

    public void SecondUnlockAchievement()
    {
        PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_follow_the_unlocks, 100.0f, success => { });
    }

    public void ThirdUnlockAchievement()
    {
        PlayGamesPlatform.Instance.ReportProgress(GPGSIds.achievement_finishing_up, 100.0f, success => { });
    }
}
