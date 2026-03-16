using UnityEngine;
using Firebase.Extensions;
using System.Threading.Tasks;
using Firebase.Crashlytics;
using System;
using Firebase.RemoteConfig;

public class FirebaseSetup : MonoBehaviour
{
  public bool IsFirebaseReady { get; private set; }
  public bool IsActiveRemote { get; private set; }
  private Firebase.FirebaseApp app;

  public void Init()
  {
    Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
    {
      var dependencyStatus = task.Result;
      if (dependencyStatus == Firebase.DependencyStatus.Available)
      {
        // Create and hold a reference to your FirebaseApp,
        // where app is a Firebase.FirebaseApp property of your application class.
        app = Firebase.FirebaseApp.DefaultInstance;

        // When this property is set to true, Crashlytics will report all
        // uncaught exceptions as fatal events. This is the recommended behavior.
        if (Debug.isDebugBuild)
        {
          Crashlytics.ReportUncaughtExceptionsAsFatal = false;
        }
        else
        {
          IsFirebaseReady = true;
          Crashlytics.ReportUncaughtExceptionsAsFatal = true;
        }

        FetchDataAsync();
      }
      else
      {
        Debug.LogError($"Could not resolve all Firebase dependencies: {dependencyStatus}");
        // Firebase Unity SDK is not safe to use here.
      }
    });
  }

  // [START fetch_async]
  // Start a fetch request.
  // FetchAsync only fetches new data if the current data is older than the provided
  // timespan.  Otherwise it assumes the data is "recent enough", and does nothing.
  // By default the timespan is 12 hours, and for production apps, this is a good
  // number. For this example though, it's set to a timespan of zero, so that
  // changes in the console will always show up immediately.
  private Task FetchDataAsync()
  {
    Debug.Log("Fetching data...");
    var fetchTask =
    FirebaseRemoteConfig.DefaultInstance.FetchAsync(
        TimeSpan.Zero);
    return fetchTask.ContinueWithOnMainThread(FetchComplete);
  }
  //[END fetch_async]

  private void FetchComplete(Task fetchTask)
  {
    if (fetchTask.IsCanceled)
    {
      Debug.Log("Fetch canceled.");
    }
    else if (fetchTask.IsFaulted)
    {
      Debug.Log("Fetch encountered an error.");
    }
    else if (fetchTask.IsCompleted)
    {
      Debug.Log("Fetch completed successfully!");
    }

    var info = FirebaseRemoteConfig.DefaultInstance.Info;
    switch (info.LastFetchStatus)
    {
      case LastFetchStatus.Success:
        FirebaseRemoteConfig.DefaultInstance.ActivateAsync()
        .ContinueWithOnMainThread(task =>
        {
          Debug.Log($"Remote data loaded and ready (last fetch time {info.FetchTime}).");
          ConvertDataFromRemote();
        });

        break;
      case LastFetchStatus.Failure:
        switch (info.LastFetchFailureReason)
        {
          case FetchFailureReason.Error:
            Debug.Log("Fetch failed for unknown reason");
            break;
          case FetchFailureReason.Throttled:
            Debug.Log("Fetch throttled until " + info.ThrottledEndTime);
            break;
        }
        // that bai
        break;
      case LastFetchStatus.Pending:
        Debug.Log("Latest Fetch call still pending.");
        break;
      default:
        throw new ArgumentOutOfRangeException();
    }
  }

  #region Handle Function
  private void ConvertDataFromRemote()
  {
    IsActiveRemote = true;
  }
  #endregion
}
