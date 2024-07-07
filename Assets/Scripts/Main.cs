using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static API4399;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnGUI() {
		var inst=API4399.getInstance();

		var rect=Screen.safeArea;
		var w=rect.width/2;
		rect=new Rect(rect.x+rect.width/2-w/2,rect.y,w,rect.height);

		GUILayout.BeginArea(rect);


		if(GUILayout.Button("caPlayAd",GUILayout.ExpandHeight(true))){
			inst.CanPlayAd((bool canPlayAd,int remain)=>{
				Debug.LogFormat("caPlayAd:{0} remain:{1}",canPlayAd,remain);
			});
		}

		if(GUILayout.Button("playAd",GUILayout.ExpandHeight(true))){
			inst.PlayAd((int code,string message)=>{
				Debug.LogFormat("code:{0} message:{1}",code,message);
			});
		}

		if(GUILayout.Button("share",GUILayout.ExpandHeight(true))){
			inst.Share();
		}

		if(GUILayout.Button("isLogin",GUILayout.ExpandHeight(true))){
			Debug.LogFormat("isLogin:{0}",inst.IsLogin());
		}
		
		if(GUILayout.Button("login",GUILayout.ExpandHeight(true))){
			inst.Login((string uId,string userName)=>{
				Debug.LogFormat("uId:{0} userName:{1}",uId,userName);

			});
		}

		if(GUILayout.Button("getUserAvatar",GUILayout.ExpandHeight(true))){
			if(inst.IsLogin()){ 
				//Debug.LogFormat("getUserAvatar:{0}",inst.GetUserAvatar(inst.curLoginUserId));
			}
		}

		if(GUILayout.Button("getUserSmallAvatar",GUILayout.ExpandHeight(true))){
			if(inst.IsLogin()){ 
				//Debug.LogFormat("getUserSmallAvatar:{0}",inst.GetUserSmallAvatar(inst.curLoginUserId));
			}
		}

		if(GUILayout.Button("getUserBigAvatar",GUILayout.ExpandHeight(true))){
			if(inst.IsLogin()){ 
				//Debug.LogFormat("getUserBigAvatar:{0}",inst.GetUserBigAvatar(inst.curLoginUserId));
			}
		}

		if(GUILayout.Button("showRanking",GUILayout.ExpandHeight(true))){
			//inst.ShowRanking();
		}

		if(GUILayout.Button("submitRanking",GUILayout.ExpandHeight(true))){
			int score=Random.Range(1,10);
			Debug.Log("submitRanking score:"+score);
			//inst.SubmitRanking(score,(int code,string uId,string userName,int historyRank,int historyScore)=>{
			//	Debug.LogFormat("code:{0},uId:{1},userName:{2},historyRank:{3},historyScore:{4}",code,uId,userName,historyRank,historyScore);
			//});
		}

		if(GUILayout.Button("getRanking",GUILayout.ExpandHeight(true))){
			// inst.GetRanking((int code,int currentPage,int totalPage,bool hasNext,RankingElement[] list)=>{
			// 	Debug.LogFormat("code:{0},currentPage:{1},totalPage:{2},hasNext:{3}",code,currentPage,totalPage,hasNext);
			// 	for(int i=0;i<list.Length;i++){
			// 		var ele=list[i];
			// 		Debug.LogFormat("Index:{0},uId:{1},userName:{2},rank:{3},score:{4}",i,ele.uId,ele.userName,ele.rank,ele.score);
			// 	}
			// });
		}

		if(GUILayout.Button("getMyRanking",GUILayout.ExpandHeight(true))){
			// inst.GetMyRanking((int code,string uId,string userName,int rank,int score)=>{
			// 	Debug.LogFormat("code:{0},uId:{1},userName:{2},rank:{3},score:{4}",code,uId,userName,rank,score);
			// });
		}

		if(GUILayout.Button("getNearRanking",GUILayout.ExpandHeight(true))){
			// inst.GetNearRanking((int code,NearRankingElement[] list)=>{
			// 	Debug.LogFormat("code:{0}",code);
			// 	for(int i=0;i<list.Length;i++){
			// 		var ele=list[i];
			// 		Debug.LogFormat("Index:{0},uId:{1},userName:{2},isMe:{3},rank:{4},score:{5}",i,ele.uId,ele.userName,ele.isMe,ele.rank,ele.score);
			// 	}
			// });
		}


		GUILayout.EndArea();
	}
}
