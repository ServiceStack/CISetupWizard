/* global angular */
(function () {
    "use strict";
    var module = angular.module('manage-repo', [
        'local-services'
    ]);

    module.controller('managerRepoCtrl', ['$scope', '$routeParams', 'localServices',
        function ($scope, $routeParams, localServices) {
            $scope.loadingUserRepo = true;
            $scope.loadingSolutionDetails = true;
            $scope.ready = false;
            //Get repo
            localServices.getUserRepo($routeParams.ownerName, $routeParams.repoName).then(function (response) {
                $scope.repo = response.data.repo;
                $scope.loadingUserRepo = false;
                $scope.ready = !$scope.loadingUserRepo && !$scope.loadingSolutionDetails;
            });

            localServices.getSolutionDetails($routeParams.ownerName, $routeParams.repoName).then(function (response) {
                $scope.repoConfig = response.data;
                $scope.loadingSolutionDetails = false;
                $scope.ready = !$scope.loadingUserRepo && !$scope.loadingSolutionDetails;
            }, function (response) {
                //Error, offer to specify alternate branch?
            });

            localServices.getTeamCityProject($routeParams.repoName).then(function (response) {
                $scope.projectExists = true;
                $scope.currentProject = response.data.project;
                localServices.getTeamCityBuild($routeParams.repoName).then(function (response) {
                    $scope.buildConfigExists = true;
                    $scope.buildStatus = response.data.status;
                    $scope.buildLastUpdate = response.data.lastUpdate;
                }, function (response) {
                    // Do nothing, user hasn't created/managed build for this project yet.
                });
            }, function (response) {

            });


            $scope.createBuild = function () {
                $scope.creating = true;
                var request = {
                    name: $routeParams.repoName,
                    branch: $scope.repoConfig.branch,
                    repositoryUrl: $scope.repoConfig.repositoryUrl,
                    templateType: $scope.repoConfig.templateType,
                    workingDirectory: $scope.repoConfig.projectWorkingDirectory,
                    projectName: $scope.repoConfig.projectName,
                    privateRepository: $scope.repoConfig.privateRepository,
                    solutionPath: $scope.repoConfig.solutionPath
                };
                localServices.createTeamCityBuild(request).then(function (response) {
                    $scope.success = true;
                    $scope.creating = false;
                }, function (response) {
                    $scope.creating = false;
                });
            };

            $scope.$watch('success', function (newVal) {
                if(newVal === true) {

                }
            })
        }]);
})();