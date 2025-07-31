import axios from "axios";

const apiInstance = axios.create({
  baseURL: "https://localhost:7083/api/",
  withCredentials: true,
});
 
export default apiInstance;