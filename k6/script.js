import http from 'k6/http';
import { sleep } from 'k6';
import { Trend } from 'k6/metrics';
import { Counter } from 'k6/metrics';

const failsCounter = new Counter('http_reqs_failed');

export default function () {
  const res = http.get('http://kubernetes.docker.internal/rob-demo');
  
  if (res.error_code){
    failsCounter.add(1)
  }
  else {
    failsCounter.add(0)
   
  }
}
