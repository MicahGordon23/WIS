const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
    ],
    target: "https://localhost:58801",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
