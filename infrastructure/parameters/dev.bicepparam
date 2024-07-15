using '../main.bicep'

// MARK: Parameters
param projectName = 'budgeteer'
param environment = 'dev'
param location = 'westeurope'
param locationShortName = 'weu'
param deploymentId = take(guid(projectName, environment, locationShortName), 8)

// MARK: Configuration Store Parameters
param appConfigurationStoreSku = 'Free'
param enablePurgeProtection = false
