// MARK: Target Scope
targetScope = 'subscription'

// MARK: Imports
import { AppConfigurationKeyValue, KeyVaultSecret, RoleAssignment } from './types.bicep'

// MARK: Parameters
param projectName string
param environment string
param location string
param locationShortName string
param deploymentId string

// MARK: Key Vault Parameters
param keyVaultEnablePurgeProtection bool
param enableSoftDelete bool
param keyVaultRoleAssignments RoleAssignment[] = []
param keyVaultSecrets KeyVaultSecret[] = []

@allowed([
  'standard'
  'premium'
])
param keyVaultSku string
param disableLocalAuth bool

// MARK: Configuration Store Parameters
@allowed([
  'Free'
  'Standard'
])
param appConfigurationStoreSku string
param appConfigurationEnablePurgeProtection bool
param appConfigurationKeyValues AppConfigurationKeyValue[] = []
param appConfigurationRoleAssignments RoleAssignment[] = []

// MARK: Variables
var resourceGroupName = 'rg-${projectName}-${environment}-${locationShortName}'

// MARK: Resources

// MARK: Resource Group
resource resourceGroup 'Microsoft.Resources/resourceGroups@2024-03-01' = {
  name: resourceGroupName
  location: location
}

// MARK: Key Vault
module keyVault 'modules/keyVault.bicep' = {
  scope: resourceGroup
  name: 'keyVault-deployment-${deploymentId}'
  params: {
    projectName: projectName
    environment: environment
    location: location
    locationShortName: locationShortName
    deploymentId: deploymentId
    enablePurgeProtection: keyVaultEnablePurgeProtection
    enableSoftDelete: enableSoftDelete
    sku: keyVaultSku
    keyVaultSecrets: keyVaultSecrets
    roleAssignments: keyVaultRoleAssignments
  }
}

// MARK: App Configuration Store
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
    enablePurgeProtection: appConfigurationEnablePurgeProtection
    disableLocalAuth: disableLocalAuth
    appConfigurationKeyValues: union(appConfigurationKeyValues, [
        {
          name: 'ConnectionStrings:Database'
          label: 'BudgeteerApi'
          value: '{"uri":"${keyVault.outputs.uri}secrets/ConnectionStrings--Database"}'
          contentType: 'application/vnd.microsoft.appconfig.keyvaultref+json;charset=utf-8'
        }
      ]
    )
    roleAssignments: appConfigurationRoleAssignments
  }
}
