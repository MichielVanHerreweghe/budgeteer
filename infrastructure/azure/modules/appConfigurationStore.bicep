// MARK: Target Scope
targetScope = 'resourceGroup'

// MARK: Imports
import { AppConfigurationKeyValue, RoleAssignment } from '../types.bicep'

// MARK: Parameters

// MARK: General Parameters
param projectName string
param environment string
param location string
param locationShortName string
param deploymentId string

// MARK: Configuration Store Parameters
@allowed([
  'Free'
  'Standard'
])
param appConfigurationStoreSku string
param enablePurgeProtection bool
param disableLocalAuth bool
param appConfigurationKeyValues AppConfigurationKeyValue[]
param roleAssignments RoleAssignment[]

// MARK: Variables
var appConfigurationStoreName = 'appcs-${projectName}-${environment}-${locationShortName}'

// MARK: Resources
module appConfigurationStore 'br/public:avm/res/app-configuration/configuration-store:0.2.3' = {
  name: '${appConfigurationStoreName}-${deploymentId}'
  params: {
    name: appConfigurationStoreName
    location: location
    sku: appConfigurationStoreSku
    enablePurgeProtection: enablePurgeProtection
    disableLocalAuth: disableLocalAuth
    keyValues: [for keyValue in appConfigurationKeyValues: {
        name: '${keyValue.name}$${keyValue.label}'
        value: keyValue.value
        contentType: keyValue.contentType
      }
    ]
    roleAssignments: roleAssignments
  }
}
