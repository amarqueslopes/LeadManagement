import axios from "axios";
import CONFIG from "../config";

const api = axios.create({
    timeout: CONFIG.API_TIMEOUT,
    headers: {
        "Content-Type": "application/json",
    },
});

export default api;