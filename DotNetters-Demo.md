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

## Demo 2: Resources

```
docker build -t rsciriano/k8s-minimal-web:dnz-demo2 .
```

```
helm upgrade --install -f deploy/rob-demo/helm-values-demo2-resources.yaml --namespace rob-demo --create-namespace --atomic --wait --debug rob-demo bitnami/aspnet-core
```

```
k6 run --vus 200 --duration 5m -o influxdb=http://localhost:8086/k6 k6/script.js
```
Test results: 

> http://localhost:4000/d/XKhgaUpika/k6-load-testing-results

## Demo 3: Autoscaling

```
git checkout dnz/demo3-autoscaling
```

```
docker build -t rsciriano/k8s-minimal-web:dnz-demo3 .
```

```
helm upgrade --install -f deploy/rob-demo/helm-values-demo3-autoscaling.yaml --namespace rob-demo --create-namespace --atomic --wait --debug rob-demo ../bitnami-charts/bitnami/aspnet-core
```

## Demo 4: RollingUpdate

```
docker build -t rsciriano/k8s-minimal-web:dnz-demo4 .
```

```
helm upgrade --install -f deploy/rob-demo/helm-values-demo4-rollingupdate.yaml --namespace rob-demo --create-namespace --atomic --wait --debug rob-demo ../bitnami-charts/bitnami/aspnet-core
```