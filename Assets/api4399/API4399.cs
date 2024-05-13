using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class API4399 : MonoBehaviour {
    
    public bool enableAPI = true;
    
    private static API4399 _instance;
    public static API4399 getInstance() {
        /*if(_instance==null){
            var className=System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            var obj=new GameObject(className);
            DontDestroyOnLoad(obj);
            _instance=obj.AddComponent<API4399>();
        }*/
        return _instance;
    }

    private void Awake() {
        _instance = this;
    }

    private void OnDestroy() {
        _instance = null;
    }


    public delegate void CanPlayAdCallback(bool canPlayAd, int remain);
    private CanPlayAdCallback _canPlayAdFunc;
    [DllImport("__Internal")] private static extern void canPlayAd();
    public void canPlayAdCallback(string datas) {
#if UNITY_WEBGL
		if(enableAPI){
			string[] list = datas.Split(',');
			bool canPlayAd = list[0]=="true";
			int remain = int.Parse(list[1]);
			_canPlayAdFunc(canPlayAd,remain);
		}
#endif
    }

    public void CanPlayAd(CanPlayAdCallback callback) {
#if UNITY_WEBGL
		if(enableAPI){
			_canPlayAdFunc = callback;
			canPlayAd();
		}
#endif
    }


    public delegate void PlayAdCallback(int code, string message);
    private PlayAdCallback _playAdFunc;
    private float _volume;
    [DllImport("__Internal")] private static extern void playAd();
    public void playAdCallback(string datas) {
#if UNITY_WEBGL
		if(enableAPI){
			string[] list = datas.Split(',');
			int code = int.Parse(list[0]);
			string message = list[1];
            if (code == 10000) {
                //开始播放
                
            }else if (code==10001) {
                // 播放结束
                AudioListener.volume = _volume; //恢复音量
            } else {
                // 播放异常
                AudioListener.volume = _volume; //恢复音量
            }
			_playAdFunc(code,message);
		}
#endif
    }

    public void PlayAd(PlayAdCallback callback) {
#if UNITY_WEBGL
		if(enableAPI) {
            // 静音
            _volume = AudioListener.volume;
            AudioListener.volume = 0f;
            
			_playAdFunc = callback;
			playAd();
		}
#endif
    }


    [DllImport("__Internal")] private static extern void share();
    public void Share() {
#if UNITY_WEBGL
		if(enableAPI) share();
#endif
    }


    [DllImport("__Internal")] private static extern bool isLogin();
    public bool IsLogin() {
#if UNITY_WEBGL
		if(enableAPI) return isLogin();
#endif
        return false;
    }

    
    public delegate void LoginCallback(string uId, string userName);
    private LoginCallback _loginAdFunc;
    [DllImport("__Internal")] private static extern void login();
    public void loginCallback(string datas) {
#if UNITY_WEBGL
		if(enableAPI){
			string[] list = datas.Split(',');
			string uId = list[0];
			string userName = list[1];
			_loginAdFunc(uId,userName);
        }
#endif
    }

    public void Login(LoginCallback callback) {
#if UNITY_WEBGL
		if(enableAPI){
			_loginAdFunc = callback;
			login();
		}
#endif
    }

    [DllImport("__Internal")] private static extern string getUserAvatar(string uId);
    public string GetUserAvatar(string uId) {
#if UNITY_WEBGL
		if(enableAPI) return getUserAvatar(uId);
#endif
        return null;
    }


    [DllImport("__Internal")] private static extern string getUserSmallAvatar(string uId);
    public string GetUserSmallAvatar(string uId) {
#if UNITY_WEBGL
		if(enableAPI) return getUserSmallAvatar(uId);
#endif
        return null;
    }


    [DllImport("__Internal")] private static extern string getUserBigAvatar(string uId);
    public string GetUserBigAvatar(string uId) {
#if UNITY_WEBGL
		if(enableAPI) return getUserBigAvatar(uId);
#endif
        return null;
    }


    //=========================================== (新) 排行榜API start=============
    [DllImport("__Internal")] private static extern void showRankList();
    public void ShowRankList() {
#if UNITY_WEBGL
        if (enableAPI) showRankList();
#endif
    }


     public delegate void SubmitRankScoreCallback(int code, string msg, int score, int rank);
     private SubmitRankScoreCallback _submitRankScoreFunc;
     [DllImport("__Internal")] private static extern void submitRankScore(int rankId, int score);
    public void submitRankScoreCallback(string datas) {
#if UNITY_WEBGL
         if(enableAPI){
             string[] list = datas.Split(',');
             int code = int.Parse(list[0]);
             string msg = list[1];
             int score = int.Parse(list[2]);
             int rank = int.Parse(list[3]);
             _submitRankScoreFunc?.Invoke(code, msg, score, rank);
         }
#endif
    }
    public void SubmitRankScore(int rankId, int score, SubmitRankScoreCallback callback=null) {
#if UNITY_WEBGL
        if (enableAPI) {
            _submitRankScoreFunc = callback;
            submitRankScore(rankId, score);
        }
#endif
    }
    //=========================================== (新) 排行榜API end===============
    
}