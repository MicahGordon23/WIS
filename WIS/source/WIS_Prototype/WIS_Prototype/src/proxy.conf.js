const PROXY_CONFIG = [
  {
    context: [
      "/api",
    ],
    target: "https://localhost:58801",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
