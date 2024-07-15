// MARK: Target Scope
targetScope = 'subscription'

// MARK: Imports
import { AppConfigurationKeyValue } from './types.bicep'

// MARK: Parameters
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
param appConfigurationKeyValues AppConfigurationKeyValue[] = []

// Mark: Variables
var resourceGroupName = 'rg-${projectName}-${environment}-${locationShortName}'

// Mark: Resources
resource resourceGroup 'Microsoft.Resources/resourceGroups@2024-03-01' = {
  name: resourceGroupName
  location: location
}

module appConfigurationStore 'modules/appConfigurationStore.bicep' = {
  scope: resourceGroup
  name: 'appConfigurationStore-deployment-${deploymentId}'
  params: {
    projectName: projectName
    environment: environment
    location: location
    locationShortName: locationShortName
    deploymentId: deploymentId
    appConfigurationStoreSku: appConfigurationStoreSku
    enablePurgeProtection: enablePurgeProtection
    appConfigurationKeyValues: appConfigurationKeyValues
  }
}
