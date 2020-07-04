using UnityEngine.UI;
using UnityEngine;
using GameSparks.Api.Requests;
using UnityEngine.SceneManagement;
using System.Collections;

public class RegisterLogin : MonoBehaviour {

    #region Variables
    [SerializeField]
    private InputField UserNameInput, PasswordInput;
    [SerializeField]
    private Text Dialog;
    #endregion

	public void Register() {
        RegistrationRequest NewUser = new RegistrationRequest();

        NewUser.SetDisplayName(UserNameInput.text);
        NewUser.SetUserName(UserNameInput.text);
        NewUser.SetPassword(PasswordInput.text);

        NewUser.Send((response) =>
        {
            // Checking result of operation
            if (!response.HasErrors)
            {
                Debug.Log("Register Success; new username is " + response.DisplayName);

                Login(UserNameInput.text, PasswordInput.text);
            }
            else if (response.Errors.JSON.ToString().Contains("TAKEN"))
            {
                StartCoroutine(Mammad("This Username is Exist!"));
            }
            else
            {
                Debug.Log(response.Errors.JSON.ToString());
            }
        });
    }
    //public void Register(string username, string email, string password)
    //{
    //    BacktoryUser NewUser = new BacktoryUser
    //    {
    //        Username = username,
    //        Email = email,
    //        Password = password
    //    };

    //    NewUser.RegisterInBackground(response =>
    //    {
    //        // Checking result of operation
    //        if (response.Successful)
    //        {
    //            Debug.Log("Register Success; new username is " + response.Body.Username);

    //            Login(username, password);
    //        }
    //        else if (response.Code == (int)BacktoryHttpStatusCode.Conflict)
    //        {
    //            // Username is invalid
    //            Debug.Log("Bad username; a user with this username already exists.");
    //        }
    //        else if (response.Code == (int)BacktoryHttpStatusCode.NotFound)
    //        {
    //            // Username is invalid
    //            Debug.Log("your authentication is  wrong");
    //        }
    //        else
    //        {
    //            // General failure
    //            Debug.Log("Registration failed; for network or some other reasons: " + response.Code.ToString());
    //        }
    //    });
    //}

    public void RegisterAsGuest()
    {
        DeviceAuthenticationRequest user = new DeviceAuthenticationRequest();

        user.Send((respone) =>
        {
            if (!respone.HasErrors)
            {
                Debug.Log("ok");
                SceneManager.LoadScene(0);
            }
            else
            {
                // Operation generally failed, maybe internet connection issue
                Debug.Log(respone.Errors.JSON.ToString());
            }
        });
    }

    public void Login()
    {
        AuthenticationRequest user = new AuthenticationRequest();

        user.SetUserName(UserNameInput.text);
        user.SetPassword(PasswordInput.text);

        user.Send((respone) => {
            // Login operation done (fail or success), handling it:
            if (!respone.HasErrors)
            {
                // Login successful
                Debug.Log("Welcome " + respone.DisplayName);
                SceneManager.LoadScene(0);
            }
            else if(respone.Errors.JSON.ToString().Contains("UNRECOGNISED"))
            {
                StartCoroutine(Mammad("Username or Password is wrong."));
            } 
            else
            {
                Debug.Log(respone.Errors.JSON.ToString());
            }
        });

        new LogEventRequest().SetEventKey("USER_INF").SetEventAttribute("USERNAME", UserNameInput.text).Send((respone) => {
            if (respone.HasErrors)
            {
                print(respone.Errors.JSON.ToString());
            }
        });
    }
    public void Login(string username, string password)
    {
        AuthenticationRequest user = new AuthenticationRequest();

        user.SetUserName(username);
        user.SetPassword(password);

        user.Send((respone) => {
            // Login operation done (fail or success), handling it:
            if (!respone.HasErrors)
            {
                // Login successful
                Debug.Log("Welcome " + respone.DisplayName);
                SceneManager.LoadScene(0);
            }
            else if (respone.Errors.JSON.ToString().Contains("UNRECOGNISED"))
            {
                StartCoroutine(Mammad("Username or Password is wrong."));
            }
            else
            {
                Debug.Log(respone.Errors.JSON.ToString());
            }
        });

        new LogEventRequest().SetEventKey("USER_INF").SetEventAttribute("USERNAME", username).Send((respone) => {
            if (respone.HasErrors)
            {
                print(respone.Errors.JSON.ToString());
            }
            else
            {
                print("Hey");
            }
        });
    }

