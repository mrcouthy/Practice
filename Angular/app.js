(function(){
	var app = angular.module("gemStore",[]);
	
	var gems=[{
	name:'Diamond',
	price:20,
	soldOut:false,
	canPurchase:false
	},{
	name:'Ruby',
	price:10,
	soldOut:true,
	canPurchase:true
	},
	{
	name:'Yayy',
	price:100,
	soldOut:false,
	canPurchase:true
	}];
	
	app.controller('StoreController',function(){
  	this.products=gems;
  	});
})();
 