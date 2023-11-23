# DotNetters Demo

## Add Bitnami helm repo

```
helm repo add bitnami https://charts.bitnami.com/bitnami
```

## Basic deploy

helm deploy

```
helm upgrade --install -f deploy/rob-demo/helm-values-00-base.yaml --namespace rob-demo --create-namespace --atomic --wait --debug rob-demo bitnami/aspnet-core
```

load tests

```
cd k6
./k6 run --vus 200 --duration 5m --out 'dashboard=ui=http://127.0.0.1:8080/&period=1' script.js
```