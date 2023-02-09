import http from 'k6/http';
import { sleep } from 'k6';

export default function () {
  http.post('http://host.docker.internal:8081/Work');
  sleep(1);
}