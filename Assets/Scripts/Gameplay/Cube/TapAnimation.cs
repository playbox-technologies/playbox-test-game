using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;
using Utils.Timer;

public class TapAnimation : MonoBehaviour
{
    [SerializeField] private float currentTime = 0f;
    [SerializeField] private float startTime = 1f;
    [SerializeField] private bool isReady = false;
    [SerializeField] private float ad_bonus = 300;
    [SerializeField] private UnityEvent<string> ChangeCounter;
    [SerializeField] private UnityEvent<string> ChangeLevel;
    [SerializeField] private UnityEvent<string> ChangeLevelButton;
    [SerializeField] private UnityEvent UpgradeLevelEvent;
    [SerializeField] [CanBeNull] private UnityEvent ClickOnObject;
    [SerializeField] private Color startColor = Color.white;
    [SerializeField] private Color endColor = Color.cyan;

    private const string tapKey = "cube_tap_count";
    private const string levelKey = "cube_level_key";
    
    private PlayboxTimer playboxTimer;
    private float level = 1;
    private float money = 0;
    private Vector3 startPosition;
    private Vector3 scale;
    Renderer rend;

    private void Start()
    {
        rend = GetComponent<MeshRenderer>();
        
        if (rend == null)
            throw new NullReferenceException();
        
        LoadCounter();
        LoadLevel();
        
        rend.material.SetColor("_BaseColor", Color.Lerp(startColor, endColor, level/100f));
        
        scale = transform.localScale;
        startPosition = transform.localPosition;
        
        playboxTimer = new PlayboxTimer();

        playboxTimer.initialTime = startTime;

        playboxTimer.OnTimeOut += () =>
        {
            isReady = true;

            transform.DOScale(scale, .2f);
        };

        playboxTimer.OnTimeRemaining += f =>
        {
            currentTime = f;
        };

        playboxTimer.Start();
    }

    private void OnMouseDown()
    {
        if (isReady)
        {
            isReady = false;
            
            playboxTimer.Restart();
            
            transform.DOScale(Vector3.one * 1.1f, .2f);
                
            ClickOnObject?.Invoke();
            AddCounter();
        }
    }

    private void PunchAnimation()
    {
        if (isReady)
        {
            isReady = false;
            
            playboxTimer.Restart();
            
            transform.DOScale(Vector3.one * 1.1f, .2f);
        }
    }

    private void Update()
    {
        playboxTimer.Update(Time.deltaTime);
    }

    private void LoadCounter()
    {
        if(PlayerPrefs.HasKey(tapKey))
        {
            money = PlayerPrefs.GetFloat(tapKey);
            ChangeCounter?.Invoke(money.ToString());
        }
    }
    
    private void SaveCounter()
    {
        PlayerPrefs.SetFloat(tapKey, money);
        ChangeCounter?.Invoke(money.ToString());
    }

    private void AddCounter()
    {
       LoadCounter();
       money += Mathf.Max(1,level) * 1.5f;
       SaveCounter();
    }
    
    public void AddAdvertisementMoney()
    {
        LoadCounter();
        money += (ad_bonus * 0.3f) * level;
        SaveCounter();
    }

    private void LoadLevel()
    {
        if (PlayerPrefs.HasKey(levelKey))
        {
            level = PlayerPrefs.GetFloat(levelKey);
            ChangeLevel?.Invoke($"Level : {level}");
            ChangeLevelButton?.Invoke($"Cost : {level * 100}");
            rend.material.SetColor("_BaseColor", Color.Lerp(startColor, endColor, level/100f));
        }
    }

    public void UpgradeLevel()
    {
        if (money - (level * 100) >= 0)
        {
            money -= (level * 100);
            
            LoadLevel();
            level++;
            SaveCounter();
            SaveLevel();
            
            UpgradeLevelEvent?.Invoke();
            PunchAnimation();
            rend.material.SetColor("_BaseColor", Color.Lerp(startColor, endColor, level/100f));
        }
    }

    private void SaveLevel()
    {
        PlayerPrefs.SetFloat(levelKey,level);
        ChangeLevel?.Invoke($"Level : {level}");
        ChangeLevelButton?.Invoke($"Cost : {level * 100}");
    }
}
