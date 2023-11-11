var apiObject={
	/**
	 * 覆盖内置的方法（有外部通讯导致审核无法通过）
	 */
	JS_WebRequest_Send:function (request, ptr, length) {
		
	},
	
	canPlayAd:function(){
		function callback(data) {
			var datas=data.canPlayAd+","+data.remain;
			unityInstance.SendMessage('API4399', 'canPlayAdCallback',datas);
		}
		window.h5api.canPlayAd(callback);
	},
	
	playAd:function(){
		function callback(data){
			var datas=data.code+","+data.message;
			unityInstance.SendMessage('API4399', 'playAdCallback',datas);
		}
		window.h5api.playAd(callback);
	},
	
	share:function(){
		window.h5api.share();
	},

	isLogin:function(){
		return window.h5api.isLogin();
	},
	
	login:function(){
		function callback(data){
			var datas=data.uId+","+data.userName;
			unityInstance.SendMessage('API4399', 'loginCallback',datas);
		}
		window.h5api.login(callback);
	},
	
	/**
	 * 获得用户头像地址，高宽为120*120像素
	 * @param {String} uId 用户编号
	 */
	getUserAvatar:function(uId){
		var path=window.h5api.getUserAvatar(Pointer_stringify(uId));
		
		var bufferSize=lengthBytesUTF8(path)+1;
		var buffer=_malloc(bufferSize);
		stringToUTF8(path,buffer,bufferSize);
		return buffer;
	},
	
	/**
	 * 获得用户小头像地址，高宽为48*48像素
	 * @param {String} uId 用户编号
	 */
	getUserSmallAvatar:function(uId){
		var path=window.h5api.getUserSmallAvatar(Pointer_stringify(uId));
		
		var bufferSize=lengthBytesUTF8(path)+1;
		var buffer=_malloc(bufferSize);
		stringToUTF8(path,buffer,bufferSize);
		return buffer;
	},
	
	getUserBigAvatar:function(uId){
		var path=window.h5api.getUserBigAvatar(Pointer_stringify(uId));
		
		var bufferSize=lengthBytesUTF8(path)+1;
		var buffer=_malloc(bufferSize);
		stringToUTF8(path,buffer,bufferSize);
		return buffer;
	},
	
	//===========================================积分排行榜API===============
	//A方案
	showRanking:function(){
		window.h5api.showRanking();
	},
	submitRanking:function(score){
		function callback(data){
			console.log(data);
			var datas="";
			datas+=data.code+",";
			datas+=data.my.uId+",";
			datas+=data.my.userName+",";
			datas+=data.history.rank+",";
			datas+=data.history.score;
			unityInstance.SendMessage('API4399', 'submitRankingCallback',datas);
		}
		window.h5api.submitRanking(score,callback);
	},
	//B方案
	getRanking:function(){
		function callback(data){
			var datas="";
			datas+=data.code+",";
			datas+=data.data.currentPage+",";
			datas+=data.data.totalPage+",";
			datas+=data.data.hasNext+",";
			
			var list=data.data.list;
			for(var i=0;i<list.length;i++){
				var element=list[i];
				datas+=element.uId+",";
				datas+=element.userName+",";
				datas+=element.rank+",";
				datas+=element.score;
				if(i<list.length-1){
					datas+="|";
				}
			}
			unityInstance.SendMessage('API4399', 'getRankingCallback',datas);
		}
		window.h5api.getRanking(callback);
	},
	
	getMyRanking:function(){
		function callback(data){
			var datas="";
			datas+=data.code+",";
			datas+=data.data.uId+",";
			datas+=data.data.userName+",";
			datas+=data.data.rank+",";
			datas+=data.data.score;
			unityInstance.SendMessage('API4399', 'getMyRankingCallback',datas);
		}
		window.h5api.getMyRanking(callback);
	},
	
	getNearRanking:function(){
		function callback(data){
			var datas="";
			datas+=data.code+",";
			
			var list=data.data.list;
			for(var i=0;i<list.length;i++){
				var element=list[i];
				datas+=element.uId+",";
				datas+=element.userName+",";
				datas+=element.isMe+",";
				datas+=element.rank+",";
				datas+=element.score;
				if(i<list.length-1){
					datas+="|";
				}
			}
			unityInstance.SendMessage('API4399', 'getNearRankingCallback',datas);
		}
		window.h5api.getNearRanking(callback);
	}
	
};
mergeInto(LibraryManager.library, apiObject);