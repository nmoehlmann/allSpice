import vue from '@vitejs/plugin-vue'
import { defineConfig } from 'vite'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [vue()],
  build: {
    minify: false,
    outDir: 'docs',
    sourcemap: false
  },
  server: {
    port: 8080
  }
})
