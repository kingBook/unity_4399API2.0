var apiObject={
	/**
	 * 覆盖内置的方法（有外部通讯导致4399审核无法通过）
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
	
	/**
	 * 获得用户大头像地址，高宽为200*200像素
	 * @param {String} uid 用户编号
	 */
	getUserBigAvatar:function(uId){
		var path=window.h5api.getUserBigAvatar(Pointer_stringify(uId));
		
		var bufferSize=lengthBytesUTF8(path)+1;
		var buffer=_malloc(bufferSize);
		stringToUTF8(path,buffer,bufferSize);
		return buffer;
	},
	
	//=========================================== (新) 排行榜API start=============
	/**
	 * 展示排行榜面板
	 */
	showRankList:function(){
		window.h5api.showRankList();
	},
	
	/**
	 * 提交排名
	 * @param {Number} rankId 排行榜 id
	 * @param {Number} score 分数
	 */
	submitRankScore:function(rankId, score){
		function callback(res){
			var datas="";
			datas+=res.code+",";
			datas+=res.msg+",";
			datas+=res.data.score+",";
			datas+=res.data.rank;
			unityInstance.SendMessage('API4399', 'submitRankScoreCallback', datas);
	    }
		window.h5api.submitRankScore(rankId, score, callback);
	}
	//=========================================== (新) 排行榜API end===============
	
};
mergeInto(LibraryManager.library, apiObject);