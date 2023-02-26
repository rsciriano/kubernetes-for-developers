import http from 'k6/http';
import { sleep } from 'k6';
import { Trend } from 'k6/metrics';
import { Counter } from 'k6/metrics';

const failsCounter = new Counter('http_reqs_failed');

function httpGet(url) {
  const res = http.get(url);
  
  if (res.error_code){
    failsCounter.add(1)
  }
  else {
    failsCounter.add(0)   
  }
}

function httpDelete(url) {
  const res = http.del(url);
  
  if (res.error_code){
    failsCounter.add(1)
  }
  else {
    failsCounter.add(0)   
  }
}


export default function () {

  httpGet('http://kubernetes.docker.internal/rob-demo')
  httpGet('http://kubernetes.docker.internal/crappy-api/cpu/30')
  httpGet('http://kubernetes.docker.internal/crappy-api/memory/1000')
  httpDelete('http://kubernetes.docker.internal/crappy-api/memory/1000')

}
