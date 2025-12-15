import http from "k6/http";
import { check, sleep } from "k6";

export const options = {
  stages: [
    { duration: "10s", target: 5 },
    { duration: "20s", target: 10 },
    { duration: "10s", target: 0 },
  ],
  thresholds: {
    http_req_failed: ["rate<0.01"],        // <1% failures
    http_req_duration: ["p(95)<1200"],     // 95% under 1.2s
  },
};

export default function () {
  const baseUrl = __ENV.BASE_URL;
  if (!baseUrl) {
    throw new Error("BASE_URL env var is missing. Example: https://your-app.azurewebsites.net");
  }

  // Keep it simple: GET the home page (no anti-forgery token issues)
  const res = http.get(`${baseUrl}/`, {
    tags: { name: "GET /" },
  });

  check(res, {
    "status is 200": (r) => r.status === 200,
  });

  sleep(1);
}