    //public void CompleteGuest()
    //{
    //    // Fill "complete registration" form from Activity or other ways
    //    BacktoryUser.GuestCompletionParam parameters = new BacktoryUser.GuestCompletionParam()
    //    // creating new instance and initializing properties inline
    //    {
    //        FirstName = UFirstName.text,
    //        LastName = ULastName.text,
    //        Email = UEmailInput.text,
    //        NewPassword = UNewPassword.text,
    //        NewUsername = UUserNameInput.text
    //    };

    //    // CurrentUser is your guest user, so get your currentUser and complete his/her registration
    //    BacktoryUser.CurrentUser.CompleteRegistrationInBackgrond(parameters,
    //        completedUserResponse =>
    //        {
    //    // Checking result of operation
    //    if (completedUserResponse.Successful)
    //            {
    //        // Hooray, You are a normal user now!
    //        string firstName = completedUserResponse.Body.FirstName;
    //                Debug.Log(firstName + ", thanks for registration.");
    //            }
    //            else if (completedUserResponse.Code == (int)BacktoryHttpStatusCode.Conflict)
    //            {
    //        // You requested username “a_farahani” already exists
    //        Debug.Log("A user with this username already exists.");
    //            }
    //            else
    //            {
    //        // Operation generally failed, maybe internet connection issue
    //        Debug.Log("Registration failed.");
    //            }
    //        });
    //}
    //public void CompleteGueststring(string firstname, string lastname, string username, string email, string password)
    //{
    //    // Fill "complete registration" form from Activity or other ways
    //    BacktoryUser.GuestCompletionParam parameters = new BacktoryUser.GuestCompletionParam()
    //    // creating new instance and initializing properties inline
    //    {
    //        FirstName = firstname,
    //        LastName = lastname,
    //        NewUsername = username,
    //        Email = email,
    //        NewPassword = password,
    //    };

    //    // CurrentUser is your guest user, so get your currentUser and complete his/her registration
    //    BacktoryUser.CurrentUser.CompleteRegistrationInBackgrond(parameters,
    //        completedUserResponse =>
    //        {
    //            // Checking result of operation
    //            if (completedUserResponse.Successful)
    //            {
    //                // Hooray, You are a normal user now!
    //                string firstName = completedUserResponse.Body.FirstName;
    //                Debug.Log(firstName + ", thanks for registration.");
    //            }
    //            else if (completedUserResponse.Code == (int)BacktoryHttpStatusCode.Conflict)
    //            {
    //                // You requested username “a_farahani” already exists
    //                Debug.Log("A user with this username already exists.");
    //            }
    //            else
    //            {
    //                // Operation generally failed, maybe internet connection issue
    //                Debug.Log("Registration failed.");
    //            }
    //        });
    //}

    //public void UpdateUser()
    //{
    //    // Get current user of system
    //    BacktoryUser currentUser = BacktoryUser.CurrentUser;

    //    // Change his/her profile
    //    currentUser.FirstName = UFirstName.text;
    //    currentUser.LastName = ULastName.text;
    //    currentUser.Username = UUserNameInput.text;
    //    currentUser.PhoneNumber = UPhoneNumber.text;
    //    currentUser.Email = UEmailInput.text;

