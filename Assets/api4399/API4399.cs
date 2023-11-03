using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class API4399 : MonoBehaviour{
	public bool enableAPI=false;
	private static API4399 _instance;
	public static API4399 getInstance(){
		if(_instance==null){
			var className=System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
			var obj=new GameObject(className);
			DontDestroyOnLoad(obj);
			_instance=obj.AddComponent<API4399>();
		}
		return _instance;
	}

	public delegate void CanPlayAdCallback(bool canPlayAd,int remain);
	private CanPlayAdCallback _canPlayAdFunc;
	[DllImport("__Internal")]
	private static extern void canPlayAd();
	public void canPlayAdCallback(string datas){
	#if UNITY_WEBGL
		if(enableAPI){
			string[] list=datas.Split(',');
			bool canPlayAd=list[0]=="true";
			int remain=int.Parse(list[1]);
			_canPlayAdFunc(canPlayAd,remain);
		}
	#endif
	}
	public void CanPlayAd(CanPlayAdCallback callback){
	#if UNITY_WEBGL
		if(enableAPI){
			_canPlayAdFunc=callback;
			canPlayAd();
		}
	#endif
	}


	public delegate void PlayAdCallback(int code,string message);
	private PlayAdCallback _playAdFunc;
	[DllImport("__Internal")]
	private static extern void playAd();
	public void playAdCallback(string datas){
	#if UNITY_WEBGL
		if(enableAPI){
			string[] list=datas.Split(',');
			int code=int.Parse(list[0]);
			string message=list[1];
			_playAdFunc(code,message);
		}
	#endif
	}
	public void PlayAd(PlayAdCallback callback){
	#if UNITY_WEBGL
		if(enableAPI){
			_playAdFunc=callback;
			playAd();
		}
	#endif
	}


	[DllImport("__Internal")]
	private static extern void share();
	public void Share(){
	#if UNITY_WEBGL
		if(enableAPI) share();
	#endif
	}


	[DllImport("__Internal")]
	private static extern bool isLogin();
	public bool IsLogin(){
	#if UNITY_WEBGL
		if(enableAPI) return isLogin();
	#endif
		return false;
	}


	private string _curLoginUserId;
	public delegate void LoginCallback(string uId,string userName);
	private LoginCallback _loginAdFunc;
	[DllImport("__Internal")]
	private static extern void login();
	public void loginCallback(string datas){
	#if UNITY_WEBGL
		if(enableAPI){
			string[] list=datas.Split(',');
			string uId=list[0];
			string userName=list[1];
			_loginAdFunc(uId,userName);
			_curLoginUserId=uId;
		}
	#endif
	}
	public void Login(LoginCallback callback){
	#if UNITY_WEBGL
		if(enableAPI){
			_loginAdFunc=callback;
			login();
		}
	#endif
	}

	[DllImport("__Internal")]
	private static extern string getUserAvatar(string uId);
	public string GetUserAvatar(string uId){
	#if UNITY_WEBGL
		if(enableAPI) return getUserAvatar(uId);
	#endif
		return null;
	}


	[DllImport("__Internal")]
	private static extern string getUserSmallAvatar(string uId);
	public string GetUserSmallAvatar(string uId){
	#if UNITY_WEBGL
		if(enableAPI) return getUserSmallAvatar(uId);
	#endif
		return null;
	}


	[DllImport("__Internal")]
	private static extern string getUserBigAvatar(string uId);
	public string GetUserBigAvatar(string uId){
	#if UNITY_WEBGL
		if(enableAPI) return getUserBigAvatar(uId);
	#endif
		return null;
	}


	//===========================================积分排行榜API===============
	//A方案
	[DllImport("__Internal")]
	private static extern void showRanking();
	public void ShowRanking(){
	#if UNITY_WEBGL
		if(enableAPI) showRanking();
	#endif
	}


	public delegate void SubmitRankingCallback(int code,string uId,string userName,int historyRank,int historyScore);
	private SubmitRankingCallback _submitRankingFunc;
	[DllImport("__Internal")]
	private static extern void submitRanking(int score);
	public void submitRankingCallback(string datas){
	#if UNITY_WEBGL
		if(enableAPI){
			string[] list=datas.Split(',');
			int code=int.Parse(list[0]);
			string uId=list[1];
			string userName=list[2];
			int historyRank=int.Parse(list[3]);
			int historyScore=int.Parse(list[4]);
			_submitRankingFunc(code,uId,userName,historyRank,historyScore);
		}
	#endif
	}
	public void SubmitRanking(int score,SubmitRankingCallback callback){
	#if UNITY_WEBGL
		if(enableAPI){
			_submitRankingFunc=callback;
			submitRanking(score);
		}
	#endif
	}


	//B方案
	public struct RankingElement{
		public string uId;
		public string userName;
		public int rank;
		public int score;
	}
	public delegate void GetRankingCallback(int code,int currentPage,int totalPage,bool hasNext,RankingElement[] list);
	private GetRankingCallback _getRankingFunc;
	[DllImport("__Internal")]
	private static extern void getRanking();
	public void getRankingCallback(string datas){
	#if UNITY_WEBGL
		if(enableAPI){
			string[] tmpList=datas.Split(',');
			string[] preList=new string[4];
			int preCharCount=0;
			for(int i=0;i<preList.Length;i++){
				preList[i]=tmpList[i];
				preCharCount+=tmpList[i].Length;
			}
			preCharCount+=preList.Length;//加,号个数

			string elementsStr=datas.Substring(preCharCount);
			string[] elementStrs=elementsStr.Split('|');

			int code=int.Parse(preList[0]);
			int currentPage=int.Parse(preList[1]);
			int totalPage=int.Parse(preList[2]);
			bool hasNext=preList[3]=="true";

			RankingElement[] elementList=new RankingElement[elementStrs.Length];
			for(int i=0;i<elementStrs.Length;i++){
				RankingElement ele=new RankingElement();
				tmpList=elementStrs[i].Split(',');

				ele.uId=tmpList[0];
				ele.userName=tmpList[1];
				ele.rank=int.Parse(tmpList[2]);
				ele.score=int.Parse(tmpList[3]);
				elementList[i]=ele;
			}
		
			_getRankingFunc(code,currentPage,totalPage,hasNext,elementList);
		}
	#endif
	}
	public void GetRanking(GetRankingCallback callback){
	#if UNITY_WEBGL
		if(enableAPI){
			_getRankingFunc=callback;
			getRanking();
		}
	#endif
	}


	public delegate void GetMyRankingCallback(int code,string uId,string userName,int rank,int score);
	private GetMyRankingCallback _getMyRankingFunc;
	[DllImport("__Internal")]
	private static extern void getMyRanking();
	public void getMyRankingCallback(string datas){
	#if UNITY_WEBGL
		if(enableAPI){
			string[] list=datas.Split(',');
			int code=int.Parse(list[0]);
			string uId=list[1];
			string userName=list[2];
			int rank=int.Parse(list[3]);
			int score=int.Parse(list[4]);
			_getMyRankingFunc(code,uId,userName,rank,score);
		}
	#endif
	}
	public void GetMyRanking(GetMyRankingCallback callback){
	#if UNITY_WEBGL
		if(enableAPI){
			_getMyRankingFunc=callback;
			getMyRanking();
		}
	#endif
	}


	public struct NearRankingElement{
		public string uId;
		public string userName;
		public bool isMe;
		public int rank;
		public int score;
	}
	public delegate void GetNearRankingCallback(int code,NearRankingElement[] list);
	private GetNearRankingCallback _getNearRankingFunc;
	[DllImport("__Internal")]
	private static extern void getNearRanking();
	private void getNearRankingCallback(string datas){
	#if UNITY_WEBGL
		if(enableAPI){
			string[] tmpList=datas.Split(',');
			string[] preList=new string[1];
			int preCharCount=0;
			for(int i=0;i<preList.Length;i++){
				preList[i]=tmpList[i];
				preCharCount+=tmpList[i].Length;
			}
			preCharCount+=preList.Length;//加,号个数

			string elementsStr=datas.Substring(preCharCount);
			string[] elementStrs=elementsStr.Split('|');

			int code=int.Parse(preList[0]);

			NearRankingElement[] elementList=new NearRankingElement[elementStrs.Length];
			for(int i=0;i<elementStrs.Length;i++){
				NearRankingElement ele=new NearRankingElement();
				tmpList=elementStrs[i].Split(',');

				ele.uId=tmpList[0];
				ele.userName=tmpList[1];
				ele.isMe=tmpList[1]=="true";
				ele.rank=int.Parse(tmpList[2]);
				ele.score=int.Parse(tmpList[3]);
				elementList[i]=ele;
			}

			_getNearRankingFunc(code,elementList);
		}
	#endif
	}
	public void GetNearRanking(GetNearRankingCallback callback){
	#if UNITY_WEBGL
		if(enableAPI){
			_getNearRankingFunc=callback;
			getNearRanking();
		}
	#endif
	}


	public string curLoginUserId{
		get{ return _curLoginUserId;}
	}
}
