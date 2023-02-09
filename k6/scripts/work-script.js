import http from 'k6/http';
import { sleep } from 'k6';

export default function () {
  http.post('http://host.docker.internal:8080/Work');
  sleep(1);
}