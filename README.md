# GetStarted-AzFunction-ZipDeploy

Azure functions are great. I used to do a lot of "csx" version (C# scripted version) but more recently I switched to the compile version, and I definitely loved it!  However, I was looking for a way to keep my deployment short and sweet, because sometimes  I don't have time to setup a "big" CI/CD or simply because sometimes I'm not the one doing the deployment... In those cases, I need a simple script that will deploy everything! In this post, I will share with you how you can deploy everything with one easy script.

## The Context

In this demo, I will deploy a simple C# (full .Net framework) Azure functions. I will create the Azure Function App and storage using an Azure Resource Manager (ARM template) and deploy with a method named Zip push or ZipDeploy.  All steps are available on my blog at: [How to Deploy your Azure Functions Faster and Easily with Zip Push](https://www.frankysnotes.com/2018/06/how-to-deploy-your-azure-functions.html)
or in video on YouTube at: https://youtu.be/2xzjRSOuSKU

![tumbnail](GetStarted-AzFunction-ZipDeploy/Azure Functions ZipDeploy EN.png)
