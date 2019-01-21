using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class API4399 : MonoBehaviour{

	public static API4399 getInstance(){
		var className=System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
		var obj=new GameObject(className);
		DontDestroyOnLoad(obj);
		return obj.AddComponent<API4399>();
	}

	public delegate void CanPlayAdCallback(bool canPlayAd,int remain);
	private CanPlayAdCallback _canPlayAdFunc;
	[DllImport("__Internal")]
	private static extern void canPlayAd();
	public void canPlayAdCallback(string datas){
		string[] list=datas.Split(',');
		bool canPlayAd=bool.Parse(list[0]);
		int remain=int.Parse(list[1]);
		_canPlayAdFunc(canPlayAd,remain);
	}
	public void CanPlayAd(CanPlayAdCallback callback){
		_canPlayAdFunc=callback;
		canPlayAd();
	}


	public delegate void PlayAdCallback(int code,string message);
	private PlayAdCallback _playAdFunc;
	[DllImport("__Internal")]
	private static extern void playAd();
	public void playAdCallback(string datas){
		string[] list=datas.Split(',');
		int code=int.Parse(list[0]);
		string message=list[1];
		_playAdFunc(code,message);
	}
	public void PlayAd(PlayAdCallback callback){
		_playAdFunc=callback;
		playAd();
	}


	[DllImport("__Internal")]
	private static extern void share();
	public void Share(){
		share();
	}


	[DllImport("__Internal")]
	private static extern bool isLogin();
	public bool IsLogin(){
		return isLogin();
	}


	public delegate void LoginCallback(int uId,string userName);
	private LoginCallback _loginAdFunc;
	[DllImport("__Internal")]
	private static extern void login();
	public void loginCallback(string datas){
		string[] list=datas.Split(',');
		int uId=int.Parse(list[0]);
		string userName=list[1];
		_loginAdFunc(uId,userName);
	}
	public void Login(LoginCallback callback){
		_loginAdFunc=callback;
		login();
	}

	[DllImport("__Internal")]
	private static extern string getUserAvatar(int uId);
	public string GetUserAvatar(int uId){
		return getUserAvatar(uId);
	}


	[DllImport("__Internal")]
	private static extern string getUserSmallAvatar(int uId);
	public string GetUserSmallAvatar(int uId){
		return getUserSmallAvatar(uId);
	}


	[DllImport("__Internal")]
	private static extern string getUserBigAvatar(int uId);
	public string GetUserBigAvatar(int uId){
		return getUserBigAvatar(uId);
	}


	//===========================================积分排行榜API===============
	//A方案
	//B方案
}
