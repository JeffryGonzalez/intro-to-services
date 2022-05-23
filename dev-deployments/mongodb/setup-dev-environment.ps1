Write-Host "*** Getting you Setup ***"

Write-Host "*** Setting up the MongoDb Server ***"
Write-Host "    - creating the data namespace"
kubectl create namespace data
Write-Host "    - changing context to data"
kubectl config set-context --current --namespace=data
Write-Host "    - installing MongDb Helm Chart"
helm install mongodb bitnami/mongodb --version "12.1.0" --values .\mongodb-12.1.0-values.yaml
Write-Host "    - Installing Mongo Express with an Ingress at dev.hypertheory-training.com"
kubectl apply -f ..\mongo-express



Write-Host "*** ALL DONE! Remember: ****"
Write-Host "    - Add a Hosts Entry for dev.hypertheory-training.com"
Write-Host "    -   Admin user is root / TokyoJoe138!"
Write-Host "    - Create your Databases"
