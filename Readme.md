Lien github : https://github.com/aftisseamel/amel-aftisse-ObjectDetection
Amel
Aftisse 
M2 Cyber

*****Quelques étapes du traitement du sujet :*****

mkdir ObjectDetection 
cd ObjectDetection


dotnet new sln -n amel.aftisse.ObjectDetection
dotnet new classlib -n amel.aftisse.ObjectDetection

*Associer la solution au projet*
dotnet sln add amel.aftisse.ObjectDetection/amel.aftisse.ObjectDetection.csproj


dotnet new xunit -n amel.aftisse.ObjectDetection.Tests 
dotnet sln add  amel.aftisse.ObjectDetection.Tests/ amel.aftisse.ObjectDetection.Tests.csproj
référencer par rider


Le test compile bien mais il me retourne une erreur car code pas encore implémenté

Tous les packages Nugets ont été ajoutés en success (manage Nuget Packages via rider)

***Pour les tests unitaires :*** 
Je pouvais récuperer des valeurs en faisant un debugage sur Tests : Mettre point rouge sur une ligne dans ce cas, avant le equal pour 
avoir les dimensions et les remplacer directement 
Mais méthode mieux: récuperer les points dans des variables et faire les tests directement

Pour run : dotnet run ..\amel.aftisse.ObjectDetection.Tests\Scenes\


***WebApi:***
Swagger authomatiquement ajouté 
code implementé
ça marche ! 


***Intégration continue avec GitHubActionn***
Lien github : https://github.com/aftisseamel/amel-aftisse-ObjectDetection
