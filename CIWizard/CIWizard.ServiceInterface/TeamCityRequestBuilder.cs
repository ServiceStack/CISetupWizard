﻿using System.Collections.Generic;
using ServiceStack;
using ServiceStack.TeamCityClient;

namespace CIWizard.ServiceInterface
{
    public static class TeamCityRequestBuilder
    {
        public static CreateBuildStep GetNpmInstallStepRequest(string buildConfigId,string workingDirectory)
        {
            var npmStepRequest = new CreateBuildStep
            {
                BuildTypeLocator = "id:" + buildConfigId,
                Name = "NPM Install",
                TypeId = BuidStepTypes.Npm,
                StepProperties = new CreateTeamCityProperties
                {
                    Properties = new List<CreateTeamCityProperty>
                    {
                        new CreateTeamCityProperty
                        {
                            Name = "npm_commands",
                            Value = "install\ninstall grunt\ninstall grunt-cli\ninstall bower"
                        },
                        new CreateTeamCityProperty
                        {
                            Name = "teamcity.build.workingDir",
                            Value = workingDirectory
                        },
                        new CreateTeamCityProperty
                        {
                            Name = "teamcity.step.mode",
                            Value = "default"
                        }
                    }
                }
            };
            return npmStepRequest;
        }

        public static CreateVcsRoot GetCreateVcsRootRequest(string projectName, string projectId, string repositoryUrl, bool isPrivate, string branch = null)
        {
            var createVcs = new CreateVcsRoot
            {
                Name = "GitHub_{0}".Fmt(projectName),
                VcsName = VcsRootTypes.Git,
                Project = new CreateVcsRootProject { Id = projectId },
                Properties = new CreateVcsRootProperties
                {
                    Properties = new List<CreateVcsRootProperty>
                    {
                        new CreateVcsRootProperty
                        {
                            Name = "url",
                            Value = repositoryUrl
                        },
                        new CreateVcsRootProperty
                        {
                            Name = "authMethod",
                            Value = isPrivate ? "PASSWORD" : "ANONYMOUS"
                        },
                        new CreateVcsRootProperty
                        {
                            Name = "branch",
                            Value = "refs/heads/{0}".Fmt(branch.IsNullOrEmpty() ? branch : "master")
                        }
                    }
                }
            };
            return createVcs;
        }

        public static AttachVcsEntries GetAttachVcsEntriesRequest(string buildConfigId, string vcsId)
        {
            var attachRequest = new AttachVcsEntries
            {
                BuildTypeLocator = "id:" + buildConfigId,
                VcsRootEntries = new List<AttachVcsRootEntry>
                {
                    new AttachVcsRootEntry
                    {
                        Id = vcsId,
                        VcsRoot = new AttachVcsRoot
                        {
                            Id = vcsId
                        }
                    }
                }
            };
            return attachRequest;
        }

        public static CreateBuildStep GetBowerInstallBuildStep(string buildConfigId, string workingDirectory)
        {
            var bowerInstallBuildStep = new CreateBuildStep
            {
                BuildTypeLocator = "id:" + buildConfigId,
                Name = "Bower Install",
                TypeId = BuidStepTypes.CommandLine,
                StepProperties = new CreateTeamCityProperties
                {
                    Properties = new List<CreateTeamCityProperty>
                    {
                        new CreateTeamCityProperty
                        {
                            Name = "script.content",
                            Value = "bower install"
                        },
                        new CreateTeamCityProperty
                        {
                            Name = "teamcity.build.workingDir",
                            Value = workingDirectory
                        },
                        new CreateTeamCityProperty
                        {
                            Name = "teamcity.step.mode",
                            Value = "default"
                        },
                        new CreateTeamCityProperty
                        {
                            Name = "use.custom.script",
                            Value = "true"
                        },
                    }
                }
            };
            return bowerInstallBuildStep;
        }

        public static CreateBuildStep GetNuGetRestoreBuildStep(string buildConfigId, string nugetSlnPath)
        {
            var nuGetRestoreBuildStep = new CreateBuildStep
            {
                BuildTypeLocator = "id:" + buildConfigId,
                Name = "NuGet Restore",
                TypeId = BuidStepTypes.NuGetInstaller,
                StepProperties = new CreateTeamCityProperties
                {
                    Properties = new List<CreateTeamCityProperty>
                    {
                        new CreateTeamCityProperty
                        {
                            Name = "nuget.path",
                            Value = "?NuGet.CommandLine.DEFAULT.nupkg"
                        },
                        new CreateTeamCityProperty
                        {
                            Name = "nuget.updatePackages.mode",
                            Value = "sln"
                        },
                        new CreateTeamCityProperty
                        {
                            Name = "nuget.use.restore",
                            Value = "restore"
                        },
                        new CreateTeamCityProperty
                        {
                            Name = "nugetCustomPath",
                            Value = "?NuGet.CommandLine.DEFAULT.nupkg"
                        },
                        new CreateTeamCityProperty
                        {
                            Name = "nugetPathSelector",
                            Value = "?NuGet.CommandLine.DEFAULT.nupkg"
                        },
                        new CreateTeamCityProperty
                        {
                            Name = "sln.path",
                            Value = nugetSlnPath
                        },
                        new CreateTeamCityProperty
                        {
                            Name = "teamcity.step.mode",
                            Value = "default"
                        }
                    }
                }
            };
            return nuGetRestoreBuildStep;
        }

