﻿using System;

namespace Dataverse.XrmTools.Deployer.Models
{
    public class ImportDependency
    {
        public DependencyComponent Required { get; set; }
        public DependencyComponent Dependent { get; set; }
    }

    public class DependencyComponent
    {
        public ComponentType Type { get; set; }
        public Guid Id { get; set; }
        public string LogicalName { get; set; }
        public string DisplayName { get; set; }
    }

    public enum ComponentType
    {
        Unknown = 0,
        Entity = 1,
        Attribute = 2,
        Relationship = 3,
        AttributePicklistValue = 4,
        AttributeLookupValue = 5,
        ViewAttribute = 6,
        LocalizedLabel = 7,
        RelationshipExtraCondition = 8,
        OptionSet = 9,
        EntityRelationship = 10,
        EntityRelationshipRole = 11,
        EntityRelationshipRelationships = 12,
        ManagedProperty = 13,
        EntityKey = 14,
        Privilege = 16,
        PrivilegeObjectTypeCode = 17,
        Index = 18,
        Role = 20,
        RolePrivilege = 21,
        DisplayString = 22,
        DisplayStringMap = 23,
        Form = 24,
        Organization = 25,
        View = 26,
        Workflow = 29,
        Report = 31,
        ReportEntity = 32,
        ReportCategory = 33,
        ReportVisibility = 34,
        Attachment = 35,
        EmailTemplate = 36,
        ContractTemplate = 37,
        KBArticleTemplate = 38,
        MailMergeTemplate = 39,
        DuplicateRule = 44,
        DuplicateRuleCondition = 45,
        EntityMap = 46,
        AttributeMap = 47,
        RibbonCommand = 48,
        RibbonContextGroup = 49,
        RibbonCustomization = 50,
        RibbonRule = 52,
        RibbonTabToCommandMap = 53,
        RibbonDiff = 55,
        SavedQueryVisualization = 59,
        SystemForm = 60,
        WebResource = 61,
        SiteMap = 62,
        ConnectionRole = 63,
        ComplexControl = 64,
        HierarchyRule = 65,
        CustomControl = 66,
        CustomControlDefaultConfig = 68,
        FieldSecurityProfile = 70,
        FieldPermission = 71,
        AppModule = 80,
        PluginType = 90,
        PluginAssembly = 91,
        SDKMessageProcessingStep = 92,
        SDKMessageProcessingStepImage = 93,
        ServiceEndpoint = 95,
        RoutingRule = 150,
        RoutingRuleItem = 151,
        SLA = 152,
        SLAItem = 153,
        ConvertRule = 154,
        ConvertRuleItem = 155,
        MobileOfflineProfile = 161,
        MobileOfflineProfileItem = 162,
        SimilarityRule = 165,
        DataSourceMapping = 166,
        SDKMessage = 201,
        SDKMessageFilter = 202,
        SdkMessagePair = 203,
        SdkMessageRequest = 204,
        SdkMessageRequestField = 205,
        SdkMessageResponse = 206,
        SdkMessageResponseField = 207,
        ImportMap = 208,
        WebWizard = 210,
        CanvasApp = 300,
        Connector1 = 371,
        Connector2 = 372,
        EnvironmentVariableDefinition = 380,
        EnvironmentVariableValue = 381,
        AIProjectType = 400,
        AIProject = 401,
        AIConfiguration = 402,
        EntityAnalyticsConfiguration = 430,
        AttributeImageConfiguration = 431,
        EntityImageConfiguration = 432
    }
}
