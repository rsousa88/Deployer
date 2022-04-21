// System
using System;
using System.Linq;
using System.Collections.Generic;

// Microsoft
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

// ActiveLayerExplorer
using Dataverse.XrmTools.ActiveLayerExplorer.Models;
using Dataverse.XrmTools.ActiveLayerExplorer.AppSettings;
using Dataverse.XrmTools.ActiveLayerExplorer.Repositories;

namespace Dataverse.XrmTools.ActiveLayerExplorer.Logic
{
    public class MappingsLogic
    {
        #region Global Variables
        private readonly IOrganizationService  _sourceSvc;
        private readonly IOrganizationService  _targetSvc;
        #endregion Global Variables

        #region Constructors
        public MappingsLogic(IOrganizationService sourceSvc, IOrganizationService targetSvc)
        {
            _sourceSvc = sourceSvc;
            _targetSvc = targetSvc;
        }
        #endregion Constructors

        #region Public Methods
        #endregion Public Methods

        #region Private Methods
        #endregion Private Methods
    }
}
