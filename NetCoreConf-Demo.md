# NetCoreConf Demo

## Prepare k6 dashboard

```
cd k6
export PATH=$(go env GOPATH)/bin:$PATH
xk6 build --with github.com/szkiba/xk6-dashboard@latest
```

```
cd k6/dashboard-ui
http-server
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