var apiObject={
	
	canPlayAd:function(){
		function callback(data) {
			var datas=data.canPlayAd+","+data.remain;
			SendMessage('API4399', 'canPlayAdCallback',datas);
		}
		window.h5api.canPlayAd(callback);
	},
	
	playAd:function(){
		function callback(data){
			var datas=data.code+","+data.message;
			SendMessage('API4399', 'playAdCallback',datas);
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
			SendMessage('API4399', 'loginCallback',datas);
		}
		window.h5api.login(callback);
	},
	
	/**
	 * 获得用户头像地址，高宽为120*120像素
	 * @param {String} uId 用户编号
	 */
	getUserAvatar:function(uId){
		return window.h5api.getUserAvatar(uId);
	},
	
	/**
	 * 获得用户小头像地址，高宽为48*48像素
	 * @param {String} uId 用户编号
	 */
	getUserSmallAvatar:function(uId){
		return window.h5api.getUserSmallAvatar(uId);
	},
	
	getUserBigAvatar:function(uId){
		return window.h5api.getUserBigAvatar(uId);
	},
	
	//===========================================积分排行榜API===============
	//A方案
	showRanking:function(){
		window.h5api.showRanking();
	},
	submitRanking:function(score){
		function callback(data){
			var datas="";
			datas+=data.code+",";
			datas+=data.my.uid+",";
			datas+=data.my.userName+",";
			datas+=data.history.rank+",";
			datas+=data.history.score;
			SendMessage('API4399', 'submitRankingCallback',datas);
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
			//datas+=data.data.
			SendMessage('API4399', 'getRankingCallback',datas);
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
			SendMessage('API4399', 'getMyRankingCallback',datas);
		}
		window.h5api.getMyRanking(callback);
	},
	
	getNearRanking:function(){
		function callback(data){
			var datas="";
			datas+=data.code+",";
			
			SendMessage('API4399', 'getNearRankingCallback',datas);
		}
		window.h5api.getNearRanking(callback);
	}
	
};
mergeInto(LibraryManager.library, apiObject);