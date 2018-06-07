# script to Create an Azure Gramophone-PoC Solution

resourceGroupName=$1
resourceGroupLocation=$2

templateFilePath="./arm/azuredeploy.json"
parameterFilePath="./arm/azuredeploy.parameters.json"

dateToken=`date '+%Y%m%d%H%M'`
deploymentName="FrankDemo"$dateToken

# az login

# You can select a specific subscription if you do not want to use the default
# az account set -s SUBSCRIPTION_ID

if !( $(az group exists -g  $resourceGroupName) ) then
    echo "---> Creating the Resourcegroup: " $resourceGroupName
    az group create -g $resourceGroupName -l $resourceGroupLocation
else
    echo "---> Resourcegroup:" $resourceGroupName "already exists."
fi

az group deployment create --name $deploymentName --resource-group $resourceGroupName --template-file $templateFilePath --parameters $parameterFilePath --verbose

echo "---> Deploying Function Code"
az functionapp deployment source config-zip -g $resourceGroupName -n zipdeploydemo --src "./zip/AzFunction-ZipDeploy.zip"

echo "---> done <---"
