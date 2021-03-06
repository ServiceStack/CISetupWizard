﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ServiceStack.TeamCityClient.Types
{
    [DataContract]
    public class Project
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "href")]
        public string Href { get; set; }

        [DataMember(Name = "webUrl")]
        public string WebUrl { get; set; }

        [DataMember(Name = "parentProjectId")]
        public string ParentProjectId { get; set; }
    }

    [DataContract]
    public class VcsRoot
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "href")]
        public string Href { get; set; }
    }

    [DataContract]
    public class BuildTypesResponse
    {
        public BuildTypesResponse()
        {
            BuildTypes = new List<BuildType>();
        }

        [DataMember(Name = "count")]
        public int Count { get; set; }

        [DataMember(Name = "buildType")]
        public List<BuildType> BuildTypes { get; set; }
    }

    [DataContract]
    public class TemplatesResponse
    {
        public TemplatesResponse()
        {
            BuildTypes = new List<BuildType>();
        }

        [DataMember(Name = "count")]
        public int Count { get; set; }

        [DataMember(Name = "buildType")]
        public List<BuildType> BuildTypes { get; set; }
    }

    [DataContract]
    public class ParametersResponse
    {
        public ParametersResponse()
        {
            Properties = new List<Property>();
        }

        [DataMember(Name = "count")]
        public int Count { get; set; }

        [DataMember(Name = "href")]
        public string Href { get; set; }

        [DataMember(Name = "property")]
        public List<Property> Properties { get; set; }
    }

    [DataContract]
    public class VcsRootsResponse
    {
        [DataMember(Name = "count")]
        public int Count { get; set; }

        [DataMember(Name = "href")]
        public string Href { get; set; }
    }

    [DataContract]
    public class VcsRootResponse
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "vcsName")]
        public string VcsName { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "lastChecked")]
        public string LastChecked { get; set; }

        [DataMember(Name = "href")]
        public string Href { get; set; }

        [DataMember(Name = "project")]
        public Project Project { get; set; }

        [DataMember(Name = "properties")]
        public Properties Properties { get; set; }

        [DataMember(Name = "vcsRootInstances")]
        public VcsRootInstance VcsRootInstances { get; set; }
    }

    [DataContract]
    public class ProjectsResponse
    {
        public ProjectsResponse()
        {
            Projects = new List<Project>();
        }

        [DataMember(Name = "count")]
        public int Count { get; set; }

        [DataMember(Name = "project")]
        public List<Project> Projects { get; set; }
    }

    [DataContract]
    public class User
    {
        [DataMember(Name = "username")]
        public string UserName { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "href")]
        public string Href { get; set; }
    }

    [DataContract]
    public class UsersResponse
    {
        public UsersResponse()
        {
            Users = new List<User>();    
        }

        [DataMember(Name = "count")]
        public int Count { get; set; }

        [DataMember(Name = "user")]
        public List<User> Users { get; set; }
    }

    [DataContract]
    public class Build
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "buildTypeId")]
        public string BuildTypeId { get; set; }

        [DataMember(Name = "number")]
        public string Number { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "state")]
        public string State { get; set; }

        [DataMember(Name = "href")]
        public string Href { get; set; }

        [DataMember(Name = "webUrl")]
        public string WebUrl { get; set; }
    }

    [DataContract]
    public class BuildType
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "projectName")]
        public string ProjectName { get; set; }

        [DataMember(Name = "projectId")]
        public string ProjectId { get; set; }

        [DataMember(Name = "href")]
        public string Href { get; set; }

        [DataMember(Name = "webUrl")]
        public string WebUrl { get; set; }
    }

    [DataContract]
    public class Triggered
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "date")]
        public string Date { get; set; }

        [DataMember(Name = "user")]
        public User User { get; set; }
    }

    [DataContract]
    public class Change
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "version")]
        public string Version { get; set; }

        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "date")]
        public string Date { get; set; }

        [DataMember(Name = "href")]
        public string Href { get; set; }

        [DataMember(Name = "webUrl")]
        public string WebUrl { get; set; }
    }

    [DataContract]
    public class Changes
    {
        [DataMember(Name = "href")]
        public string Href { get; set; }
    }

    [DataContract]
    public class LastChangesResponse
    {
        public LastChangesResponse()
        {
            Changes = new List<Change>();
        }

        [DataMember(Name = "count")]
        public int Count { get; set; }

        [DataMember(Name = "change")]
        public List<Change> Changes { get; set; }
    }

    [DataContract]
    public class VcsRootInstance
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "vcs-root-id")]
        public string VcsRootId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "href")]
        public string Href { get; set; }
    }

    [DataContract]
    public class Revision
    {
        [DataMember(Name = "version")]
        public string Version { get; set; }

        [DataMember(Name = "vcs-root-instance")]
        public VcsRootInstance VcsRootInstance { get; set; }
    }

    [DataContract]
    public class RevisionsResponse
    {
        public RevisionsResponse()
        {
            Revisions = new List<Revision>();
        }

        [DataMember(Name = "count")]
        public int Count { get; set; }

        [DataMember(Name = "revision")]
        public List<Revision> Revisions { get; set; }
    }

    [DataContract]
    public class Agent
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "typeId")]
        public int TypeId { get; set; }

        [DataMember(Name = "href")]
        public string Href { get; set; }
    }

    [DataContract]
    public class ProblemOccurrences
    {
        [DataMember(Name = "count")]
        public int Count { get; set; }

        [DataMember(Name = "href")]
        public string Href { get; set; }

        [DataMember(Name = "default")]
        public bool IsDefault { get; set; }
    }

    [DataContract]
    public class Artifacts
    {
        [DataMember(Name = "href")]
        public string Href { get; set; }
    }

    [DataContract]
    public class RelatedIssues
    {
        [DataMember(Name = "href")]
        public string Href { get; set; }
    }

    [DataContract]
    public class Property
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "value")]
        public string Value { get; set; }
    }

    [DataContract]
    public class PropertiesResponse
    {
        public PropertiesResponse()
        {
            Properties = new List<Property>();
        }

        [DataMember(Name = "count")]
        public int Count { get; set; }

        [DataMember(Name = "property")]
        public List<Property> Properties { get; set; }
    }

    [DataContract]
    public class Statistics
    {
        [DataMember(Name = "href")]
        public string Href { get; set; }
    }

    [DataContract]
    public class Role
    {
        [DataMember(Name = "roleId")]
        public string RoleId { get; set; }

        [DataMember(Name = "scope")]
        public string Scope { get; set; }

        [DataMember(Name = "href")]
        public string Href { get; set; }
    }

    [DataContract]
    public class RolesResponse
    {
        public RolesResponse()
        {
            Roles = new List<Role>();
        }

        [DataMember(Name = "role")]
        public List<Role> Roles { get; set; }
    }

    [DataContract]
    public class Group
    {
        [DataMember(Name = "key")]
        public string Key { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "href")]
        public string Href { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }
    }

    [DataContract]
    public class GroupsResponse
    {
        public GroupsResponse()
        {
            Groups = new List<Group>();
        }

        [DataMember(Name = "count")]
        public int Count { get; set; }

        [DataMember(Name = "group")]
        public List<Group> Groups { get; set; }
    }

    [DataContract]
    public class SettingsResponse
    {
        public SettingsResponse()
        {
            Properties = new List<Property>();
        }

        [DataMember(Name = "count")]
        public int Count { get; set; }

        [DataMember(Name = "property")]
        public List<Property> Properties { get; set; }
    }

    [DataContract]
    public class StepsResponse
    {
        [DataMember(Name = "count")]
        public int Count { get; set; }
        [DataMember(Name = "step")]
        public List<Step> Steps { get; set; }
    }

    [DataContract]
    public class Step
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "type")]
        public string Type { get; set; }
        [DataMember(Name = "properties")]
        public PropertiesResponse Properties { get; set; }
    }

    [DataContract]
    public class FeaturesResponse
    {
        [DataMember(Name = "count")]
        public int Count { get; set; }
    }

    [DataContract]
    public class TriggersResponse
    {
        [DataMember(Name = "count")]
        public int Count { get; set; }
    }

    [DataContract]
    public class SnapshotDependencies
    {
        [DataMember(Name = "count")]
        public int Count { get; set; }
    }

    [DataContract]
    public class ArtifactDependenciesResponse
    {
        [DataMember(Name = "count")]
        public int Count { get; set; }
    }

    [DataContract]
    public class AgentRequirementsResponse
    {
        [DataMember(Name = "count")]
        public int Count { get; set; }
    }

    [DataContract]
    public class Builds
    {
        [DataMember(Name = "href")]
        public string Href { get; set; }
    }

    [DataContract]
    public class BuildTypeResponse
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "projectName")]
        public string ProjectName { get; set; }
        [DataMember(Name = "projectId")]
        public string ProjectId { get; set; }
        [DataMember(Name = "href")]
        public string Href { get; set; }
        [DataMember(Name = "webUrl")]
        public string WebUrl { get; set; }
        [DataMember(Name = "project")]
        public Project Project { get; set; }
        [DataMember(Name = "vcs-root-entries")]
        public VcsRootsResponse VcsRootEntries { get; set; }
        [DataMember(Name = "settings")]
        public SettingsResponse SettingsResponse { get; set; }
        [DataMember(Name = "parameters")]
        public ParametersResponse Parameters { get; set; }
        [DataMember(Name = "steps")]
        public StepsResponse StepsResponse { get; set; }
        [DataMember(Name = "features")]
        public FeaturesResponse FeaturesResponse { get; set; }
        [DataMember(Name = "triggers")]
        public TriggersResponse TriggersResponse { get; set; }
        [DataMember(Name = "snapshot-dependencies")]
        public SnapshotDependencies SnapshotDependencies { get; set; }
        [DataMember(Name = "artifact-dependencies")]
        public ArtifactDependenciesResponse ArtifactDependenciesResponse { get; set; }
        [DataMember(Name = "agent-requirements")]
        public AgentRequirementsResponse AgentRequirementsResponse { get; set; }
        [DataMember(Name = "builds")]
        public Builds Builds { get; set; }
    }
}