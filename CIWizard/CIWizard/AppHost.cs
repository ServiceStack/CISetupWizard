﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using Funq;
using CIWizard.ServiceInterface;
using CIWizard.ServiceModel;
using ServiceStack;
using ServiceStack.Auth;
using ServiceStack.Configuration;
using ServiceStack.FluentValidation;
using ServiceStack.Logging;
using ServiceStack.Logging.EventLog;
using ServiceStack.OrmLite;
using ServiceStack.TeamCityClient;
using ServiceStack.Text;
using ServiceStack.Validation;

namespace CIWizard
{
    public class AppHost : AppHostBase
    {
        /// <summary>
        /// Default constructor.
        /// Base constructor requires a Name and assembly to locate web service classes. 
        /// </summary>
        public AppHost()
            : base("CIWizard", typeof(MyServices).Assembly)
        {
            var customSettings = new FileInfo(@"~/appsettings.txt".MapHostAbsolutePath());
            AppSettings = customSettings.Exists
                ? (IAppSettings)new TextFileSettings(customSettings.FullName)
                : new AppSettings();

            if (AppSettings.Exists("ServiceStackLicense"))
                LicenseUtils.RegisterLicense(AppSettings.GetString("ServiceStackLicense"));
        }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        /// <param Name="container"></param>
        public override void Configure(Container container)
        {

            //Config examples
            //this.Plugins.Add(new PostmanFeature());
            //this.Plugins.Add(new CorsFeature());

            SetConfig(new HostConfig
            {
                DebugMode = AppSettings.Get("DebugMode", false),
                AddRedirectParamsToQueryString = true,
                
            });

            if(!AppSettings.Exists("ApplicationSettingsBaseFolder"))
                AppSettings.Set("ApplicationSettingsBaseFolder","C:\\src\\");

            if (!Directory.Exists(AppSettings.GetString("ApplicationSettingsBaseFolder")))
                Directory.CreateDirectory(AppSettings.GetString("ApplicationSettingsBaseFolder"));

            LogManager.LogFactory = new EventLogFactory("CIWizard","Application");

            JsConfig.DateHandler = DateHandler.ISO8601;
            Plugins.Add(new ValidationFeature());
            container.RegisterValidators(typeof(CreateSpaBuildProjectValidator).Assembly);

            this.Plugins.Add(new AuthFeature(() => new AuthUserSession(), new IAuthProvider[]
            {
                new GithubAuthProvider(AppSettings)
            }));

            container.Register(new TcClient(
                AppSettings.GetString("ServerApiBaseUrl"),
                AppSettings.GetString("UserName"),
                AppSettings.GetString("Password")));

            JsConfig.EmitCamelCaseNames = true;
        }
    }

    public class CreateSpaBuildProjectValidator : AbstractValidator<CreateSpaBuildProject>
    {
        public CreateSpaBuildProjectValidator()
        {
            RuleFor(x => x.RepositoryUrl).NotNull().NotEmpty();
            RuleFor(x => x.SolutionPath).NotNull().NotEmpty();
            RuleFor(x => x.WorkingDirectory).NotNull().NotEmpty();
        }
    }
}