    //    // Send update command to backtory servers
    //    currentUser.UpdateUserInBackground(updatedUserResponse =>
    //    {
    //        // Checking whether operation was OK or not.
    //        if (updatedUserResponse.Successful)
    //        {
    //            // It was OK :)
    //            Debug.Log("Your user updated successfully.");
    //        }
    //        else
    //        {
    //            // It failed. :(
    //            Debug.Log("Request failed.");
    //        }
    //    });
    //}
    //public void UpdateUser(string firstname, string lastname, string username, string email, string phonenumber)
    //{
    //    // Get current user of system
    //    BacktoryUser currentUser = BacktoryUser.CurrentUser;

    //    // Change his/her profile
    //    currentUser.FirstName = firstname;
    //    currentUser.LastName = lastname;
    //    currentUser.Username = username;
    //    currentUser.PhoneNumber = phonenumber;
    //    currentUser.Email = email;

    //    // Send update command to backtory servers
    //    currentUser.UpdateUserInBackground(updatedUserResponse =>
    //    {
    //        // Checking whether operation was OK or not.
    //        if (updatedUserResponse.Successful)
    //        {
    //            // It was OK :)
    //            Debug.Log("Your user updated successfully.");
    //        }
    //        else
    //        {
    //            // It failed. :(
    //            Debug.Log("Request failed.");
    //        }
    //    });
    //}

    //public void ChangePassword()
    //{
    //    // Getting old and new password
    //    string oldPassword = ULastPassword.text;
    //    string newPassword = UNewPassword.text;

    //    // Requesting change password to backtory
    //    BacktoryUser.CurrentUser.ChangePasswordInBackground(oldPassword, newPassword,
    //        changePassResponse =>
    //        {
    //    // Operation done (success or fail), handling it:
    //    if (changePassResponse.Successful)
    //            {
    //        // Password changed successfully
    //        Debug.Log("Your password successfully changed.");
    //            }
    //            else if (changePassResponse.Code == (int)BacktoryHttpStatusCode.Forbidden)
    //            {
    //        // value "OLD-PASSWORD" is not your real old password
    //        Debug.Log("Old password was incorrect.");
    //            }
    //            else
    //            {
    //        // Operation generally failed, maybe internet connection issue
    //        Debug.Log("Request failed.");
    //            }
    //        });
    //}
    //public void ChangePassword(string LastPass, string NewPass)
    //{
    //    // Getting old and new password
    //    string oldPassword = LastPass;
    //    string newPassword = NewPass;

    //    // Requesting change password to backtory
    //    BacktoryUser.CurrentUser.ChangePasswordInBackground(oldPassword, newPassword,
    //        changePassResponse =>
    //        {
    //            // Operation done (success or fail), handling it:
    //            if (changePassResponse.Successful)
    //            {
    //                // Password changed successfully
    //                Debug.Log("Your password successfully changed.");
    //            }
    //            else if (changePassResponse.Code == (int)BacktoryHttpStatusCode.Forbidden)
    //            {
    //                // value "OLD-PASSWORD" is not your real old password
    //                Debug.Log("Old password was incorrect.");
    //            }
    //            else
    //            {
    //                // Operation generally failed, maybe internet connection issue
    //                Debug.Log("Request failed.");
    //            }
    //        });
    //}

    //public void ForgetPassword()
    //{
    //    // Requesting forget password to backtory
    //    BacktoryUser.ForgotPasswordInBackground("<USERNAME>", response => {
    //        if (response.Successful)
    //        {
    //            Debug.Log("Go to your mail inbox and verify your request.");
    //        }
    //        else
    //        {
    //            Debug.Log("failed; " + response.Message);
    //        }
    //    });
    //}

    //public void Logout()
    //{
    //    BacktoryUser.LogoutInBackground();
    //}

    IEnumerator Mammad(string dialog)
    {
        Dialog.text = dialog;
        yield return new WaitForSeconds(3);
        Dialog.text = "";
    }
}