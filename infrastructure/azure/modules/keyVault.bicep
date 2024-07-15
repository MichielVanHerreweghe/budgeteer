// MARK: Target Scope
targetScope = 'resourceGroup'

// MARK: Imports
import { RoleAssignment, KeyVaultSecret } from '../types.bicep'

// MARK: Parameters

// MARK: General Parameters
param projectName string
param environment string
param location string
param locationShortName string
param deploymentId string

// MARK: Key Vault Parameters
param enablePurgeProtection bool
param enableSoftDelete bool
param roleAssignments RoleAssignment[]
param keyVaultSecrets KeyVaultSecret[]

@allowed([
  'standard'
  'premium'
])
param sku string

// MARK: Variables
var keyVaultName = 'kv-${projectName}-${environment}-${locationShortName}'
// MARK: Resources
module keyVault 'br/public:avm/res/key-vault/vault:0.6.2' = {
  name: '${keyVaultName}-${deploymentId}'
  params: {
    name: keyVaultName
    location: location
    enablePurgeProtection: enablePurgeProtection
    enableSoftDelete: enableSoftDelete
    sku: sku
    secrets: keyVaultSecrets
    roleAssignments: roleAssignments
  }
}

// MARK: Outputs
output uri string = keyVault.outputs.uri
