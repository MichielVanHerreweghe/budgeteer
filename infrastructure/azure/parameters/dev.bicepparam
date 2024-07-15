using '../main.bicep'

// MARK: Parameters
param projectName = 'budgeteer'
param environment = 'dev'
param location = 'westeurope'
param locationShortName = 'weu'
param deploymentId = take(guid(projectName, environment, locationShortName), 8)

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

// MARK: Configuration Store Parameters
param appConfigurationStoreSku = 'Free'
param appConfigurationEnablePurgeProtection = false
param disableLocalAuth = false
param appConfigurationRoleAssignments = [
  {
    principalId: '634823ed-49f0-45e0-af7f-2428d7323994' // Budgeteer.Services.BudgeteerApi.Api.Dev
    principalType: 'ServicePrincipal'
    roleDefinitionIdOrName: '516239f1-63e1-4d78-a4de-a74fb236a071' // App Configuration Data Reader
  }
]
