using UnityEngine;

using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.OurUtils;

namespace Scripts.Utilities
{
    public class GoogleServices : Singleton<GoogleServices>
    {
        public bool SignInSuccessful = false;

        private void Start()
        {
            #if UNITY_ANDROID
            PlayGamesPlatform.Activate();
            PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
            #endif
        }

        internal void ProcessAuthentication(SignInStatus status)
        {
            if (status == SignInStatus.Success)
            {
                SignInSuccessful = true;
                Debug.Log("Login Success");
            }
            else
            {
                SignInSuccessful = false;
                Debug.Log("Login Error");
            }
        }

        public void ShowLeaderboard()
        {
            if (!SignInSuccessful)
                return;

            Social.ShowLeaderboardUI();
        }
    }
}