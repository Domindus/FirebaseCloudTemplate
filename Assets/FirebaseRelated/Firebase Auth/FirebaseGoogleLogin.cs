//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.Threading.Tasks;
//using Firebase;
//using Firebase.Extensions;
//using Firebase.Auth;
//using UnityEngine.UI;
//using Google;

//public class FirebaseGoogleLogin : MonoBehaviour
//{
//    // Required for Google Sign-In, can be found in Firebase
//    public string GoogleWebAPI = "135127784451-f153v7pro4dcu1o79hflioq41nmldv6a.apps.googleusercontent.com";

//    private GoogleSignInConfiguration configuration;

//    Firebase.DependencyStatus dependencyStatus = Firebase.DependencyStatus.UnavailableOther;
//    Firebase.Auth.FirebaseAuth auth;
//    Firebase.Auth.FirebaseUser user;

//    public Text UsernameTxt, UserEmailTxt;
//    public Image UserProfilePic;
//    public string imageUrl;
//    public GameObject LoginScreen, ProfileScreen;

//    void Awake()
//    {
//        // Configure webAPI key with Google
//        configuration = new GoogleSignInConfiguration
//        {
//            WebClientId = GoogleWebAPI,
//            RequestIdToken = true
//        };
//    }

//    void Start()
//    {
//        InitFirebase();



//    }

//    void InitFirebase()
//    {
//        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
//    }

//    public void GoogleSignInClick()
//    {
//        GoogleSignIn.Configuration = configuration;
//        GoogleSignIn.Configuration.UseGameSignIn = false;
//        GoogleSignIn.Configuration.RequestIdToken = true;
//        GoogleSignIn.Configuration.RequestEmail = true;
//        GoogleSignIn.DefaultInstance.SignIn().ContinueWith(OnGoogleAuthenticatedFinished);
//    }

//    void OnGoogleAuthenticatedFinished(Task<GoogleSignInUser> task)
//    {
//        if (task.IsFaulted)
//        {
//            Debug.LogError("Fault");
//        }
//        else if (task.IsCanceled)
//        {
//            Debug.LogError("Login Cancel");
//        }
//        else
//        {
//            Firebase.Auth.Credential credential = Firebase.Auth.GoogleAuthProvider.GetCredential(task.Result.IdToken, null);
//            auth.SignInWithCredentialAsync(credential).ContinueWithOnMainThread(task =>
//            {
//                if (task.IsCanceled)
//                {
//                    Debug.LogError("SignInWithCredentialAsync was canceled.");
//                    return;
//                }
//                if (task.IsFaulted)
//                {
//                    Debug.LogError("SignInWithCredentialAsync encountered an error: " + task.Exception);
//                    return;
//                }

//                user = auth.CurrentUser;
//                //UsernameTxt.text = user.DisplayName;
//                //UserEmailTxt.text = user.Email;
//                //LoginScreen.SetActive(false);
//                //ProfileScreen.SetActive(true);
//                //StartCoroutine(LoadImage(CheckImageUrl(user.PhotoUrl.ToString())));
//            });
//        }
//    }

//    //private string CheckImageUrl(string url)
//    //{
//    //    if (!string.IsNullOrEmpty(url))
//    //    {
//    //        return url;
//    //    }
//    //    return imageUrl;
//    //}

//    //IEnumerator LoadImage(string imageUrl)
//    //{
//    //    WWW www = new WWW(imageUrl);
//    //    yield return www;
//    //    UserProfilePic.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
//    //}
//}