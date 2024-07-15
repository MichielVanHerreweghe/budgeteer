using '../main.bicep'

// MARK: Parameters
param projectName = 'budgeteer'
param environment = 'dev'
param location = 'westeurope'
param locationShortName = 'weu'
param deploymentId = take(guid(projectName, environment, locationShortName), 8)

// MARK: Configuration Store Parameters
param appConfigurationStoreSku = 'Free'
param appConfigurationEnablePurgeProtection = false
param disableLocalAuth = false

// MARK: Key Vault Parameters
param keyVaultEnablePurgeProtection = false
param enableSoftDelete = false
param keyVaultSku = 'standard'
param keyVaultRoleAssignments = [
  {
    principalId: '1a35a812-d458-45c0-8bc7-4cbaaaf08139' // Budgeteer.Infrastructure
    principalType: 'Group'
    roleDefinitionIdOrName: '00482a5a-887f-4fb3-b363-3b7fe8e74483' // Key Vault Administrator
  }
  {
    principalId: '1a35a812-d458-45c0-8bc7-4cbaaaf08139' // Budgeteer.Infrastructure
    principalType: 'Group'
    roleDefinitionIdOrName: 'b86a8fe4-44ce-4948-aee5-eccb2c155cd7' // Key Vault Secrets Officer
  }
]
param keyVaultSecrets = [
  {
    name: 'ConnectionStrings--Database'
    value: ''
  }
]
