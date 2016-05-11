var myApp = angular.module('myApp', ['ngMap']);

myApp.controller("TopSpots", [
	'$scope', 
	'$http', 
	'NgMap', 
	function($scope, $http, NgMap) {

	var activate = function() {
		$http({
			method: 'GET',
			url: 'http://localhost:51358/api/topspots',

		})
		.then(function(response) {
			$scope.topSpots = response.data;
		});
	};

	$scope.addNewLocation = function (newTopSpot) {
		if (isNaN(Number(newTopSpot.latitude))) {
			alert("\"" + newTopSpot.longitude + "\"" + " is not a valid coordinate");
			return;
		}

		if(isNaN(Number(newTopSpot.longitude))) {
			alert("\"" + newTopSpot.longitude + "\"" + " is not a valid coordinate");
			return;
		}

		newTopSpot.location = [Number(newTopSpot.latitude), Number(newTopSpot.longitude)];
		$scope.topSpots.forEach(function(element) {
			if(newTopSpot.location == $scope.topSpots.location) {
				alert("This item already exists!");
			}
		
		});
		$http({
			method: 'POST',
			url: 'http://localhost:51358/api/topspots',
			data: $scope.newTopSpot
			}).then(function() {
				$scope.topSpots.push(newTopSpot);
				$scope.newTopSpot = {};
			});	

		

		
	};

	activate();
}]);