        public static CreateBuildStep GetGruntBuildStep(string buildConfigId, string workingDirectory)
        {
            var bowerInstallBuildStep = new CreateBuildStep
            {
                BuildTypeLocator = "id:" + buildConfigId,
                Name = "Grunt build",
                TypeId = BuidStepTypes.Grunt,
                StepProperties = new CreateTeamCityProperties
                {
                    Properties = new List<CreateTeamCityProperty>
                    {
                        new CreateTeamCityProperty
                        {
                            Name = "jonnyzzz.grunt.file",
                            Value = workingDirectory + "/gruntfile.js"
                        },
                        new CreateTeamCityProperty
                        {
                            Name = "jonnyzzz.grunt.mode",
                            Value = "npm"
                        },
                        new CreateTeamCityProperty
                        {
                            Name = "jonnyzzz.grunt.tasks",
                            Value = "build"
                        },
                        new CreateTeamCityProperty
                        {
                            Name = "teamcity.build.workingDir",
                            Value = workingDirectory
                        },
                        new CreateTeamCityProperty
                        {
                            Name = "teamcity.step.mode",
                            Value = "default"
                        }
                    }
                }
            };
            return bowerInstallBuildStep;
        }

        public static CreateBuildStep GetCopyAppSettingsStep(string buildConfigId, string workingDirectory, string ownerName, string repoName)
        {
            var copyAppSettingsStep = new CreateBuildStep
            {
                BuildTypeLocator = "id:" + buildConfigId,
                Name = "Copy App Settings",
                TypeId = BuidStepTypes.CommandLine,
                StepProperties = new CreateTeamCityProperties
                {
                    Properties = new List<CreateTeamCityProperty>
                    {
                        new CreateTeamCityProperty
                        {
                            Name = "script.content",
                            Value = "xcopy C:\\src\\{0}\\{1}\\appsettings.txt %teamcity.build.workingDir%\\wwwroot /Y".Fmt(ownerName,repoName)
                        },
                        new CreateTeamCityProperty
                        {
                            Name = "teamcity.build.workingDir",
                            Value = workingDirectory
                        },
                        new CreateTeamCityProperty
                        {
                            Name = "teamcity.step.mode",
                            Value = "default"
                        },
                        new CreateTeamCityProperty
                        {
                            Name = "use.custom.script",
                            Value = "true"
                        },
                    }
                }
            };
            return copyAppSettingsStep;
        }

        public static CreateBuildStep GetWebDeployPackStep(string buildConfigId, string workingDirectory)
        {
            var getWebDeployPackStep = new CreateBuildStep
            {
                BuildTypeLocator = "id:" + buildConfigId,
                Name = "Web Deploy - Pack",
                TypeId = BuidStepTypes.CommandLine,
                StepProperties = new CreateTeamCityProperties
                {
                    Properties = new List<CreateTeamCityProperty>
                    {
                        new CreateTeamCityProperty
                        {
                            Name = "command.executable",
                            Value = "%env.MSDeployPath%\\msdeploy.exe"
                        },
                        new CreateTeamCityProperty
                        {
                            Name = "command.parameters",
                            Value = "-verb:sync -source:iisApp=\"%teamcity.build.workingDir%\\wwwroot\" -dest:package=\"%teamcity.build.workingDir%\\webapp.zip\""
                        },
                        new CreateTeamCityProperty
                        {
                            Name = "teamcity.build.workingDir",
                            Value = workingDirectory
                        },
                        new CreateTeamCityProperty
                        {
                            Name = "teamcity.step.mode",
                            Value = "default"
                        }
                    }
                }
            };
            return getWebDeployPackStep;
        }

        public static CreateBuildStep GetWebDeployPush(string buildConfigId, string workingDirectory,string appName, string endpoint)
        {
            var getWebDeployPush = new CreateBuildStep
            {
                BuildTypeLocator = "id:" + buildConfigId,
                Name = "Web Deploy - Push",
                TypeId = BuidStepTypes.CommandLine,
                StepProperties = new CreateTeamCityProperties
                {
                    Properties = new List<CreateTeamCityProperty>
                    {
                        new CreateTeamCityProperty
                        {
                            Name = "command.executable",
                            Value = "%env.MSDeployPath%\\msdeploy.exe"
                        },
                        new CreateTeamCityProperty
                        {
                            Name = "command.parameters",
                            Value = "-verb:sync -source:package=\"%teamcity.build.workingDir%\\webapp.zip\" -dest:iisApp=\"{0}\",wmsvc={1},username=%ss.msdeploy.username%,password=%ss.msdeploy.password% -allowUntrusted=true"
                                .Fmt(appName,endpoint)
                        },
                        new CreateTeamCityProperty
                        {
                            Name = "teamcity.build.workingDir",
                            Value = workingDirectory
                        },
                        new CreateTeamCityProperty
                        {
                            Name = "teamcity.step.mode",
                            Value = "default"
                        }
                    }
                }
            };
            return getWebDeployPush;
        }

        public static CreateTrigger GetCreateVcsTrigger(string buildConfigId)
        {
            var createTrigger = new CreateTrigger
            {
                BuildTypeLocator = "id:" + buildConfigId,
                TypeId = "vcsTrigger",
                TriggerProperties = new CreateTeamCityProperties
                {
                    Properties = new List<CreateTeamCityProperty>
                    {
                        new CreateTeamCityProperty
                        {
                            Name = "quietPeriodMode",
                            Value = "DO_NOT_USE"
                        }
                    }
                }
            };
            return createTrigger;
        }
    }
}