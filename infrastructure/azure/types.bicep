@export()
type AppConfigurationKeyValue = {
  name: string
  label: string
  value: string
  contentType: string
}

@export()
type RoleAssignment = {
  principalId: string
  principalType: ('Device' | 'ForeignGroup' | 'Group' | 'ServicePrincipal' | 'User')
  roleDefinitionIdOrName: string
}

@export()
type KeyVaultSecret = {
  name: string
  value: string
}
