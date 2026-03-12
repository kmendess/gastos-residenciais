import axios from "axios";
import { showError } from "./toast";

const api = axios.create({
  baseURL: import.meta.env.DEV ? "https://localhost:7035/" : import.meta.env.VITE_API_URL,
  validateStatus: (status) => status < 500
});

api.interceptors.response.use(
  (response) => response,
  (error) => {
    const status = error.response?.status

    if (!error.response) {
      showError("Erro de conexão com o servidor.")
    }

    if (status === 500) {
      showError("Erro interno do servidor.")
    }

    return Promise.reject(error)
  }
)

export default api;