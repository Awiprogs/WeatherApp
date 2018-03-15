
app.controller("MainController",
    function($scope, $http, configData) {
        $scope.ShowWeather = function() {
            $scope.countryInputInvalid = !$scope.InputPageForm.countryInput.$valid;
            $scope.cityInputInvalid = !$scope.InputPageForm.cityInput.$valid;

            if (!$scope.InputPageForm.$valid) {
                $scope.errorUrl = null;
                $scope.detailsUrl = null;
                return;
            }

            $http({
                method: 'GET',
                url: configData.WebApiUrl + $scope.WeatherInputModel.Country + '/' + $scope.WeatherInputModel.City
            }).then(function successCallback(response) {
                    $scope.Weather = response.data;
                    $scope.detailsUrl = '/WeatherAppJS/Content/Views/Home/details.html';
                    $scope.errorUrl = null;
                },
                function errorCallback(response) {
                    $scope.ErrorModel = {};
                    if (response.status === 400) {
                        $scope.ErrorModel.Message = ErrorMessages.InvalidInputData;
                    } else {
                        $scope.ErrorModel.Message = ErrorMessages.UnexpectedError;
                    }

                    $scope.detailsUrl = null;
                    $scope.errorUrl = '/WeatherAppJS/Content/Views/Home/error.html';
                });
        }
    });