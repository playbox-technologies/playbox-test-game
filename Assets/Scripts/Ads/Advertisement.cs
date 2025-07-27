using System;
using Playbox;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Utils.Timer;

public class Advertisement : MonoBehaviour
{
    [SerializeField] private UnityEvent<Color> OnChangeRewardedButton;
    [SerializeField] private UnityEvent<string> OnButtonTimer;
    [SerializeField] private float AdDuration = 1f;
    [SerializeField] private UnityEvent OnRewardedAdReceived;
    
    private PlayboxTimer timer;
    private bool isTimerReady = false;
    
    private bool isReady => Playbox.Advertisement.isReady() && isTimerReady;
    
    private void Awake()
    {
        timer = new PlayboxTimer();
        timer.initialTime = AdDuration;
        
        MainInitialization.PostInitialization += () =>
        {
            Playbox.Advertisement.OnRewarderedReceived += OnRewarderedReceived;
            Playbox.Advertisement.OnLoaded += AdvertisementOnOnLoaded;

        };
        
        timer.OnTimerStart += () =>
        {
            isTimerReady = false;
                
        };
        
        timer.OnTimeRemaining += (f) =>
        {
            OnButtonTimer?.Invoke(f.ToString());

        };
            
        timer.OnTimeOut += () =>
        {
            isTimerReady = true;

        };
        
        
        timer.Start();
    }

    private void AdvertisementOnOnLoaded()
    {
        
    }

    private void OnRewarderedReceived()
    {
        OnRewardedAdReceived?.Invoke();
        timer.Restart();
        isTimerReady = false;
    }

    private void CheckReadyStatus()
    {
        if (isReady)
        {
            OnChangeRewardedButton?.Invoke(Color.green);
        }
        else
        {
            OnChangeRewardedButton?.Invoke(Color.white);
        }
    }

    private void Update()
    {
        timer.Update(Time.deltaTime);
        CheckReadyStatus();
    }

    public void ShowRewardedAd()
    {
        if (isReady)
        {
            Playbox.Advertisement.Show();
        }
    }
}
