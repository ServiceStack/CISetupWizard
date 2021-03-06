/* global angular */
(function () {
    "use strict";
    var module = angular.module('upload-settings',[
        'local-services',
        'ciwizard.files'
    ]);

    module.directive('uploadSettings', ['localServices','fileUpload', function (localServices,fileUpload) {
        return {
            restrict: 'E',
            scope: {
                ownerName: '=',
                repoName: '=',
                isDisabled: '=',
                hasAppSettings: '='
            },
            templateUrl: 'js/upload-settings/upload.html',
            controller: function ($scope, $element, $attrs) {
                $scope.localAppSettings = false;
                $scope.getFiles = function () {
                    localServices.getProjectFiles($scope.ownerName,$scope.repoName).then(function (response) {
                        $scope.localAppSettings = false;
                        for(var i = 0; i < response.data.fileNames.length;i++) {
                            var file = response.data.fileNames[i];
                            if(file === "appsettings.txt") {
                                // use {} and null cause of two way binding issues with primitives..
                                $scope.hasAppSettings = {};
                                $scope.localAppSettings = true;
                            }
                        }
                        if(!$scope.localAppSettings) {
                            // use {} and null cause of two way binding issues with primitives..
                            $scope.hasAppSettings = null;
                        }
                        $scope.files = response.data.fileNames;
                    });
                };

                $scope.deleteFile = function (fileName) {
                    localServices.deleteProjectFile($scope.ownerName,$scope.repoName,fileName).then(function (response) {
                        $scope.getFiles();
                    }, function (response) {
                        //Handle error
                    });
                };

                $scope.uploadFile = function () {
                    var file = $scope.appSettingsFile;
                    var uploadUrl = '/user/projects/' + $scope.ownerName + '/' + $scope.repoName + '/settings';
                    fileUpload.uploadFileToUrl(file, uploadUrl).then(function () {
                        $scope.getFiles();
                    }, function () {
                        // Failed to upload error
                    })
                };

                $scope.getFiles();
            }
        }
    }])
})();