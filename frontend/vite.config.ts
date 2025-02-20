import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react'

// https://vitejs.dev/config/
export default defineConfig({
    plugins: [react()],
    server: {
        port: 8080,
        proxy: {
            '/api': {
                target: 'http://localhost:5118', // URL do backend
                changeOrigin: true,
                secure: false,
            },
        },
    },
})


