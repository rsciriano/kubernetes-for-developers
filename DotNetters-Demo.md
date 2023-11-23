# DotNetters Demo

## Add Bitnami helm repo

```
helm repo add bitnami https://charts.bitnami.com/bitnami
```

## Demo 1: Basic

```
docker build -t rsciriano/k8s-minimal-web:dnz-demo1 .
```

```
helm upgrade --install -f deploy/rob-demo/helm-values-demo1-basic.yaml --namespace rob-demo --create-namespace --atomic --wait --debug rob-demo bitnami/aspnet-core
```
