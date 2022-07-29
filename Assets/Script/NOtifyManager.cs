using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.SimpleAndroidNotifications;
public class NOtifyManager : MonoBehaviour
{

    string title = "Bird Game";
    string content = "새를 다시 찾아주세요";

    private void OnApplicationPause(bool pause)
    {
#if UNITY_ANDROID
        //등록된 알림 모두 제거
        NotificationManager.CancelAll();

        if(pause)
        {
            //앱을 잠시 쉴 때 일정시간 이후에 알림을 호출합니다.
            DateTime timeToNotify = DateTime.Now.AddMinutes(1);
            TimeSpan time = timeToNotify - DateTime.Now;
            NotificationManager.SendWithAppIcon(time, title, content, Color.blue, NotificationIcon.Bell);
        }

#endif

    }
}
