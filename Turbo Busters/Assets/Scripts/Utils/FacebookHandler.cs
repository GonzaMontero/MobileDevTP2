using Facebook.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FacebookHandler : MonoBehaviour
{
    [Header("References")]
    public TextMeshProUGUI FB_userName;

    private void Awake()
    {
        FB.Init(SetInit, onHidenUnity);

        if (!FB.IsInitialized)
        {
            FB.Init(() =>
            {
                if (FB.IsInitialized)
                    FB.ActivateApp();
                else
                    print("Couldn't initialize");
            },
            isGameShown =>
            {
                if (!isGameShown)
                    Time.timeScale = 0;
                else
                    Time.timeScale = 1;
            });
        }
        else
            FB.ActivateApp();
    }


    void SetInit()
    {
        if (FB.IsLoggedIn)
        {
            Debug.Log("Facebook is Login!");
            string s = "client token" + FB.ClientToken + "User Id" + AccessToken.CurrentAccessToken.UserId + "token string" + AccessToken.CurrentAccessToken.TokenString;
        }
        else
        {
            Debug.Log("Facebook is not Logged in!");
        }
        DealWithFbMenus(FB.IsLoggedIn);
    }

    void onHidenUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    void DealWithFbMenus(bool isLoggedIn)
    {
        if (isLoggedIn)
        {
            FB.API("/me?fields=first_name", HttpMethod.GET, DisplayUsername);
        }
        else
        {
            Debug.Log("Not logged in");
        }
    }

    void DisplayUsername(IResult result)
    {
        if (result.Error == null)
        {
            string name = "" + result.ResultDictionary["first_name"];
            if (FB_userName != null) FB_userName.text = name;
            FB_userName.text = name;
            Debug.Log("" + name);
        }
        else
        {
            Debug.Log(result.Error);
        }
    }

    public void Facebook_LogIn()
    {
        List<string> permissions = new List<string>();
        permissions.Add("public_profile");
        //permissions.Add("user_friends");
        FB.LogInWithReadPermissions(permissions, AuthCallBack);

    }

    void AuthCallBack(IResult result)
    {
        if (FB.IsLoggedIn)
        {
            SetInit();
            //AccessToken class will have session details
            var aToken = AccessToken.CurrentAccessToken;

            print(aToken.UserId);

            foreach (string perm in aToken.Permissions)
            {
                print(perm);
            }
        }
        else
        {
            print("Failed to log in");
        }

    }

    //logout
    public void Facebook_LogOut()
    {
        StartCoroutine(LogOut());
    }

    IEnumerator LogOut()
    {
        FB.LogOut();
        while (FB.IsLoggedIn)
        {
            print("Logging Out");
            yield return null;
        }
        print("Logout Successful");
        if (FB_userName != null) FB_userName.text = "";
    }

    public void FacebookSharefeed()
    {
        FB.ShareLink(new System.Uri("https://github.com/GonzaMontero/MobileDevTP2"), "Check it out!",
            "Project Repository", new System.Uri("https://resocoder.com/wp-content/uploads/2017/01/logoRound512.png"));
    }

    public void FacebookFriendRequest()
    {
        FB.AppRequest("Hey! Come and play this awesome game", title: "Tower Defense");
    }
}
