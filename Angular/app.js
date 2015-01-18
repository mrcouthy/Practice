(function(){
	var app = angular.module("gemStore",[]);
	
	var gem={
	name:'Diamond',
	price:20,
	description:'Glass like'
	};
	
	app.controller('StoreController',function(){
  	this.product=gem;
  	});
})();
 