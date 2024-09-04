import { defineConfig } from "vite";
import path from "node:path";
import { fileURLToPath } from "node:url";
import react from "@vitejs/plugin-react";
import fable from "vite-plugin-fable";
import { internalIpV4 } from "internal-ip";

const currentDir = path.dirname(fileURLToPath(import.meta.url));
const fsproj = path.join(currentDir, "src/App.fsproj");
const mobile = !!/android|ios/.exec(process.env.TAURI_ENV_PLATFORM);

// https://vitejs.dev/config/
export default defineConfig(async () => ({
  plugins: [
    fable({ jsx: "automatic", fsproj: fsproj}),
    react({ include: /\.(fs|js|jsx)$/ }),
  ],

  clearScreen: false,
  server: {
    port: 1420,
    strictPort: true,
    host: mobile ? "0.0.0.0" : false,
    hmr: mobile
      ? {
          protocol: "ws",
          host: await internalIpV4(),
          port: 1421,
        }
      : undefined,
  },
}));
