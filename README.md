# AzureKeyVaultSample
A sample dotNet application to query secret's from Azure Key Vault.

To run this application, you need an Azure Subscription with the following setup:

* An Active Directory resource with a registered application. See here [here](https://docs.microsoft.com/en-us/azure/azure-resource-manager/resource-group-create-service-principal-portal).
* A Key Vault resource, where the application mentioned above has access. See [here](https://docs.microsoft.com/en-us/azure/key-vault/key-vault-get-started).
* And secret added to your key vault.

In `Program.cs` replace `<ClientId>` with the ID of your application, `<AuthenticationKey>` with the access key of your application, and `<Secret>` with the name of your secret. 
