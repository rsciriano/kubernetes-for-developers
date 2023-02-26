# Kubernetes for developers

## Runing kubernetes on local

- Docker Desktop | Rancher Desktop | Minikube
- Install Ingress controller
- Install Prometheus Stack
- Install metric server
https://artifacthub.io/packages/helm/metrics-server/metrics-server
```
    helm repo add metrics-server https://kubernetes-sigs.github.io/metrics-server/
    helm upgrade --install metrics-server metrics-server/metrics-server --namespace metrics-server --create-namespace --atomic --wait -f deploy/metrics-server/heml-values.yaml
```

## Conecting to the kubernetes cluster

- OpenLens
    - [lensapp/lens: Lens - The way the world runs Kubernetes](https://github.com/lensapp/lens)
    - [MuhammedKalkan/OpenLens: OpenLens Binary Build Repository](https://github.com/MuhammedKalkan/OpenLens)
    - [alebcay/openlens-node-pod-menu: Node and pod menus for OpenLens](https://github.com/alebcay/openlens-node-pod-menu)

- k9s
    ```
    docker run --network host -it -v ~/.kube/config:/tmp/kubeconfig.conf -e KUBECONFIG=/tmp/kubeconfig.conf derailed/k9s
    ```
## Build Docker image

```
docker build -t rsciriano/k8s-minimal-web:v2
```

## Deploy with helm

https://github.com/bitnami/charts/tree/main/bitnami/aspnet-core

```
helm upgrade --install -f deploy/rob-demo/helm-values-00-base.yaml \
--namespace rob-demo --create-namespace \
--atomic --wait --debug \
rob-demo bitnami/aspnet-core \
-f deploy/rob-demo/helm-values-02-autoscaling.yaml 
```

```
helm upgrade --install -f deploy/crappy-api/helm-values-00-base.yaml \
--namespace rob-demo --create-namespace \
--atomic --wait --debug \
crappy-api bitnami/aspnet-core 
```

## Load testing

- [Top 10 HTTP Benchmarking and Load Testing Tools](https://thechief.io/c/editorial/top-10-http-benchmarking-and-load-testing-tools/)
- [ab - Apache HTTP server benchmarking tool - Apache HTTP Server Version 2.4](https://httpd.apache.org/docs/2.4/programs/ab.html)
- [rakyll/hey: HTTP load generator, ApacheBench (ab) replacement](https://github.com/rakyll/hey)
- [wg/wrk: Modern HTTP benchmarking tool](https://github.com/wg/wrk)
- [Load testing for engineering teams | Grafana k6](https://k6.io/)

```
hey -c 200 -z 3m http://kubernetes.docker.internal/rob-demo
```

```
brew install wrk
```
### k6

- [szkiba/xk6-dashboard: A k6 extension that enables creating web based metrics dashboard for k6](https://github.com/szkiba/xk6-dashboard)

```
export PATH=$(go env GOPATH)/bin:$PATH
xk6 build --with github.com/szkiba/xk6-dashboard@latest
./k6 run --vus 200 --duration 30m --out 'dashboard=ui=http://127.0.0.1:8080/&period=1' script.js
```

## Secrets

```
kubectl apply -f .secrets/secrets.yaml -n rob-demo
```

## Monitoring

https://github.com/microsoft/ApplicationInsights-Kubernetes

```
kubectl apply -f deploy/rob-demo/application-insights-sa-role.yml -n rob-demo
```