using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using System;
using System.Threading.Tasks;
using Firebase.Extensions;
using Firebase.Database;
using Firebase;

public class FirebaseController : MonoBehaviour
{
    [SerializeField] private GameObject loginPanel, signupPanel, homePanel, forgotPasswordPanel, notificationPanel, welcomePanel;
    [SerializeField] private InputField loginEmail, loginPassword, signupEmail, signupPassword, signupCPassword, signupName, forgetPassEmail;
    [SerializeField] private Text notif_Title_Text, notif_Message_Text, profileUserName_Text, profileUserEmail_Text;
    [SerializeField] private Toggle remember;
    public InputField Username;

    DatabaseReference dbReference;

    Firebase.Auth.FirebaseAuth auth;
    public Firebase.Auth.FirebaseUser user;
    public bool isSingIn = false;

    void Start()
    {
        if (isSingIn == false)
        {
            OpenWelcomePanel();
        }

        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                InitializeFirebase();

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });

        dbReference = FirebaseDatabase.DefaultInstance.RootReference;

    }




    public void OpenLoginPanel()
    {
        loginPanel.SetActive(true);
        signupPanel.SetActive(false);
        homePanel.SetActive(false);
        forgotPasswordPanel.SetActive(false);
        welcomePanel.SetActive(false);
    }

    public void OpenSignUpPanel()
    {
        loginPanel.SetActive(false);
        signupPanel.SetActive(true);
        homePanel.SetActive(false);
        forgotPasswordPanel.SetActive(false);
        welcomePanel.SetActive(false);
    }

    public void OpenHomePanel()
    {
        loginPanel.SetActive(false);
        signupPanel.SetActive(false);
        homePanel.SetActive(true);
        forgotPasswordPanel.SetActive(false);
        welcomePanel.SetActive(false);
    }

    public void OpenForgetPanel()
    {
        loginPanel.SetActive(false);
        signupPanel.SetActive(false);
        homePanel.SetActive(false);
        forgotPasswordPanel.SetActive(true);
        welcomePanel.SetActive(false);
    }

    public void OpenWelcomePanel()
    {
        loginPanel.SetActive(false);
        signupPanel.SetActive(false);
        homePanel.SetActive(false);
        forgotPasswordPanel.SetActive(false);
        welcomePanel.SetActive(true);
    }

    public void LoginUser()
     {
        if(string.IsNullOrEmpty(loginEmail.text) && string.IsNullOrEmpty(loginPassword.text))
        {
            ShowNotificationMessage("Error", "Fields empty! Please input details in all fields");
            return;
        }

        //if not null then login
        SingInUser(loginEmail.text, loginPassword.text);

    }

    public void SignUpUser()
    {
        if (string.IsNullOrEmpty(signupEmail.text) && string.IsNullOrEmpty(signupPassword.text) && string.IsNullOrEmpty(signupCPassword.text) && string.IsNullOrEmpty(signupName.text))
        {
            ShowNotificationMessage("Error", "Fields empty! Please input details in all fields");
            return;
        }

        //if not null then SignUp
        CreateUser(signupEmail.text, signupPassword.text, signupName.text);


    }


    public void ForgetPass()
    {
        if (string.IsNullOrEmpty(forgetPassEmail.text))
        {
            ShowNotificationMessage("Error", "Fields empty! Please input details in all fields");
            return;
        }

        //if not null then reset password

        ForgetPasswordSubmit(forgetPassEmail.text);

    }

    private void ShowNotificationMessage(string title, string message)
    {
        notif_Title_Text.text = "" + title;
        notif_Message_Text.text = "" + message;
        notificationPanel.SetActive(true);
    }

    public void CloseNotif_Panel()
    {
        notificationPanel.SetActive(false);
        notif_Title_Text.text = "";
        notif_Message_Text.text = "";
        
    }

    public void LogOut()
    {
        isSingIn = false;
        OpenLoginPanel();
        auth.SignOut();
        profileUserName_Text.text = "";
        profileUserEmail_Text.text = "";
        
    }


    void CreateUser(string email, string password, string Username)
    {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);

                foreach (Exception exception in task.Exception.Flatten().InnerExceptions)
                {

                    Firebase.FirebaseException firebaseEx = exception as Firebase.FirebaseException;
                    if (firebaseEx != null)
                    {
                        var errorCode = (AuthError)firebaseEx.ErrorCode;
                        ShowNotificationMessage("Error", GetErrorMessage(errorCode));
                    }

                }

                return;
            }

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);

            UpdateUserProfile(Username);

            //create register of the user on database
            dbReference.Child(user.UserId).Child("UserInfo").Child("ID").SetValueAsync(newUser.UserId);
            dbReference.Child(user.UserId).Child("UserInfo").Child("Name").SetValueAsync(Username);
            dbReference.Child(user.UserId).Child("UserInfo").Child("Email").SetValueAsync(newUser.Email);

        });

        
    }

    public void SingInUser(string email, string password)
    {
        auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);

                foreach (Exception exception in task.Exception.Flatten().InnerExceptions)
                {      
                    Firebase.FirebaseException firebaseEx = exception as Firebase.FirebaseException;
                    if (firebaseEx != null)
                    {
                        var errorCode = (AuthError)firebaseEx.ErrorCode;
                        ShowNotificationMessage("Error", GetErrorMessage(errorCode));
                    }

                }

                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
            profileUserName_Text.text = "" + newUser.DisplayName;
            profileUserEmail_Text.text = "" + newUser.Email;
            OpenHomePanel();
        });

        

    }

   

    void InitializeFirebase()
    {
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }

    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if (auth.CurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && user != null)
            {
                Debug.Log("Signed out " + user.UserId);
            }
            user = auth.CurrentUser;
            if (signedIn)
            {
                Debug.Log("Signed in " + user.UserId);
                isSingIn = true;


            }
        }
    }

    void OnDestroy()
    {
        auth.StateChanged -= AuthStateChanged;
        auth = null;
    }

    void UpdateUserProfile(string UserName)
    {
        Firebase.Auth.FirebaseUser user = auth.CurrentUser;
        if (user != null)
        {
            Firebase.Auth.UserProfile profile = new Firebase.Auth.UserProfile
            {
                DisplayName = UserName,
                PhotoUrl = new System.Uri("https://via.placeholder.com/150"),
            };
            user.UpdateUserProfileAsync(profile).ContinueWith(task => {
                if (task.IsCanceled)
                {
                    Debug.LogError("UpdateUserProfileAsync was canceled.");
                    return;
                }
                if (task.IsFaulted)
                {
                    Debug.LogError("UpdateUserProfileAsync encountered an error: " + task.Exception);
                    return;
                }

                Debug.Log("User profile updated successfully.");

                ShowNotificationMessage("Alert", "Account successfully created");
            });
        }
    }

    bool loged = true;

    void Update()
    {
        if (isSingIn)
        {
            if (loged)
            {
                loged = true;
                OpenHomePanel();
                profileUserName_Text.text = "" + user.DisplayName;
                profileUserEmail_Text.text = "" + user.Email;
            }
            if (loged == false)
            {
                OpenWelcomePanel();
            }
        }
        

        

    }

    private static string GetErrorMessage(AuthError errorCode)
    {
        var message = "";
        switch (errorCode)
        {
            case AuthError.AccountExistsWithDifferentCredentials:
                message = "Account Not Exist";
                break;
            case AuthError.MissingPassword:
                message = "Missing Password";
                break;
            case AuthError.WeakPassword:
                message = "Password So Weak";
                break;
            case AuthError.WrongPassword:
                message = "Wrong Password";
                break;
            case AuthError.EmailAlreadyInUse:
                message = "Your Email Already in Use";
                break;
            case AuthError.InvalidEmail:
                message = "Your Email is Invalid";
                break;
            case AuthError.MissingEmail:
                message = "Email Missing";
                break;
            default:
                message = "Invalid Error";
                break;
        }
        return message;
    }

    void ForgetPasswordSubmit(string forgetPasswordEmail)
    {
        auth.SendPasswordResetEmailAsync(forgetPasswordEmail).ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                Debug.LogError("SendPasswordResetEmailAsync was canceled");
            }
            if (task.IsFaulted)
            {
                foreach (Exception exception in task.Exception.Flatten().InnerExceptions)
                {

                    Firebase.FirebaseException firebaseEx = exception as Firebase.FirebaseException;
                    if (firebaseEx != null)
                    {
                        var errorCode = (AuthError)firebaseEx.ErrorCode;
                        ShowNotificationMessage("Error", GetErrorMessage(errorCode));
                    }

                }
            }
            ShowNotificationMessage("Alert", "Successfully send email for reset password");

        });
    }


    /// Database
    public void SaveData()
    {
        dbReference.Child(user.UserId).Child("UserInfo").Child("name").SetValueAsync(Username.text);
        dbReference.Child(user.UserId).Child("UserInfo2").Child("sobrenome").SetValueAsync(Username.text);
    }

}
