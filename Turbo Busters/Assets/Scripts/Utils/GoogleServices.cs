using UnityEngine;

using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.OurUtils;

namespace Scripts.Utilities
{
    public class GoogleServices : MonoBehaviour
    {
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
                Debug.Log("Login Success");
            }
            else
            {
                Debug.Log("Login Error");
            }
        }
    }
}